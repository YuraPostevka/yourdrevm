using Models;
using System.Collections.Generic;

namespace BAL.Interface
{
    public interface IUserManager
    {
        void Update(User user);
        User GetById(int? id);
        List<User> GetAll();
        void Insert(User user);
        string GetEmail(int? Id);
        bool EmailIsExist(string email);
        void Delete(int? id);
        User Find(string email, string passwrod);
    }
}