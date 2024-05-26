using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class BusinessProcesses
	{
		[Key]
		public int ProcessId { get; set; }

		public int? NextProcessId { get; set; }

		public string? ProcessName { get; set; }

		public string? ProcessDescription { get; set; }

		public string? OtherDetails { get; set; }

		public virtual BusinessProcesses? NextProcess { get; set; }

		public virtual ICollection<BusinessProcesses>? Processes { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
