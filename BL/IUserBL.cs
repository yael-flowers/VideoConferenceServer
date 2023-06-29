namespace BL
{
    public interface IUserBL
    {
        void HandleMuteParticipant(int userId);
        void MuteAllParticipants(int meetingId);
    }
}