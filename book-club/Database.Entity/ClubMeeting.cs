using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public partial class ClubMeeting
{
    public int MeetingId { get; set; }

    public int ClubId { get; set; }

    public string? Location { get; set; }

    public DateTime? Date { get; set; }

    public string? BookId { get; set; }

    public int? HostId { get; set; }

    public virtual BookClub Club { get; set; } = null!;

    public virtual User? Host { get; set; }

    public virtual ICollection<Rsvp> Rsvps { get; set; } = new List<Rsvp>();
}
