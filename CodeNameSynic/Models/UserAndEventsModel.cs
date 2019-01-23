using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class UserAndEventsModel
    {
        public SynicUser User { get; set; }
        public List<Event> Events { get; set; }
    }
}