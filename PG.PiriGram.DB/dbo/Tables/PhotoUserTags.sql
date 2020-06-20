CREATE TABLE [dbo].[PhotoUserTags] (
    [PhotoId]      UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [TaggedBy]     UNIQUEIDENTIFIER NOT NULL,
    [DateCreated]  DATETIME         CONSTRAINT [DF_PhotoUserTags_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateModified] DATETIME         CONSTRAINT [DF_PhotoUserTags_DateModified] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_PhotoUserTags] PRIMARY KEY CLUSTERED ([PhotoId] ASC, [UserId] ASC),
    CONSTRAINT [FK_PhotoUserTags_Photos] FOREIGN KEY ([PhotoId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_PhotoUserTags_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

