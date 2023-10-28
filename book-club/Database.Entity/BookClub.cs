using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public partial class BookClub
{
    public int ClubId { get; set; }

    public string ClubName { get; set; } = null!;

    public int OwnerId { get; set; }

    public virtual ICollection<BookClubMember> BookClubMembers { get; set; } = new List<BookClubMember>();

    public virtual ICollection<ClubMeeting> ClubMeetings { get; set; } = new List<ClubMeeting>();

    public virtual User? User { get; set; }
}
