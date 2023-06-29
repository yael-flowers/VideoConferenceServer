using DL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class MeetingBL : IMeetingBL
    {
        IMeetingDL iMeetingDL;
        public MeetingBL(IMeetingDL _iMeetingDL)
        {
            iMeetingDL = _iMeetingDL;
        }

        public Task<ActionResult<string>> GetMeetingName(int meetingId)
        {
            return iMeetingDL.GetMeetingName(meetingId);
        }

        public async Task<List<MeetingUser>> GetMeetingUsers(int meetingId)
        {
            return await iMeetingDL.GetMeetingUsers(meetingId);
        }

    }
}
