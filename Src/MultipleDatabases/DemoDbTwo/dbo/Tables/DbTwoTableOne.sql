CREATE TABLE [dbo].[DbTwoTableOne] (
    [Id]                      INT            NOT NULL IDENTITY(1,1),
    [DbTwoTableTwoLookupId]   SMALLINT       NOT NULL,
    [Data]                    VARCHAR (50)   NOT NULL, 
    [DateCreated]             DATETIME       NOT NULL DEFAULT(GetUtcDate()),
    
    CONSTRAINT [PK_DbTwoTableOne] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_DbTwoTableOne_Lookup] FOREIGN KEY ([DbTwoTableTwoLookupId]) REFERENCES [DbTwoTableTwoLookup]([Id])
);


GO

CREATE INDEX [IX_DbOneTableOne_Data] ON [dbo].[DbTwoTableOne] ([Data])
