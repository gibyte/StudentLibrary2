using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Data;
using StudentLibrary2.Hubs;
using StudentLibrary2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor(); // авторизация

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentLibrary2Db")));

// Регистрация Typed Client
builder.Services.AddHttpClient<WeatherService>();

//SignalR
builder.Services.AddSignalR();

// Добавляем Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // куда перекидывать неавторизованных
        options.AccessDeniedPath = "/Account/AccessDenied"; // можно отдельно /AccessDenied
        options.Cookie.Name = "StudentLibraryCookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // Срок действия
    });

builder.Services.AddAuthorization(); // авторизация

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseExceptionHandler("/Error");
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();// порядок важен
app.UseAuthorization(); // внимание эта после UseAuthentication

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

//SignalR
app.MapHub<BookHub>("/bookHub"); // хаб после UseAuthorization
app.MapHub<ChatHub>("/chatHub");

app.Run();
