using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PollsAppAssessment.Data;
using PollsAppAssessment.Models;

namespace PollsAppAssessment.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Poll> Poll { get; set; } = default!;
        public DbSet<PollDetail> PollDetail { get; set; } = default!;
    }
}
