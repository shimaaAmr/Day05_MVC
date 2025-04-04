using System.ComponentModel.DataAnnotations;

namespace Day02_MVC.Models
{
	public class Department
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Required Field")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Required Field")]
		[MaxLength(30, ErrorMessage = "Less than 30")]
		[MinLength(3, ErrorMessage = "More than 3")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "only contains letters and spaces")]
		[Display(Name = "Manager Name")]
		public string? ManagerName { get; set; }

		//Navifation property
		public List<Teacher>? Teachers { get; set; }
		public List<Course>? Courses { get; set; }
		public List<Student>? Students { get; set; }

	}
}
