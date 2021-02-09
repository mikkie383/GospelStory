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
            GospelSharing = new HashSet<GospelSharing>();
        }

        public int GospelUserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Passcode { get; set; }

        public virtual ICollection<GospelSharing> GospelSharing { get; set; }
    }
}
