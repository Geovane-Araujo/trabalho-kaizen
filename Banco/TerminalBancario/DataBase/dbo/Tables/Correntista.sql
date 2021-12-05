CREATE TABLE [dbo].[Correntista] (
    [Id]   INT        IDENTITY (1, 1) NOT NULL,
    [CPF]  NCHAR (14) NOT NULL,
    [Nome] NCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

