using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class ProcessStatus
	{
		[Key]
		public int ProcessStatusCode { get; set; }

		public string? ProcessStatusDescription { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
