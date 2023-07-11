using BotVoceVaiCantar.Domain.Interfaces;
using BotVoceVaiCantar.Repository.Context;
using BotVoceVaiCantar.Repository.Repositories;
using BotVoceVaiCantar.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region build service e repository
builder.Services.AddScoped<ICantorService, CantorService>();
builder.Services.AddScoped<ICantorRepository, CantorRepository>();
#endregion

#region mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region conexão banco
var connectionString = Environment.GetEnvironmentVariable("BOT_MUSICA_CONNSTRING");
builder.Services.AddDbContextPool<AppDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
#endregion

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
