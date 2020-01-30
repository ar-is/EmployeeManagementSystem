using AutoMapper;
using Employee_Management_System.Core.Dtos.Skills;
using Employee_Management_System.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee_Management_System.Core.Helpers.MappingProfiles
{
    public class SkillsProfile : Profile
    {
        public SkillsProfile()
        {
            CreateMap<Skill, SkillDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    );
        }
    }
}
