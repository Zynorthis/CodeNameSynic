using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class SynicUser
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Rating")]
        [Display(Name = "RatingKey")]
        public int RatingRefId { get; set; }
        public Rating Rating { get; set; }
    }
}