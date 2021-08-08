using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Employees
{
    public interface IEmployeeAppService
    {
        Task<IEnumerable<Employyee>> GetAllEmployee();
        Task<string> GetCodeEmployyee(int? idEmployee = 0);
    }
    public class EmployeeAppServices : IEmployeeAppService
    {
        private readonly IAsyncRepository<Employyee> _employyeeRepository;
        public EmployeeAppServices()
        {
            _employyeeRepository = new EfRepository<Employyee>(new StarServiceDbContext());
        }
        public async Task<IEnumerable<Employyee>> GetAllEmployee()
        {
            var iQueryableEmployee = await _employyeeRepository.GetAllAsync();
            return iQueryableEmployee.AsEnumerable();
        }

        public async Task<string> GetCodeEmployyee(int? idEmployee = 0)
        {
            if (idEmployee > 0)
            {
                var employyee = await _employyeeRepository.FirstOrDefaultAsync(x => x.Id == idEmployee.Value);
                return employyee != null ? employyee.Address : null;
            }
            return null;
        }
    }
}
