namespace Entities
{
    public partial class Meeting
    {
        public int MeetingId { get; set; }

        public string MeetingName { get; set; } = null!;

        public int AdminUserId { get; set; }

        public virtual User AdminUser { get; set; } = null!;
    }
}