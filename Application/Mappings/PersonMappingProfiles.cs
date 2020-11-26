using System;
using Application.Domain;
using Application.ViewModels;
using AutoMapper;

namespace Application.Mappings
{
    public class PersonMappingProfiles : IMapFrom<Person>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonDto, Person>()
                .ForMember(p => p.AddressId, op => op.Ignore())
                .ForMember(p => p.Address, op => op.Ignore())
                .ForMember(p => p.JobId, op => op.Ignore())
                .ForMember(p => p.Job, op => op.Ignore());
            profile.CreateMap<Person, PersonDto>()
                .ForMember(p => p.HouseName, op => op.Ignore())
                .ForMember(p => p.JobDto, op => op.Ignore())
                .ForMember(p => p.Jobs, op => op.Ignore());

            profile.CreateMap<string, DateTime>().ConvertUsing(new StringToDateTimeConverter());
            profile.CreateMap<DateTime, string>().ConvertUsing(new DateTimeToStringConverter());
        }

        private class StringToDateTimeConverter : ITypeConverter<string, DateTime>
        {
            public DateTime Convert(string source, DateTime destination, ResolutionContext context)
            {
                return System.Convert.ToDateTime(source);
            }
        }

        private class DateTimeToStringConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString("dd/MMMM/yyyy");
            }
        }
    }
}