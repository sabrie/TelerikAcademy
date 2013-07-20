using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        public string Data { get; set; }

        public Material(string data)
        {
            this.Data = data;
        }
    }
}
