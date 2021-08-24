CREATE TABLE [dbo].[Teams] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Flag]        INT          NULL,
    [createBy]    INT          NULL,
    [createdDate] DATETIME     NULL,
    [updatedBy]   INT          NULL,
    [updatedDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

