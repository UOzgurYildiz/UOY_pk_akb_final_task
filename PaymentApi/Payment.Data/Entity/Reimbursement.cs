using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Base.Entity;

namespace Payment.Data.Entity;

[Table("Reimbursement", Schema = "dbo")]
public class Reimbursement : BaseEntity
{
    public decimal Amount {get; set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}
    public string Message {get; set;}

    public virtual Employee Employee {get; set;}
}

public class ReimbursementConfiguration : IEntityTypeConfiguration<Reimbursement>
{
    public void Configure(EntityTypeBuilder<Reimbursement> builder)
    {
        
    }
}