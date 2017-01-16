using BAL.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiTask.Controllers
{
    public class UserController : ApiController
    {
        private IUserManager userManager;

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
        public User GetById(int id)
        {
            try
            {
                return userManager.GetById(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
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
