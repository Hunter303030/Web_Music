using Microsoft.EntityFrameworkCore;
using Web_Music_v3.Data;
using Web_Music_v3.Repository.Interfaces;
using Web_Music_v3.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Configuration;
using MailKit;
using Web_Music_v3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession(s =>
{
    s.IdleTimeout = TimeSpan.FromSeconds(2000);
});

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Web_MusicDB"));
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<IPlayListUserRepository, PlayListUserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumTrackRepository, AlbumTrackRepository>();
builder.Services.AddScoped<IAlbumUserRepository, AlbumUserRepository>();

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
app.UseSession();
app.UseCookiePolicy();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Auth}");


app.Run();
