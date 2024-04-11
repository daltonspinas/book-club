using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public class User : IdentityUser<int>
{
    public virtual ICollection<BookClubMember> BookClubMembers { get; set; } = new List<BookClubMember>();

    public virtual ICollection<ClubMeeting> ClubMeetings { get; set; } = new List<ClubMeeting>();

    public virtual ICollection<Rsvp> Rsvps { get; set; } = new List<Rsvp>();
}
