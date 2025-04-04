using Day02_MVC.DbContexts;
using Day02_MVC.Models;
using Day02_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Day02_MVC.Controllers
{
	public class StudentController : Controller
	{
		StudentBL studentBL = new StudentBL();
		DepartmentBl departmentBl = new DepartmentBl();
		FacultyDbContext context = new FacultyDbContext();
		public IActionResult Details(int id)
		{
			Student studnetModel = studentBL.GetById(id);
			return View("Details", studnetModel);
		}
		public IActionResult Add()
		{
			ViewData["DeptList"] = new SelectList(departmentBl.GetAll(), "Id", "Name");
			return View("Add");

		}


		public IActionResult SaveAdd(Student stuFromReq)
		{

			if (ModelState.IsValid == true)
			{
				// Add to local/cache
				context.Students.Add(stuFromReq);
				// save to Database
				context.SaveChanges();
				//if saved
				return RedirectToAction(nameof(ShowAll));
			}

			ViewData["DeptList"] = new SelectList(departmentBl.GetAll(), "Id", "Name");
			return View("Add", stuFromReq);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var student = await context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", student.DepartmentId);

			return View("Edit", student);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SaveEdit(int id, Student student)
		{
			if (id != student.Id)
			{
				return NotFound();
			}

			//if (student.Name != null)
			if (ModelState.IsValid == true)
			{

				context.Update(student);
				await context.SaveChangesAsync();
				return RedirectToAction(nameof(ShowAll));
			}
			ViewBag.Departments = new SelectList(context.Departments, "Id", "Name", student.DepartmentId);
			return View("Edit", student);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var student = await context.Students.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);

			if (student == null)
			{
				return NotFound();
			}

			return View("Delete", student);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var student = await context.Students.FindAsync(id);

			if (student != null)
			{
				var relatedRecords = context.StuCrsResults.Where(r => r.StudentId == id);
				context.StuCrsResults.RemoveRange(relatedRecords);
				await context.SaveChangesAsync();
				context.Students.Remove(student);
				await context.SaveChangesAsync();
			}

			return RedirectToAction(nameof(ShowAll));
		}

		public async Task<IActionResult> ShowAll(string search, int? departmentId, int page = 1)
		{
			int pageSize = 10;

			var students = context.Students.Include(s => s.Department).AsQueryable();

			//search by name
			if (!string.IsNullOrEmpty(search))
			{
				students = students.Where(s => s.Name.Contains(search));
			}


			if (departmentId.HasValue && departmentId > 0)
			{
				students = students.Where(s => s.DepartmentId == departmentId);
			}


			int totalStudents = await students.CountAsync();
			var paginatedStudents = await students
										.Skip((page - 1) * pageSize)
										.Take(pageSize)
										.ToListAsync();
			ViewBag.Departments = new SelectList(context.Departments, "Id", "Name");
			ViewBag.Search = search;
			ViewBag.DepartmentId = departmentId;
			ViewBag.Page = page;
			ViewBag.TotalPages = (int)Math.Ceiling((double)totalStudents / pageSize);

			return View(paginatedStudents);
		}
	}
}
