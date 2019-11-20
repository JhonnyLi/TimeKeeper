using System;
using System.ComponentModel.DataAnnotations;

namespace TimeKeeper.Web.Models
{
    public class AddressModel
    {
        [Key]
        public Guid AddressModelId { get; set; }
        [MaxLength(256)]
        public string Street { get; set; }
        [MaxLength(256)]
        public string Street2 { get; set; }
        [MaxLength(256)]
        public string PostCode { get; set; }
        [MaxLength(256)]
        public string City { get; set; }
        [MaxLength(256)]
        public string County { get; set; }
        [MaxLength(256)]
        public string Country { get; set; }
    }
}
