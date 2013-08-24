using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Students.Services.Models
{
    [DataContract]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }
        
        [DataMember(Name = "score")]
        public decimal Score { get; set; }

        public Mark(string subject, decimal score)
        {
            this.Subject = subject;
            this.Score = score;
        }
    }
}