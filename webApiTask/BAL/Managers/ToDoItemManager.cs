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

        /// <summary>
        /// Delete todo item
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            if (id == null) return;
            var item = uOW.ToDoItemRepo.GetByID(id);
            uOW.ToDoItemRepo.Delete(item);
        }

        /// <summary>
        /// Get all todo items
        /// </summary>
        /// <returns></returns>
        public List<ToDoItem> GetAll()
        {
            return uOW.ToDoItemRepo.All.ToList();
        }

        /// <summary>
        /// Get todo item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoItem GetById(int? id)
        {
            if (id == null) return null;
            return uOW.ToDoItemRepo.GetByID(id);
        }

        /// <summary>
        /// Get not completed todo items
        /// </summary>
        /// <returns></returns>
        public List<ToDoItem> GetNotCompletedItems()
        {
            return uOW.ToDoItemRepo.All.Where(n => n.IsCompleted == false).ToList();
        }

        /// <summary>
        /// Insert todo item
        /// </summary>
        /// <param name="item"></param>
        public void Insert(ToDoItem item)
        {
            try
            {
                item.Created = DateTime.Now;

                uOW.ToDoItemRepo.Insert(item);
                uOW.Save();
            }
            catch { }
        }

        /// <summary>
        /// Mark tidi item as comleted
        /// </summary>
        /// <param name="item"></param>
        public void MarkAsCompleted(ToDoItem item)
        {
            try
            {
                var dbItem = uOW.ToDoItemRepo.GetByID(item.Id);

                dbItem.IsCompleted = true;
                dbItem.Modified = DateTime.Now;

                uOW.Save();
            }
            catch { }
        }

        /// <summary>
        /// Update todo item
        /// </summary>
        /// <param name="item"></param>
        public void Update(ToDoItem item)
        {
            try
            {
                var dbItem = uOW.ToDoItemRepo.GetByID(item.Id);
                dbItem = item;
                dbItem.Modified = DateTime.Now;

                uOW.Save();
            }
            catch { }

        }
    }
}
