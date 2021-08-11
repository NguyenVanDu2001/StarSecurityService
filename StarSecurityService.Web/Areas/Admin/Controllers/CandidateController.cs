using StarSecurityService.Application.Candidates;
using StarSecurityService.Application.Vacancys;
using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StarSecurityService.Web.Areas.Admin.Controllers
{
    public class CandidateController : Controller
    {

        private readonly IVacancyService _vacancyService;
        private readonly ICandidateService _candidateRepository;

        public CandidateController()
        {
            _vacancyService = new VacancyService();
            _candidateRepository = new CandidateService();
        }

        // GET: Admin/Candidate
        public async Task<ActionResult> Index()
        {
            var items = await _candidateRepository.GetAll();
            return View(items);
        }

        // GET: Admin/Candidate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Candidate/Create
        public async Task<ActionResult> Create(int? Id)
        {
            Candidate item = await _candidateRepository.FirstOrDefaultAsync(Id);
            ViewBag.Varcancy = new SelectList(await _vacancyService.GetAll(), "Id", "Title");
            return View(item);
        }

        // POST: Admin/Candidate/Create
        [HttpPost]
        public ActionResult Create(Candidate candidate, HttpPostedFileBase Image)
        {
            try
            {
                if (Image.ContentLength > 0)
                {
                    candidate.UrlFile = Image.FileName;
                    string _FileName = Path.GetFileName(Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Areas/Asset/img"), _FileName);
                    Image.SaveAs(_path);
                }
                if(candidate.Id > 0)
                {
                    _candidateRepository.UpdateAsync(candidate);
                } else
                {
                    _candidateRepository.AddAsync(candidate);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Candidate/Delete/5
        public ActionResult Delete(int id)
        {
            _candidateRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
