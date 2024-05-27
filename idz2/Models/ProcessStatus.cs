using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class ProcessStatus
	{
		[Key]
		public int ProcessStatusCode { get; set; }

        [Required(ErrorMessage = "Укажите описание статуса процесса")]
        [Display(Name = "Описание статуса процесса")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? ProcessStatusDescription { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
