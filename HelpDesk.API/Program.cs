using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.RP;
using HelpDesk.API.Repositories;
using HelpDesk.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CategoriasRepository>();
builder.Services.AddScoped<InteracoesRepository>();
builder.Services.AddScoped<CategoriasService>();

var app = builder.Build();

app.MapControllers();
app.Run();
