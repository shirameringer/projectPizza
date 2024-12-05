using myModels;
using myModels.Interfaces;
using myServices;
using fileScdervices.Interface;
using fileServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Ipizza, pizzaService>();
builder.Services.AddTransient<Iorder,orderService>();
builder.Services.AddScoped<Iworker,workerService>();
builder.Services.AddSingleton<IfileServices<Pizza>>(new ReadWrite<Pizza>(@"H:\lesson6\projectPizza\PizzaCollection.Json"));
var app = builder.Build();

// Configure the HTTP requestd pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
