using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        public int Points { get; set; }
    }
}
