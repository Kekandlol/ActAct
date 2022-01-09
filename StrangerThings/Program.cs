using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using StrangerThings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contex>(x=>x.UseNpgsql(builder.Configuration["cons"]));
builder.Services.AddRazorPages();
builder.Services.AddScoped<CookieValidator>();
//builder.Services.AddScoped<IDataProtectionProvider, ProtectorProv>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.Cookie.Name = "pekar";

        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromSeconds(60);

        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
        options.Cookie.MaxAge = TimeSpan.FromDays(90);
        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;

        options.EventsType = typeof(CookieValidator);
        options.DataProtectionProvider = new ProtectorProv();
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
