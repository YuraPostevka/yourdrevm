using BAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiTask.Controllers
{
    public class ToDoListController : ApiController
    {
        private IToDoListManager toDoListManager;

        public ToDoListController(IToDoListManager toDoListManager)
        {
            this.toDoListManager = toDoListManager;
        }
        // GET: api/ToDoList
        public List<ToDoList> Get()
        {
            return toDoListManager.GetAll();
        }

        // GET: api/ToDoList/5
        public ToDoList Get(int id)
        {
            try
            {
                return toDoListManager.GetById(id);
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // POST: api/ToDoList
        public void Post(ToDoList toDoList)
        {
            toDoListManager.Insert(toDoList);
        }

        // PUT: api/ToDoList/5
        public void Put(ToDoList toDoList)
        {
            toDoListManager.Update(toDoList);
        }

        // DELETE: api/ToDoList/5
        public void Delete(int id)
        {
            toDoListManager.Delete(id);
        }
    }
}
