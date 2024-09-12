CREATE TABLE [dbo].[Addresses]
(
	[AddressID] INT NOT NULL PRIMARY KEY, 
    [StreetNumber] INT NULL, 
    [StreetAddress] VARCHAR(95) NULL, 
    [City] VARCHAR(35) NULL, 
    [ZipCode] VARCHAR(15) NULL, 
    [State] VARCHAR(35) NULL, 
    [Country] VARCHAR(35) NULL
)
