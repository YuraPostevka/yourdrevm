using Models;
using System.Collections.Generic;

namespace BAL.Interface
{
    public interface IUserManager
    {
        void UpdateUser(User user);
        User GetById(int id);
        List<User> GetAll();
        void Insert(User user);
        string GetEmail(int Id);
        bool EmailIsExist(string email);
    }
}