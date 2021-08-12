using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.EmployeeSerivceOffers
{
    public interface IEmployeeServiceOfferAppSerivce
    {
        Task<bool> InsertMuntiple(List<EmployeeServiceOffered> EmployeeServiceOffereds);
    }
    public class EmployeeServiceOfferAppService : IEmployeeServiceOfferAppSerivce
    {
        private readonly IAsyncRepository<EmployeeServiceOffered> _employeeServiceOfferedRepository;
        public EmployeeServiceOfferAppService()
        {
            _employeeServiceOfferedRepository = new EfRepository<EmployeeServiceOffered>(new StarServiceDbContext());
        }

        public async Task<bool> InsertMuntiple(List<EmployeeServiceOffered> employeeServiceOffereds)
        {
            try
            {
                foreach (var item in employeeServiceOffereds)
                {
                    await _employeeServiceOfferedRepository.AddAsync(item);
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
