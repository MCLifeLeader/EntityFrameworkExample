/*
Post-Deployment Script Template                     
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.      
 Use SQLCMD syntax to include a file in the post-deployment script.         
 Example:      :r .\myfile.sql                        
 Use SQLCMD syntax to reference a variable in the post-deployment script.      
 Example:      :setvar TableName MyTable                     
               SELECT * FROM [$(TableName)]               
--------------------------------------------------------------------------------------
*/
GO

DECLARE @itemCount AS INT

BEGIN TRAN
IF (SELECT COUNT([Id]) AS [Id] FROM [dbo].[DbTwoTableTwoLookup] WHERE [Id] = 100) = 0
BEGIN
   INSERT INTO [dbo].[DbTwoTableTwoLookup] ([Id],[Description]) VALUES ('100','Started')
END

IF (SELECT COUNT([Id]) AS [Id] FROM [dbo].[DbTwoTableTwoLookup] WHERE [Id] = 200) = 0
BEGIN
   INSERT INTO [dbo].[DbTwoTableTwoLookup] ([Id],[Description]) VALUES ('200','Step')
END

IF (SELECT COUNT([Id]) AS [Id] FROM [dbo].[DbTwoTableTwoLookup] WHERE [Id] = 300) = 0
BEGIN
   INSERT INTO [dbo].[DbTwoTableTwoLookup] ([Id],[Description]) VALUES ('300','Finished')
END

IF (SELECT COUNT([Id]) AS [Id] FROM [dbo].[DbTwoTableTwoLookup] WHERE [Id] = 400) = 0
BEGIN
   INSERT INTO [dbo].[DbTwoTableTwoLookup] ([Id],[Description]) VALUES ('400','Abort')
END

IF (SELECT COUNT([Id]) AS [Id] FROM [dbo].[DbTwoTableTwoLookup] WHERE [Id] = 500) = 0
BEGIN
   INSERT INTO [dbo].[DbTwoTableTwoLookup] ([Id],[Description]) VALUES ('500','Error')
END

COMMIT TRAN
