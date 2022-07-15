using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("About")]
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        [Required]
        [DisplayName("About")]
        public string About_Description { get; set; }
    }
}