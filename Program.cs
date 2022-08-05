using FluentValidation;
using FluentValidation.AspNetCore;
using microservice.Context;
using microservice.Dto;
using microservice.Infrastructure.Implementation;
using microservice.Infrastructure.Interfaces;
using microservice.Mapper;
using microservice.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DefaultMapper>();
});
builder.Services.AddSingleton<IValidator<CarDto>, CarValidator>();

builder.Services.AddTransient<ICarRepository, CarRepository>();

builder.Services.AddSingleton<ICharacterService, CharacterService>();

builder.Services.AddDbContext<TeslaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("Harry", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["Endpoints:Harry"]);
    c.DefaultRequestHeaders.Add("test", "ok");
});

builder.Services.AddHttpClient();

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
