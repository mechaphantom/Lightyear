using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("WebsiteIdentity")]
    public class WebsiteIdentity
    {
        [Key]
        public int WebsiteID { get; set; }
        [DisplayName("Website Title")]
        [Required, StringLength(100, ErrorMessage = "Need 100 characters!")]
        public string Title { get; set; }
        [DisplayName("Keywords for Website")]
        [Required, StringLength(200, ErrorMessage = "Need 200 characters!")]
        public string Keywords { get; set; }
        [DisplayName("Description of Website")]
        [Required, StringLength(300, ErrorMessage = "Need 300 characters!")]
        public string Description { get; set; }
        [DisplayName("Website Logo")]
        public string LogoURL { get; set; }
        [DisplayName("Rank")]
        public string Rank { get; set; }
    }
}