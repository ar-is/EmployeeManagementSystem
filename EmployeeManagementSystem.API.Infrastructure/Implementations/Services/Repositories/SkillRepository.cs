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

        public IEnumerable<Skill> GetSkills(string type, string status)
        {
            var skills = _context.Skills.AsQueryable();
            GetSkillsFilteredByType(type, ref skills);
            GetSkillsFilteredByStatus(status, ref skills);
            
            return skills.ToList();
        }

        private void GetSkillsFilteredByType(string type, ref IQueryable<Skill> skills)
        {
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "Soft":
                        skills = skills.Where(s => s.Type == SkillType.Soft);
                        break;

                    case "Technical":
                        skills = skills.Where(s => s.Type == SkillType.Technical);
                        break;

                    case "All":
                    default:
                        break;
                }
            }
        }

        private void GetSkillsFilteredByStatus(string status, ref IQueryable<Skill> skills)
        {
            if (!string.IsNullOrEmpty(status))
            {
                switch (status)
                {
                    case "Enabled":
                        skills = skills.Where(s => s.IsEnabled);
                        break;

                    case "Disabled":
                        skills = skills.Where(s => !s.IsEnabled);
                        break;

                    case "All":
                    default:
                        break;
                }
            }
        }

        public PagedList<Skill> GetSkillsForJob(Guid jobId, SkillsResourceParameters parameters)
        {
            if (jobId == Guid.Empty)
                throw new ArgumentNullException(nameof(jobId));

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

            var skills = _context.JobSkills
                .Include(js => js.Job)
                .Where(js => js.Job.Id == job.Id)
                .Select(js => js.Skill)
                .Where(s => s.IsEnabled);

            return skills;
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

        public Skill GetSkill(Guid skillId)
        {
            if (skillId == Guid.Empty)
                throw new ArgumentNullException(nameof(skillId));

            return _context.Skills
                .Include(s => s.JobSkills)
                    .ThenInclude(js =>js.Job)
                .FirstOrDefault(s => s.Guid == skillId);
        }

        public void AddSkill(Skill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));

            if (skill.Guid == Guid.Empty)
                skill.Guid = Guid.NewGuid();

            _context.Skills.Add(skill);
        }

        public void UpdateSkill(Skill skill)
        {

        }

        public bool SkillExists(Skill skill)
        {
            return _context.Skills.Any(s => s.Name == skill.Name &&
                                            s.Type == skill.Type);
        }

        public void DeleteSkill(Skill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));

            _context.Skills.Remove(skill);
        }
    }
}
