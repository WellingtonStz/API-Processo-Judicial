
using API_ProcessJudicial.Domain.Interfaces;
using API_ProcessJudicial.Infra.Data.Repository;
using API_ProcessJudicial.Service.Validators;
using Crud_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProcessJudicialRepository, ProcessJudicialRepository>();
builder.Services.AddScoped<IValidateUsers, ValidateUsers>();
builder.Services.AddDbContext<_DbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var OpenCorsPolicy = "_openCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: OpenCorsPolicy,
                        builder =>
                        {
                            builder.AllowAnyOrigin();
                            builder.WithMethods("PUT", "DELETE", "GET", "POST");
                            builder.AllowAnyHeader();
                        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(OpenCorsPolicy);

app.MapControllers();

app.Run();
