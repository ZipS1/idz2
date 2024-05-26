using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class Staff
	{
        [HiddenInput(DisplayValue = false)]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Укажите детали сотрудника")]
        [Display(Name = "Детали сотрудника")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? StaffDetails { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
