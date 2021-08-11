using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Clients
{
    public interface IClientAppService
    {
        Task<Client> AddAsync(Client client);
        Task<IEnumerable<Client>> GetAll();
        Task<Client> FirstOrDefaultAsync(int Id);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int Id);
        Task<List<ComboboxCommonDto>> GetComboboxClient();
    }
    public class ClientAppServices : IClientAppService
    {
        private readonly IAsyncRepository<Client> _ClientRepository;
        public ClientAppServices()
        {
            _ClientRepository = new EfRepository<Client>(new StarServiceDbContext());
        }

        public async Task<Client> AddAsync(Client client)
        {
            return await _ClientRepository.AddAsync(client);
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _ClientRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _ClientRepository.DeleteAsync(a);
        }

        public async Task<Client> FirstOrDefaultAsync(int Id)
        {
            return await _ClientRepository.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _ClientRepository.GetAllAsync();
        }

        public async Task<string> GetCodeClient(int? idClient = 0)
        {
            if (idClient > 0)
            {
                var Client = await _ClientRepository.FirstOrDefaultAsync(x => x.Id == idClient.Value);
                return Client != null ? Client.Address : null;
            }
            return null;
        }

        public async Task<List<ComboboxCommonDto>> GetComboboxClient()
        {
            return (await _ClientRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.Name,
                Value = x.Id
            }).ToList();
        }

        public async Task UpdateAsync(Client client)
        {
            await _ClientRepository.UpdateAsync(client);
        }
    }
}
