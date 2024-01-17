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
    private readonly IMemoryCache memoryCache;
    private readonly IDistributedCache distributedCache;

    public ReimbursementController(IMediator mediator, IMemoryCache memoryCache, IDistributedCache distributedCache)
    {
        this.mediator = mediator;
        this.memoryCache = memoryCache;
        this.distributedCache = distributedCache;
    }

    [HttpPost("Reimbursement")]
    [Authorize(Roles = "employee"]
    public async Task<ApiResponse<ReimbursementResponse>> Reimbursement([FromBody] ReimbursementRequest request)
    {
        var operation = new CreateReimbursementCommand(request);
        var result = await mediator.Send(operation);

        return result;
    }
}
