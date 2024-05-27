using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class RefStaffRoles
	{
		[Key]
        public int StaffRoleCode { get; set; }

        [Required(ErrorMessage = "Укажите описание роли сотрудника")]
        [Display(Name = "Описание роли сотрудника")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? StaffRoleDescription { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
