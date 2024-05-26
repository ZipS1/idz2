using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class ProcessOutcomes
	{
		[Key]
		public int ProcessOutcomeCode { get; set; }

		public string? ProcessOutcomeDescription { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
