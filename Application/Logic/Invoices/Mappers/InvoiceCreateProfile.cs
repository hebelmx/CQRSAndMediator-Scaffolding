using Application.Domain;
using Application.ViewModels;
using AutoMapper;

namespace Application.Logic.Invoices.Mappers
{
    public class InvoiceCreateProfile : Profile
    {
        public InvoiceCreateProfile()
        {
            CreateMap<Invoice, InvoiceCreateDto>();
        }
    }
}