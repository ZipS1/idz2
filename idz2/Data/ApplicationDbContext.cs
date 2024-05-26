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
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Documents>()
				.HasOne(e => e.Authors)
				.WithMany(e => e.Documents)
				.HasForeignKey(e => e.AuthorName);

			builder.Entity<BusinessProcesses>()
				.HasOne(e => e.NextProcess)
				.WithMany(e => e.Processes)
				.HasForeignKey(e => e.NextProcessId);

			builder.Entity<DocumentsProcesses>()
				.HasKey(e => new { e.DocumentId, e.ProcessId });
		}

		public DbSet<Authors> Authors { get; set; }
		public DbSet<Documents> Documents { get; set; }
		public DbSet<BusinessProcesses> BusinessProcesses { get; set; }
		public DbSet<DocumentsProcesses> DocumentsProcesses { get; set; }
		public DbSet<ProcessStatus> ProcessStatus { get; set; }
		public DbSet<ProcessOutcomes> ProcessOutcomes { get; set; }
	}
}
