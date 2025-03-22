using PasswordGenerative.services.implementations;
using PasswordGenerative.Services.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//services
builder.Services.AddScoped<IUniqueNumberGeneratorService, UniqueNumberGeneratorService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
