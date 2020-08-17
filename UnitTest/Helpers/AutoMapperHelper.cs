using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TestCreatorWebApp.Mapping;

namespace UnitTests.Helpers
{
    class AutoMapperHelper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    // Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new TestCreatorWebApp.Mapping.Mapper());
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                return _mapper;
            }
        }
    }
}
