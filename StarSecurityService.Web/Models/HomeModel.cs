using StarSecurityService.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarSecurityService.Web.Models
{
    public class HomeModel
    {
    }
    public class HomeAboutUs
    {
        public IEnumerable<History> HistoryModel { get; set; }
        public IEnumerable<ShareHolder> ShareHolderModel { get; set; }
        public List<ServiceOfferCategoryOuput> ServiceOffersModel { get; set; }
        public IEnumerable<Client> ClientModel { get; set; }
        public IEnumerable<Vacancy> VacancyModel { get; set; }
    }
    public class ServiceOfferCategoryOuput
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public string Url { get; set; }
        public string Introduce { get; set; }
        public string Description { get; set; }
        public bool isSelected { get; set; } = false;
        public int Id { get; set; }
        public int CategoryServiceOfferId { get; set; }
        public IEnumerable<Client> ClientModel { get; set; } = new List<Client>(); 
        public ServiceOfferCategoryOuput()
        {

        }
    }
}