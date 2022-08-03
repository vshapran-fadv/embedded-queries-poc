INSERT INTO [dbo].[Customer]
(
	[Name],
	[Address],
	[Email],
	[Phone]
)
VALUES
(@name, @address, @email, @phone)

SELECT SCOPE_IDENTITY() AS Id