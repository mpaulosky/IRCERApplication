CREATE PROCEDURE [dbo].[spUser_InsertSet]
	@people BasicUserDT readonly
AS
BEGIN
	INSERT INTO [dbo].[User](FirstName, LastName, EmailAddress, PhoneNumber)
	SELECT [FirstName], [LastName], [EmailAddress], [PhoneNumber]
	FROM @people;
end
