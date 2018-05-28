using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MyStore.Utility
{
    public class JwtAuthenticationAttribute: AuthorizationFilterAttribute
    {
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public override void OnAuthorization(HttpActionContext filterContext)
        {
            string authorizedToken = string.Empty;
            string userAgent = string.Empty;

            try
            {
                AuthenticationHeaderValue headerToken = filterContext.Request.Headers.Authorization;

                if (headerToken != null)
                {
                    authorizedToken = Convert.ToString(headerToken.Scheme);
                    userAgent = Convert.ToString(filterContext.Request.Headers.UserAgent);
                    if (!IsAuthorize(authorizedToken, userAgent))
                    {
                        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        return;
                    }
                }
                else
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    return;
                }
            }
            catch (Exception)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                return;
            }

            base.OnAuthorization(filterContext);
        }

        private bool IsAuthorize(string authorizedToken, string userAgent)
        {
            bool result = false;
            try
            {
                result = ValidateToken(authorizedToken,out userAgent);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        
        private static bool ValidateToken(string token, out string username)
        {
            username = null;
            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            if (string.IsNullOrEmpty(username)) return false;
            // More validate to check whether username exists in system  
            return true;
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string username;
            if (ValidateToken(token, out username))
            {
                // based on username to get more information from database in order to build local identity  
                var claims = new List<Claim> 
                {  
                    new Claim(ClaimTypes.Name, username)  
                    // Add more claims if needed: Roles, ...  
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);
                return Task.FromResult(user);
            }

            return Task.FromResult<IPrincipal>(null);
        }
    }
}