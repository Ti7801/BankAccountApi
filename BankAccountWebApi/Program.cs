using BankAccountWebApi.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BankAccountWebApi.Dados;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inje��o de Depend�ncia
builder.Services.AddDbContext<AppDbContext> ((DbContextOptionsBuilder optionsBuilder) =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    optionsBuilder.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
