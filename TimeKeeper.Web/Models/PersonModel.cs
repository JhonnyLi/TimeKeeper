using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeKeeper.Web.Models
{
    public class PersonModel
    {
        [Key]
        public Guid PersonModelId { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string MiddleName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        public List<AddressModel> Addresses { get; set; }
        public List<PhoneNumberModel> PhoneNumbers { get; set; }
    }
}
