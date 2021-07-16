USE master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE NAME = 'BoltsAndNutsV2')
		DROP DATABASE BoltsAndNutsV2
GO

IF NOT EXISTS (SELECT * FROM sys.databases WHERE NAME = 'BoltsAndNutsV2')
BEGIN
	CREATE DATABASE [BoltsAndNutsV2]  COLLATE Latin1_General_CI_AS;
END
GO

SET DATEFORMAT ymd
GO

USE BoltsAndNutsV2
GO

CREATE SCHEMA BAN;
GO

 CREATE TABLE [BAN].[Facility](
	[ID_Facility] [int] IDENTITY(1,1),					--PK
	[Facility_Name] [nvarchar](30),
	[FacilityDescription] [nvarchar](255),
	[SAP] [nvarchar] (10)

CONSTRAINT "PK_Facility" PRIMARY KEY CLUSTERED ("ID_Facility") 
 );
GO


 CREATE TABLE [BAN].[BillOfMaterials](
	[ID_SteelJoint] [int] IDENTITY(1,1) NOT NULL,		--PK
	[ID_Facility] [int],								--FK
	[JointName] [nvarchar] (25) NOT NULL,
	[ID_Bolt] [int],									--FK
	[ID_Diameter] [int] NOT NULL,						--FK
	[ID_Lenght] [int] NOT NULL,							--FK
 	[BoltWasherFirst] [int],							--FK
	[BoltWasherSecond] [int],							--FK
	[BoltWasherThird] [int],							--FK
	[ID_Nut] [int],										--FK
	[NumberOfSteelJoint] [int] NOT NULL,
	[PiecesOfSteelJoint] [int] NOT NULL,

CONSTRAINT "PK_ID_SteelJoint" PRIMARY KEY CLUSTERED ("ID_SteelJoint")
 );
 GO


CREATE TABLE [BAN].[BoltType](
	[ID_Bolt] [int] IDENTITY(1,1) NOT NULL,				--PK
	[BoltName] [nvarchar] (25),
	[BoltStandard] [nvarchar] (10),
	[BoltDescription] [nvarchar] (100),

CONSTRAINT "PK_BoltType" PRIMARY KEY CLUSTERED ("ID_Bolt")
 );
GO


CREATE TABLE [BAN].[NutType](
	[ID_Nut] [int] IDENTITY(1,1) NOT NULL,				--PK
	[NutName] [nvarchar] (35),
	[NutStandard] [nvarchar] (10),
	[NutDescription] [nvarchar] (100),

CONSTRAINT "PK_NutType" PRIMARY KEY clustered ("ID_Nut")
 );
 GO

 CREATE TABLE [BAN].[DiameterType](
	[ID_Diameter] [int] IDENTITY(1,1) NOT NULL,			--PK
	[Diameter] [nvarchar] (5),

CONSTRAINT "PK_DiameterType" PRIMARY KEY clustered ("ID_Diameter")
 );
 GO

 CREATE TABLE [BAN].[WasherType](
	[ID_Washer] [int] IDENTITY(1,1) NOT NULL,			--PK
	[WasherName] [nvarchar] (25),
	[WasherStandard] [nvarchar] (10),
	[WasherDescription] [nvarchar] (100),

CONSTRAINT "PK_WasherType" PRIMARY KEY clustered ("ID_Washer")
 );
 GO

  CREATE TABLE [BAN].[LenghtType](
	[ID_Lenght] [int] IDENTITY(1,1) NOT NULL,			--PK
	[BoltLenght] [nvarchar] (5),


CONSTRAINT "PK_LenghtType" PRIMARY KEY clustered ("ID_Lenght")
 );
 GO
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_Facility] FOREIGN KEY ([ID_Facility]) REFERENCES [BAN].[Facility]([ID_Facility]) ON UPDATE CASCADE;
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_BoltType] FOREIGN KEY ([BoltWasherFirst]) REFERENCES [BAN].[BoltType]([ID_Bolt]) ON UPDATE CASCADE;
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_WasherType_First] FOREIGN KEY ([BoltWasherFirst]) REFERENCES [BAN].[WasherType]([ID_Washer]) ON UPDATE CASCADE;
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_WasherType_Second] FOREIGN KEY ([BoltWasherSecond]) REFERENCES [BAN].[WasherType]([ID_Washer]);
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_WasherType_Third] FOREIGN KEY ([BoltWasherThird]) REFERENCES [BAN].[WasherType]([ID_Washer]);
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_NutType] FOREIGN KEY ([ID_Bolt]) REFERENCES [BAN].[NutType]([ID_Nut]) ON UPDATE CASCADE;
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_DiameterType] FOREIGN KEY ([ID_Diameter]) REFERENCES [BAN].[DiameterType]([ID_Diameter]) ON UPDATE CASCADE;
ALTER TABLE [BAN].[BillOfMaterials] ADD CONSTRAINT [FK_BillOfMaterials_LenghtType] FOREIGN KEY ([ID_Lenght]) REFERENCES [BAN].[LenghtType]([ID_Lenght]) ON UPDATE CASCADE;

USE master
GO