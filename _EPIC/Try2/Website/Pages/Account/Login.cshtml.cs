using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Website.Models;

namespace Website.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential zCredential { get; set; }

        public void OnGet()
        {
            this.zCredential = new Credential { Username = "Admin" };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Verify the credential
            if (zCredential.Username == "admin" && zCredential.Password == "password")
            {

                // Creating the security context
                var claims = new List<Claim> {

                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}


