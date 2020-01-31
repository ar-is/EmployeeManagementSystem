using EmployeeManagementSystem.API.Core.Dtos.Skills;
using EmployeeManagementSystem.API.Core.Entities;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Repositories;
using EmployeeManagementSystem.API.Core.Interfaces.Services.Sorting;
using EmployeeManagementSystem.API.Infrastructure.DbContexts;
using EmployeeManagementSystem.API.Infrastructure.Helpers.Extension_Methods;
using EmployeeManagementSystem.API.Utils.Paging;
using EmployeeManagementSystem.API.Utils.ResourceFilters.Skills;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagementSystem.API.Infrastructure.Implementations.Services.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly EMSDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public SkillRepository(EMSDbContext context, IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService
               ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }

        //public IEnumerable<Skill> GetSkills(Guid jobId)
        //{
        //    if (jobId == Guid.Empty)
        //        throw new ArgumentNullException(nameof(jobId));

        //    var job = _context.Jobs.FirstOrDefault(j => j.Guid == jobId);

        //    return _context.JobSkills
        //        .Include(js => js.Job)
        //        .Where(js => js.Job.Guid == jobId)
        //        .Select(js => js.Skill)
        //        .ToList();                
        //}

        public PagedList<Skill> GetSkills(Guid jobId, SkillsResourceParameters parameters)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentNullException(nameof(jobId));

            var job = _context.Jobs.FirstOrDefault(j => j.Guid == jobId);

            IQueryable<Skill> skills = Enumerable.Empty<Skill>().AsQueryable();

            if (parameters.Filter != null)
            {
                foreach (var condition in GetSkillsDictionary(jobId, parameters.Filter).Keys)
                {
                    if (condition)
                        skills = GetSkillsDictionary(jobId, parameters.Filter)[condition];
                }
            }
            else
                skills = GetSkills(jobId);

            if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            {
                var moviePropertyMappingDictionary =
                    _propertyMappingService.GetPropertyMapping<SkillDto, Skill>();

                skills = skills.ApplySort(parameters.OrderBy,
                    moviePropertyMappingDictionary);
            }

            return PagedList<Skill>.Create(skills, parameters.PageNumber, parameters.PageSize);
        }

        private Dictionary<bool, IQueryable<Skill>> GetSkillsDictionary(Guid jobId, 
            SkillsFilter filter)
        {
            return new Dictionary<bool, IQueryable<Skill>>
            {
                [filter.HasName()] = GetSkillsFilteredByName(jobId, filter),
                [filter.HasType()] = GetSkillsFilteredByType(jobId, filter),
                [filter.HasNameAndType()] = GetSkillsFilteredByNameAndType(jobId, filter)
            };
        }

        private IQueryable<Skill> GetSkills(Guid jobId)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentNullException(nameof(jobId));

            var job = _context.Jobs.FirstOrDefault(j => j.Guid == jobId);

            return _context.JobSkills
                .Include(js => js.Job)
                .Where(js => js.Job.Guid == jobId)
                .Select(js => js.Skill);
        }

        private IQueryable<Skill> GetSkillsFilteredByName(Guid jobId, SkillsFilter filter)
        {
            return GetSkills(jobId).Where(s => s.Name.Contains(filter.Name));
        }

        private IQueryable<Skill> GetSkillsFilteredByType(Guid jobId, SkillsFilter filter)
        {
            return GetSkills(jobId).Where(s => 
                    Enum.GetName(typeof(SkillType), s.Type).Contains(filter.Type));
        }

        private IQueryable<Skill> GetSkillsFilteredByNameAndType(Guid jobId, SkillsFilter filter)
        {
            return GetSkills(jobId)
                .Where(s => s.Name.Contains(filter.Name))
                .Where(s => Enum.GetName(typeof(SkillType), s.Type).Contains(filter.Type));
        }
    }
}
