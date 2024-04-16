namespace book_club.DTOs
{
    public class BookClubDTO
    {
        public int ClubId { get; set; }

        public string ClubName { get; set; } = null!;

        public bool IsOwner { get; set; } = false;
    }
}
