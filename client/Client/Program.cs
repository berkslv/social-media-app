using System.Globalization;
using Client.Models;
using Client.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");


// Add services to the container.
builder.Services
.AddValidatorsFromAssemblyContaining<PostForCreateModelValidator>()
.AddControllersWithViews();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Feed}/{action=Index}");

app.Run();
