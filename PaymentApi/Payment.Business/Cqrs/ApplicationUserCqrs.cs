using MediatR;
using Payment.Base.Response;
using Payment.Schema;

namespace Payment.Business.Cqrs;


public record CreateApplicationUserCommand(ApplicationUserRequest Model) : IRequest<ApiResponse<ApplicationUserResponse>>;
public record UpdateApplicationUserCommand(int Id,ApplicationUserRequest Model) : IRequest<ApiResponse>;
public record DeleteApplicationUserCommand(int Id) : IRequest<ApiResponse>;

public record GetAllApplicationUserQuery() : IRequest<ApiResponse<List<ApplicationUserResponse>>>;
public record GetApplicationUserByIdQuery(int Id) : IRequest<ApiResponse<ApplicationUserResponse>>;
public record GetApplicationUserByParameterQuery(string FirstName,string LastName,string UserName) : IRequest<ApiResponse<List<ApplicationUserResponse>>>;