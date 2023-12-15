using MiddleWare.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<CustomMiddleWare>(); //adding scope to middlware
var app = builder.Build();


app.MapGet("/api", () => "Hello World!");


app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Middleware 1\n");
    await next(context);
}); //this is middlware but it also executes subsequent middlewares

app.UseConventionalMiddleware();
//app.UseMiddleware<CustomMiddleWare>(); //callling custom middleware
app.UseCustomeMiddleWare();

app.Run( async(HttpContext context) =>
{
    await context.Response.WriteAsync("MiddleWare 2\n");
}); //this is middleware where we provided lambda func or anonymous function


app.Run();
