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
    public interface IBranchService
    {
        Task<IEnumerable<Branch>> GetAllBranchs();
    }
    public class BranchService : IBranchService
    {
        private readonly IAsyncRepository<Branch> _branchRepository;

        public BranchService()
        {
            _branchRepository = new EfRepository<Branch>(new StarServiceDbContext());
        }

        public async Task<IEnumerable<Branch>> GetAllBranchs()
        {
            var iQueryableEmployee = await _branchRepository.GetAllAsync();
            return iQueryableEmployee.AsEnumerable();
        }
    }
}
