using System;

namespace TimeKeeper.Web.Models
{
    public class CompanyModel
    {
        public Guid CompanyModelId { get; set; }
        public string Name { get; set; }
        public string VatId { get; set; }
        public AddressModel Address { get; set; }
        public PersonModel Contact { get; set; }
    }
}
