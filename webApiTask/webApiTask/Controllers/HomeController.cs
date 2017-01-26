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
using Microsoft.AspNet.Identity;

namespace webApiTask.Controllers
{
    public class HomeController : BaseController
    {
        private IToDoItemManager itemManager;
        private IToDoListManager listManager;
        private IAuthenticationManager authManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public HomeController(IToDoItemManager itemManager, IToDoListManager listManager)
        {
            this.itemManager = itemManager;
            this.listManager = listManager;
        }

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Get all toDoLists
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetAllToDoLists()
        {
            var userId = User.Identity.GetUserId();
            if(userId==null)
            {
                return Json(new {
                    redirectUrl = Url.Action("Login", "Home"),
                    isRedirect = false
                }, "application/json", JsonRequestBehavior.AllowGet);
            }
            var lists = listManager.GetAll().Where(u => u.User_Id == Convert.ToInt32(userId)).ToList();


            return Json(lists, "application/json", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Change status of isCompleted property in todoItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isCompleted"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeStatusOfItem(int id, bool isCompleted)
        {
            itemManager.ChangeCompletedItem(id, isCompleted);
            return Json("");
        }

        [HttpPost]
        public JsonResult ChangeItemText(int id, string text)
        {
            itemManager.ChangeItemText(id, text);
            return Json("");
        }

        [HttpPost]
        public JsonResult ChangeListName(int id, string name)
        {
            listManager.ChangeName(id, name);
            return Json("");
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
