USE [SrinivasToolkit]
GO
/****** Object:  Table [dbo].[eCanarysPayslip]    Script Date: 16-Aug-2013 18:37:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[eCanarysPayslip](
	[ID] [uniqueidentifier] NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[CompanyAddress] [nvarchar](500) NOT NULL,
	[PaymentMonth] [varchar](15) NOT NULL,
	[PaymentYear] [int] NOT NULL,
	[PayrollNumber] [int] NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[Department] [varchar](50) NOT NULL,
	[AccountNumber] [bigint] NOT NULL,
	[Remarks] [nvarchar](500) NULL,
	[CreditType] [varchar](50) NOT NULL,
	[CreditedAmount] [money] NOT NULL,
	[DebitType] [varchar](50) NOT NULL,
	[DebitedAmount] [money] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[eCanarysPayslip] ADD  CONSTRAINT [DF_eCanarysPayslip_ID]  DEFAULT (newid()) FOR [ID]
GO
