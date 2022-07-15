using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Carrier")]
    public class Carrier
    {
        public int CarrierID { get; set; }
        public string CarrierTitle { get; set; }
        public string CarrierContent { get; set; }
        public string CarrierImageURL { get; set; }
        public int? CarrierCategoryID { get; set; }
        //[Required]
        public CarrierCategory CarrierCategory { get; set; }
    }
}