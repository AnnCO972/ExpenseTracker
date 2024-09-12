CREATE TABLE [dbo].[CreditCards]
(
	[CreditCardID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [WalletID] UNIQUEIDENTIFIER NOT NULL, 
    [CardholderName] VARCHAR(100) NOT NULL, 
    [ExpiryDate] DATETIME2 NOT NULL, 
    [CardType] VARCHAR NOT NULL, 
    [BillingAddressID] INT NOT NULL,
    FOREIGN KEY (BillingAddressID) references Addresses(AddressID)
)
