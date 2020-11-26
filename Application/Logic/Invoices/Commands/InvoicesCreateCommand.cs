using System;
using Application.Persistency;
using Application.ViewModels;
using MediatR;

namespace Application.Logic.Invoices.Commands
{
    public class InvoicesCreateCommand : IRequest<Response<InvoiceDto>>
    {
        public InvoiceCreateDto Dto
        {
            get;
        }

        public InvoicesCreateCommand(InvoiceCreateDto dto)
        {
            Dto = dto ?? throw new ArgumentNullException($"dto cant be null {nameof(dto)}");
        }
    }
}