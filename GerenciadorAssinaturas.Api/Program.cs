using GerenciadorAssinaturas.Api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<GerenciadorDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AssinaturaService>();
builder.Services.AddScoped<CartaoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<PlanoService>();
builder.Services.AddScoped<UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
