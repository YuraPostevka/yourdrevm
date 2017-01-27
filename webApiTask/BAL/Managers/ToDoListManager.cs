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
                var item = new ToDoList() { Id = id.Value };
                uOW.ToDoListRepo.Delete(item);
                uOW.Save();
            }
            catch { }
        }

        /// <summary>
        /// Get all todo lists
        /// </summary>
        /// <returns></returns>
        public List<ToDoList> GetAll()
        {
            List<ToDoList> toDoList = uOW.ToDoListRepo.Get(includeProperties: "Items").ToList();

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
        public ToDoList Insert(ToDoList item)
        {

            if (item == null) return null;

            uOW.ToDoListRepo.Insert(item);
            uOW.Save();

            return item;
        }

        /// <summary>
        /// Update todo list
        /// </summary>
        /// <param name="item"></param>
        public void ChangeName(int id, string name)
        {
            var dbItem = uOW.ToDoListRepo.GetByID(id);
            dbItem.Name = name;

            uOW.Save();
        }
    }
}
