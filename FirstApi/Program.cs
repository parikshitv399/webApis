using FirstApi.Data;
using FirstApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddDbContext<FirstApiContext>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("FirstApiContext")));
builder.Services.AddCors(
    builder =>
    {
        builder.AddPolicy(name: "AllowOrigin", (corsPolicy) =>
        {
            corsPolicy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
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

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();
