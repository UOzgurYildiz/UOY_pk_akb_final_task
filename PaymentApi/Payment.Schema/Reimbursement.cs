using Payment.Base.Schema;

namespace Payment.Schema;

public class ReimbursementRequest : BaseRequest
{
    public string EmployeeID {get; set;}
    public string EmployeeName {get; set;}
    public int ReferenceNumber {get; set;}
    public decimal Amount {get; set;}
    public string Category {get;set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}
}

public class ReimbursementResponse: BaseResponse
{
    public string EmployeeID {get; set;}
    public string EmployeeName {get; set;}
    public int ReferenceNumber {get; set;}
    public decimal Amount {get; set;}
    public string Category {get; set;}
    public string Explanation {get; set;}
    public bool IsApproved {get; set;}
}