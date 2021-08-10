using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Candidate : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int VacancyId { get; set; }
        [ForeignKey("VacancyId")]
        public virtual Vacancy Vacancies { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public string UrlFile { get; set; }
        public bool Status { get; set; }

        public Candidate() {}

        public Candidate(string name, string phone, int vacancyId, string message, string email, DateTime startDate, bool status, string urlFile)
        {
            Name = name;
            Phone = phone;
            VacancyId = vacancyId;
            Message = message;
            Email = email;
            StartDate = startDate;
            Status = status;
            UrlFile = urlFile;
        }
    }
}