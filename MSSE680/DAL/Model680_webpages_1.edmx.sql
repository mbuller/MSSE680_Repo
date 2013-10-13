
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/12/2013 11:38:31
-- Generated from EDMX file: C:\Users\mbuller\Documents\Visual Studio 2012\Projects\MSSE680_SPF3\DAL\Model680.edmx
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
IF OBJECT_ID(N'[dbo].[fk_RoleId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_RoleId];
GO
IF OBJECT_ID(N'[dbo].[fk_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_UserId];
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
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
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
    [City] nvarchar(50)  NOT NULL,
    [Street] nvarchar(50)  NOT NULL,
    [State] nvarchar(50)  NOT NULL,
    [Zipcode] int  NOT NULL
);
GO

-- Creating table 'CreditCards'
CREATE TABLE [dbo].[CreditCards] (
    [CreditCardId] int IDENTITY(1,1) NOT NULL,
    [CreditCardNumber] bigint  NOT NULL,
    [CardType] tinyint  NOT NULL,
    [Limit] int  NOT NULL,
    [Balance] decimal(10,4)  NOT NULL,
    [ExpirationMonth] tinyint  NOT NULL,
    [ExpirationYear] tinyint  NOT NULL,
    [CreditCardUser_PersonId] int  NULL,
    [Account_AccountId] int  NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [PersonId] int IDENTITY(1,1) NOT NULL,
    [Age] tinyint  NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [UserName] nvarchar(50)  NULL,
    [Address_AddressId] int  NULL,
    [Password] nvarchar(50)  NULL
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

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [webpages_Roles_RoleId] int  NOT NULL,
    [People_PersonId] int  NOT NULL
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

-- Creating primary key on [CreditCardId] in table 'CreditCards'
ALTER TABLE [dbo].[CreditCards]
ADD CONSTRAINT [PK_CreditCards]
    PRIMARY KEY CLUSTERED ([CreditCardId] ASC);
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

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [webpages_Roles_RoleId], [People_PersonId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY NONCLUSTERED ([webpages_Roles_RoleId], [People_PersonId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

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

-- Creating foreign key on [webpages_Roles_RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_webpages_Roles]
    FOREIGN KEY ([webpages_Roles_RoleId])
    REFERENCES [dbo].[webpages_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [People_PersonId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [FK_webpages_UsersInRoles_Person]
    FOREIGN KEY ([People_PersonId])
    REFERENCES [dbo].[People]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_webpages_UsersInRoles_Person'
CREATE INDEX [IX_FK_webpages_UsersInRoles_Person]
ON [dbo].[webpages_UsersInRoles]
    ([People_PersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------