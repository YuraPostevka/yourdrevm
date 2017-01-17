using BAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webApiTask.ActionFilters;

namespace webApiTask.Controllers
{
    public class UserController : ApiController
    {
        private IUserManager userManager;
        private GlobalExceptionAttribute exc;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: api/User
        public List<User> GetAll()
        {
            return userManager.GetAll();
        }

        // GET: api/User/5
        public HttpResponseMessage GetById(int id)
        {
            var user = userManager.GetById(id);
            if (user == null)
            { 
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);

        }

        // POST: api/User
        public void Post(User user)
        {
            userManager.Insert(user);
        }

        // PUT: api/User/5
        public void Put(User user)
        {
            userManager.UpdateUser(user);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {

        }
    }
}
