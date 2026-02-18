using Microsoft.EntityFrameworkCore;
using Tarea6Semana6API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<Tarea6Semana6AppContext>(
    options => {
        options.UseMySQL(cs,
    mySqlOptions =>
    {
        mySqlOptions.MigrationsHistoryTable("__EFMigrationsHistory");

    });

    });
const string CorsPolicyName = "AllowAll";

builder.Services.AddCors(options =>

{
    options.AddPolicy(CorsPolicyName, policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(CorsPolicyName);

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
