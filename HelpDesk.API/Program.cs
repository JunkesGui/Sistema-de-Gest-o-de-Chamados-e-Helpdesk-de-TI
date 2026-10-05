using HelpDesk.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(
    "Server=localhost;User Id=sa;Password=Novasenha123!;TrustServerCertificate=True;Database=HelpDesk"
    ));

var app = builder.Build();

app.MapControllers();

app.Run();
