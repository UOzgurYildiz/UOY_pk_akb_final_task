using System.IO.Compression;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payment.Base.Response;
using Payment.Business.Cqrs;
using Payment.Data;
using Payment.Data.Entity;
using Payment.Schema;

namespace Payment.Business.Command;

public class ReimbursementCommandHandler :
    IRequestHandler<CreateReimbursementCommand, ApiResponse<ReimbursementResponse>>,
    IRequestHandler<UpdateReimbursementCommand,ApiResponse>,
    IRequestHandler<DeleteReimbursementCommand,ApiResponse>

    {
        private readonly PaymentDbContext dbContext;
        private readonly IMapper mapper;
        
        public ReimbursementCommandHandler(PaymentDbContext dbContext, IMapper mapper)
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

        public async Task<ApiResponse> Handle(UpdateReimbursementCommand request, CancellationToken cancellationToken)
        {
            var fromdb = await dbContext.Set<Reimbursement>().Where( x=> x.ReferenceNumber == request.Model.ReferenceNumber)
                .FirstOrDefaultAsync(cancellationToken);
                if(fromdb == null)
                {
                    return new ApiResponse("Record not found");
                }

                fromdb.IsApproved = request.Model.IsApproved;

                await dbContext.SaveChangesAsync(cancellationToken);
                return new ApiResponse();
        }

        public async Task<ApiResponse> Handle(DeleteReimbursementCommand request, CancellationToken cancellationToken)
        {
            var fromdb = await dbContext.Set<Reimbursement>().Where(x=> x.ReferenceNumber == request.ReferenceNumber)
                .FirstOrDefaultAsync(cancellationToken);

            if(fromdb == null)
            {
                return new ApiResponse("Record not found");
            }

            fromdb.IsActive = false;

            await dbContext.SaveChangesAsync(cancellationToken);
            return new ApiResponse();
        }
    }