using System;

namespace TimeKeeper.Web.Models
{
    public class SessionModel
    {
        public Guid SessionModelId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }
    }
}
