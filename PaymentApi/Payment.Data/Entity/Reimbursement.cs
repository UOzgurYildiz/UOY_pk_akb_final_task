using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Base.Entity;

namespace Payment.Data.Entity;

[Table("Reimbursement", Schema = "dbo")]
public class Reimbursement : BaseEntity
{
    public int ReferenceNumber {get; set;}
    public decimal Amount {get; set;}
    public string Category {get; set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}

    public virtual Employee Employee {get; set;}
}

public class ReimbursementConfiguration : IEntityTypeConfiguration<Reimbursement>
{
    public void Configure(EntityTypeBuilder<Reimbursement> builder)
    {
        builder.Property(x => x.ReferenceNumber).IsRequired(true);
        builder.Property(x => x.Amount).IsRequired(true);
        builder.Property(x => x.Category).IsRequired(true);
        builder.Property(x => x.Explanation).IsRequired(true);
        builder.Property(x => x.IsApproved).IsRequired(true);

        builder.HasIndex(x => x.ReferenceNumber);
        builder.HasKey(x => x.ReferenceNumber);
    }
}