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
    /// <summary>
    /// ToDoItem
    /// </summary>

    public class ToDoItemController : ApiController
    {
        private IToDoItemManager toDoItemMngr;
        public ToDoItemController(IToDoItemManager toDoItemMngr)
        {
            this.toDoItemMngr = toDoItemMngr;
        }
        /// <summary>
        /// Getl all Todo items
        /// </summary>
        /// <returns></returns>
        // GET: api/ToDoItem
        [ResponseType(typeof(List<ToDoItem>))]
        public IHttpActionResult GetAll()
        {


            try
            {
                var items = toDoItemMngr.GetAll();
                if (items != null) return Ok(items);
                else return NotFound();
            }
            catch { return NotFound(); }
        }

        /// <summary>
        ///Get todo item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ToDoItem/5
        [ResponseType(typeof(ToDoItem))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var item = toDoItemMngr.GetById(id);
                if (item != null) return Ok(item);
                else return NotFound();
            }
            catch { return NotFound(); }

        }

        /// <summary>
        /// Insert Todo items
        /// </summary>
        /// <param name="value"></param>
        // POST: api/ToDoItem
        public IHttpActionResult Post(ToDoItem item)
        {
            try
            {
                toDoItemMngr.Insert(item);
                return Ok();
            }
            catch { return InternalServerError(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        // PUT: api/ToDoItem/5
        public IHttpActionResult Put(ToDoItem item)
        {
            try
            {
                toDoItemMngr.Update(item);
                return Ok();
            }
            catch { return InternalServerError(); }
        }

        /// <summary>
        /// Mark as completed
        /// </summary>
        /// <param name="id"></param>
        [HttpPut]
        public IHttpActionResult MarkAsCompleted(int id)
        {
            try
            {
                var item = toDoItemMngr.GetById(id);
                toDoItemMngr.MarkAsCompleted(item);
                return Ok();
            }
            catch { return InternalServerError(); }

        }

        /// <summary>
        /// Delete Todo item
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ToDoItem/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                toDoItemMngr.Delete(id);
                return Ok();
            }
            catch { return InternalServerError(); }
        }
    }
}
