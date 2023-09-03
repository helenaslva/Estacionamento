using EstacionamentoAPI.Data;
using EstacionamentoAPI.Handler.Estacionamentos;
using EstacionamentoAPI.Repository.Estacionamentos;
using EstacionamentoAPI.Repository.Preco;
using EstacionamentoAPI.Shared;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
    }
    );
});

// Add services to the container.
builder.Services.AddScoped<IEstacionamentoRepository, EstacionamentoRepository>();
builder.Services.AddScoped<IEstacionamentoHandler, EstacionamentoHandler>();
builder.Services.AddScoped<IPrecoRepository, PrecoRepository>();

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EstacionamentoContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("Default"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Default")))
    //Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")
    );


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

// app.UseCorsMiddleware();

app.Run();
