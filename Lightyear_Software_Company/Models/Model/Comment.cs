using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.Model
{
    [Table("Comment")]
    public class Comment
    {
        public int CommentID { get; set; }
        [Required, StringLength(50, ErrorMessage = "Max Lenght is 50!")]
        public string Name { get; set; }
        public string Mail { get; set; }
        [DisplayName("CommentContent")]
        public string CommentContent { get; set; }
        public bool Approval { get; set; }
        public int? BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}