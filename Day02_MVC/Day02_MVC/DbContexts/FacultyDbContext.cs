using Day02_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC.DbContexts
{
	public class FacultyDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=.;Database=Faculty;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
		}

		#region Tables
		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StuCrsRes> StuCrsResults { get; set; }
		#endregion

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			// Department & student
			modelBuilder.Entity<Department>()
				.HasMany(D => D.Students)
				.WithOne(st => st.Department);

			// Department & Course
			modelBuilder.Entity<Department>()
				.HasMany(D => D.Courses)
				.WithOne(C => C.Department);

			// Department & Teacher
			modelBuilder.Entity<Department>()
				.HasMany(D => D.Teachers)
				.WithOne(T => T.Department);

			//Student & StuCrsRes
			modelBuilder.Entity<Student>()
				.HasMany(St => St.StuCrsResults)
				.WithOne(SC => SC.Student);

			//Course & StuCrsRes
			modelBuilder.Entity<Course>()
				.HasMany(C => C.StuCrsResults)
				.WithOne(SC => SC.Course);
			modelBuilder.Entity<StuCrsRes>()
				.HasKey(St => new { St.StudentId, St.CourseId });




			modelBuilder.Entity<StuCrsRes>()
				.HasOne(s => s.Student)
				.WithMany(s => s.StuCrsResults)
				.HasForeignKey(s => s.StudentId)
				.OnDelete(DeleteBehavior.NoAction);
			base.OnModelCreating(modelBuilder);
		}

	}
}
