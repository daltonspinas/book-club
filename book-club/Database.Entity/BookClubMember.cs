using System;
using System.Collections.Generic;

namespace book_club.Database.Entity;

public partial class BookClubMember
{
    public int Id { get; set; }

    public int ClubId { get; set; }

    public int UserId { get; set; }

    public virtual BookClub Club { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
