using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GospelStoriesApi.Models
{
    public partial class GospelUser
    {
        public GospelUser()
        {
            GospelPost = new HashSet<GospelPost>();
        }

        public int GospelUserId { get; set; }
        public string GospelLastName { get; set; }
        public string GospelFirstName { get; set; }

        public virtual ICollection<GospelPost> GospelPost { get; set; }
    }
}
