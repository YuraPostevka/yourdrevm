using BAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace webApiTask.Controllers
{
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
        public IHttpActionResult GetAll()
        {
            try
            {
                var todoLists = toDoListManager.GetAll();
                if (todoLists != null) return Ok(todoLists);
                else { return NotFound(); }
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
                toDoListManager.Update(toDoList);
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
