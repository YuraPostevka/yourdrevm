using BAL.Interfaces;
using Microsoft.AspNet.Identity;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace webApiTask.Controllers
{
    [Authorize]
    public class ToDoListController : ApiController
    {
        private IToDoListManager toDoListManager;

        public ToDoListController(IToDoListManager toDoListManager)
        {
            this.toDoListManager = toDoListManager;
        }

        /// <summary>
        /// Get all Todo lists
        /// </summary>
        /// <returns></returns>
        // GET: api/ToDoList
        [ResponseType(typeof(List<ToDoList>))]
        public IHttpActionResult GetAll(string tagName)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                if (userId == null)
                {
                    return Json(new
                    {
                        message = "You need to LogIn"
                    });
                }
                List<ListTagDTO> lists;
                if (tagName == null)
                {
                    lists = toDoListManager.GetAll().Where(u => u.User_Id == Convert.ToInt32(userId)).ToList();
                }
                else
                {
                    lists = toDoListManager.GetListsByTagName(tagName);
                }
                return Ok(lists);
            }
            catch { return NotFound(); }
        }

        /// <summary>
        /// Get Todo list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ToDoList/5
        [ResponseType(typeof(ToDoList))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var list = toDoListManager.GetById(id);
                if (list != null) return Ok(list);
                else { return NotFound(); }
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Insert Todo list
        /// </summary>
        /// <param name="toDoList"></param>
        // POST: api/ToDoList
        public IHttpActionResult Post(ToDoList toDoList)
        {
            try
            {
                toDoListManager.Insert(toDoList);
                return Ok();
            }
            catch { return InternalServerError(); }
        }

        /// <summary>
        /// Update Todo list
        /// </summary>
        /// <param name="toDoList"></param>
        // PUT: api/ToDoList/5
        public IHttpActionResult Put(ToDoList toDoList)
        {
            try
            {
                //toDoListManager.ChangeName(toDoList);
                return Ok();
            }
            catch { return InternalServerError(); }

        }

        /// <summary>
        /// Delete Todo list
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ToDoList/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                toDoListManager.Delete(id);
                return Ok();
            }
            catch { return InternalServerError(); }

        }
    }
}
