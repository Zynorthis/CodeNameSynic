using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeNameSynic.Models
{
    public class PreferencesCategoryJunction
    {
        [Key, Column(Order = 0), ForeignKey("UserPreferences")]
        public int UserPreferenceRefId { get; set; }
        public UserPreferences UserPreferences { get; set; }
        [Key, Column(Order = 1), ForeignKey("Category")]
        public int CategoryRefId { get; set; }
        public Category Category { get; set; }
    }
}