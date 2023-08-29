using System;
using FluentValidation;

namespace Application.Feature.Brands.Commands.Create
{
	public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
	{
		public CreateBrandCommandValidator()
		{
			RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
		}
	}
}

