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
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public double TotalRating { get; set; }
        [ForeignKey("Rating")]
        public int RatingRefId { get; set; }
        public Rating Rating { get; set; }
        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public SynicUser User { get; set; }
        [ForeignKey("Category")]
        public int CategoryRefId { get; set; }
        public Category Category { get; set; }
    }
}