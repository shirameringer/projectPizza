using myModels;
using myModels.Interfaces;
using myServices;
using fileScdervices.Interface;
using fileServices;
using porjectPizza.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Login.tokenService;
using Login.Interface;
using Login.service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Ipizza, pizzaService>();
builder.Services.AddTransient<Iorder, orderService>();
builder.Services.AddScoped<Iworker, workerService>();
builder.Services.AddScoped<Ilogin, LoginService>();
builder.Services.AddSingleton<IfileServices<Order>>(new ReadWrite<Order>(@"..\orderList.Json"));
builder.Services.AddSingleton<IfileServices<Worker>>(new ReadWrite<Worker>(@"..\workerList.Json"));
builder.Services.AddSingleton<IfileServices<Pizza>>(new ReadWrite<Pizza>(@"..\PizzaList.Json"));
builder.Services.AddSingleton<IfileServices<string>>(new ReadWrite<string>(@"..\ActuonLog.txt"));
builder.Services
              .AddAuthentication(options =>
              {
                  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(cfg =>
              {
                  cfg.RequireHttpsMetadata = false;
                  cfg.TokenValidationParameters = TokenService.GetTokenValidationParameters();
              });
builder.Services.AddAuthorization(cfg =>
        {
           Console.WriteLine("kkhkbkbkbk");
            cfg.AddPolicy("superWorker", policy => policy.RequireClaim("role", "superWorker"));
            //cfg.AddPolicy("worker", policy => policy.RequireClaim("role", "worker"));
        });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "pizza", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                    new string[] {}
                }
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");
}
// שאר ההגדרות
app.UseDefaultFiles();
app.UseStaticFiles();  // מאפשר לשרת להגיש קבצים מתוך wwwroot

// הפניות ל-HTTPS
app.UseHttpsRedirection();

// הפעלת אימות (אם יש צורך באימות JWT או אחר)
app.UseAuthentication();

// ניתוב בקשות
app.UseRouting();

// הפעלת הרשאות
app.UseAuthorization();

// מיפוי controllers
app.MapControllers();

// הגדרת fallback לדף index.html
app.MapFallbackToFile("index.html");

app.Run();