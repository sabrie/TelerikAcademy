using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Material> Materials { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public Course()
        {
            this.Materials = new List<Material>();
            this.Students = new List<Student>();
        }
    }
}
