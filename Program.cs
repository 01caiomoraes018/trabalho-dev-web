using Microsoft.EntityFrameworkCore;
using Trabalho1DevWebNet.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "Este campo é obrigatório.");
    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
        (_, campo) => $"Informe um valor válido para {campo}.");
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Popula();
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
