using StarSecurityService.Application.Commons.Dto;
using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Branchs
{
    public interface IBrachAppService {
        Task<List<ComboboxCommonDto>> GetAllForCombobox();
    }
    public class BranchAppService : IBrachAppService
    {
        private readonly IAsyncRepository<Branch> _branchRepository;
        public BranchAppService()
        {
            _branchRepository = new EfRepository<Branch>(new StarServiceDbContext());
        }
        public async Task<List<ComboboxCommonDto>> GetAllForCombobox()
        {
            return (await _branchRepository.GetAllAsync()).Select(x => new ComboboxCommonDto
            {
                Lable = x.Name,
                Value = x.Id
            }).ToList();
        }
    }
}
