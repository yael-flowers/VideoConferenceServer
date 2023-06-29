using BL;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace VideoConferenceSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingParticipanteController : ControllerBase
    {
        IUserBL iUserBL;
        IMeetingBL iMeetingBL;

        public MeetingParticipanteController(IUserBL _iUserBL, IMeetingBL _iMeetingBL)
        {
            iUserBL = _iUserBL;
            iMeetingBL = _iMeetingBL;
        }

        [HttpGet]
        [Route("[action]/{meetingId}")]
        public Task<ActionResult<string>> GetMeetingName(int meetingId)
        {
            //maybe we should amend the logic of this function with GetMeetingParticipants function
            //to avoid force access to the DB
            return iMeetingBL.GetMeetingName(meetingId);
        }

        [HttpGet]
        [Route("[action]/{meetingId}")]
        public Task<List<MeetingUser>> GetMeetingParticipants(int meetingId)
        {
            return iMeetingBL.GetMeetingUsers(meetingId);
        }

        [HttpPost]
        [Route("[action]/{userId}")]
        public void HandleMuteParticipant(int userId)
        {
            iUserBL.HandleMuteParticipant(userId);
        }

        [HttpPost]
        [Route("[action]/{meetingId}")]
        public void MuteAllParticipants(int meetingId)
        {
            iUserBL.MuteAllParticipants(meetingId);
        }
    }
}
