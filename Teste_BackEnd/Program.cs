using Microsoft.EntityFrameworkCore;
using Teste_BackEnd.Data;
using Teste_BackEnd.Interfaces.Repository;
using Teste_BackEnd.Interfaces.Services;
using Teste_BackEnd.Repository;
using Teste_BackEnd.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Repositories
builder.Services.AddTransient<IContaRepository, ContaRepository>();

// Add Services
builder.Services.AddScoped<IContaService, ContaService>();

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
