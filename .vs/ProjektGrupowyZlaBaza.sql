USE [master]
GO

/****** Object:  Database [GrupowyProjektBazaDanych]    Script Date: 29.09.2019 11:31:33 ******/
CREATE DATABASE [GrupowyProjektBazaDanych]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GrupowyProjektBazaDanych', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GrupowyProjektBazaDanych.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GrupowyProjektBazaDanych_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\GrupowyProjektBazaDanych_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GrupowyProjektBazaDanych].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ARITHABORT OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET  DISABLE_BROKER 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET RECOVERY FULL 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET  MULTI_USER 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET QUERY_STORE = OFF
GO

ALTER DATABASE [GrupowyProjektBazaDanych] SET  READ_WRITE 
GO

