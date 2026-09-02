using Microsoft.AspNetCore.Authentication.Cookies;
using MongoDB.Driver;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();



var mongoUri = Environment.GetEnvironmentVariable("MONGODB_URI");
builder.Services.AddSingleton<IMongoClient>(new MongoClient(mongoUri));



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();