namespace idz2.Models
{
	public class Staff
	{
		public int StaffId { get; set; }

		public string? StaffDetails { get; set; }

		public virtual ICollection<StaffInProcesses>? StaffInProcesses { get; set; }
	}
}
