using Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//3 ways to add service into IOC container

builder.Services.AddScoped<IProduct,ProductServiceImpl>();
//builder.Services.AddScoped(typeof(IProduct),typeof(ProductServiceImpl));
//builder.Services.Add(new ServiceDescriptor(typeof(IProduct), typeof(ProductServiceImpl), ServiceLifetime.Scoped));
var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();
