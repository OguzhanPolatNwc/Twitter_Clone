using App.Application;
using App.Application.Interfaces;
using App.Application.Services;
using App.Application.Services.Mail;
using App.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<UserService>();

builder.Services.AddTransient<PostService>();

builder.Services.AddTransient<SearchService>();

builder.Services.AddTransient<IEmailService, SmtpEmailService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");

    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Auth/Login";
        option.AccessDeniedPath = "/Auth";
    });

//Used for Session Structure
//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = ".MvcTwitter";
//    options.IdleTimeout = TimeSpan.FromMinutes(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // DataBase Code that deletes every time.
    db.Database.EnsureDeleted();

    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.Microsoft.Data.SqlClient.SqlException: 'Introducing FOREIGN KEY constraint 'FK_PostCommentUser_Users_UsersUserId' on table 'PostCommentUser' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Used for Session Structure
//app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();