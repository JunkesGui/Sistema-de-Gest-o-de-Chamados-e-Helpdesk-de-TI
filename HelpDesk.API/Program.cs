using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.RP;
using HelpDesk.API.Repositories;
using HelpDesk.API.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CategoriasRepository>();
builder.Services.AddScoped<ChamadosRepository>();
builder.Services.AddScoped<InteracoesRepository>();
builder.Services.AddScoped<CategoriasService>();
builder.Services.AddScoped<ChamadosService>();

var app = builder.Build();

app.MapControllers();
app.MapOpenApi();
app.UseSwaggerUI(Options =>
{
    Options.SwaggerEndpoint("/openapi/v1.json", "API v1");
});

app.MapControllers();
app.Run();
