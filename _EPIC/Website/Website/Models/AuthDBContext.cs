using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Website.Models
{
	public class AuthDBContext : IdentityDbContext
	{
		public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
		{
		}



	}
}
