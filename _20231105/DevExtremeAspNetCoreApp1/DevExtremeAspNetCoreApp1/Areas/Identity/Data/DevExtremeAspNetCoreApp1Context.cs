using DevExtremeAspNetCoreApp1.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevExtremeAspNetCoreApp1.Data;

public class DevExtremeAspNetCoreApp1Context : IdentityDbContext<DevExtremeAspNetCoreApp1User>
{
    public DevExtremeAspNetCoreApp1Context(DbContextOptions<DevExtremeAspNetCoreApp1Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
