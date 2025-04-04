using Day02_MVC.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC.Models
{
	public class StudentBL
	{
		FacultyDbContext context = new FacultyDbContext();


		public List<Student> GetAll()
		{
			List<Student> studentsList = new List<Student>();
			studentsList = context.Students.ToList();
			return studentsList;
		}
		public Student GetById(int id)
		{
			return context.Students.FirstOrDefault(st => st.Id == id);
		}
		public void AddStudent(Student student)
		{
			//save to loacal
			context.Students.AddAsync(student);
			//save to DB
			context.SaveChanges();
		}
	}

}
