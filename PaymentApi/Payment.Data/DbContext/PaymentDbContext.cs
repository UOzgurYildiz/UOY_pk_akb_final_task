using Microsoft.EntityFrameworkCore;
using Payment.Data.Entity;

namespace Payment.Data;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> options) : DbContext(options)
{

    // dbset 
    public DbSet<Reimbursement> Reimbursements { get; set; }
  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ReimbursementConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    
}