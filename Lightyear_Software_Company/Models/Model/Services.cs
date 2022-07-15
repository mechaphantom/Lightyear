using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }
        [DisplayName("Service Title")]
        [Required, StringLength(150, ErrorMessage = "Need 150 characters!")]
        public string ServiceTitle { get; set; }
        [DisplayName("Service Description")]
        public string ServiceDescription { get; set; }
        [DisplayName("Service Image")]
        public string ImageURL { get; set; }
    }
}