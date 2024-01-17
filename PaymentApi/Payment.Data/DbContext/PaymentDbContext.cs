using Microsoft.EntityFrameworkCore;
using Payment.Data.Entity;

namespace Payment.Data;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options): base(options)
    {
    
    }   
    
    // dbset 
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Reimbursement> Reimbursements { get; set; }
  
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new ReimbursementConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    
}