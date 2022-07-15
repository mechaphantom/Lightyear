using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required, StringLength(250, ErrorMessage = "Need 250 characters!")]
        public string Address { get; set; }
        [Required, StringLength(250, ErrorMessage = "Need 250 characters!")]
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WhatsApp { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }
}