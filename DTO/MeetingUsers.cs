namespace DTO
{
    public class MeetingUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public bool IsMuted { get; set; }
        public bool IsAdmin { get; set; }

        public MeetingUser(int userId, string userName, string roleName, bool isMuted, bool isAdmin) { 
            this.UserId = userId;
            this.UserName = userName;
            this.RoleName = roleName;
            this.IsMuted = isMuted;
            this.IsAdmin = isAdmin;
        }
    
    }
}
