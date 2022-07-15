using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("BlogCategory")]
    public class BlogCategory
    {
        [Key]
        public int BlogCategoryID { get; set; }
        [Required, StringLength(50, ErrorMessage = "Need 50 characters")]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}