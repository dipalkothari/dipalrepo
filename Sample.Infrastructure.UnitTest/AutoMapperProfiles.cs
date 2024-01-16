using AutoMapper;
using Sample.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.UnitTest
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Employee, EmployeeDTO>().ReverseMap();
            }
        }
    }
}
