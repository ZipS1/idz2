using idz2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace idz2.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Authors> Authors { get; set; }
		public DbSet<Documents> Documents { get; set; }
		public DbSet<BusinessProcesses> BusinessProcesses { get; set; }
		public DbSet<DocumentsProcesses> DocumentsProcesses { get; set; }
		public DbSet<ProcessStatus> ProcessStatus { get; set; }
		public DbSet<ProcessOutcomes> ProcessOutcomes { get; set; }
		public DbSet<StaffInProcesses> StaffInProcesses { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<RefStaffRoles> RefStaffRoles { get; set; }
	}
}
