using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext: DbContext{

    //passando de um construtor padrão para um construtor do Entity Framework
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){
        
    }
    
    //modelos que estão dentro do contexto do banco de dados
    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    //criação dos modelos
    protected override void OnModelCreating(ModelBuilder builder) {
       //construção de entidade Pessoa com as seguintes instruções: 
        builder.Entity<Person>(e =>{
            
            e.HasKey( e => e.Id); //uma pessoa tem uma chave. faz autoencremento
            e
            .HasMany(e => e.contratos) //uma pessoa tem muitos contratos.
            .WithOne()                  //pra cada um
            .HasForeignKey(e => e.PersonId);// tem uma chave estrangeira
        });
        builder.Entity<Contract>(e =>{
            e.HasKey( e => e.Id);
        });
    }

}