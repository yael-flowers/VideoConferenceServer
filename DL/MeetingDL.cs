using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL
{
    public class MeetingDL : IMeetingDL
    {
        VideoConferenceContext db;

        public MeetingDL(VideoConferenceContext _videoConferenceContext)
        {
            db = _videoConferenceContext;
        }

        public async Task<ActionResult<string>> GetMeetingName(int meetingId)
        {
             Meeting meeting = await db.Meetings.FirstOrDefaultAsync(meeting => meeting.MeetingId == meetingId);
             if(meeting != null)
             {
                 return meeting.MeetingName;
             }
             return null;
        }

        public async Task<List<MeetingUser>> GetMeetingUsers(int meetingId)
        {
            List<MeetingUser> meetingUsers = new List<MeetingUser>();
            
            var query = from mp in db.MeetingParticipants
                        join m in db.Meetings on mp.MeetingId equals m.MeetingId
                        join u in db.Users on mp.UserId equals u.UserId
                        join r in db.Roles on u.RoleId equals r.RoleId
                        where mp.MeetingId == meetingId
                        select new
                        {
                            mp.UserId,
                            u.Username,
                            r.RoleName,
                            mp.IsMuted,
                            m.AdminUserId
                        };

            await query.ForEachAsync(mp =>
            {
                MeetingUser user = new MeetingUser(mp.UserId, mp.Username, mp.RoleName, mp.IsMuted, mp.AdminUserId == mp.UserId);
                meetingUsers.Add(user);
            });

            return meetingUsers;
        }

    }
}
