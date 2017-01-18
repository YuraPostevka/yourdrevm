using BAL.Managers;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IToDoItemManager
    {
        List<ToDoItem> GetAll();
        ToDoItem GetById(int? id);
        void Insert(ToDoItem item);
        void Delete(int? id);
        void Update(ToDoItem item);
        void MarkAsCompleted(ToDoItem item);
        List<ToDoItem> GetNotCompletedItems();
    }
}
