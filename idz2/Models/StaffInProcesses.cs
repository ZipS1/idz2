using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class StaffInProcesses
	{
        [Required(ErrorMessage = "Укажите идентификатор документа")]
        [Display(Name = "Идентификатор документа")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Укажите идентификатор бизнес-процесса")]
        [Display(Name = "Идентификатор бизнес-процесса")]
        public int ProcessId { get; set; }

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

		[ForeignKey("DocumentId, ProcessId")]
		public virtual DocumentsProcesses? DocumentsProcesses { get; set; }

		public virtual Staff? Staff { get; set; }

		public virtual RefStaffRoles? RefStaffRoles { get; set; }
	}
}
