using Microsoft.EntityFrameworkCore;
using radzen.Infrastructure.Data;
using radzen.Application;
using radzen.Application.Contracts;
using radzen.Application.Services;
using radzen.Components;
using radzen.Domain;
using radzen.Infrastructure;
using radzen.Infrastructure.Implementations;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
// CLEAN ARCHITECTURE

// Register DbContext so EmployeeRepo can be constructed.
// Uses the same connection string name as your WebAPI: "DefaultConnection"
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7203/") });
builder.Services.AddScoped<IEmployee, EmployeeRepo>();
builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
