
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2018 13:37:18
-- Generated from EDMX file: C:\Users\chundjinec\Documents\Visual Studio 2017\Projects\hw144\hw144\Library.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Library];
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

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AuthorSet'
CREATE TABLE [dbo].[AuthorSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookAuthorSet'
CREATE TABLE [dbo].[BookAuthorSet] (
    [BookId] int  NOT NULL,
    [AuthorId] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] bit  NOT NULL
);
GO

-- Creating table 'BookRequestSet'
CREATE TABLE [dbo].[BookRequestSet] (
    [BookId] int  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AuthorSet'
ALTER TABLE [dbo].[AuthorSet]
ADD CONSTRAINT [PK_AuthorSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BookId], [AuthorId] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [PK_BookAuthorSet]
    PRIMARY KEY CLUSTERED ([BookId], [AuthorId] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BookId], [UserId] in table 'BookRequestSet'
ALTER TABLE [dbo].[BookRequestSet]
ADD CONSTRAINT [PK_BookRequestSet]
    PRIMARY KEY CLUSTERED ([BookId], [UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookId] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [FK_BookBookAuthor]
    FOREIGN KEY ([BookId])
    REFERENCES [dbo].[BookSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BookId] in table 'BookRequestSet'
ALTER TABLE [dbo].[BookRequestSet]
ADD CONSTRAINT [FK_BookBookRequest]
    FOREIGN KEY ([BookId])
    REFERENCES [dbo].[BookSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AuthorId] in table 'BookAuthorSet'
ALTER TABLE [dbo].[BookAuthorSet]
ADD CONSTRAINT [FK_AuthorBookAuthor]
    FOREIGN KEY ([AuthorId])
    REFERENCES [dbo].[AuthorSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthorBookAuthor'
CREATE INDEX [IX_FK_AuthorBookAuthor]
ON [dbo].[BookAuthorSet]
    ([AuthorId]);
GO

-- Creating foreign key on [UserId] in table 'BookRequestSet'
ALTER TABLE [dbo].[BookRequestSet]
ADD CONSTRAINT [FK_UserBookRequest]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserBookRequest'
CREATE INDEX [IX_FK_UserBookRequest]
ON [dbo].[BookRequestSet]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------