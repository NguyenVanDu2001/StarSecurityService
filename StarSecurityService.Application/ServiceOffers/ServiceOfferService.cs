using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.DTO;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.ServiceOffers
{
    public interface IServiceOfferService
    {
        Task<List<ComboboxCommonDto>> GetComboboxServiceOffer();
        Task<ServiceOffer> AddAsync(ServiceOfferViewModel service);
        Task<IEnumerable<ServiceOffer>> GetAll();
        Task<ServiceOffer> FirstOrDefaultAsync(int Id);
        Task UpdateAsync(ServiceOffer service);
        Task DeleteAsync(int Id);
    }
    public class ServiceOfferService : IServiceOfferService
    {
        private readonly IAsyncRepository<ServiceOffer> _serviceOfferRepository;
        public ServiceOfferService()
        {
            _serviceOfferRepository = new EfRepository<ServiceOffer>(new StarServiceDbContext());
        }

        public async Task<ServiceOffer> AddAsync(ServiceOfferViewModel service)
        {
            //return await _serviceOfferRepository.AddAsync(service);
            
            return null;
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _serviceOfferRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _serviceOfferRepository.DeleteAsync(a);
        }

        public async Task<ServiceOffer> FirstOrDefaultAsync(int Id)
        {
            return await _serviceOfferRepository.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<ServiceOffer>> GetAll()
        {
            return await _serviceOfferRepository.GetAllAsync();
        }

        public async Task<List<ComboboxCommonDto>> GetComboboxServiceOffer()
        {
            return (await _serviceOfferRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.Title,
                Value = x.Id
            }).ToList();
        }

        public async Task UpdateAsync(ServiceOffer service)
        {
            await _serviceOfferRepository.UpdateAsync(service);
        }
    }
}
