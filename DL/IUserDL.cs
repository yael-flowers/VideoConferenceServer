namespace DL
{
    public interface IUserDL
    {
        void HandleMuteParticipant(int userId);
        void MuteAllParticipants(int meetingId);
    }
}