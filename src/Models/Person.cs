namespace src.Models;

public class Person
{

    //construtor
    public Person()
    {
        this.nome = "";
        this.idade = 0;
    }

    public Person(string nome, int idade, string cpf){
        this.nome = nome;
        this.idade = idade;
        this.cpf = cpf;
    }

    // Get & Set
    public string nome { get; set; }

    public int idade { get; set;}

    public string? cpf { get; set; }

    public bool ativa { get; set; }
}