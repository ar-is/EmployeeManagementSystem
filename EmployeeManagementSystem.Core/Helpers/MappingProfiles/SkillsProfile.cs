using AutoMapper;
using EmployeeManagementSystem.Core.Dtos.Skills;
using EmployeeManagementSystem.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EmployeeManagementSystem.Core.Helpers.MappingProfiles
{
    public class SkillsProfile : Profile
    {
        public SkillsProfile()
        {
            CreateMap<Skill, SkillDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    )
                .ForMember(
                    dest => dest.CreationDate,
                    opt => opt.MapFrom(src => string.Format("{0:G}", src.CreationDate.LocalDateTime, new CultureInfo("el-GR")))
                    );

            CreateMap<Skill, SkillFullDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    );
        }
    }
}
