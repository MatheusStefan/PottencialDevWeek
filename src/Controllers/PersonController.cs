//declarar que vai usar o ASP NET
using Microsoft.AspNetCore.Mvc;
using src.Models;
using src.Persistence;

//estrutura de pastas virtual
namespace src.Controllers;

//indicação que essa classe é uma classe API: 
[ApiController]
[Route("[controller]")] //pega o nome inteiro do Controller e 
                        //elimina a palavra "controller",
                        //resultando nesse caso a rota "/person"

//os dois pontos significa herança de uma classe                        
public class PersonController: ControllerBase {

    //propriedade para que essa classe encontre o banco de dados e faça chamadas
    private DatabaseContext _repository { get; set; }

    public PersonController(DatabaseContext repository){
        this._repository = repository;
    }

//criação de metodo get que através da rota "/person", retorna uma pessoa
    [HttpGet]
    public List<Person> GetPerson(){
        //Person pessoa = new Person("Matheus", 24, "12345678901", 1);
        
        //criação e instanciação de um contrato 
        //Contract contrato = new Contract("a1b2c3", 20.0);
        //pessoa.contratos.Add(contrato);

        return _repository.Persons.ToList();;
    }
//criação de metodo post
    [HttpPost]
    public Person PostPerson([FromBody]Person pessoa) {
        _repository.Persons.Add(pessoa);
        _repository.SaveChanges();
        return pessoa;
    }

//criação de metodo put
    [HttpPut("{id}")]
    public string UpdatePerson([FromRoute]int id, [FromBody]Person pessoa) {
        Console.WriteLine(id);
        Console.WriteLine(pessoa);
        return "Dados do id " + id + " atualizados";
    }

//criação de metodo delete
    [HttpDelete("{id}")]
    public string DeletePersonById([FromRoute]int id) {
        Console.WriteLine(id);
        return "deletando pessoa de id " + id;
    }
}
