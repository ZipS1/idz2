using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class StaffInProcesses
	{
		public int DocumentId { get; set; }

		public int ProcessId { get; set; }

		[ForeignKey("Staff")]
		public int StaffId { get; set; }

		[ForeignKey("RefStaffRoles")]
		public int? StaffRoleCode { get; set; }

		public DateTime? DateFrom { get; set; }

		public DateTime? DateTo { get; set; }

		public string? OtherDetails { get; set; }

		[ForeignKey("DocumentId, ProcessId")]
		public virtual DocumentsProcesses? DocumentsProcesses { get; set; }

		public virtual Staff? Staff { get; set; }

		public virtual RefStaffRoles? RefStaffRoles { get; set; }
	}
}
