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
        [Display(Name = "Email Preferences")]
        public bool SendEmail { get; set; }
        [Display(Name = "Text Preferences")]
        public bool SendText { get; set; }
        [Display(Name = "Followed Categories")]
        public List<Category> FollowedCategories { get; set; }
    }
}