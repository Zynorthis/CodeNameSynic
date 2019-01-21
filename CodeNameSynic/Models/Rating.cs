using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}