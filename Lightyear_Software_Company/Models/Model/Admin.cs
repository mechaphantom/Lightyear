using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır!")]
        public string Mail { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 Karakter olmalıdır!")]
        public string Password { get; set; }
        public string Yetki { get; set; }
    }
}