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
    public class ToDoListManager : BaseManager, IToDoListManager
    {
        public ToDoListManager(IUnitOfWork uOW)
            : base(uOW) { }

        /// <summary>
        /// Delete todo list
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            if (id == null) return;
            try
            {
                var item = uOW.ToDoListRepo.GetByID(id);
                uOW.ToDoListRepo.Delete(item);
            }
            catch { }
        }

        /// <summary>
        /// Get all todo lists
        /// </summary>
        /// <returns></returns>
        public List<ToDoList> GetAll()
        {
            var toDoList = uOW.ToDoListRepo.All.ToList();

            return toDoList;
        }

        /// <summary>
        /// Get todo list by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDoList GetById(int? id)
        {
            if (id == null) return null;
            return uOW.ToDoListRepo.GetByID(id);
        }

        /// <summary>
        /// Insert todo list
        /// </summary>
        /// <param name="item"></param>
        public void Insert(ToDoList item)
        {
            try
            {
                if (item == null) return;
                item.Created = DateTime.Now;
                uOW.ToDoListRepo.Insert(item);
                uOW.Save();
            }
            catch { }
        }

       /// <summary>
       /// Update todo list
       /// </summary>
       /// <param name="item"></param>
        public void Update(ToDoList item)
        {
            item.Modified = DateTime.Now;
            uOW.ToDoListRepo.Update(item);

            uOW.Save();
        }
    }
}
