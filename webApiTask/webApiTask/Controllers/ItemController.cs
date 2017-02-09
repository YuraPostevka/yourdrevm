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
    [RoutePrefix("api/items")]
    public class ItemController : ApiController
    {
        private IToDoItemManager itemManager;

        public ItemController(IToDoItemManager itemManager)
        {
            this.itemManager = itemManager;
        }

        // GET: api/Item
        public IHttpActionResult Get()
        {
            return Ok();
        }

        // GET: api/Item/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/Item
        public IHttpActionResult Post(ToDoItem item)
        {
            var result = itemManager.Insert(item);

            return Ok(result);
        }

        // PUT: api/Item/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE: api/Item/5
        public IHttpActionResult Delete(int id)
        {
            itemManager.Delete(id);

            return Ok();
        }
    }
}
