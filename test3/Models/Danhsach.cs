using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public class Danhsach
{
	[Key]
	public int Id { get; set; }
	[Required]
	[MaxLength(30)]
	[DisplayName("Tên trường")]
	public required string University { get; set; }

}
