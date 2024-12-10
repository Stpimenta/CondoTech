using MicroServiceWorkOrder.Application.ClientServices.Implementation;
using MicroServiceWorkOrder.Application.ClientServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using MicroServiceWorkOrder.Application.Services;
using MicroServiceWorkOrder.Infrastructure.Data;
using MicroServiceWorkOrder.Infrastructure.Repository;
using MicroServiceWorkOrder.Infrastructure.Repository.Interfaces;
using MicroServiceWorkOrder.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

/* dataBase*/
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("appDb"));

/* services */
builder.Services.AddScoped<WorkOrderService>();

builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepositrory>();

builder.Services.AddScoped<ICondominiumClientService, CondominiumClientService>();
builder.Services.AddHttpClient<ICondominiumClientService, CondominiumClientService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5251");
    client.DefaultRequestHeaders.Add("Accept","application/json");
});

builder.Services.AddScoped<IWorkerClientService, WorkerClientService>();
builder.Services.AddHttpClient<IWorkerClientService, WorkerClientService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5246");
    client.DefaultRequestHeaders.Add("Accept","application/json");
});

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

