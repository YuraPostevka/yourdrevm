using BAL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BAL.Managers
{
    public class ToDoItemManager : BaseManager, IToDoItemManager
    {
        public ToDoItemManager(IUnitOfWork uOW)
            : base(uOW)
        { }

        public void Delete(int id)
        {
            var item = uOW.ToDoItemRepo.GetByID(id);
            uOW.ToDoItemRepo.Delete(item);
        }

        public List<ToDoItem> GetAll()
        {
            return uOW.ToDoItemRepo.All.ToList();
        }

        public ToDoItem GetById(int id)
        {
            return uOW.ToDoItemRepo.GetByID(id);
        }

        public List<ToDoItem> GetNotCompletedItems()
        {
            return uOW.ToDoItemRepo.All.Where(n => n.IsCompleted == false).ToList();
        }

        public void Insert(ToDoItem item)
        {
            item.Created = DateTime.Now;

            uOW.ToDoItemRepo.Insert(item);
            uOW.Save();
        }

        public bool IsAnyPropertyNotNull(ToDoItem item)
        {
            bool result = false;
            foreach (var property in item.GetType().GetProperties())
            {
                if (property != null) result = true;
                else result = false;
            }
            return result;
        }

        public void MarkAsCompleted(ToDoItem item)
        {
            var dbItem = uOW.ToDoItemRepo.GetByID(item.Id);

            dbItem.IsCompleted = true;
            dbItem.Modified = DateTime.Now;

            uOW.Save();
        }

        public void Update(ToDoItem item)
        {
            var dbItem = uOW.ToDoItemRepo.GetByID(item.Id);
            dbItem = item;
            dbItem.Modified = DateTime.Now;

            uOW.Save();
        }
    }
}
