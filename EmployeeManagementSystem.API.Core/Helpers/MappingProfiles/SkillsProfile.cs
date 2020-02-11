using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Helpers.MappingProfiles
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

            CreateMap<SkillForUpdateDto, Skill>();
                //.ForMember(
                //    dest => dest.Type,
                //    opt => opt.MapFrom(src => (SkillType)Enum.Parse(typeof(SkillType), src.Type)))
                // .ForMember(
                //    dest => dest.CreationDate,
                //    opt => opt.Ignore()
                //    );

            CreateMap<Skill, SkillForUpdateDto>();
        }
    }
}
