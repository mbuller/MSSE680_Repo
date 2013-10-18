
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2013 22:27:43
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
