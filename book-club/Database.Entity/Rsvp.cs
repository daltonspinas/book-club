using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public partial class Rsvp
{
    public int Id { get; set; }

    public int MeetingId { get; set; }

    public int UserId { get; set; }

    public bool? Rsvpstatus { get; set; }

    public virtual ClubMeeting Meeting { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
