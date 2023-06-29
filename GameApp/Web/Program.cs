using App;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//
builder.Services.AddControllers();


//builder.Configuration = object that holds the configuration settings for the application. It is typically loaded from
//various configuration sources such as appsettings.json, environment variables, command-line arguments, etc
var settings = new Settings(builder.Configuration);

//Where dependency is injected. Add all the services and settings such as http requests, and registering transicent
DiConfigurations.ConfigureServices(builder.Services, settings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//Not for deployment i would take this out if this was a real app :)
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
