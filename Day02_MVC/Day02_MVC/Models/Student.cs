using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day02_MVC.Models
{
	public class Student
	{

		public int Id { get; set; }
		[Required(ErrorMessage = "Required Field")]
		[MaxLength(30, ErrorMessage = "Less than 30")]
		[MinLength(3, ErrorMessage = "More than 3")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "only contains letters and spaces")]
		[Display(Name = "Full Name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Required Field")]
		[Range(18, 100, ErrorMessage = "Age must be 18 or older")]
		public int Age { get; set; }
		//forign key
		[ForeignKey("Department")]
		[Required(ErrorMessage = "Department is required")]
		[Range(1, int.MaxValue, ErrorMessage = "Please select a department")]
		[Display(Name = "Department")]
		public int DepartmentId { get; set; }

		//Navigation Property
		public Department? Department { get; set; }
		public List<StuCrsRes>? StuCrsResults { get; set; }
	}
}
