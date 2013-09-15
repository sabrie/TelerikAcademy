using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _06.GraphicalWebCounterUsingDb.Models
{
    public class WebCounter
    {
        public int Id { get; set; }

        public int UsersCount { get; set; }
    }
}