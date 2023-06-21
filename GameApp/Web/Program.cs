using App;
using App.Adapters;
using App.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<DBAdapter>(); // Register the DBAdapter service
//builder.Services.AddScoped<GetAllDevCompanies>(); // Register the GetAllDevCompanies use case
//builder.Services.AddControllers();


builder.Services.AddControllers(options =>
{
    //Generates bearer token used for authorization
    //var policy = new AuthorizationPolicyBuilder()
    //    .RequireAuthenticatedUser()
    //    .Build();
    //options.Filters.Add(new AuthorizeFilter(policy));
})
    .AddJsonOptions(configure =>
    {
        //configure.JsonSerializerOptions.Converters.Add(new DateOnlyConverter());
        //configure.JsonSerializerOptions.Converters.Add(new JsonEmptyStringToNullConverter());
        //configure.JsonSerializerOptions.Converters.Add(new NullableDateTimeConverter());

    });

//builder.Services.AddScoped((provider) => new SqlConnection(builder.Configuration.GetConnectionString("VideogameDbConnection")));
var settings = new Settings(builder.Configuration);

builder.Services.AddMemoryCache();


//Used for authenication
//Ad - azure active directory
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd", JwtBearerDefaults.AuthenticationScheme);


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


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
