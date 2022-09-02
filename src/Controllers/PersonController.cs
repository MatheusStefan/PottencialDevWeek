//declarar que vai usar o ASP NET
using Microsoft.EntityFrameworkCore;
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
    public ActionResult<List<Person>> GetPerson(){
        
        var result = _repository.Persons.Include(p => p.contratos).ToList();
        if(!result.Any()) {
            return NoContent();
        } 
        return Ok(result);
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
        _repository.Persons.Update(pessoa);
        _repository.SaveChanges();
        return "Dados do id " + id + "atualizados";
    }

//criação de metodo delete
    [HttpDelete("{id}")]
    public ActionResult<Object> DeletePersonById([FromRoute]int id) {
        var result = _repository.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null) {
            return BadRequest(new {
                msg = "Solicitação inválida.",
                status = 400
            });
        }
        _repository.Persons.Remove(result);
        _repository.SaveChanges();
        return Ok(new {
            msg = "deletando pessoa de Id " + id,
            status = 200
        });
    }
}
