using Application.Logic.Invoices.Commands;
using FluentValidation;

namespace Application.Logic.Invoices.Validators
{
    public class InvoiceCreateValidator : AbstractValidator<InvoicesCreateCommand>
    {
        public InvoiceCreateValidator()
        {
            RuleFor(d => d.Dto).NotNull();
        }
    }
}