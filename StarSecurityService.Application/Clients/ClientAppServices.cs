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
        Task<IEnumerable<Client>> GetAllClient();
        Task<string> GetCodeClient(int? idClient = 0);
        Task<List<ComboboxCommonDto>> GetComboboxClient();
    }
    public class ClientAppServices : IClientAppService
    {
        private readonly IAsyncRepository<Client> _ClientRepository;
        public ClientAppServices()
        {
            _ClientRepository = new EfRepository<Client>(new StarServiceDbContext());
        }
        public async Task<IEnumerable<Client>> GetAllClient()
        {
            var iQueryableClient = await _ClientRepository.GetAllAsync();
            return iQueryableClient.AsEnumerable();
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
                                                                }).ToList();}
    }
}
