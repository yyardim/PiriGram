CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserName]     NVARCHAR (50)    NOT NULL,
    [FirstName]    NVARCHAR (50)    NULL,
    [MiddleName]   NVARCHAR (50)    NULL,
    [LastName]     NVARCHAR (50)    NULL,
    [Email]        NVARCHAR (40)    NOT NULL,
    [AvatarUrl] NVARCHAR(100) NULL, 
    [About]        NVARCHAR (2000)  NULL,
    [DateCreated]  DATETIME         CONSTRAINT [DF_Users_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateModified] DATETIME         NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

