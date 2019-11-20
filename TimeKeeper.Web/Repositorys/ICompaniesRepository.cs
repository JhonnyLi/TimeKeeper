using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Web.Models.ViewModels;

namespace TimeKeeper.Web.Repositorys
{
    public interface ICompaniesRepository
    {
        public TimeKeeperViewModel GetTimeKeeperViewModel(string name);
    }
}
