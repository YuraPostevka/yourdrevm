using Models;

namespace DAL.Interfaces
{
	public interface IUnitOfWork
	{
		IGenericRepository<User> UserRepo { get; }
        IGenericRepository<ToDoList> ToDoListRepo { get; }
        IGenericRepository<ToDoItem> ToDoItemRepo { get; }

        void Dispose();

		int Save();
	}
}