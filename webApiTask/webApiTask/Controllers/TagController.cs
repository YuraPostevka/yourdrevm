using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace webApiTask.Controllers
{
    [Authorize]
    public class TagController : ApiController
    {
        private ITagManager tagManager;
        public TagController(ITagManager tagManager)
        {
            this.tagManager = tagManager;
        }

        // GET: api/Tag
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tag/5
        public string Get(string tagName)
        {
            return "tag";
        }

        // POST: api/Tag
        public void Post(string tag, int listId)
        {
            tagManager.AttachToList(tag, listId);
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}
