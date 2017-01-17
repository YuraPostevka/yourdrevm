using BAL.Interface;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using BAL.Managers;
using Models;

namespace BAL.Manager
{
    public class UserManager : BaseManager, IUserManager
    {
        public UserManager(IUnitOfWork uOW)
            : base(uOW)
        {
        }

        /// <summary>
        /// Get all users from db.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {

            return uOW.UserRepo.All.ToList();
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            var user = uOW.UserRepo.GetByID(id);
            if (user == null) return null;

            return user;
        }
        /// <summary>
        /// Get user by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetByEmail(string email, string password)
        {
            var user = uOW.UserRepo.All.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }

        public string GetEmail(int Id)
        {
            var email = uOW.UserRepo.GetByID(Id).Email;
            return email;
        }

       /// <summary>
       /// update user in database
       /// </summary>
       /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            user.Modified = DateTime.Now;
            uOW.UserRepo.Update(user);
            uOW.Save();
        }

        /// <summary>
        /// Insert user into database
        /// </summary>
        /// <param name="user">User</param>
        public void Insert(User user)
        {
            if (user == null) return;
            user.Created = DateTime.Now;
            uOW.UserRepo.Insert(user);
            uOW.Save();
        }

        /// <summary>
        /// Check the email's exictance in database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
		public bool EmailIsExist(string email)
        {
            return uOW.UserRepo.All.Any(x => x.Email == email);
        }
    }
}