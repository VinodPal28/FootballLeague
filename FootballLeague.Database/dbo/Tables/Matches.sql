CREATE TABLE [dbo].[Matches] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [MatchNo]     INT          NULL,
    [Team1]       VARCHAR (50) NULL,
    [Team2]       VARCHAR (50) NULL,
    [Score1]      INT          NULL,
    [Score2]      INT          NULL,
    [createdBy]   INT          NULL,
    [createdDate] DATETIME     NULL,
    [updatedBy]   INT          NULL,
    [updatedDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

