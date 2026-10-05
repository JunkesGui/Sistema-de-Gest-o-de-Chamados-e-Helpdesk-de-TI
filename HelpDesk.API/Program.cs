using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.RP;
using HelpDesk.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CategoriasRepository>();

var app = builder.Build();

app.MapControllers();
app.Run();
