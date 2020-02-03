using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Helpers.MappingProfiles
{
    public class JobsProfile : Profile
    {
        public JobsProfile()
        {
            CreateMap<Job, JobDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    );
        }
    }
}
