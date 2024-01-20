using Microsoft.EntityFrameworkCore;
using Payment.Data.Entity;

namespace Payment.Data;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> options) : DbContext(options)
{

    // dbset 
    public DbSet<Reimbursement> Reimbursements { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers {get; set;}
  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReimbursementConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

        
        base.OnModelCreating(modelBuilder);
    }
    
}