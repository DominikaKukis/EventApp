
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/21/2019 17:16:41
-- Generated from EDMX file: D:\Studia\Semestr VI\Nowoczesne technologie programistyczne\Projekt\EventApp\EventApp\Models\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbEvent];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EventTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventTable];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EventTable'
CREATE TABLE [dbo].[EventTable] (
    [Id] int  NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Address] varchar(50)  NOT NULL,
    [StartTime] datetime  NULL,
    [EndTime] datetime  NULL,
    [Organizer] varchar(50)  NOT NULL,
    [Cost] float  NULL,
    [LimitOfPlace] int  NULL,
    [AgeRequirement] int  NULL,
    [Comment] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EventTable'
ALTER TABLE [dbo].[EventTable]
ADD CONSTRAINT [PK_EventTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------