using MeuProjeto.Repositories;
using MeuProjeto.Repositories.IRepositories;
using MeuProjeto.Services;
using MeuProjeto.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Repositories
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();

// Services
builder.Services.AddTransient<IClienteService, ClienteService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
