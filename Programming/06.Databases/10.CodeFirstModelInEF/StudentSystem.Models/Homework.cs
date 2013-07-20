using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public DateTime TimeSent { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
