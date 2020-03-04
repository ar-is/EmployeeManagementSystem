using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.Employees;
using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Helpers.MappingProfiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    )
                //.ForMember(
                //    dest => dest.HiringDate,
                //    opt => opt.MapFrom(src => string.Format("{0:G}", src.HiringDate.LocalDateTime, new CultureInfo("el-GR")))
                //    )
                .ForMember(
                    dest => dest.LatestSkillsetUpdate,
                    opt => opt.MapFrom(src => string.Format("{0:G}", src.LatestSkillsetUpdate.LocalDateTime, new CultureInfo("el-GR")))
                    )
                .ForMember(
                    dest => dest.LatestUpdate,
                    opt => opt.MapFrom(src => string.Format("{0:G}", src.LatestUpdate.LocalDateTime, new CultureInfo("el-GR")))
                    )
                .ForMember(
                    dest => dest.Job,
                    opt => opt.MapFrom(src => src.Job.FullTitle)
                    )
                .ForMember(
                    dest => dest.Department,
                    opt => opt.MapFrom(src => src.Job.Department.Name)
                    );

            CreateMap<Employee, EmployeeFullDto>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Guid)
                    )
                .ForMember(
                    dest => dest.Skills,
                    opt => opt.Ignore()
                    );

            CreateMap<EmployeeForUpdateDto, Employee>()
                .ForMember(
                    dest => dest.EmployeeSkills,
                    opt => opt.Ignore()
                    );

            CreateMap<Employee, EmployeeForUpdateDto>()
                .ForMember(
                    dest => dest.EmployeeSkills,
                    opt => opt.Ignore()
                    );
        }
    }
}
