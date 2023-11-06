using WebApplication5.Areas.Identity.Data;
using WebApplication5.Data;
using System.Linq;
using System.Collections;

namespace WebApplication5.Models
{
    public class Users_in_Role_ViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

         private readonly UserManager<ApplicationUser> _userManager;

    private readonly ApplicationDbContext _context;
    public ApplicationUserController(UserManager<ApplicationUser> usermanager, ApplicationDbContext context)
    {
        _userManager = usermanager;
        _context = context;
    }
    public IActionResult Index()
    { 
        var result = _context.Users
            .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
            .Join(_context.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur, r }) 
            .Select(c => new UsersViewModel()
            {
                Username = c.ur.u.UserName,
                Email = c.ur.u.Email,
                Role = c.r.Name
            }).ToList().GroupBy(uv=> new { uv.Username, uv.Email }).Select(r=> new UsersViewModel()
            {
                Username = r.Key.Username,
                Email = r.Key.Email,
                Role = string.Join(",", r.Select(c=>c.Role).ToArray())
            }).ToList();

        // you could also use the following code:
        var result2 = _context.Users
        .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
        .Join(_context.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur, r })
        .ToList()
        .GroupBy(uv => new { uv.ur.u.UserName, uv.ur.u.Email }).Select(r => new UsersViewModel()
        {
            Username = r.Key.UserName,
            Email = r.Key.Email,
            Role = string.Join(",", r.Select(c => c.r.Name).ToArray())
        }).ToList();

        return View(result);
    }


        public void doit()
        {


            var usersWithRoles = (from user in WebApplication5Context.Users
                                  select new
                              {
                                  UserId = user.Id,
                                  Username = user.UserName,
                                  Email = user.Email,
                                  RoleNames = (from userRole in user.Roles
                                               join role in context.Roles on userRole.RoleId
                                               equals role.Id
                                               select role.Name).ToList()
                              }).ToList().Select(p => new Users_in_Role_ViewModel()

                              {
                                  UserId = p.UserId,
                                  Username = p.Username,
                                  Email = p.Email,
                                  Role = string.Join(",", p.RoleNames)
                              });
    }
}
