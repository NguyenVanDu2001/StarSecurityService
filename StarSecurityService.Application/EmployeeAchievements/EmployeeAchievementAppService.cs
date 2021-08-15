using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.EmployeeAchievements
{
    public interface IEmployeeAchievementAppService
    {
         Task<bool> InsertMuntiple(List<EmployeeAchievement> employeeAchievements);
        Task<bool> DeleteByEmployeeId(int employeeId);
    }
    public class EmployeeAchievementAppService : IEmployeeAchievementAppService
    {
        private readonly IAsyncRepository<EmployeeAchievement> _employeeAchievementRepository;
        public EmployeeAchievementAppService()
        {
            _employeeAchievementRepository = new EfRepository<EmployeeAchievement>(new StarServiceDbContext());
        }
        public async Task<bool> DeleteByEmployeeId(int employeeId)
        {
            try
            {
                var getList = (await _employeeAchievementRepository.GetAllAsync(x => x.EmployeeId == employeeId)).ToList();
                foreach (var item in getList)
                {
                    await _employeeAchievementRepository.DeleteAsync(item);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<bool> InsertMuntiple(List<EmployeeAchievement> employeeAchievements)
        {
            try
            {
                foreach (var item in employeeAchievements)
                {
                    await _employeeAchievementRepository.AddAsync(item);
                }
                return true;

            }
            catch (Exception ex)
            {
                return  false;
            }
        }
    }
}
