using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Payment.Base.Response;
using Payment.Business.Cqrs;
using Payment.Schema;

namespace PaymentApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReimbursementController : ControllerBase
{
    private readonly IMediator mediator;

    public ReimbursementController(IMediator mediator, IMemoryCache memoryCache, IDistributedCache distributedCache)
    {
        this.mediator = mediator;
    }

    [HttpPost("Reimbursement")]
    public async Task<ApiResponse<ReimbursementResponse>> Post([FromBody] ReimbursementRequest request)
    {
        var operation = new CreateReimbursementCommand(request);
        var result = await mediator.Send(operation);

        return result;
    }

    [HttpPut("Reimbursement")]
    public async Task<ApiResponse> Put([FromBody] ReimbursementRequest request)
    {
        var operation = new UpdateReimbursementCommand(request);
        var result = await mediator.Send(operation);

        return result;
    }

    [HttpDelete("Reimbursement")]
    public async Task<ApiResponse> Delete([FromBody] ReimbursementRequest request)
    {
        var operation = new UpdateReimbursementCommand(request);
        var result = await mediator.Send(operation);

        return result;
    }
}
