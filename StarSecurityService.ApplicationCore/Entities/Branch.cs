using System.Collections.Generic;

namespace StarSecurityService.ApplicationCore.Entities
{
    public class Branch : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Vacancy> Vacancies { get; set; }
        public Branch(int id, string name, string phone, string email, string address)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
        }
    }
}
