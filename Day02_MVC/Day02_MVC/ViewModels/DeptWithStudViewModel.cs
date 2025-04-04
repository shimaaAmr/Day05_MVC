using Day02_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day02_MVC.ViewModels
{
	public class DeptWithStudViewModel
	{
		public string DeptName { get; set; }
		public List<SelectListItem> Students { get; set; }
		public string DeptState { get; set; }
	}
}
