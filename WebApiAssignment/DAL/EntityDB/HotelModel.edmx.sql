
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/26/2021 18:39:51
-- Generated from EDMX file: C:\Users\aarsh.modi\GATEWAY-ASSIGNMENTS\WebApiAssignment\DAL\EntityDB\HotelModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Bookings_Rooms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bookings] DROP CONSTRAINT [FK_Bookings_Rooms];
GO
IF OBJECT_ID(N'[dbo].[FK_Rooms_Hotel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rooms] DROP CONSTRAINT [FK_Rooms_Hotel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Bookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bookings];
GO
IF OBJECT_ID(N'[dbo].[Hotels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hotels];
GO
IF OBJECT_ID(N'[dbo].[Rooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rooms];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Bookings'
CREATE TABLE [dbo].[Bookings] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Booking_Date] datetime  NOT NULL,
    [Room_ID] bigint  NOT NULL,
    [Status] nvarchar(50)  NULL
);
GO

-- Creating table 'Hotels'
CREATE TABLE [dbo].[Hotels] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Address] nvarchar(max)  NULL,
    [City] nvarchar(50)  NOT NULL,
    [Pincode] nvarchar(25)  NOT NULL,
    [Contact_Number] nvarchar(50)  NOT NULL,
    [Contatct_Person] nvarchar(50)  NOT NULL,
    [Website] nvarchar(50)  NOT NULL,
    [Facebook] nvarchar(50)  NOT NULL,
    [Twitter] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [Created_Date] datetime  NOT NULL,
    [Created_By] nvarchar(50)  NULL,
    [Updated_Date] datetime  NOT NULL,
    [Updated_By] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [ID] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Category] nvarchar(50)  NULL,
    [Price] decimal(19,4)  NULL,
    [IsActive] bit  NOT NULL,
    [Created_Date] datetime  NULL,
    [Created_By] nvarchar(50)  NULL,
    [Updated_Date] datetime  NULL,
    [Updated_By] nvarchar(50)  NULL,
    [Hotel_ID] bigint  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [PK_Bookings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Hotels'
ALTER TABLE [dbo].[Hotels]
ADD CONSTRAINT [PK_Hotels]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Room_ID] in table 'Bookings'
ALTER TABLE [dbo].[Bookings]
ADD CONSTRAINT [FK_Bookings_Rooms]
    FOREIGN KEY ([Room_ID])
    REFERENCES [dbo].[Rooms]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bookings_Rooms'
CREATE INDEX [IX_FK_Bookings_Rooms]
ON [dbo].[Bookings]
    ([Room_ID]);
GO

-- Creating foreign key on [Hotel_ID] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [FK_Rooms_Hotel]
    FOREIGN KEY ([Hotel_ID])
    REFERENCES [dbo].[Hotels]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Rooms_Hotel'
CREATE INDEX [IX_FK_Rooms_Hotel]
ON [dbo].[Rooms]
    ([Hotel_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------