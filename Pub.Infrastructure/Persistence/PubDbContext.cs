using Microsoft.EntityFrameworkCore;
using Pub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub.Infrastructure.Persistence
{
	public class PubDbContext : DbContext
	{
		public PubDbContext(DbContextOptions<PubDbContext> options) 
			: base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=pubs;Trusted_Connection=True;TrustServerCertificate=True");
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Publication> Publications { get; set;}
	}
}
