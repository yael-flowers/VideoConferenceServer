using DL;

namespace BL
{
    public class UserBL: IUserBL
    {
        IUserDL iUserDL;
        public UserBL(IUserDL userDl)
        {
            iUserDL = userDl;
        }
        public void HandleMuteParticipant(int userId)
        {
            iUserDL.HandleMuteParticipant(userId);
        }
        public void MuteAllParticipants(int meetingId)
        {
            iUserDL.MuteAllParticipants(meetingId);
        }

    }
}
