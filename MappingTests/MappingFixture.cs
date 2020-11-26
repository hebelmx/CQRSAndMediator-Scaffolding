using System;
using System.Collections.Generic;
using System.Text;
using Application;
using Application.Mappings;
using AutoMapper;

namespace MappingTests
{
    public abstract class MappingFixture
    {
        protected IMapper Mapper { get; set; }

        protected IConfigurationProvider Configuration { get; set; }

        public MappingFixture()
        {
            Configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = Configuration.CreateMapper();
        }
    }
}