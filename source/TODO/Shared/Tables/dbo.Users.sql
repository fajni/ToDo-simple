CREATE TABLE [dbo].[Users] (
    [user_id]  INT           IDENTITY (1, 1) NOT NULL,
    [name]     NVARCHAR (50) NOT NULL,
    [lastname] NVARCHAR (50) NOT NULL,
    [password] NVARCHAR (50)    NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);

