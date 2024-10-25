using AspNetCoreMvc2.Introduction.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc2.Introduction.Models
{
	public class SchoolContext : DbContext
	{

		public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
		{

		}

		public DbSet<Student> Students { get; set; }

	}
}
