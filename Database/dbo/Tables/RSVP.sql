CREATE TABLE [dbo].[RSVP] (
    [ID]         INT NOT NULL,
    [MeetingID]  INT NOT NULL,
    [UserID]     INT NOT NULL,
    [RSVPStatus] BIT NULL,
    CONSTRAINT [PK_RSVP] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_RSVP_ClubMeeting] FOREIGN KEY ([MeetingID]) REFERENCES [dbo].[ClubMeeting] ([MeetingID]),
    CONSTRAINT [FK_RSVP_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([UserID])
);

