-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2013 00:25:31
-- Generated from EDMX file: C:\Users\mbuller\Documents\GitHub\MSSE680_Repo\MSSE680\DAL\Model680.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [buller];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Accounts_dbo_CreditCards_CreditCard_CreditCardId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_dbo_Accounts_dbo_CreditCards_CreditCard_CreditCardId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Accounts_dbo_People_AccountUser_PersonId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accounts] DROP CONSTRAINT [FK_dbo_Accounts_dbo_People_AccountUser_PersonId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Addresses_dbo_People_Person_PersonId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_dbo_Addresses_dbo_People_Person_PersonId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CreditCards_dbo_Accounts_Account_AccountId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCards] DROP CONSTRAINT [FK_dbo_CreditCards_dbo_Accounts_Account_AccountId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_CreditCards_dbo_People_CreditCardUser_PersonId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditCards] DROP CONSTRAINT [FK_dbo_CreditCards_dbo_People_CreditCardUser_PersonId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_People_dbo_Addresses_Address_AddressId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[People] DROP CONSTRAINT [FK_dbo_People_dbo_Addresses_Address_AddressId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Transactions_dbo_CreditCards_CreditCard_CreditCardId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_dbo_Transactions_dbo_CreditCards_CreditCard_CreditCardId];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[CreditCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditCards];
GO
IF OBJECT_ID(N'[dbo].[People]', 'U') IS NOT NULL
    DROP TABLE [dbo].[People];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountId] int IDENTITY(1,1) NOT NULL,
    [CreditCard_CreditCardId] int  NULL,
    [AccountUser_PersonId] int  NULL,
    [Limit] int  NOT NULL,
    [Balance] decimal(10,4)  NOT NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [AddressId] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(50)  NULL,
    [Street] nvarchar(50)  NULL,
    [State] nvarchar(50)  NULL,
    [Zipcode] int  NULL,
    [Person_PersonId] int  NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PersonId] int IDENTITY(1,1) NOT NULL,
    [Age] tinyint  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [Address_AddressId] int  NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [TransactionId] int IDENTITY(1,1) NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [TransactionDay] tinyint  NOT NULL,
    [TransactionMonth] tinyint  NOT NULL,
    [TransactionYear] tinyint  NOT NULL,
    [BusinessName] nvarchar(25)  NOT NULL,
    [CreditCard_CreditCardId] int  NULL
);
GO

-- Creating table 'CreditCards'
CREATE TABLE [dbo].[CreditCards] (
    [CreditCardId] int IDENTITY(1,1) NOT NULL,
    --[CreditCardNumber] bigint  NULL,
		[CreditCardNumber] AS ([CreditCardId] + CAST (9000000000000000 as BigInt)),
    [CardType] tinyint  NULL,
    [Limit] int  NULL,
    [Balance] decimal(10,4)  NULL default 2,
    [ExpirationMonth] tinyint  NULL,
    [ExpirationYear] tinyint  NULL,
    [CreditCardUser_PersonId] int  NULL,
    [Account_AccountId] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [AddressId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([AddressId] ASC);
GO

-- Creating primary key on [PersonId] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [TransactionId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([TransactionId] ASC);
GO

-- Creating primary key on [CreditCardId] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [PK_CreditCards]
    PRIMARY KEY CLUSTERED ([CreditCardId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountUser_PersonId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_dbo_Accounts_dbo_People_AccountUser_PersonId]
    FOREIGN KEY ([AccountUser_PersonId])
    REFERENCES [dbo].[People]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Accounts_dbo_People_AccountUser_PersonId'
CREATE INDEX [IX_FK_dbo_Accounts_dbo_People_AccountUser_PersonId]
ON [dbo].[Accounts]
    ([AccountUser_PersonId]);
GO

-- Creating foreign key on [Person_PersonId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_dbo_Addresses_dbo_People_Person_PersonId]
    FOREIGN KEY ([Person_PersonId])
    REFERENCES [dbo].[People]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Addresses_dbo_People_Person_PersonId'
CREATE INDEX [IX_FK_dbo_Addresses_dbo_People_Person_PersonId]
ON [dbo].[Addresses]
    ([Person_PersonId]);
GO

-- Creating foreign key on [Address_AddressId] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [FK_dbo_People_dbo_Addresses_Address_AddressId]
    FOREIGN KEY ([Address_AddressId])
    REFERENCES [dbo].[Addresses]
        ([AddressId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_People_dbo_Addresses_Address_AddressId'
CREATE INDEX [IX_FK_dbo_People_dbo_Addresses_Address_AddressId]
ON [dbo].[People]
    ([Address_AddressId]);
GO

-- Creating foreign key on [CreditCard_CreditCardId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK_dbo_Accounts_dbo_CreditCards_CreditCard_CreditCardId]
    FOREIGN KEY ([CreditCard_CreditCardId])
    REFERENCES [dbo].[CreditCards]
        ([CreditCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Accounts_dbo_CreditCards_CreditCard_CreditCardId'
CREATE INDEX [IX_FK_dbo_Accounts_dbo_CreditCards_CreditCard_CreditCardId]
ON [dbo].[Accounts]
    ([CreditCard_CreditCardId]);
GO

-- Creating foreign key on [Account_AccountId] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [FK_dbo_CreditCards_dbo_Accounts_Account_AccountId]
    FOREIGN KEY ([Account_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CreditCards_dbo_Accounts_Account_AccountId'
CREATE INDEX [IX_FK_dbo_CreditCards_dbo_Accounts_Account_AccountId]
ON [dbo].[CreditCards]
    ([Account_AccountId]);
GO

-- Creating foreign key on [CreditCardUser_PersonId] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [FK_dbo_CreditCards_dbo_People_CreditCardUser_PersonId]
    FOREIGN KEY ([CreditCardUser_PersonId])
    REFERENCES [dbo].[People]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_CreditCards_dbo_People_CreditCardUser_PersonId'
CREATE INDEX [IX_FK_dbo_CreditCards_dbo_People_CreditCardUser_PersonId]
ON [dbo].[CreditCards]
    ([CreditCardUser_PersonId]);
GO

-- Creating foreign key on [CreditCard_CreditCardId] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_dbo_Transactions_dbo_CreditCards_CreditCard_CreditCardId]
    FOREIGN KEY ([CreditCard_CreditCardId])
    REFERENCES [dbo].[CreditCards]
        ([CreditCardId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Transactions_dbo_CreditCards_CreditCard_CreditCardId'
CREATE INDEX [IX_FK_dbo_Transactions_dbo_CreditCards_CreditCard_CreditCardId]
ON [dbo].[Transactions]
    ([CreditCard_CreditCardId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
