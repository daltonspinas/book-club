CREATE TABLE [dbo].[User] (
    [Email]    VARCHAR (50) NOT NULL,
    [Username] VARCHAR (50) NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    [UserID]   INT          NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_BookClub] FOREIGN KEY ([UserID]) REFERENCES [dbo].[BookClub] ([OwnerID])
);

