using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace mn.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Tên sinh viên")]
        public required string Name { get; set; }
        [DisplayName("Số Điện Thoại")]
        public required int PhoneNumber { get; set; }
        [DisplayName("Tên trường")]
        public required string University { get; set; }

    }
}