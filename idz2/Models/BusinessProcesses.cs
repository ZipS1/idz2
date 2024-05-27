using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class BusinessProcesses
	{
        [Key]
        public int ProcessId { get; set; }

        [Required(ErrorMessage = "Укажите имя процесса")]
        [Display(Name = "Имя процесса")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? ProcessName { get; set; }

        [Display(Name = "Описание процесса")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? ProcessDescription { get; set; }

        [Display(Name = "Другие детали")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string? OtherDetails { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
