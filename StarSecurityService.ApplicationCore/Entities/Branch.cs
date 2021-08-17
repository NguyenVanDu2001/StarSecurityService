using System.Collections.Generic;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Branch : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Vacancy> Vacancies { get; set; }

        public Branch(string name, string phone, string email, string address, bool status, ICollection<Vacancy> vacancies)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            Status = status;
            Vacancies = vacancies;
        }

        public Branch()
        {

        }

    }
}
