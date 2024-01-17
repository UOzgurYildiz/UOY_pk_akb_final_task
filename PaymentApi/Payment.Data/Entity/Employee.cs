using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Base.Entity;

namespace Payment.Data.Entity;

[Table("Employee", Schema = "dbo")]
public class Employee : BaseEntity
{
    public string IDNumber {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime LastActivityDate {get; set;}

    public virtual List<Reimbursement> Reimbursements {get; set;}
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.IDNumber).IsRequired(true);
        builder.Property(x => x.FirstName).IsRequired(true);
        builder.Property(x => x.LastName).IsRequired(true);
        builder.Property(x => x.LastActivityDate).IsRequired(true);
    }
}