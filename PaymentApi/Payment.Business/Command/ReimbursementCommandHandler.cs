using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Base.Response;
using Payment.Business.Cqrs;
using Payment.Data;
using Payment.Data.Entity;
using Payment.Schema;

namespace Payment.Business.Command;

public class ReimbursementCommandHAndler :
    IRequestHandler<CreateReimbursementCommand, ApiResponse<ReimbursementResponse>>
     //IRequestHandler<UpdateReimbursementHandler, ApiResponse>,
     //IRequestHandler<DeleteReimbursementHandler, ApiResponse>

    {
        private readonly PaymentDbContext dbContext;
        private readonly IMapper mapper;
        
        public ReimbursementCommandHAndler(PaymentDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ApiResponse<ReimbursementResponse>> Handle(CreateReimbursementCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ReimbursementRequest, Reimbursement>(request.Model);

            var entityResult = await dbContext.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            var mapped = mapper.Map<Reimbursement, ReimbursementResponse>(entityResult.Entity);
            return new ApiResponse<ReimbursementResponse>(mapped);
        }
    }