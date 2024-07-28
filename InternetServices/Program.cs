using InternetServices.Middlwares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LogMiddleware>("Start Task!");
app.UseMiddleware<LogMiddleware>("End Task!");

app.Run(async context =>
{
    await context.Response.WriteAsync($"Hello from some function in {DateTime.Now}");
});

app.MapGet("/", () => "Hello World!");

app.Run();
