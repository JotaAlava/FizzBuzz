
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2014 14:23:52
-- Generated from EDMX file: C:\Users\joseal\Documents\GitHub\FlexOffersFizzBuzz\FlexOffersFizzBuzz\Models\FlexOffersFizzBuzzModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FizzBuzzProdDb];
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

-- Creating table 'Operations'
CREATE TABLE [dbo].[Operations] (
    [OperationId] int IDENTITY(1,1) NOT NULL,
    [LowNumber] int  NOT NULL,
    [HighNumber] int  NOT NULL,
    [Output] nvarchar(max)  NOT NULL,
    [Result] nvarchar(max)  NOT NULL,
    [DateExecuted] datetime  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [TypeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [OperationId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [OperationId] in table 'Operations'
ALTER TABLE [dbo].[Operations]
ADD CONSTRAINT [PK_Operations]
    PRIMARY KEY CLUSTERED ([OperationId] ASC);
GO

-- Creating primary key on [TypeId] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([TypeId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OperationId] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [FK_OperationType]
    FOREIGN KEY ([OperationId])
    REFERENCES [dbo].[Operations]
        ([OperationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OperationType'
CREATE INDEX [IX_FK_OperationType]
ON [dbo].[Types]
    ([OperationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------