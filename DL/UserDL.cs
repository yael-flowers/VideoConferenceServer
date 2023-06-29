using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public class UserDL : IUserDL
    {
        VideoConferenceContext db;

        public UserDL(VideoConferenceContext _videoConferenceContext)
        {
            db = _videoConferenceContext;
        }

        public void MuteParticipant(int userId)
        {
            MeetingParticipant meetingParticipant = db.MeetingParticipants.FirstOrDefault(meeting => meeting.UserId == userId);

            if (meetingParticipant != null)
            {
                bool isMute = meetingParticipant.IsMuted;
                meetingParticipant.IsMuted = !isMute;

                db.SaveChanges();
            }
        }

        public void HandleMuteParticipant(int meetingId)
        {
            Meeting meeting = db.Meetings.FirstOrDefault(m => m.MeetingId == meetingId);
            if (meeting != null)
            {
                List<MeetingParticipant> mp = db.MeetingParticipants.Where(m => m.MeetingId == meetingId).ToList();
                mp.ForEach(mp =>
                 {
                     if (!mp.IsMuted && mp.UserId != meeting.AdminUserId)
                     {
                         mp.IsMuted = true;
                     }
                 });

                db.SaveChanges();
            }
        }
    }
}
