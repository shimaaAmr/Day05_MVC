using System.ComponentModel.DataAnnotations;
using Day02_MVC.Models;

namespace Day02_MVC.ViewModels
{
	public class StudWithDeptListViewModel
	{
		public string StudName { get; set; }
		public int Age { get; set; }
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }
		public List<Department> DeptList { get; set; }
	}
}
