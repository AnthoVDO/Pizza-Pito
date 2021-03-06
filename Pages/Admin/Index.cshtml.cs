using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Pizza_Pito.Pages.Admin
{
    public class IndexModel : PageModel
    {
        IConfiguration configuration;
        public bool incorrectInput = false;
        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Admin/Pizzas");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string username, string password, string ReturnUrl)
        {
            var authSection = configuration.GetSection("Auth");

            string adminLogin = authSection["AdminLogin"];
            string adminPassword = authSection["AdminPassword"];
            if((username == adminLogin)&&(password==adminPassword))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl == null ? "/Admin/Pizzas" : ReturnUrl);
            }
            incorrectInput = true;
            return Page();
        }

        public async Task<IActionResult> OnGetLogout()
        {
            await HttpContext.SignOutAsync();
            
            return Redirect("/Admin");
        }
    }
}
