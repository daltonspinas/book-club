CREATE TABLE [dbo].[BookClub] (
    [ClubID]   INT          NOT NULL,
    [ClubName] VARCHAR (50) NOT NULL,
    [OwnerID]  INT          NOT NULL,
    CONSTRAINT [PK_BookClub] PRIMARY KEY CLUSTERED ([ClubID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_BookClub]
    ON [dbo].[BookClub]([OwnerID] ASC);

