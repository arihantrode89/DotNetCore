using Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<OptionModel>(builder.Configuration.GetSection("AWsConfig")); //need to configure option model by giving particular section
var app = builder.Build();


//app.Run(async(HttpContext context) =>
//{
//    await context.Response.WriteAsync(app.Configuration["myKey"]);
//});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.Map("apikey", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["myKey"]);
        await context.Response.WriteAsync(app.Configuration["AWsConfig:key"]);
    });
});
app.MapControllers();
app.Run();
