using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mn.Data;
using mn.Models;

namespace mn.Controllers
{
	public class DanhsachController : Controller
	{
		private readonly ApplicationDbContext _db;
		public DanhsachController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Danhsach> objDanhsachList = _db.Danhsaches.ToList();
			return View(objDanhsachList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Danhsach obj)
		{
			if (ModelState.IsValid)
			{
				_db.Danhsaches.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Tạo Thành Công";
				return RedirectToAction("Index");
			}

			return View();
		}
	
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Danhsach? danhsachFromDb = _db.Danhsaches.Find(id);
			//Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
			if (danhsachFromDb == null)
			{
				return NotFound();
			}
			return View(danhsachFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Danhsach obj)
		{

			if (ModelState.IsValid)
			{
				_db.Danhsaches.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Cập Nhật Thành Công";

			}
			return RedirectToAction("Index");

		}
		public IActionResult Delete(int? id)

		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Danhsach? danhsachFromDb = _db.Danhsaches.Find(id);
			if (danhsachFromDb == null)
			{
				return NotFound();
			}
			return View(danhsachFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Danhsach? obj = _db.Danhsaches.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Danhsaches.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Xóa Thành Công";
			return RedirectToAction("Index");
		}

		public void PopulateCityDropdown()
		{
			List<Danhsach> danhsaches = _db.Danhsaches.ToList();
			ViewBag.DanhsachList = danhsaches
				.Select(danhsaches => new SelectListItem
				{
					Text = danhsaches.University, // Assuming Name is the property representing the name of the city in your City model
					Value = danhsaches.Id.ToString()
				}).ToList();
		}
	}
}