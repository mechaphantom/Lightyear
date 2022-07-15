using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("CarrierCategory")]
    public class CarrierCategory
    {
        [Key]
        public int CarrierCategoryID { get; set; }
        [Required, StringLength(50, ErrorMessage = "Need 50 characters")]
        public string CarrierCategoryName { get; set; }
        public string CarrierCategoryDescription { get; set; }
        public ICollection<Carrier> Carriers { get; set; }
    }
}