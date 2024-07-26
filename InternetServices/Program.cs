using InternetServices.Middlwares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<LogMiddleware>("Start Task!");
app.UseMiddleware<LogMiddleware>("End Task!");


app.MapGet("/", () => "Hello World!");

app.Run();
