using Microsoft.EntityFrameworkCore;
using WorkerMicroService.Infrastructure.Repository;
using WorkerMicroService.Application.Services;
using WorkerMicroService.Infrastructure.Data;
using WorkerMicroService.Infrastructure.Repository.implementations;
using WorkerMicroService.Infrastructure.Repository.Interfaces;
using WorkerMicroService.Infrastructure.Seed;

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
builder.Services.AddScoped<WorkerService>();
builder.Services.AddScoped<IWorkerRepository, WorkerRepositrory>();


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

