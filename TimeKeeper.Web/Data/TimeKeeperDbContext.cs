using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Web.Models;

namespace TimeKeeper.Web.Data
{
    public class TimeKeeperDbContext
    {
        public TimeKeeperDbContext()
        {

        }

        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
    }
}
