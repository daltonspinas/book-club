using book_club.Database.Entity;

namespace book_club.DTOs
{
    public class UserInfoDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public BookClubDTO[] BookClubs { get; set; }      
    }
}
