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

delete from [dbo].[User]
insert into dbo.[User] (Id, FirstName, LastName, EmailAddress, PhoneNumber)
values ('7e28e1d8-be18-4a85-8f48-409fb8c7b711', 'Matthew', 'Paulosky', 'matthew.paulosky@paulosky.org', '555-453-1212'),
('7e28e1d8-be18-4a85-8f48-409fb8c7b712', 'Tammy', 'Paulosky', 'tammy.paulosky@paulosky.org', '555-453-1313'),
('7e28e1d8-be18-4a85-8f48-409fb8c7b713', 'Eric', 'Paulosky', 'eric.paulosky@paulosky.org', '555-453-1414'),
('7e28e1d8-be18-4a85-8f48-409fb8c7b714', 'Ara', 'Paulosky', 'ara.paulosky@paulosky.org', '555-453-1515');