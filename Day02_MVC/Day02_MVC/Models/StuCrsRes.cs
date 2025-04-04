namespace Day02_MVC.Models
{
	public class StuCrsRes
	{

		public float Grade { get; set; }
		// Composite PK 
		public int CourseId { get; set; }
		public int StudentId { get; set; }

		// Navigation property
		public Student Student { get; set; }
		public Course Course { get; set; }


	}
}
