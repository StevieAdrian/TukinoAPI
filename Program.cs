using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// using cors because my API and my react interface run on a different port
builder.Services.AddCors(options => {
  options.AddPolicy("AllowAllOrigins", 
    builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
  );
});

builder.Services.AddDbContext<AppDbContext>(options => {
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAllOrigins");
app.MapControllers();
app.Run();