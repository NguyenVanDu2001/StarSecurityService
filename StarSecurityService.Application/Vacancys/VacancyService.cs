using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace StarSecurityService.Application.Vacancys
{
    public interface IVacancyService
    {
        Task<Vacancy> AddAsync(Vacancy vacancy);
        Task<IEnumerable<Vacancy>> GetAll();
        Task<IEnumerable<Vacancy>> GetAllByStatus();
        Task<Vacancy> FirstOrDefaultAsync(int Id);
        Task UpdateAsync(Vacancy vacancy);
        Task DeleteAsync(int Id);
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
            vacancy.UpdateAt = DateTime.Now;
            return await _vacancyRepository.AddAsync(vacancy)
    ;
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _vacancyRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _vacancyRepository.DeleteAsync(a);
        }

        public async Task<Vacancy> FirstOrDefaultAsync(int Id)
        {
            return await _vacancyRepository.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Vacancy>> GetAll()
        {
            return await _vacancyRepository.GetAllAsync();
        }
        public async Task<IEnumerable<Vacancy>> GetAllByStatus()
        {
            return await _vacancyRepository.ListAsync(x => x.Status == true);
        }

        public async Task UpdateAsync(Vacancy vacancy)
        {
            vacancy.UpdateAt = DateTime.Now;
            await _vacancyRepository.UpdateAsync(vacancy);
        }
    }
}