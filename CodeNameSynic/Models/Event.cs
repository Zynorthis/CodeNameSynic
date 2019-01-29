using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [Display(Name = "Start Time")]
        public int StartTime { get; set; }
        [Display(Name = "End Time")]
        public int EndTime { get; set; }
        [Display(Name = "Total Rating")]
        public double TotalRating { get; set; }

        [ForeignKey("User")]
        public int? UserRefId { get; set; }
        public SynicUser User { get; set; }

        [ForeignKey("Category")]
        public int? CategoryRefId { get; set; }
        public Category Category { get; set; }
    }
}