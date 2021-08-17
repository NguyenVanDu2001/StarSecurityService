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
        Task<bool> DeleteByEmployeeId(int employeeId);
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
        public async Task<bool> DeleteByEmployeeId(int employeeId)
        {
            try
            {
                var getList = (await _ClientEmployeesRepository.GetAllAsync(x => x.EmployeeId == employeeId)).ToList();
                foreach (var item in getList)
                {
                    await _ClientEmployeesRepository.DeleteAsync(item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
