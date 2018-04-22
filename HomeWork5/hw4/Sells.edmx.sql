
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2018 02:02:03
-- Generated from EDMX file: C:\Users\chundjinec\Documents\Visual Studio 2017\Projects\hw4\hw4\Sells.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BuyersSet'
CREATE TABLE [dbo].[BuyersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SellersSet'
CREATE TABLE [dbo].[SellersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Sells'
CREATE TABLE [dbo].[Sells] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sum] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [BuyersId] int  NOT NULL,
    [SellersId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BuyersSet'
ALTER TABLE [dbo].[BuyersSet]
ADD CONSTRAINT [PK_BuyersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SellersSet'
ALTER TABLE [dbo].[SellersSet]
ADD CONSTRAINT [PK_SellersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Sells'
ALTER TABLE [dbo].[Sells]
ADD CONSTRAINT [PK_Sells]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BuyersId] in table 'Sells'
ALTER TABLE [dbo].[Sells]
ADD CONSTRAINT [FK_BuyersSell]
    FOREIGN KEY ([BuyersId])
    REFERENCES [dbo].[BuyersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BuyersSell'
CREATE INDEX [IX_FK_BuyersSell]
ON [dbo].[Sells]
    ([BuyersId]);
GO

-- Creating foreign key on [SellersId] in table 'Sells'
ALTER TABLE [dbo].[Sells]
ADD CONSTRAINT [FK_SellersSell]
    FOREIGN KEY ([SellersId])
    REFERENCES [dbo].[SellersSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SellersSell'
CREATE INDEX [IX_FK_SellersSell]
ON [dbo].[Sells]
    ([SellersId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------