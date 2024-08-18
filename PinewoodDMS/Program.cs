using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using PinewoodDMS.Services.CustomerService;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Access IConfiguration from the WebApplicationBuilder
IConfiguration configuration = builder.Configuration;

// Register services
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.Configure<string>(configuration.GetSection("PinewoodAPI"));

// Register each validator individually
builder.Services.AddHttpClient();
builder.Services.AddTransient<ICustomerService, CustomerService>();

//fluend validation service registration
builder.Services.AddControllersWithViews().AddFluentValidation(fv =>
{
    // fv.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseDeveloperExceptionPage();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();


