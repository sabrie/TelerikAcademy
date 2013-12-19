
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/17/2013 13:06:04
-- Generated from EDMX file: C:\Users\Adrian\Documents\Visual Studio 2013\Projects\Teamwork\TeamEmereald\EmeraldForum\EmeraldForum\EmeraldForum.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EmeraldForum];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comments_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Comments_Posts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comments_Posts];
GO
IF OBJECT_ID(N'[dbo].[FK_Posts_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Posts] DROP CONSTRAINT [FK_Posts_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_PostsTags_Posts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostsTags] DROP CONSTRAINT [FK_PostsTags_Posts];
GO
IF OBJECT_ID(N'[dbo].[FK_PostsTags_Tags]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PostsTags] DROP CONSTRAINT [FK_PostsTags_Tags];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Posts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Posts];
GO
IF OBJECT_ID(N'[dbo].[PostsTags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostsTags];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tags]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tags];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NULL,
    [Email] nvarchar(50)  NULL,
    [PhotoPath] nvarchar(100)  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [UserId] nvarchar(128)  NULL,
    [PostId] int  NULL
);
GO

-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(200)  NULL,
    [Content] nvarchar(max)  NULL,
    [PostDate] datetime  NULL,
    [UserId] nvarchar(128)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL
);
GO

-- Creating table 'PostsTags'
CREATE TABLE [dbo].[PostsTags] (
    [Posts_Id] int  NOT NULL,
    [Tags_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'Tags'
ALTER TABLE [dbo].[Tags]
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Posts_Id], [Tags_Id] in table 'PostsTags'
ALTER TABLE [dbo].[PostsTags]
ADD CONSTRAINT [PK_PostsTags]
    PRIMARY KEY CLUSTERED ([Posts_Id], [Tags_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_AspNetUsers'
CREATE INDEX [IX_FK_Comments_AspNetUsers]
ON [dbo].[Comments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Posts'
ALTER TABLE [dbo].[Posts]
ADD CONSTRAINT [FK_Posts_AspNetUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Posts_AspNetUsers'
CREATE INDEX [IX_FK_Posts_AspNetUsers]
ON [dbo].[Posts]
    ([UserId]);
GO

-- Creating foreign key on [PostId] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comments_Posts]
    FOREIGN KEY ([PostId])
    REFERENCES [dbo].[Posts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Comments_Posts'
CREATE INDEX [IX_FK_Comments_Posts]
ON [dbo].[Comments]
    ([PostId]);
GO

-- Creating foreign key on [Posts_Id] in table 'PostsTags'
ALTER TABLE [dbo].[PostsTags]
ADD CONSTRAINT [FK_PostsTags_Posts]
    FOREIGN KEY ([Posts_Id])
    REFERENCES [dbo].[Posts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tags_Id] in table 'PostsTags'
ALTER TABLE [dbo].[PostsTags]
ADD CONSTRAINT [FK_PostsTags_Tags]
    FOREIGN KEY ([Tags_Id])
    REFERENCES [dbo].[Tags]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PostsTags_Tags'
CREATE INDEX [IX_FK_PostsTags_Tags]
ON [dbo].[PostsTags]
    ([Tags_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------