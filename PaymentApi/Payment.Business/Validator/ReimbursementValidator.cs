using FluentValidation;
using Payment.Schema;

namespace Payment.Business.Validator;

public class CreateReimbursementValidator : AbstractValidator<ReimbursementRequest>
{
    public CreateReimbursementValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
        
    }
}