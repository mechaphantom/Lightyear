using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogImageURL { get; set; }
        public int? BlogCategoryID { get; set; }
        //[Required]
        public BlogCategory BlogCategory { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}