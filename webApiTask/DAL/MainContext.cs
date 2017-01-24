﻿using Models;
using System.Data.Entity;

namespace DAL
{
	public class MainContext : DbContext
	{
		public MainContext()
			: base("ConnStr")
		{
			this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

		public MainContext(string connString)
			: base(connString)
		{
			this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
	}
}