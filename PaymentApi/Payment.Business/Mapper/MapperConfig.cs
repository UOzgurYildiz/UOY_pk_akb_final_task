using AutoMapper;
using Payment.Business.Command;
using Payment.Data.Entity;
using Payment.Schema;

namespace Payment.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<ReimbursementRequest, Reimbursement>();
        CreateMap<Reimbursement, ReimbursementResponse>();
    }
}