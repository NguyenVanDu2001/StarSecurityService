using StarSecurityService.ApplicationCore.Entities;
using StarSecurityService.ApplicationCore.InterFaces;
using StarSecurityService.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Candidates
{
    public interface ICandidateService
    {
        Task<Candidate> AddAsync(Candidate vacancy);
        Task<IEnumerable<Candidate>> GetAll();
        Task<Candidate> FirstOrDefaultAsync(int? Id);
        Task UpdateAsync(Candidate candidate);
        Task DeleteAsync(int Id);
    }
    public class CandidateService : ICandidateService
    {

        private readonly IAsyncRepository<Candidate> _candidateRepository;

        public CandidateService()
        {
            _candidateRepository = new EfRepository<Candidate>(new StarServiceDbContext());
        }

        public async Task<Candidate> AddAsync(Candidate candidate)
        {
            candidate.CreateAt = DateTime.Now;
            return await _candidateRepository.AddAsync(candidate);
        }

        public async Task<IEnumerable<Candidate>> GetAll()
        {
            return await _candidateRepository.GetAllAsync();
        }

        public async Task<Candidate> FirstOrDefaultAsync(int? Id)
        {
            if (Id.HasValue)
            {
                return await _candidateRepository.FirstOrDefaultAsync(x => x.Id == Id);
            }
            return new Candidate();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            candidate.CreateAt = DateTime.Now;
            await _candidateRepository.UpdateAsync(candidate);
        }

        public async Task DeleteAsync(int Id)
        {
            var a = await _candidateRepository.FirstOrDefaultAsync(x => x.Id == Id);
            await _candidateRepository.DeleteAsync(a);
        }
    }
}
