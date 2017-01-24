using BAL.Interface;
using BAL.Interfaces;
using BAL.Manager;
using BAL.Managers;
using DAL;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using webApiTask.Models;

namespace webApiTask.Controllers
{
    public class HomeController : BaseController
    {
        private IToDoItemManager itemManager;

        public HomeController()
        {

        }
        private IAuthenticationManager authManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetAllItems()
        {

            //var itemManager = new ToDoItemManager(new UnitOfWork());
            //var items = itemManager.GetAll();
            var userId = 2;
            var listManager = new ToDoListManager(new UnitOfWork());

            var lists = listManager.GetAll().Where(u => u.User_Id == userId).ToList();


    //        var jsonList = JsonConvert.SerializeObject(lists,
    //Formatting.None,
    //new JsonSerializerSettings()
    //{
    //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    //});

            var res = from l in lists
                      select new
                      {
                          Name = l.Name,
                          Items = l.Items
                      };

            return Json(lists, "application/json", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginBindingModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginBindingModel model)
        {

            var userManager = new UserManager(new UnitOfWork());
            var userDb = userManager.Find(model.Email, model.Password);

            if (userDb == null) return View("Error");

            ApplicationUser user = new ApplicationUser()
            {
                Id = userDb.Id.ToString(),
                UserName = userDb.Email,
                Email = userDb.Email
            };

            ClaimsIdentity claim = new ClaimsIdentity(OAuthDefaults.AuthenticationType, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            claim.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            claim.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
            claim.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "OWIN Provider", ClaimValueTypes.String));


            ClaimsIdentity cookiesIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            cookiesIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            cookiesIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
            cookiesIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                "OWIN Provider", ClaimValueTypes.String));



            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(claim, properties);
            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, cookiesIdentity);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            authManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return RedirectToAction("Index", "Home");
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }

    }
}
