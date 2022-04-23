using Core.Constants;
using FluentValidation;

namespace Core.Utilities.Query
{
    public class PaginationParameters : IPaginationParameters
    {
        public int PageSize { get; set; } = 25;
        public int PageNumber { get; set; } = 1;
        
    }

    public class PaginationParametersValidator : AbstractValidator<PaginationParameters>
    {
        public PaginationParametersValidator()
        {
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(25).WithName(Names.PageSize);
            
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1).WithName(Names.PageNumber);
        }
    }
}