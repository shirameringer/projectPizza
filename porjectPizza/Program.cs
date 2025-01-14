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

// הוספת שירותים לאפליקציה
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FBI", Version = "v1" });
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

            cfg.AddPolicy("superWorker", policy => policy.RequireClaim("role", "superWorker"));
            cfg.AddPolicy("worker", policy => policy.RequireClaim("role", "worker"));
        });
builder.Services.AddSingleton<Ipizza, pizzaService>();
builder.Services.AddTransient<Iorder, orderService>();
builder.Services.AddScoped<Iworker, workerService>();
builder.Services.AddScoped<Ilogin, LoginService>();
builder.Services.AddSingleton<IfileServices<Worker>>(new ReadWrite<Worker>(@"..\workerList.Json"));
builder.Services.AddSingleton<IfileServices<Pizza>>(new ReadWrite<Pizza>(@"..\PizzaCollection.Json"));
builder.Services.AddSingleton<IfileServices<string>>(new ReadWrite<string>(@"..\ActuonLog.txt"));




// הגדרת CORS - מאפשר בקשות מכל מקור
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll", policy =>
//     {
//         policy.AllowAnyOrigin()        // מאפשר בקשות מכל מקור
//               .AllowAnyHeader()        // מאפשר כל כותרת (header)
//               .AllowAnyMethod();       // מאפשר כל שיטה (method)
//     });
// });

var app = builder.Build();

// אם האפליקציה רצה בסביבת פיתוח, הפעל את Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseCustom();
// הפעלת CORS
// app.UseCors("AllowAll");  // כאן חשוב להפעיל את ה-CORS אחרי הגדרת הפוליסה

// שאר ההגדרות
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