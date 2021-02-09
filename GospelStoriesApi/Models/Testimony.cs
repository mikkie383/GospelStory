using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GospelStoriesApi.Models
{
    public partial class Testimony
    {
        public int TestimonyId { get; set; }
        public string ContentText { get; set; }
        public byte[] ContentImg { get; set; }
        public DateTime? PostDate { get; set; }
        public int GospelUserId { get; set; }
    }
}
