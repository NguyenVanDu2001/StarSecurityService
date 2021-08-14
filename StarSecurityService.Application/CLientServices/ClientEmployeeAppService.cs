using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.CLientServices
{
    public interface IClientEmployeeAppService
    {
        Task<bool> InsertMuntiple(List<ClientEmployees> clientEmployees);
    }
    public class ClientEmployeeAppService : IClientEmployeeAppService
    {
        private readonly IAsyncRepository<ClientEmployees> _ClientEmployeesRepository;
        public ClientEmployeeAppService()
        {
            _ClientEmployeesRepository = new EfRepository<ClientEmployees>(new StarServiceDbContext());
        }

        public async Task<bool> InsertMuntiple(List<ClientEmployees> clientEmployees)
        {
            try
            {
                foreach (var item in clientEmployees)
                {
                    await _ClientEmployeesRepository.AddAsync(item);
                }
                return true;
                 
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
