using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeKeeper.Web.Models.ViewModels
{
    public class TimeKeeperViewModel
    {
        [Display(Name = "KundNummer")]
        public string CustomerID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "VatId")]
        public IEnumerable<SelectListItem> VadIds { get; set; }
    }
}
