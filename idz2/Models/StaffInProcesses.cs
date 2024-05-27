using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class StaffInProcesses
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите идентификатор процесса документа")]
        [Display(Name = "Идентификатор процесса документа")]
        public int DocumentsProcessesId { get; set; }

		[ForeignKey("Staff")]
        [Required(ErrorMessage = "Укажите идентификатор сотрудника")]
        [Display(Name = "Идентификатор сотрудника")]
        public int StaffId { get; set; }

		[ForeignKey("RefStaffRoles")]
        [Required(ErrorMessage = "Укажите роль сотрудника")]
        [Display(Name = "Роль сотрудника")]
        public int? StaffRoleCode { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime? DateTo { get; set; }

        [Display(Name = "Другие детали")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 200 символов")]
        public string? OtherDetails { get; set; }

		public virtual DocumentsProcesses? DocumentsProcesses { get; set; }

		public virtual Staff? Staff { get; set; }

		public virtual RefStaffRoles? RefStaffRoles { get; set; }
	}
}
