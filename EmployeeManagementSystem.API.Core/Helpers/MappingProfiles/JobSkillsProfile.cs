using AutoMapper;
using EmployeeManagementSystem.API.Core.Dtos.JobSkills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementSystem.API.Core.Helpers.MappingProfiles
{
    public class JobSkillsProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobSkillsProfile(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public JobSkillsProfile()
        {
            CreateMap<JobSkillForCreationDto, JobSkill>();
                //.ForMember(
                //    dest => dest.JobId,
                //    opt => opt.MapFrom(src => _unitOfWork.Jobs.GetJob(src.JobId).Id)
                //    );
        }
    }
}
