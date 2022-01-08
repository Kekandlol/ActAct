using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace StrangerThings.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public IndexModel()
        {
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(
                 new Claim[]
                 {
                     new Claim("LoginTime", DateTime.Now.ToLongTimeString()),
                    new Claim("FromSign", "In")
                 }, CookieAuthenticationDefaults.AuthenticationScheme)));
            return RedirectToPage();
        }
    }
}