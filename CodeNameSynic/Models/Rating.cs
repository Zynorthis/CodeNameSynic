using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        public int RatingNumber { get; set; }
        public string Description { get; set; }

        [ForeignKey("Event")]
        [Display(Name = "Event")]
        public int? EventRefId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("SynicUser")]
        [Display(Name = "User")]
        public int? SynicUserRefId { get; set; }
        public SynicUser SynicUser { get; set; }
    }
}