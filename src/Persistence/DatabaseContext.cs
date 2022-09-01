using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

public class DatabaseContext: DbContext{
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<Contract> Contracts { get; set; }
}