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
        Task<bool> DeleteByEmployeeId(int employeeId);
    }
    public class EmployeeServiceOfferAppService : IEmployeeServiceOfferAppSerivce
    {
        private readonly IAsyncRepository<EmployeeServiceOffered> _employeeServiceOfferedRepository;
        public EmployeeServiceOfferAppService()
        {
            _employeeServiceOfferedRepository = new EfRepository<EmployeeServiceOffered>(new StarServiceDbContext());
        }

        public async Task<bool> DeleteByEmployeeId(int employeeId)
        {
            try
            {
                var getList = (await _employeeServiceOfferedRepository.GetAllAsync(x => x.EmployeeId == employeeId)).ToList();
                foreach (var item in getList)
                {
                    await _employeeServiceOfferedRepository.DeleteAsync(item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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
