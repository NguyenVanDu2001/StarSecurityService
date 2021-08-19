using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Histories
{
    public interface IHistoryService
    {
        Task<History> AddAsync(History vacancy);
        Task<IEnumerable<History>> GetAll();
        Task<History> FirstOrDefaultAsync(int? Id);
        Task UpdateAsync(History History);
        Task DeleteAsync(int Id);
    }
    public class HistoryService : IHistoryService
    {

        private readonly IAsyncRepository<History> _HistoryRepository;

        public HistoryService()
        {
            _HistoryRepository = new EfRepository<History>(new StarServiceDbContext());
        }

        public async Task<History> AddAsync(History History)
        {
            History.CreateAt = DateTime.Now;
            return await _HistoryRepository.AddAsync(History);
        }

        public async Task<IEnumerable<History>> GetAll()
        {
            return await _HistoryRepository.GetAllAsync();
        }

        public async Task<History> FirstOrDefaultAsync(int? Id)
        {
            if (Id.HasValue)
            {
                return await _HistoryRepository.FirstOrDefaultAsync(x => x.Id == Id);
            }
            return new History();
        }

        public async Task UpdateAsync(History history)
        {
            history.CreateAt = DateTime.Now;
            await _HistoryRepository.UpdateAsync(history);
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _HistoryRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _HistoryRepository.DeleteAsync(a);
        }
    }
}
