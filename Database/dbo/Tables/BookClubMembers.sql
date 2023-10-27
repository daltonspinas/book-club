CREATE TABLE [dbo].[BookClubMembers] (
    [ID]     INT NOT NULL,
    [ClubID] INT NOT NULL,
    [UserID] INT NOT NULL,
    CONSTRAINT [PK_BookClubMembers] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_BookClubMembers_BookClub] FOREIGN KEY ([ClubID]) REFERENCES [dbo].[BookClub] ([ClubID]),
    CONSTRAINT [FK_BookClubMembers_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID])
);

