using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace idz2.Models
{
	public class Authors
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string? AuthorName { get; set; }

		public string? OtherDetails { get; set; }

		public virtual ICollection<Documents>? Documents { get; set; }
	}
}
