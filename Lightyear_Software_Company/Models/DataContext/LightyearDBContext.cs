using Lightyear_Software_Company.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lightyear_Software_Company.Models.DataContext
{
    public class LightyearDBContext:DbContext
    {
        public LightyearDBContext():base("LightyearWebDB")
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<CarrierCategory> CarrierCategory { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<WebsiteIdentity> WebsiteIdentity { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}