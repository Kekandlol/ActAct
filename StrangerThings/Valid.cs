using Microsoft.AspNetCore.Authentication.Cookies;
using System.Diagnostics;
using System.Security.Claims;

namespace StrangerThings
{
    public class CookieValidator : CookieAuthenticationEvents
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<CookieValidator> logger;

        public CookieValidator(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<CookieValidator>();
        }

        public override Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            context.HttpContext.Features.Set(new Govno
            {
                Pub = context.Properties.IssuedUtc?.ToLocalTime().ToString("HH:mm:ss"),
                Exp = context.Properties.ExpiresUtc?.ToLocalTime().ToString("HH:mm:ss")
            });

            var userPrincipal = context.Principal;
            Debug.WriteLine(string.Join('\n', userPrincipal!.Claims.Select(x=>$"{x?.Type} - {x?.Value}")));
            //context.ReplacePrincipal(new ClaimsPrincipal(
            //    new ClaimsIdentity(
            //        new Claim[] {
            //            new Claim("Valida", "te Cooke")
            //        })));
            //    context.Properties.AllowRefresh = true;
            context.Properties.Items["AAAA"] = DateTime.UtcNow.ToShortTimeString(); ;
        //    context.Properties.IsPersistent = true;
            context.ShouldRenew = true;
            return Task.CompletedTask;
        }
    }

    class Govno {
        public string? Pub { get; set; }
        public string? Exp { get; set; }
    }

}
