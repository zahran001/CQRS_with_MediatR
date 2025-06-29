using BlazorUI.Components;
using DemoLibrary;
using DemoLibrary.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Chaining only works if each method returns the same type.

// Register custom services separately
builder.Services.AddSingleton<IDataAccess, DemoDataAccess>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DemoLibraryMediatREntrypoint>()); // adding the entire assembly

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
