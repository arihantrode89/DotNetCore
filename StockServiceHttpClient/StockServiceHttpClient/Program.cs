using StockServiceHttpClient.StockService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IStock, Stock>();
var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
