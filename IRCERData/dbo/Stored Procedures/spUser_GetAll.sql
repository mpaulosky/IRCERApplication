CREATE PROCEDURE [dbo].[spUser_GetAll]
AS
begin
	set nocount on;

	select [Id], [FirstName], [LastName], [EmailAddress], [PhoneNumber], [CreatedDate]
	from [dbo].[User];
end