using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public class User : IdentityUser<int>
{
    public override string Email { get; set; } = null!;

    //public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    //public int UserId { get; set; }

    //public override int Id { 
    //    get { return UserId; }
    //    set { Id = UserId; }
    //}

    public virtual ICollection<BookClubMember> BookClubMembers { get; set; } = new List<BookClubMember>();

    public virtual ICollection<ClubMeeting> ClubMeetings { get; set; } = new List<ClubMeeting>();

    public virtual ICollection<Rsvp> Rsvps { get; set; } = new List<Rsvp>();
}
