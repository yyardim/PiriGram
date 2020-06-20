CREATE TABLE [dbo].[Clips] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Title]        NVARCHAR (100)   NOT NULL,
    [Description]  NVARCHAR (2000)  NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [DateCreated]  DATETIME         CONSTRAINT [DF_Clips_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateModified] DATETIME         NOT NULL,
    CONSTRAINT [PK_Clips] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Clips_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

