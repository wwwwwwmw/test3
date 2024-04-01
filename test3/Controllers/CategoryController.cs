using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mn.Data;
using mn.Models;

namespace mn.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		private readonly ILogger<CategoryController> _logger;

		public CategoryController(ApplicationDbContext db, ILogger<CategoryController> logger)
		{
			_db = db;
			_logger = logger;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.Include(c => c.Danhsach).ToList();
			return View(objCategoryList);
		}
		public IActionResult Create()
		{
			PopulateCityDropdown();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Category obj)
		{
			if (ModelState.IsValid)
			{

				_db.Categories.Add(obj);
				await _db.SaveChangesAsync();
				TempData["success"] = "Tạo Thành Công";
				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.";
			PopulateCityDropdown();
			return View(obj);
		}


		//public IActionResult Edit(int? id)

		//{
		//    if (id == null || id == 0)
		//    {
		//        return NotFound();
		//    }
		//    Category? categoryFromDb = _db.Categories.Find(id);
		//    //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
		//    //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
		//    if (categoryFromDb == null)
		//    {
		//        return NotFound();
		//    }
		//    PopulateCityDropdown();
		//    return View(categoryFromDb);
		//}
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Edit(Category obj)
		//{
		//    if (ModelState.IsValid)
		//    {

		//        _db.Categories.Add(obj);
		//        await _db.SaveChangesAsync();
		//        TempData["success"] = "Tạo Thành Công";
		//        return RedirectToAction(nameof(Index));
		//    }

		//    TempData["error"] = "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.";
		//    PopulateCityDropdown();
		//    return View(obj);
		//}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Category categoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}// Lấy danh sách thành phố
			PopulateCityDropdown();

			// Truyền dữ liệu danhsachFromDb vào view để hiển thị và chỉnh sửa
			return View(categoryFromDb);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_db.Categories.Update(obj);
					await _db.SaveChangesAsync();
					TempData["success"] = "Cập Nhật Thành Công";
					return RedirectToAction(nameof(Index));
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error occurred while updating category.");
					TempData["error"] = "Đã xảy ra lỗi khi cập nhật dữ liệu. Vui lòng thử lại.";
				}
			}

			// Nếu ModelState không hợp lệ, cần phải lấy lại danh sách thành phố
			PopulateCityDropdown();
			return View(obj);
		}

		private void PopulateCityDropdown()
		{
			List<Danhsach> danhsaches = _db.Danhsaches.ToList();
			ViewBag.DanhsachList = danhsaches
				.Select(danhsach => new SelectListItem
				{
					Text = danhsach.University,
					Value = danhsach.Id.ToString()
				}).ToList();
		}
		public IActionResult Delete(int? id)

		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Xóa Thành Công";
			return RedirectToAction("Index");
		}

	}
}