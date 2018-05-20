using EF_DBContext.Models;
using Services.Contract;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyUser.Controllers
{
    public class UserController : ApiController
    {
        private IUserService UserService = null;

        public UserController()
        {
            UserService = new UserService();
        }

        [Route("api/GetAllUser")]
        public HttpResponseMessage GetAllUsers() 
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, UserService.GetAllUsers());            
        }

        [Route("api/AddUsers")]
        public HttpResponseMessage AddUsers(MstUser user)
        {
            if (user != null)
                return Request.CreateResponse(HttpStatusCode.Accepted, UserService.AddUser(user));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Model is null.");
        }

        [Route("api/UpdateUsers")]
        public HttpResponseMessage UpdateUsers(MstUser user)
        {
            if (user != null)
                return Request.CreateResponse(HttpStatusCode.Accepted, UserService.UpdateUser(user));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Model is null.");
        }

        [Route("api/DeleteUsers")]
        public HttpResponseMessage DeleteUsers(int userId)
        {
            if (userId > 0)
                return Request.CreateResponse(HttpStatusCode.Accepted, UserService.DeleteUser(userId));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "User Id is zero.");
        }
    }
}
