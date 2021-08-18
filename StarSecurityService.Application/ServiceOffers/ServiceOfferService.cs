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
        Task<ServiceOffer> AddAsync(ServiceOfferViewModel service, string name);
        Task<IEnumerable<ServiceOffer>> GetAll();
        Task<ServiceOffer> FirstOrDefaultAsync(int Id);
        Task UpdateAsync(ServiceOfferViewModel service, string name, int id);
        Task DeleteAsync(int Id);
    }
    public class ServiceOfferService : IServiceOfferService
    {
        private readonly IAsyncRepository<ServiceOffer> _serviceOfferRepository;
        public ServiceOfferService()
        {
            _serviceOfferRepository = new EfRepository<ServiceOffer>(new StarServiceDbContext());
        }

        public async Task<ServiceOffer> AddAsync(ServiceOfferViewModel service, string name)
        {
            ServiceOffer db = new ServiceOffer(service.Title, service.Details, name, service.Introduce, service.Description, service.Status);
            return await _serviceOfferRepository.AddAsync(db);
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

        public async Task UpdateAsync(ServiceOfferViewModel service, string name, int id)
        {
            ServiceOffer db = await FirstOrDefaultAsync(id);
            db.Title = service.Title;
            db.Details = service.Details;
            db.Url = name;
            db.Introduce = service.Introduce;
            db.Description = service.Description;
            db.Status = service.Status;
            await _serviceOfferRepository.UpdateAsync(db);
        }
    }
}
