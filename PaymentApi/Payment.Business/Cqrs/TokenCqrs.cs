using MediatR;
using Payment.Base.Response;
using Payment.Schema;

namespace Payment.Business.Cqrs;

public record CreateTokenCommand(TokenRequest Model) : IRequest<ApiResponse<TokenResponse>>;