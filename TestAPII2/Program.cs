using Microsoft.Extensions.Configuration;
using System.Configuration;
using TestAPII2.DbContexttest;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<DbContextTest>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=TestC;Integrated Security=True;TrustServerCertificate=true"));


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

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
