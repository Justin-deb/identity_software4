using DemoIdentity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<MyIdentityDBContext>(o =>
o.UseSqlServer(conn));


builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services
    .AddIdentity<MyUser, MyRol>(
    options =>
    {
        //Password
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;

        //Require Email confirmed
        options.SignIn.RequireConfirmedEmail = false;

        //Lockout
        options.Lockout.AllowedForNewUsers = true;
        options.Lockout.MaxFailedAccessAttempts = 5;


    }

    )
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<MyIdentityDBContext>()
    .AddApiEndpoints()
    ;


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapIdentityApi<MyUser>();

// 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();


}
else
{
}

app.UseStaticFiles();



app.MapRazorPages();







app.Run();