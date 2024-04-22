using FluentValidation;
using FluentValidation.AspNetCore;
using Foodee.Application.Validator;
using NToastNotify;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 4000
        
    })
    .AddFluentValidation(opt =>
 {
        opt.RegisterValidatorsFromAssemblyContaining<EventValidator>();
        opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("en");
        opt.DisableDataAnnotationsValidation = true;

 });






builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseNToastNotify();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
