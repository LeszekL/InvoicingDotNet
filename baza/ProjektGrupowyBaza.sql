-- SQL Manager for SQL Server 5.0.2.53045
-- ---------------------------------------
-- Host      : (local)
-- Database  : ProjektGrupowyBaza
-- Version   : Microsoft SQL Server 2017 (RTM-GDR) (KB4505224) 14.0.2027.2


--
-- Definition for table Contractor :
--

CREATE TABLE dbo.Contractor (
  ID int IDENTITY(0, 1) NOT NULL,
  Name varchar(100) COLLATE Polish_CI_AS NOT NULL,
  ShortName varchar(30) COLLATE Polish_CI_AS NOT NULL,
  PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table InvoiceHeader :
--

CREATE TABLE dbo.InvoiceHeader (
  ID int IDENTITY(1, 1) NOT NULL,
  Buyer int NOT NULL,
  Seller int NOT NULL,
  PayoffType varchar(30) COLLATE Polish_CI_AS NOT NULL,
  CallculationType varchar(30) COLLATE Polish_CI_AS NULL
)
ON [PRIMARY]
GO

--
-- Definition for table VAT :
--

CREATE TABLE dbo.VAT (
  ID int IDENTITY(0, 1) NOT NULL,
  PayRate int NOT NULL,
  Name varchar(30) COLLATE Polish_CI_AS NOT NULL,
  PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Product :
--

CREATE TABLE dbo.Product (
  ID int IDENTITY(0, 1) NOT NULL,
  Name varchar(50) COLLATE Polish_CI_AS NOT NULL,
  Code varchar(30) COLLATE Polish_CI_AS NOT NULL,
  PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for table Position :
--

CREATE TABLE dbo.Position (
  ID int NOT NULL,
  Product_ID int NOT NULL,
  Header_ID int NOT NULL,
  Vat_ID int NOT NULL,
  Value money NOT NULL,
  Price money NOT NULL,
  Amount int NOT NULL,
  PRIMARY KEY CLUSTERED (ID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

--
-- Definition for indices :
--

ALTER TABLE dbo.InvoiceHeader
ADD UNIQUE NONCLUSTERED (ID)
WITH (
  PAD_INDEX = OFF,
  IGNORE_DUP_KEY = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY]
GO

--
-- Definition for foreign keys :
--

ALTER TABLE dbo.InvoiceHeader
ADD CONSTRAINT InvoiceHeader_fk FOREIGN KEY (Buyer)
  REFERENCES dbo.Contractor (ID)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.InvoiceHeader
ADD CONSTRAINT InvoiceHeader_fk2 FOREIGN KEY (Seller)
  REFERENCES dbo.Contractor (ID)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Position
ADD CONSTRAINT Position_fk FOREIGN KEY (Product_ID)
  REFERENCES dbo.Product (ID)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Position
ADD CONSTRAINT Position_fk2 FOREIGN KEY (Header_ID)
  REFERENCES dbo.InvoiceHeader (ID)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

ALTER TABLE dbo.Position
ADD CONSTRAINT Position_fk3 FOREIGN KEY (Vat_ID)
  REFERENCES dbo.VAT (ID)
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
GO

