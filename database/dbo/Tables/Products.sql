CREATE TABLE [dbo].[Products] (
    [ProductId]          UNIQUEIDENTIFIER NOT NULL,
    [ProductName]        NVARCHAR (100)   NULL,
    [Price]              DECIMAL (18)     NULL,
    [ProdcutDescription] NVARCHAR (MAX)   NULL,
    [CreatedOn]          DATETIME         NULL,
    [UpdateOn]           DATETIME         NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

