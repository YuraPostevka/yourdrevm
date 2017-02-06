using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface ITagManager
    {
        List<Tag> GetAll(int toDoListId);
        Tag Insert(string item, int toDoListId);
        void Delete(string name, int listId);
        Tag GetByName(string name);
    }
}
