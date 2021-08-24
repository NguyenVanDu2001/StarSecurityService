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
        Task<List<Vacancy>> GetAllByStatus(string filter = "");
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
        public async Task<List<Vacancy>> GetAllByStatus(string filter = "")
        {
            if (!string.IsNullOrEmpty(filter))
            {
                 return (await _vacancyRepository.GetAllListAsync()).FindAll(x => (x.Branchs.Name.ToLower().Contains(filter.ToLower())
                                                                                || x.ServiceOffer.Title.ToLower().Contains(filter.ToLower())
                                                                                )  || x.Title.ToLower().Contains(filter.ToLower())
                                                                                && x.Status == true);
            }
           return (await _vacancyRepository.GetAllListAsync()).FindAll(x => x.Status == true);
        }
            
        public async Task UpdateAsync(Vacancy vacancy)
        {
            vacancy.UpdateAt = DateTime.Now;
            await _vacancyRepository.UpdateAsync(vacancy);
        }
    }
}