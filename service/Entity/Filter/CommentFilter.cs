using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{
    public class CommentFilter : FilterParameters
    {
        public string Content { get; set; }

        public int? AuthorId { get; set; }
        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(Comment));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (AuthorId is not null)
            {
                filter.Add(String.Format("AuthorId == {0}", AuthorId));
            }

            if (Content is not null)
            {
                filter.Add(String.Format("Content.Contains(\"{0}\")", Content));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class CommentFilterValidator : AbstractValidator<CommentFilter>
    {
        public CommentFilterValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThanOrEqualTo(1).WithName(Names.Author);

            RuleFor(x => x.Content).Length(1, 16).WithName(Names.Content);
        }
    }

}