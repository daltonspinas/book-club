using book_club.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace book_club.Database.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Demo Owner 1", Email = "test@gmail.com", Password = "password" },
                new User { Id = 2, UserName = "Demo Member 1", Email = "test@gmail.com", Password = "password" },
                new User { Id = 3, UserName = "Demo Member 2", Email = "test@gmail.com", Password = "password" },
                new User { Id = 4, UserName = "Demo Member 3", Email = "test@gmail.com", Password = "password" }
            );

            modelBuilder.Entity<BookClub>().HasData(
                new BookClub { ClubId = 1, ClubName = "Demo Book Club", OwnerId = 1 }
            );

            modelBuilder.Entity<BookClubMember>().HasData(
                new BookClubMember { Id = 1, ClubId = 1, UserId = 1 },
                new BookClubMember { Id = 2, ClubId = 1, UserId = 2 },
                new BookClubMember { Id = 3, ClubId = 1, UserId = 3 },
                new BookClubMember { Id = 4, ClubId = 1, UserId = 4 }
            );

            modelBuilder.Entity<ClubMeeting>().HasData(
                new ClubMeeting { MeetingId = 1, ClubId = 1, HostId = 3, Location = "1234 Address, City, State, Zip" , Date = DateTime.Now.AddDays(5)}
            );
        }
    }
}
