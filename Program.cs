using Microsoft.EntityFrameworkCore;
using src.Persistence;

//variavel que vai criar uma web aplicação(criar builder com qualquer argumento)
var builder = WebApplication.CreateBuilder(args);

//adiciona ao builder a relação para o banco de dados
builder.Services
    .AddDbContext<DatabaseContext>((options => options.UseInMemoryDatabase("dbContracts")));

builder.Services.AddScoped<DatabaseContext, DatabaseContext>();

// adiciona ao builder os controllers
builder.Services.AddControllers();

// adiciona ao builder os endpoits com APIS
builder.Services.AddEndpointsApiExplorer();

// adiciona ao builder o swagger
builder.Services.AddSwaggerGen();

// para criar a aplicação de fato
var app = builder.Build();

// verificar se está no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
