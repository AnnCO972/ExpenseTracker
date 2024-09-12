CREATE TABLE [dbo].[Transactions]
(
	[TransactionsID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [WalletID] UNIQUEIDENTIFIER NOT NULL, 
    [CreditCardID] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [TransactionDate] DATETIME2 NOT NULL, 
    [Vendor] VARCHAR(100) NULL, 
    [Category] VARCHAR(50) NOT NULL, 
    [ReceiptURL] VARCHAR(MAX) NULL,
    FOREIGN KEY (WalletID) references Wallets(WalletID),
    FOREIGN KEY (CreditCardID) references CreditCards(CreditCardID)
)
