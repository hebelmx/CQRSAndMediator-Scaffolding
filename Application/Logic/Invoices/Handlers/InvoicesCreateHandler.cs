using System.Threading;
using System.Threading.Tasks;
using Application.Logic.Invoices.Commands;
using Application.Persistence;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Logic.Invoices.Handlers
{
    public class InvoicesCreateHandler : IRequestHandler<InvoicesCreateCommand, Response<InvoiceDto>>
    {
        private IMapper _mapper;
        private IApplicationDbContext _context;

        public Task<Response<InvoiceDto>> Handle(InvoicesCreateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}