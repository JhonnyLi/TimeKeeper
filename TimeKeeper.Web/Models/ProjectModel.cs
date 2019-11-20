using System;
using System.Collections.Generic;

namespace TimeKeeper.Web.Models
{
    public class ProjectModel
    {
        public Guid ProjectModelId { get; set; }
        public string Name { get; set; }
        public PersonModel Customer { get; set; }
        public List<SessionModel> Sessions { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
