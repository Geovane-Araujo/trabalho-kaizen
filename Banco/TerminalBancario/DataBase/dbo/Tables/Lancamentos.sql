CREATE TABLE [dbo].[Lancamentos] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [Data]      DATETIME   DEFAULT (getdate()) NOT NULL,
    [ContaId]   INT        DEFAULT ((0)) NOT NULL,
    [Operacao]  INT        DEFAULT ((0)) NOT NULL,
    [Historico] NCHAR (10) DEFAULT ('') NOT NULL,
    [Valor]     MONEY      DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContaLancamentos] FOREIGN KEY ([ContaId]) REFERENCES [dbo].[Conta] ([Id])
);

