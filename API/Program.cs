using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Infra;
using Infra.Repositorys;
using Microsoft.EntityFrameworkCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("Secret").ToString());

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<CustomerDTO, Customer>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<Contexto>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("PGDB")));

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services
builder.Services.AddScoped<IServiceCustomer, ServiceCustomer>();
builder.Services.AddScoped<IServiceToken, ServiceToken>();

//repository
builder.Services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();
builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();