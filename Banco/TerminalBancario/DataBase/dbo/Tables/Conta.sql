CREATE TABLE [dbo].[Conta] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [CorrentistaId] INT      NOT NULL,
    [LimiteCredito] MONEY    DEFAULT ((0)) NOT NULL,
    [Saldo]         MONEY    DEFAULT ((0)) NOT NULL,
    [DataAbertura]  DATETIME DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContaCorrentista] FOREIGN KEY ([CorrentistaId]) REFERENCES [dbo].[Correntista] ([Id])
);

