using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class DocumentsProcesses
	{
        public int Id { get; set; }

		[ForeignKey("Documents")]
        [Required(ErrorMessage = "Укажите идентификатор процесса документа")]
        [Display(Name = "Идентификатор процесса документа")]
        public int DocumentId { get; set; }

		[ForeignKey("BusinessProcesses")]
        [Required(ErrorMessage = "Укажите идентификатор бизнес-процесса")]
        [Display(Name = "Идентификатор бизнес-процесса")]
        public int ProcessId { get; set; }

		[ForeignKey("ProcessOutcomes")]
        [Required(ErrorMessage = "Укажите идентификатор результата процесса")]
        [Display(Name = "Идентификатор результата процесса")]
        public int ProcessOutcomeCode { get; set; }

		[ForeignKey("ProcessStatus")]
        [Required(ErrorMessage = "Укажите идентификатор статуса документа")]
        [Display(Name = "Идентификатор статуса документа")]
        public int ProcessStatusCode { get; set; }

		public virtual Documents? Documents { get; set; }

		public virtual BusinessProcesses? BusinessProcesses { get; set; }

		public virtual ProcessOutcomes? ProcessOutcomes { get; set; }

		public virtual ProcessStatus? ProcessStatus { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
