using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Vacancys
{
    public interface IVacancyService
    {
        Task<Vacancy> AddAsync(Vacancy vacancy);
    }
    public class VacancyService : IVacancyService
    {
        private readonly IAsyncRepository<Vacancy> _vacancyRepository;

        public VacancyService()
        {
            _vacancyRepository = new EfRepository<Vacancy>(new StarServiceDbContext());
        }

        public async Task<Vacancy> AddAsync(Vacancy vacancy)
        {
            //TODO: get user from systems
            vacancy.CreateBy = 1;

            vacancy.UpdateAt = DateTime.Now;
            return await _vacancyRepository.AddAsync(vacancy);
        }
    }
}
