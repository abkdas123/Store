using Models.ViewModels;
using Services.Contract;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyStore.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IAuthenticationService _AuthenticationService = null;

        public AuthenticationController()
        {
            _AuthenticationService = new AuthenticationService();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Authentication")]
        public HttpResponseMessage Authentication(Login login)
        {
            HttpResponseMessage httpResponseMessage = null;

            if (login != null)
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.Accepted, _AuthenticationService.AuthenticateUser(login));
            else
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Model");

            return httpResponseMessage;
        }
    }
}
