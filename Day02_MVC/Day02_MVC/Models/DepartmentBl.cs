using Day02_MVC.DbContexts;

namespace Day02_MVC.Models
{
	public class DepartmentBl
	{
		FacultyDbContext _db = new FacultyDbContext();
		public ICollection<Department> GetAll()
		{
			return _db.Departments.ToList();
		}

		public Department GetByID(int id)
		{
			return _db.Departments.FirstOrDefault(D => D.Id == id);
		}
		public void AddDept(Department department)
		{
			//save to local
			_db.AddAsync(department);
			//save to DB
			_db.SaveChanges();
		}
		public void DeleteDept(int id)
		{
			Department delDept = _db.Departments.FirstOrDefault(d => d.Id == id);
			//save to local
			_db.Departments.Remove(delDept);
			//save to DB
			_db.SaveChanges();
		}
	}
}
