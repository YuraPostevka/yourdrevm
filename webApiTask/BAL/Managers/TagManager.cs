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

        public void Delete(string name, int listId)
        {
            if (name == null) return;
            var tagId = GetByName(name).Id;

            var taglistdb = uOW.ToDoListsTagsRepo.All.Where(i => i.TagId == tagId && i.ToDoListId == listId).FirstOrDefault();
            uOW.ToDoListsTagsRepo.Delete(taglistdb);
            // uOW.Save();

            //правильно видаляти теги

        }

        public List<Tag> GetAll(int toDoListId)
        {
            return uOW.TagRepo.All.ToList();
        }

        public Tag Insert(string tag, int toDoListId)
        {
            //check if name is exist in db
            Tag newTag = new Tag()
            {
                Name = tag
            };
            uOW.TagRepo.Insert(newTag);
            uOW.Save();

            uOW.ToDoListsTagsRepo.Insert(new ToDoListsTags() { TagId = newTag.Id, ToDoListId = toDoListId });
            uOW.Save();

            return newTag;
        }
        public Tag GetByName(string name)
        {
            if (name == null) return null;
            var tag = uOW.TagRepo.All.FirstOrDefault(n => n.Name == name);
            return tag;
        }
    }
}
