using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTaskWebApp.Models
{
	public class EntityContext : DbContext
	{
		public EntityContext() : base("EntityContext")
		{

		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<Merchandize> Merchandize { get; set; }
	}
}