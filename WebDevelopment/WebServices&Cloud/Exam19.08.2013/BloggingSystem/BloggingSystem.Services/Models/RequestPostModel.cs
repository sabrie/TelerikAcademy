﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggingSystem.Services.Models
{
    public class RequestPostModel
    {
        public string Title { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Text { get; set; }
    }
}