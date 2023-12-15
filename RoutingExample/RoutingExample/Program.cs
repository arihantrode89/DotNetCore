using Microsoft.Extensions.FileProviders;
using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "newroot"
});

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("Email",typeof(EmailCheckConstraint)); 
}); //adding custom constraint for routes
var app = builder.Build();

//app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath +@"\myroot"),
    RequestPath ="/StaticFile",
    RedirectToAppendTrailingSlash = false
}); //use for providing new path for static file rather than wwwroot
app.UseRouting();//for enabling routing


app.UseEndpoints(endpoints =>
{
    endpoints.Map("data", async context =>
    {
        await context.Response.WriteAsync("In data route");
    });

    endpoints.MapGet("dataget/{id:int:max(1000):length(4)}", async context =>
    {
        await context.Response.WriteAsync("In dataget route");
    });

    endpoints.MapPost("datapost", async context =>
    {
        await context.Response.WriteAsync("In data post route");
    });

    endpoints.Map("Email/{mail:Email}", async context =>
    {
        await context.Response.WriteAsync("In Email route");
    });
});


app.Run( async (context) =>
{
    await context.Response.WriteAsync("Ending is ending"); 
});

app.Run();
