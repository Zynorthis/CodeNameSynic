using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class UserPreferences
    {
        [Key]
        public int ID { get; set; }
        public bool SendEmail { get; set; }
        public bool SendText { get; set; }
        public List<Category> FollowedCategories { get; set; }
    }
}