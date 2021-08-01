using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Candidate
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public int VacancyId { get; set; }
        public String Message { get; set; }
        public String Email { get; set; }
        public DateTime StartDate { get; set; }
        public bool Status { get; set; }

        public Candidate(int id, string name, string phone, int vacancyId, string message, string email, DateTime startDate, bool status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            VacancyId = vacancyId;
            Message = message;
            Email = email;
            StartDate = startDate;
            Status = status;
        }
    }
}