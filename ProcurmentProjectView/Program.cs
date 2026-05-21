using Microsoft.AspNetCore.Authentication.Cookies;
using ProcurmentProjectView.Interfaces;
using ProcurmentProjectView.Services;

var builder = WebApplication.CreateBuilder(args);
var baseUrl = builder.Configuration.GetConnectionString("BaseUrl");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IAuthService,AuthService>(client =>
{
    client.BaseAddress = new Uri(baseUrl!);
});
builder.Services.AddHttpClient<IBaseApiService, BaseServices>(client =>
{
    client.BaseAddress = new Uri(baseUrl!);
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.LoginPath = "/Login/Login";
        config.Cookie.Name = "ProcurementAuthCookie";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
