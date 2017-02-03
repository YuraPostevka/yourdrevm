using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL.Interfaces;

namespace BAL.Managers
{
    public class TagManager : BaseManager, ITagManager
    {
        public TagManager(IUnitOfWork uOW) : base(uOW)
        {
        }

        public void Delete(int id)
        {
            uOW.TagRepo.Delete(id);
            //var tgs = uOW.ToDoListsTagsRepo.All.Where(i => i.TagId == id);

            uOW.Save();
        }

        public List<Tag> GetAll(int toDoListId)
        {
            return uOW.TagRepo.All.ToList();
        }

        public Tag Insert(Tag item, int toDoListId)
        {
            uOW.TagRepo.Insert(item);
            uOW.Save();
            return item;
        }
    }
}
