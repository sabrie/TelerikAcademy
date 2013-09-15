using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _06.GraphicalWebCounterUsingDb.Models
{
    public class WebCounterContext : DbContext
    {
        public WebCounterContext()
            : base("WebCounterDb")
        {
        }

        public DbSet<WebCounter> WebCounters { get; set; }
    }
}