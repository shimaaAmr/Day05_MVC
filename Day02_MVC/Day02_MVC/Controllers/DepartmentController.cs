using Day02_MVC.DbContexts;
using Day02_MVC.Models;
using Day02_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC.Controllers
{
	public class DepartmentController : Controller
	{
		DepartmentBl departmentBl = new DepartmentBl();
		FacultyDbContext _context = new FacultyDbContext();
		public IActionResult Index()
		{
			return View("Index");
		}
		public IActionResult ShowAll()
		{
			IEnumerable<Department> deptListModel = new List<Department>();
			deptListModel = departmentBl.GetAll();
			return View("ShowAll", deptListModel);
		}
		public IActionResult Details(int id)
		{
			DepartmentBl deptBl = new DepartmentBl();
			Department deptModel = deptBl.GetByID(id);
			return View("Details", deptModel);
		}
		[HttpGet]

		public IActionResult Add()
		{
			return View("Add");
		}
		[HttpPost]
		public IActionResult SaveAdd(Department deptFromReq)
		{
			if (deptFromReq.Name != null)
			{
				departmentBl.AddDept(deptFromReq);
				return RedirectToAction(nameof(ShowAll));
			}
			return View("Add", deptFromReq);
		}
		//public IActionResult Delete(int id)
		//{
		//	departmentBl.DeleteDept(id);
		//	return RedirectToAction(nameof(Delete));
		//}
		public IActionResult Delete(int id)
		{
			var department = _context.Departments.Include(d => d.Students).FirstOrDefault(d => d.Id == id);

			if (department == null)
				return NotFound();

			if (department.Students.Any())
			{
				TempData["Error"] = "Cannot delete department because it has students.";
				return RedirectToAction("ShowAll");
			}

			return View("Warning", id); // عرض صفحة التحذير مع تمرير الـ id
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int id)
		{
			var department = _context.Departments.Find(id);
			if (department == null)
				return NotFound();

			_context.Departments.Remove(department);
			_context.SaveChanges();

			return RedirectToAction("ShowAll");
		}

		public IActionResult DetailsVM(int id)
		{


			Department department = _context.Departments.Include(d => d.Students)
											 .FirstOrDefault(d => d.Id == id);

			if (department == null)
				return NotFound();

			var students = department.Students
									 .Where(s => s.Age > 25)
									 .Select(s => new SelectListItem
									 {
										 Text = s.Name,
										 Value = s.Id.ToString()
									 }).ToList();

			string departmentState = department.Students.Count() > 50 ? "Main" : "Branch";

			var viewModel = new DeptWithStudViewModel
			{
				DeptName = department.Name,
				Students = students,
				DeptState = departmentState
			};

			return View("DetailsVM", viewModel);
		}
		public async Task<IActionResult> Edit(int id)
		{
			var department = await _context.Departments.FindAsync(id);
			if (department == null)
			{
				return NotFound();
			}
			return View("Edit", department);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveEdit(int id, Department department)
		{
			if (id != department.Id)
			{
				return NotFound();
			}

			//if (student.Name != null)
			if (ModelState.IsValid == true)
			{

				_context.Update(department);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(ShowAll));
			}
			return View("Edit", department);
		}






	}
}

