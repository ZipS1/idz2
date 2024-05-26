using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class RefStaffRoles
	{
		[Key]
		public int StaffRoleCode { get; set; }

		public string? StaffRoleDescription { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
