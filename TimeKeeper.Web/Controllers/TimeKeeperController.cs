using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Data;
using TimeKeeper.Web.Data;
using TimeKeeper.Web.Models;
using TimeKeeper.Web.Models.ViewModels;
using TimeKeeper.Web.Repositorys;

namespace TimeKeeper.Web.Controllers
{
    public class TimeKeeperController : Controller
    {
        readonly ICompaniesRepository _companies;
        public TimeKeeperController(ICompaniesRepository companyRepo)
        {
            _companies = companyRepo;
        }
        [Authorize]
        public IActionResult Index()
        {

            var model = _companies.GetTimeKeeperViewModel("Hejje");

            return View(model);
        }
    }
}