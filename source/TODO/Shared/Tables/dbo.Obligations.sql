CREATE TABLE [dbo].[Obligations] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (50) NOT NULL,
    [Date]    DATE          NOT NULL,
    [Note]    NVARCHAR (50) NULL DEFAULT('/'),
    [user_id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Obligations] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([user_id])
);

