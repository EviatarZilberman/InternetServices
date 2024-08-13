using InternetServices.Identity;
using InternetServices.Middlwares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
});

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
