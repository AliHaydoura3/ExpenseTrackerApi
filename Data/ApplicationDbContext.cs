using ExpenseTrackerApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(user =>
            {
                user.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
                user.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            });

            builder.Entity<Expense>(expense =>
            {
                expense.HasKey(e => e.Id);

                expense.Property(e => e.Amount).IsRequired().HasColumnType("decimal(18,2)");
                expense.Property(e => e.Description).IsRequired().HasMaxLength(255);
                expense.Property(e => e.Category).IsRequired().HasMaxLength(100);
                expense.Property(e => e.UserId).IsRequired();

                expense
                    .HasOne(e => e.User)
                    .WithMany(u => u.Expenses)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
