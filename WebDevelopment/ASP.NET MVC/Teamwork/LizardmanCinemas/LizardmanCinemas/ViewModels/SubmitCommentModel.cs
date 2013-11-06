﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LizardmanCinemas.ViewModels
{
    public class SubmitCommentModel
    {
        [Required]
        public string CommentText { get; set; }

        [Required]
        public int MovieId { get; set; }
    }
}