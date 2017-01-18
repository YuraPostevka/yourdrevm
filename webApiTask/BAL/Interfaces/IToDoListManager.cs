using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IToDoListManager
    {
        List<ToDoList> GetAll();
        ToDoList GetById(int? id);
        void Insert(ToDoList item);
        void Delete(int? id);
        void Update(ToDoList item);
    }
}
