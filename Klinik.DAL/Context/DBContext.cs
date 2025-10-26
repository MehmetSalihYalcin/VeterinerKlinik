using Klinik.Entity.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinik.DAL.Context
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{
		}
		public DbSet<Medicine> Medicines { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}
