//declarar que vai usar o ASP NET
using Microsoft.AspNetCore.Mvc;
using src.Models;

//estrutura de pastas virtual
namespace src.Controllers;

//indicação que essa classe é uma classe API: 
[ApiController]
[Route("[controller]")] //pega o nome inteiro do Controller e 
                        //elimina a palavra "controller",
                        //resultando nesse caso a rota "/person"

//os dois pontos significa herança de uma classe                        
public class PersonController: ControllerBase {

//criação de metodo get que através da rota "/person", retorna "ola mundo"
    [HttpGet]
    public Person GetPerson(){
        Person pessoa = new Person("Matheus", 24, "43430428878");
        
        //criação e instanciação de um contrato 
        Contract contrato = new Contract("a1b2c3", 20.0);
        pessoa.contratos.Add(contrato);
        return pessoa;
    }
}
