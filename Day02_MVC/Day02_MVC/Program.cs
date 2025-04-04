using Day02_MVC.DbContexts;
using Day02_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC
{
	public class Program
	{
		public static void Main(string[] args)
		{
			FacultyDbContext context = new FacultyDbContext();

			#region Adding Data in tables
			// Add List of Department
			List<Department> departmentList = new List<Department>
			{
				new Department {Name="CS",ManagerName="Shimaa" },
				new Department {Name="IS",ManagerName="Shahd" },
				new Department {Name="IT",ManagerName="Menna" },
				new Department {Name="AI",ManagerName="Sara" },
				new Department {Name="BIO",ManagerName="Hager" }
			};
			//context.Departments.AddRange(departmentList);
			//context.SaveChanges();

			//var dep = context.Departments.ToList();
			//context.Departments.RemoveRange(dep);
			//context.SaveChanges();


			//-------------------------------------------------------------------

			//// Adding Courses
			List<Course> courseList = new List<Course>
			{
				new Course { Name = "OOP", Degree = 100, MinDegree = 50, DepartmentId = 1 },
				new Course { Name = "DB", Degree = 100, MinDegree = 50, DepartmentId = 2 },
				new Course { Name = "AI Basics", Degree = 100, MinDegree = 50, DepartmentId = 3 },
				new Course { Name = "Networks", Degree = 100, MinDegree = 50, DepartmentId = 4 },
				new Course { Name = "Cyber Security", Degree = 100, MinDegree = 50, DepartmentId = 5 }
			};
			//context.Courses.AddRange(courseList);
			//context.SaveChanges();

			//-------------------------------------------------------------------

			////// Adding Teachers
			List<Teacher> teacherList = new List<Teacher>
			{
				new Teacher { Name = "Dr. Ali", Salary = 50000, Address = "Cairo", CourseId = 1, DepartmentId = 1 },
				new Teacher { Name = "Dr. Mariam", Salary = 45000, Address = "Alexandria", CourseId = 2, DepartmentId = 2 },
				new Teacher { Name = "Dr. Ahmed", Salary = 48000, Address = "Giza", CourseId = 3, DepartmentId = 3 },
				new Teacher { Name = "Dr. Salma", Salary = 47000, Address = "Aswan", CourseId = 4, DepartmentId = 4 },
				new Teacher { Name = "Dr. Khaled", Salary = 46000, Address = "Luxor", CourseId = 5, DepartmentId = 5 }
			};
			//context.Teachers.AddRange(teacherList);
			//context.SaveChanges();

			//-------------------------------------------------------------------

			//// Adding Students
			var students = context.Students.ToList();
			List<Student> studentList = new List<Student>
			{
				new Student { Name = "Omar", Age = 20, DepartmentId = 1 },
				new Student { Name = "Aya", Age = 22, DepartmentId = 2 },
				new Student { Name = "Khaled", Age = 21, DepartmentId = 3 },
				new Student { Name = "Nour", Age = 23, DepartmentId = 4 },
				new Student { Name = "Hassan", Age = 19, DepartmentId = 5 },
				new Student { Name = "Mostafa", Age = 27, DepartmentId = 1 },
				new Student { Name = "Rola", Age = 28, DepartmentId = 1 },
				new Student { Name = "Hoda", Age = 30, DepartmentId = 1 },
			};
			//context.Students.AddRange(studentList);
			//context.SaveChanges();

			//-------------------------------------------------------------------

			//// Adding Student-Course Relations (StuCrsRes)
			List<StuCrsRes> stuCrsResList = new List<StuCrsRes>
			{
				new StuCrsRes { StudentId = 1, CourseId = 1, Grade = 90 },
				new StuCrsRes { StudentId = 2, CourseId = 2, Grade = 85 },
				new StuCrsRes { StudentId = 3, CourseId = 3, Grade = 88 },
				new StuCrsRes { StudentId = 4, CourseId = 4, Grade = 92 },
				new StuCrsRes { StudentId = 5, CourseId = 5, Grade = 80 }
			};
			//context.StuCrsResults.AddRange(stuCrsResList);
			//context.SaveChanges();

			Console.WriteLine("All data inserted successfully!");
			#endregion


			//-----------------------------------------------------------------------

			#region Program
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
			#endregion

		}
	}
}
