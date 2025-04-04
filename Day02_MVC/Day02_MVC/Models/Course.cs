using System.ComponentModel.DataAnnotations.Schema;

namespace Day02_MVC.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public float Degree { get; set; }
		public float MinDegree { get; set; }
		//forign Key
		[ForeignKey("Department")]
		public int DepartmentId { get; set; }

		//Navigation Property
		public Department Department { get; set; }
		public List<StuCrsRes> StuCrsResults { get; set; }
		public List<Teacher> Teachers { get; set; }

	}
}
