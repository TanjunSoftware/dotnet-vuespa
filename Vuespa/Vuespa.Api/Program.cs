using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Vuespa.Api.Config;
using Vuespa.Api.Services;
using Vuespa.Data;
using Vuespa.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile("appsettings.Development.json", true)
    .AddJsonFile("appsettings.local.json", true)
    .AddEnvironmentVariables()
    .Build();

{
    var services = builder.Services;

    // Application Settings
    services.Configure<EmailConfig>(config.GetSection(EmailConfig.Key));

    // OpenApi
    services.AddEndpointsApiExplorer();
    services.AddOpenApi();

    // Services
    services.AddTransient<IEmailSender<ApplicationUser>, EmailSender>();

    // Database
    var connectionString = config.GetConnectionString("DefaultConnection");
    services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connectionString));
    services.AddDatabaseDeveloperPageExceptionFilter();

    // Identity
    services.AddAuthorization();
    services.AddIdentityApiEndpoints<ApplicationUser>()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders()
        .AddUserStore<UserStore<ApplicationUser, Role, ApplicationContext, Guid>>();

    services.AddCors();
    services.AddControllers();
}

var app = builder.Build();

// Add OpenApi and Scalar in Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
else
{
    app.UseHsts();
}

// Configure CORS policy
// NOTE: This is an example and _cannot_ be used in a production environment
// Refer to the Microsoft documentation for guidance on setting up CORS in a production environment
// https://learn.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-9.0
app.UseCors(x => x
    .WithOrigins("http://localhost:4242")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

// Run Migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();

// Authorization
app.MapGroup("/api/auth")
    .MapIdentityApi<ApplicationUser>();

// Add a logout endpoint
// NOTE: This is an example from the Microsoft documentation. Refer to the documentation
// here for more information about implementing endpoints in your application:
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-9.0
app.MapPost("/api/auth/logout", async (SignInManager<ApplicationUser> signInManager, [FromBody] object empty) =>
{
    if (empty != null)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
    return Results.Unauthorized();
});

app.Run();