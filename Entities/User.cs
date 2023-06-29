using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class User
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();

        public virtual Role Role { get; set; } = null!;
    }
}