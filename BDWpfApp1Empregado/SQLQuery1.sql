/*
Script de implantação para DBEmpregadoGUI

Esse código foi gerado por uma ferramenta.
Alterações nesse arquivo poderão causar um comportamento incorreto e serão perdidas se
o código seja regenerado.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DBEmpregadoGUI"
:setvar DefaultFilePrefix "DBEmpregadoGUI"
:setvar DefaultDataPath "C:\Users\sistemalab\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\sistemalab\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detectar modo SQLCMD e desabilitar a execução do script se o modo SQLCMD não for suportado.
Para reabilitar o script após habilitar o modo SQLCMD, execute o seguinte:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'O modo SQLCMD deve ser habilitado para executar esse script com êxito.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Atualização concluída.';


GO
