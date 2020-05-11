CREATE TABLE [dbo].[DbOneTableOne] (
    [Id]                      INT            NOT NULL IDENTITY(1,1),
    [DbOneTableTwoLookupId]   SMALLINT       NOT NULL,
    [Data]                    VARCHAR (50)   NOT NULL, 
    [DateCreated]             DATETIME       NOT NULL DEFAULT(GetUtcDate()),

    CONSTRAINT [PK_DbOneTableOne] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_DbOneTableOne_Lookup] FOREIGN KEY ([DbOneTableTwoLookupId]) REFERENCES [DbOneTableTwoLookup]([Id])
);


GO

CREATE INDEX [IX_DbOneTableOne_Data] ON [dbo].[DbOneTableOne] ([Data])
