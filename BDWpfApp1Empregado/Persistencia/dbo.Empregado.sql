CREATE DATABASE [DBEmpregadoGUI];
GO

USE [DBEmpregadoGUI]
GO

/****** Objeto: Table [dbo].[Empregado] Data do Script: 20/10/2026 09:00:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empregado] (
    [Matricula] INT            IDENTITY (1, 1) NOT NULL,
    [CPF]       NVARCHAR (MAX) NULL,
    [Nome]      NVARCHAR (MAX) NULL,
    [Endereco]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Empregado] PRIMARY KEY CLUSTERED ([Matricula] ASC)
);

GO

CREATE TABLE [dbo].[DEPT] (
    [ID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_DEPT] PRIMARY KEY CLUSTERED ([ID] ASC)
);
