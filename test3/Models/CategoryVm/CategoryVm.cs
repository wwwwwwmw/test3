using Microsoft.AspNetCore.Mvc.Rendering;
using mn.Models;
using test3.Models;

namespace test3.ViewModels // Thay đổi namespace thành QLBH.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public IEnumerable<SelectListItem> DanhsachList { get; set; }
    }
}