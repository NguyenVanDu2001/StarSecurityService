using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Achievements
{
    public interface IAchievementAppService
    {
        Task<List<ComboboxCommonDto>> GetAllComboboxAchievemnt();
    }
    public class AchievementAppService : IAchievementAppService
    {
        private readonly IAsyncRepository<Achievement> _achievementRepository;

        public AchievementAppService()
        {
            _achievementRepository = new EfRepository<Achievement>(new StarServiceDbContext());
        }
        public async Task<List<ComboboxCommonDto>> GetAllComboboxAchievemnt()
        {
            return (await _achievementRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.name,
                Value = x.Id
            })?.ToList();
        }
    }
}
