using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class ProcessOutcomes
	{
		[Key]
		public int ProcessOutcomeCode { get; set; }

        [Required(ErrorMessage = "Укажите описание результата процесса")]
        [Display(Name = "Описание результата процесса")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? ProcessOutcomeDescription { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
