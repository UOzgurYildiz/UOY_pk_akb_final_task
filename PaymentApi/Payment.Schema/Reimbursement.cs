using System.Text.Json.Serialization;
using Microsoft.AspNetCore.SignalR;
using Payment.Base.Schema;

namespace Payment.Schema;

public class ReimbursementRequest : BaseRequest
{
    public int ReferenceNumber {get; set;}
    public decimal Amount {get; set;}
    public string Category {get;set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}
}

public class ReimbursementResponse: BaseResponse
{
    public int ReferenceNumber {get; set;}
    public decimal Amount {get; set;}
    public string Category {get; set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}

   // public virtual EmployeeResponse Employee {get; set;}
}