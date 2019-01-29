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
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "User Id")]
        public string ApplicationUserRefId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("UserPreferences")]
        [Display(Name = "Preferences")]
        public int? UserPreferencesRefId { get; set; }
        public UserPreferences UserPreferences { get; set; }
    }
}