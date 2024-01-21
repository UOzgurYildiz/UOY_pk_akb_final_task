using MediatR;
using Payment.Base.Response;
using Payment.Schema;

namespace Payment.Business.Cqrs;

public record CreateReimbursementCommand(ReimbursementRequest Model) : IRequest<ApiResponse<ReimbursementResponse>>;
public record UpdateReimbursementCommand(ReimbursementRequest Model) : IRequest<ApiResponse>;
public record DeleteReimbursementCommand(int ReferenceNumber) : IRequest<ApiResponse>;

public record GetAllReimbursementQuery() : IRequest<ApiResponse<List<ReimbursementResponse>>>;
public record GetReimbursementByIdQuery(int Id) : IRequest<ApiResponse<ReimbursementResponse>>;
public record GetReimbursementByParameterQuery(string EmployeeName,int? ReferenceNumber,string Category) : IRequest<ApiResponse<List<ReimbursementResponse>>>;