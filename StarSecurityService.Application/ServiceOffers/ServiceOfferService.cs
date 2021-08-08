using StarSecurityService.Application.Commons.Dto;
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
        Task<IEnumerable<ServiceOffer>> GetAll();
    }
    public class ServiceOfferService : IServiceOfferService
    {
        private readonly IAsyncRepository<ServiceOffer> _serviceOfferRepository;
        public ServiceOfferService()
        {
            _serviceOfferRepository = new EfRepository<ServiceOffer>(new StarServiceDbContext());
        }

        public async Task<IEnumerable<ServiceOffer>> GetAll()
        {
            var iQueryableEmployee = await _serviceOfferRepository.GetAllAsync();
            return iQueryableEmployee.AsEnumerable();
        }

        public async Task<List<ComboboxCommonDto>> GetComboboxServiceOffer()
        {
           return (await _serviceOfferRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.Title,
                Value = x.Id
            }).ToList();
        }
    
    }
}
