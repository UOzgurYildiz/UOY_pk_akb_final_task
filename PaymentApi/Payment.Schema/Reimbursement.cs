using System.Text.Json.Serialization;
using Payment.Base.Schema;

namespace Payment.Schema;

public class ReimbursementRequest : BaseRequest
{
    public decimal Amount {get; set;}
}

public class ReimbursementResponse: BaseResponse
{
    public decimal Amount {get; set;}

    public virtual EmployeeResponse Employee {get; set;}
}