using book_club.Database.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Runtime.CompilerServices;

namespace book_club.Database.Context
{
    public static class ModelBuilderExtensions
    {
        public static async Task Seed(this ModelBuilder modelBuilder)
        {

            var owner = CreateSeedUser("Demo Owner 1", "test@gmail.com", "Password123!", 1);
            var member1 = CreateSeedUser("Demo Member 1", "test1@gmail.com", "Password123!", 2);
            var member2 = CreateSeedUser("Demo Member 2", "test2@gmail.com", "Password123!", 3);
            var member3 = CreateSeedUser("Demo Member 3", "test3@gmail.com", "Password123!", 4);

            modelBuilder.Entity<User>().HasData(
                owner,
                member1,
                member2,
                member3
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

        private static User CreateSeedUser(string username, string email, string password, int id)
        {
            var passHasher = new PasswordHasher<User>();
            var user = new User { Id = id, UserName = username, NormalizedUserName = username.ToUpper(), Email = email, NormalizedEmail = email.ToUpper() };
            user.PasswordHash = passHasher.HashPassword(user, password);
            return user;
        }
    }
}
