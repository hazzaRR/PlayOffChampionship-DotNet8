using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlayOffChampionship.Interfaces;
using PlayOffChampionship.Models;
using PlayOffChampionship.Repository;

var allowedOrigins = "allowedOrigins";

var builder = WebApplication.CreateBuilder(args);

string? DbConnectionString;

if (builder.Environment.IsDevelopment())
{
    DbConnectionString = builder.Configuration.GetConnectionString("DbConnectionDevelopment");
}
else
{
    DbConnectionString = builder.Configuration.GetConnectionString("DbConnectionProduction");
}


// Add services to the container.

builder.Services.AddScoped<ILeagueRepository, LeagueRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<IPlayerLeagueRepository, PlayerLeagueRepository>();
builder.Services.AddScoped<ILeaderboardRepository, LeaderboardRepository>();

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
    policy =>
    {
        policy
        .WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();

    });

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(DbConnectionString));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.MapIdentityApi<ApplicationUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("health");

app.UseCors(allowedOrigins);

app.Run();
