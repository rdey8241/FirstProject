using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityCRUD.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyDbContext:DbContext
    {
        public MyDbContext() : base("name=ProductConnection")
        {
        }

        public DbSet<Product> products{ get; set; }
    }
}