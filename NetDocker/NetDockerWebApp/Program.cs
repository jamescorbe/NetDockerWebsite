using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using NetDockerWebApp.Components;
using SignInClient.Interfaces;
using UserDatabaseCore;
using WebDevTest_Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
builder.Services.AddHttpClient<ISigninClient, SigninClient>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("RestApiAddress"));
});

builder.Services.AddMudServices();
builder.Services.AddDbContext<UserDatabaseContext>(opt => opt.UseSqlServer(DBCreationHelper.CreateUserDatabaseConnectionString()));

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
