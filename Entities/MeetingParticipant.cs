namespace Entities
{
    public partial class MeetingParticipant
    {
        public int MeetingParticipantId { get; set; }

        public int MeetingId { get; set; }

        public int UserId { get; set; }

        public bool IsMuted { get; set; }
    }
}