using AutoMapper;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Base.Response;
using Payment.Business.Cqrs;
using Payment.Data;
using Payment.Data.Entity;
using Payment.Schema;

namespace Payment.Business.Query;

public class ReimbursementQueryHandler :
    IRequestHandler<GetAllReimbursementQuery, ApiResponse<List<ReimbursementResponse>>>,
    IRequestHandler<GetReimbursementByIdQuery, ApiResponse<ReimbursementResponse>>,
    IRequestHandler<GetReimbursementByParameterQuery, ApiResponse<List<ReimbursementResponse>>>
{
    private readonly PaymentDbContext dbContext;
    private readonly IMapper mapper;

    public ReimbursementQueryHandler(PaymentDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<ReimbursementResponse>>> Handle(GetAllReimbursementQuery request,
        CancellationToken cancellationToken)
    {
        var list = await dbContext.Set<Reimbursement>().ToListAsync();
        
        var mappedList = mapper.Map<List<Reimbursement>, List<ReimbursementResponse>>(list);
         return new ApiResponse<List<ReimbursementResponse>>(mappedList);
    }

    public async Task<ApiResponse<ReimbursementResponse>> Handle(GetReimbursementByIdQuery request,
        CancellationToken cancellationToken)
    {
        var entity =  await dbContext.Set<Reimbursement>()
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            return new ApiResponse<ReimbursementResponse>("Record not found");
        }
        
        var mapped = mapper.Map<Reimbursement, ReimbursementResponse>(entity);
        return new ApiResponse<ReimbursementResponse>(mapped);
    }

    public async Task<ApiResponse<List<ReimbursementResponse>>> Handle(GetReimbursementByParameterQuery request,
        CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Reimbursement>(true);
      
        var list =  await dbContext.Set<Reimbursement>()
            .Where(predicate).ToListAsync(cancellationToken);
        
        var mappedList = mapper.Map<List<Reimbursement>, List<ReimbursementResponse>>(list);
        return new ApiResponse<List<ReimbursementResponse>>(mappedList);
    }
}