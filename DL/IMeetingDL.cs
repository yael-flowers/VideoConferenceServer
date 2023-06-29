﻿using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IMeetingDL
    {
        Task<ActionResult<string>> GetMeetingName(int meetingId);
        Task<List<MeetingUser>> GetMeetingUsers(int meetingId);
    }
}