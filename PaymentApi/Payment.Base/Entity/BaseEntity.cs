namespace Payment.Base.Entity;

public abstract class BaseEntity 
{
    public int Id {get; set;}
    public int InsertUserId {get; set;}
    public DateTime InsertDate {get; set;}
    public int? UpdateUserId {get; set;}
    public DateTime? UpdateDate {get; set;}
    public bool IsActive {get; set;}
}