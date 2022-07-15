using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }
        [DisplayName("Slider Title"), StringLength(30, ErrorMessage = "Max Length is 30!")]
        public string SliderTitle { get; set; }
        [DisplayName("Slider Description"), StringLength(200, ErrorMessage = "Max Length is 200!")]
        public string SliderDescription { get; set; }
        [DisplayName("Slider Resim"), StringLength(250)]
        public string SliderImageURL { get; set; }
    }
}