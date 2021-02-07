﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GospelStoriesApi.Models
{
    public partial class GospelPost
    {
        public int GospelPostId { get; set; }
        public string GospelPostText { get; set; }
        public int? GospelUserId { get; set; }
        public DateTime? GospelPostDate { get; set; }

        public virtual GospelUser GospelUser { get; set; }
    }
}
