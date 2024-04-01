using Microsoft.AspNetCore.Mvc;
using mn.Data;
using mn.Models;

namespace mn.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() 
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Category obj)
            {
                if (obj.Name == obj.PhoneNumber.ToString())
                {
                    ModelState.AddModelError("name", "Tên và Số Điện Thoại không trùng nhau");
                }
                if (ModelState.IsValid)
                {
                    try
                    {
                        _db.Categories.Add(obj);
                        _db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                        TempData["success"] = "Tạo Thành Công";
                        return RedirectToAction("Index");
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi
                        Console.WriteLine(ex);
                        TempData["error"] = "Đã xảy ra lỗi khi lưu dữ liệu. Vui lòng thử lại.";
                    }
                }

                // Truyền lại đối tượng Category khi ModelState không hợp lệ
                return View(obj);
            }
        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.Find(id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.PhoneNumber.ToString())
            {
                ModelState.AddModelError("name", "Tên và Số Điện Thoại không trùng nhau");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cập Nhật Thành Công";
                return RedirectToAction("Index");
            }

            return View();
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
    

