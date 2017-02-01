﻿using BAL.Interfaces;
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
using Models;
using webApiTask.Helpers;
using System.Configuration;
using System.IO;

namespace webApiTask.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : BaseController
    {
        private IToDoItemManager itemManager;
        private IToDoListManager listManager;
        private IUserManager userManager;
        private IInviteUserManager inviteUserManager;
        private IAuthenticationManager authManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="itemManager"></param>
        /// <param name="listManager"></param>
        /// <param name="userManager"></param>
        public HomeController(IToDoItemManager itemManager, IToDoListManager listManager, IUserManager userManager, IInviteUserManager inviteUserManager)
        {
            this.itemManager = itemManager;
            this.listManager = listManager;
            this.userManager = userManager;
            this.inviteUserManager = inviteUserManager;
        }

        [HttpGet]
        public ActionResult InviteUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InviteUser(InviteUser user)
        {
            inviteUserManager.CreateInvite(user);
            return RedirectToAction("Index", "Home");
        }

        //GET: localhost/webApi/RegisterInviteUser/id
        [HttpGet]
        public ActionResult RegisterInviteUser(string id)
        {
            var inviteUser = inviteUserManager.GetByGuid(id);
            if (inviteUser == null) { return HttpNotFound(); }

            var userDb = userManager.GetByEmail(inviteUser.Email);
            if (userDb == null)
            {
                userDb = new User()
                {
                    Email = inviteUser.Email
                };
                return View(userDb);
            }

            return View(userDb);
        }

        [HttpPost]
        public ActionResult RegisterInviteUser(User user)
        {
            userManager.Insert(user);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Photo()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null) { return null; }

            var imgHelper = new ImageHelper();
            var imgPath = imgHelper.GetImage(Convert.ToInt32(userId));

            return View(new UserModel() { ProfileImgUrl = imgPath });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ConfiguringUser()
        {
            var id = User.Identity.GetUserId();
            if (id == null)
            {
                return HttpNotFound();
            }
            var user = userManager.GetById(Convert.ToInt32(id));
            return View(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Profile"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfiguringUser(User user, string Profile)
        {
            var imgHelper = new ImageHelper();
            imgHelper.SaveImage(user.Id, Profile);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Index page
        /// </summary>
        /// <returns></returns>
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
            if (userId == null)
            {
                return Json(new
                {
                    message = "You need to LogIn",
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

        /// <summary>
        /// Change item text
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeItemText(int id, string text)
        {
            itemManager.ChangeItemText(id, text);
            return Json("");
        }

        /// <summary>
        /// Change list name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeListName(int id, string name)
        {
            listManager.ChangeName(id, name);
            return Json("");
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteItem(int? id)
        {
            itemManager.Delete(id);
            return Json("");
        }

        /// <summary>
        /// Delete list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteList(int? id)
        {
            listManager.Delete(id);
            return Json("");
        }
        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddItem(ToDoItem item)
        {
            var result = itemManager.Insert(item);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add new list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddList(ToDoList list)
        {
            list.User_Id = Convert.ToInt32(User.Identity.GetUserId());
            var result = listManager.Insert(list);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Login page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginBindingModel();
            return View(model);
        }

        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
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
