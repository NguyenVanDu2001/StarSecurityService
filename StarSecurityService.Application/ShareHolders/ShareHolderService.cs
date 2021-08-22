using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Histories
{
    public interface IShareHolderService
    {
        Task<ShareHolder> AddAsync(ShareHolder vacancy);
        Task<IEnumerable<ShareHolder>> GetAll(int? status = 1);
        Task<ShareHolder> FirstOrDefaultAsync(int? Id);
        Task UpdateAsync(ShareHolder ShareHolder);
        Task DeleteAsync(int Id);
    }
    public class ShareHolderService : IShareHolderService
    {

        private readonly IAsyncRepository<ShareHolder> _ShareHolderRepository;

        public ShareHolderService()
        {
            _ShareHolderRepository = new EfRepository<ShareHolder>(new StarServiceDbContext());
        }

        public async Task<ShareHolder> AddAsync(ShareHolder ShareHolder)
        {
            return await _ShareHolderRepository.AddAsync(ShareHolder);
        }

        public async Task<IEnumerable<ShareHolder>> GetAll(int? status = 1)
        {
            return (await _ShareHolderRepository.ListAsync(x=>x.Status == status));
        }

        public async Task<ShareHolder> FirstOrDefaultAsync(int? Id)
        {
            if (Id.HasValue)
            {
                return await _ShareHolderRepository.FirstOrDefaultAsync(x => x.Id == Id);
            }
            return new ShareHolder();
        }

        public async Task UpdateAsync(ShareHolder ShareHolder)
        {
            await _ShareHolderRepository.UpdateAsync(ShareHolder);
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _ShareHolderRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _ShareHolderRepository.DeleteAsync(a);
        }
    }
}
