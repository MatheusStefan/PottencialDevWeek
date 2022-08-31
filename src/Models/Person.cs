using System.Collections.Generic;

namespace src.Models;

public class Person{

    //construtor
    public Person()
    {
        this.Nome = "";
        this.Idade = 0;
        this.contratos = new List<Contract>();
        this.Ativado = true;

    }

    public Person(string Nome, int Idade, string Cpf){
        this.Nome = Nome;
        this.Idade = Idade;
        this.Cpf = Cpf;
        this.contratos = new List<Contract>();
        this.Ativado = true;
    }

    // Get & Set
    public string Nome { get; set; }

    public int Idade { get; set;}

    public string? Cpf { get; set; }

    public bool Ativado { get; set; }

    public List<Contract> contratos { get; set;}
}
