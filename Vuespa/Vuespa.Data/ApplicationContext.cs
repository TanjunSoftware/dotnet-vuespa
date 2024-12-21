namespace Vuespa.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vuespa.Data.Entities;

public class ApplicationContext(IConfiguration configuration) : IdentityDbContext<ApplicationUser, Role, Guid>
{
    private readonly IConfiguration Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }
}