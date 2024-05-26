using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class DocumentsProcesses
	{
		[ForeignKey("Documents")]
		public int DocumentId { get; set; }

		[ForeignKey("BusinessProcesses")]
		public int ProcessId { get; set; }

		[ForeignKey("ProcessOutcomes")]
		public int ProcessOutcomeCode { get; set; }

		[ForeignKey("ProcessStatus")]
		public int ProcessStatusCode { get; set; }

		public virtual Documents? Documents { get; set; }

		public virtual BusinessProcesses? BusinessProcesses { get; set; }

		public virtual ProcessOutcomes? ProcessOutcomes { get; set; }

		public virtual ProcessStatus? ProcessStatus { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
