using myModels;
using myModels.Interfaces;
using myServices;
using fileScdervices.Interface;
using fileServices;
using porjectPizza.Middleware;

var builder = WebApplication.CreateBuilder(args);

// הוספת שירותים לאפליקציה
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Ipizza, pizzaService>();
builder.Services.AddTransient<Iorder, orderService>();
builder.Services.AddScoped<Iworker, workerService>();

// הוספת שירות קבצים עם נתיב הכתיבה
builder.Services.AddSingleton<IfileServices<Pizza>>(new ReadWrite<Pizza>(@"H:\webApi\shira meringer-lesson6\projectPizza\PizzaCollection.Json"));
builder.Services.AddSingleton<IfileServices<string>>(new ReadWrite<string>(@"H:\webApi\shira meringer-lesson6\projectPizza\ActuonLog.txt"));

// הגדרת CORS - מאפשר בקשות מכל מקור
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()        // מאפשר בקשות מכל מקור
              .AllowAnyHeader()        // מאפשר כל כותרת (header)
              .AllowAnyMethod();       // מאפשר כל שיטה (method)
    });
});

var app = builder.Build();

// אם האפליקציה רצה בסביבת פיתוח, הפעל את Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCustom();
// הפעלת CORS
app.UseCors("AllowAll");  // כאן חשוב להפעיל את ה-CORS אחרי הגדרת הפוליסה

// שאר ההגדרות
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthorization();

// מיפוי ה-Controllers
app.MapControllers();

// הרצת האפליקציה
app.Run();
