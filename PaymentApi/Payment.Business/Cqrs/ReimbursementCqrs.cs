using MediatR;
using Payment.Base.Response;
using Payment.Schema;

namespace Payment.Business.Cqrs;

public record CreateReimbursementCommand(ReimbursementRequest Model) : IRequest<ApiResponse<ReimbursementResponse>>;
