using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace idz2.Models
{
	public class Documents
	{
		[Key]
		public int DocumentId { get; set; }

		public string? AuthorName { get; set; }

		public string? DocumentName { get; set; }

		public string? DocumentDescription { get; set; }

		public string? OtherDetails { get; set; }

		public virtual Authors? Authors { get; set; }

		public virtual ICollection<DocumentsProcesses>? DocumentsProcesses { get; set; }
	}
}
