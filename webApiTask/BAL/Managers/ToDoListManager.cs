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

        public void Delete(int id)
        {
            var item = uOW.ToDoListRepo.GetByID(id);
            uOW.ToDoListRepo.Delete(item);
        }

        public List<ToDoList> GetAll()
        {
            var toDoList = uOW.ToDoListRepo.All.ToList();

            return toDoList;
        }

        public ToDoList GetById(int id)
        {
            return uOW.ToDoListRepo.GetByID(id);
        }

        public void Insert(ToDoList item)
        {
            if (item == null) return;
            item.Created = DateTime.Now;
            uOW.ToDoListRepo.Insert(item);
            uOW.Save();
        }

        public void Update(ToDoList item)
        {
            var dbItem = uOW.ToDoListRepo.GetByID(item.Id);

            dbItem.Items = item.Items;
            dbItem.Name = item.Name;
            dbItem.User = item.User;
            dbItem.User_Id = dbItem.User_Id;
            dbItem.Modified = DateTime.Now;

            uOW.Save();
        }
    }
}
