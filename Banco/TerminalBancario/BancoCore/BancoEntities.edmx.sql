
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2021 00:03:54
-- Generated from EDMX file: E:\faculdade\Topicos Avancados\Projeto Final\Banco\TerminalBancario\BancoCore\BancoEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DataBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ContaCorrentista]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Conta] DROP CONSTRAINT [FK_ContaCorrentista];
GO
IF OBJECT_ID(N'[dbo].[FK_ContaLancamentos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Lancamentos] DROP CONSTRAINT [FK_ContaLancamentos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Conta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conta];
GO
IF OBJECT_ID(N'[dbo].[Correntista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Correntista];
GO
IF OBJECT_ID(N'[dbo].[Lancamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lancamentos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Conta'
CREATE TABLE [dbo].[Conta] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CorrentistaId] int  NOT NULL,
    [LimiteCredito] decimal(19,4)  NOT NULL,
    [Saldo] decimal(19,4)  NOT NULL,
    [DataAbertura] datetime  NULL
);
GO

-- Creating table 'Correntista'
CREATE TABLE [dbo].[Correntista] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CPF] nchar(16)  NOT NULL,
    [Nome] nchar(50)  NOT NULL
);
GO

-- Creating table 'Lancamentos'
CREATE TABLE [dbo].[Lancamentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] datetime  NOT NULL,
    [ContaId] int  NOT NULL,
    [Operacao] int  NOT NULL,
    [Historico] nchar(10)  NOT NULL,
    [Valor] decimal(19,4)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Conta'
ALTER TABLE [dbo].[Conta]
ADD CONSTRAINT [PK_Conta]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Correntista'
ALTER TABLE [dbo].[Correntista]
ADD CONSTRAINT [PK_Correntista]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lancamentos'
ALTER TABLE [dbo].[Lancamentos]
ADD CONSTRAINT [PK_Lancamentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CorrentistaId] in table 'Conta'
ALTER TABLE [dbo].[Conta]
ADD CONSTRAINT [FK_ContaCorrentista]
    FOREIGN KEY ([CorrentistaId])
    REFERENCES [dbo].[Correntista]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContaCorrentista'
CREATE INDEX [IX_FK_ContaCorrentista]
ON [dbo].[Conta]
    ([CorrentistaId]);
GO

-- Creating foreign key on [ContaId] in table 'Lancamentos'
ALTER TABLE [dbo].[Lancamentos]
ADD CONSTRAINT [FK_ContaLancamentos]
    FOREIGN KEY ([ContaId])
    REFERENCES [dbo].[Conta]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContaLancamentos'
CREATE INDEX [IX_FK_ContaLancamentos]
ON [dbo].[Lancamentos]
    ([ContaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------