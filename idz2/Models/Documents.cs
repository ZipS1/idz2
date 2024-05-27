using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class Documents
	{
		[Key]
		public int DocumentId { get; set; }

        [ForeignKey("Authors")]
        [Required(ErrorMessage = "Укажите идентификатор автора")]
        [Display(Name = "Идентификатор автора")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Укажите имя документа")]
        [Display(Name = "Имя документа")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? DocumentName { get; set; }

        [Display(Name = "Описание документа")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? DocumentDescription { get; set; }

        [Display(Name = "Другие детали")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? OtherDetails { get; set; }

		public virtual Authors? Authors { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
