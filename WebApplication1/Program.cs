using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure.Data;
using WebApplication1.Infrastructure.Repository;
using WebApplication1.Infrastructure.Repository.Interfaces;
using WebApplication1.Infrastructure.Seed;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

/* dataBase*/
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("appDb"));



/* services */
builder.Services.AddScoped<CondominiumService>();
builder.Services.AddScoped<ICondominiumRepositrory, CondominiumRepositrory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*exception middleware*/
app.UseMiddleware<GlobalExceptionMiddleware>();
/* database seed*/
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var seeder = new DbSeed(context);
    seeder.CondominiumSeeder();
}

app.MapControllers();
app.Run();

