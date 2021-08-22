using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.CategoryServiceoofers
{
    public interface IServiceOfferAppService
    {
        Task<CategoryServiceOffer> AddAsync(CategoryServiceOffer CategoryServiceOffer);
        Task<IEnumerable<CategoryServiceOffer>> GetAll(bool? status = false);
        Task<CategoryServiceOffer> FirstOrDefaultAsync(int Id);
        Task UpdateAsync(CategoryServiceOffer CategoryServiceOffer);
        Task DeleteAsync(int Id);
        Task<List<ComboboxCommonDto>> GetComboboxCategoryServiceOffer();
    }
    public class CategoryServiceOfferService : IServiceOfferAppService
    {
        private readonly IAsyncRepository<CategoryServiceOffer> _CategoryServiceOfferRepository;
        public CategoryServiceOfferService()
        {
            _CategoryServiceOfferRepository = new EfRepository<CategoryServiceOffer>(new StarServiceDbContext());
        }

        public async Task<CategoryServiceOffer> AddAsync(CategoryServiceOffer CategoryServiceOffer)
        {
            return await _CategoryServiceOfferRepository.AddAsync(CategoryServiceOffer);
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _CategoryServiceOfferRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _CategoryServiceOfferRepository.DeleteAsync(a);
        }

        public async Task<CategoryServiceOffer> FirstOrDefaultAsync(int Id)
        {
            return await _CategoryServiceOfferRepository.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<CategoryServiceOffer>> GetAll(bool? status = false)
        {
            if (status.HasValue)
            {
                return (await _CategoryServiceOfferRepository.GetAllAsync()).AsEnumerable();
            }else
                return (await _CategoryServiceOfferRepository.GetAllAsync()).Where(x=>x.Status == status).AsEnumerable();

        }

   

        public async Task<List<ComboboxCommonDto>> GetComboboxCategoryServiceOffer()
        {
            return (await _CategoryServiceOfferRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.Name,
                Value = x.Id
            }).ToList();
        }

        public async Task UpdateAsync(CategoryServiceOffer CategoryServiceOffer)
        {
            await _CategoryServiceOfferRepository.UpdateAsync(CategoryServiceOffer);
        }
    }
}
