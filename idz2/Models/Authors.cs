using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace idz2.Models
{
	public class Authors
	{
		[Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите имя автора")]
        [Display(Name = "Имя автора")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? AuthorName { get; set; }

        [Display(Name = "Другие детали")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? OtherDetails { get; set; }

		public virtual ICollection<Documents>? Documents { get; set; }
	}
}
