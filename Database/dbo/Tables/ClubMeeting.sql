CREATE TABLE [dbo].[ClubMeeting] (
    [MeetingID] INT           NOT NULL,
    [ClubID]    INT           NOT NULL,
    [Location]  VARCHAR (MAX) NULL,
    [Date]      DATE          NULL,
    [BookID]    VARCHAR (MAX) NULL,
    [HostID]    INT           NULL,
    CONSTRAINT [PK_ClubMeeting] PRIMARY KEY CLUSTERED ([MeetingID] ASC),
    CONSTRAINT [FK_ClubMeeting_BookClub] FOREIGN KEY ([ClubID]) REFERENCES [dbo].[BookClub] ([ClubID]),
    CONSTRAINT [FK_ClubMeeting_User] FOREIGN KEY ([HostID]) REFERENCES [dbo].[User] ([UserID])
);

