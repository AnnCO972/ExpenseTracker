CREATE TABLE [dbo].[Users]
(
	[UserID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Firstname] VARCHAR(50) NOT NULL, 
    [Lastname] VARCHAR(50) NOT NULL, 
    [Birthdate] DATETIME2 NOT NULL, 
    [EmailAddress] VARCHAR(100) NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    [AddressID] INT NOT NULL, 
    [WalletID] UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (AddressID) REFERENCES Addresses(AddressID),
    FOREIGN KEY (WalletID) REFERENCES Wallets(WalletID)
)
