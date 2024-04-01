using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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
		public int UniversityId { get; set; }
		[ForeignKey("UniversityId")]

		public Danhsach? Danhsach { get; set; }
	}
}
    
