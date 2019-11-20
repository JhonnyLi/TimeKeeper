using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Data;
using TimeKeeper.Web.Models.ViewModels;

namespace TimeKeeper.Web.Repositorys
{
    public class CompaniesRepository: ICompaniesRepository
    {
        readonly AppDbContext _context;

        public CompaniesRepository(AppDbContext context)
        {
            _context = context;
        }

        public TimeKeeperViewModel GetTimeKeeperViewModel(string name)
        {
            var model = new TimeKeeperViewModel();
            model.CustomerName = name;
            model.VadIds = _context.Companies.Select(c => new SelectListItem(c.Name, c.VatId)).ToList();

            return model;
        }
    }
}
