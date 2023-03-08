using Api.Data;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;//o import da interface não é identificado

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//service da Connection String
//comunicacao com a connection string
//se mudar o tipo de bd,basta trocar o campo 'UseSQlServer'
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//ADICIONANDO SERVIÇO DA INTERFACE(A INTERFACE É UM SERVIÇO AQUI)
builder.Services.AddScoped<IProductRepository,ProductRepository>();//interface e sua classe

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
