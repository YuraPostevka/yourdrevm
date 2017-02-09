using BAL.Interfaces;
using Microsoft.AspNet.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiTask.Controllers
{
    [RoutePrefix("api/lists")]
    public class ToDoListController : ApiController
    {
        private IToDoListManager listManager;

        public ToDoListController(IToDoListManager listManager)
        {
            this.listManager = listManager;
        }

        [Route("")]
        // GET: api/ToDoList
        public IHttpActionResult Get()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return Json(new
                {
                    message = "You need to LogIn",
                });
            }

            var lists = listManager.GetAll().Where(u => u.User_Id == Convert.ToInt32(userId)).ToList();
            return Ok(lists);
        }

        // GET: api/ToDoList/5
        [HttpGet]
        [Route("GetByName/{tagName}")]
        public IHttpActionResult Get(string tagName)
        {
            var lists = listManager.GetListsByTagName(tagName);
            return Ok(lists);
        }

        // POST: api/ToDoList
        public IHttpActionResult Post(ToDoList list)
        {
            list.User_Id = Convert.ToInt32(User.Identity.GetUserId());
            var result = listManager.Insert(list);

            return Ok(result);
        }

        // PUT: api/ToDoList/5
        [Route("changeListName/{id}/{value}")]
        public IHttpActionResult Put(int id, string value)
        {
            listManager.ChangeName(id, value);
            return Ok();
        }

        // DELETE: api/ToDoList/5
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            listManager.Delete(id);
            return Ok();
        }
    }
}
