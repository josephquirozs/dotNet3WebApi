CREATE DATABASE [my_database]
GO
USE [my_database]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--########################################################

CREATE TABLE [dbo].[product]
(
	[product_id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[price] [decimal](8, 2) NULL,
	[stock] [decimal](8, 2) NULL,
	[unit] [varchar](3) NULL,
	[expiration] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[product] ADD PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--########################################################

CREATE TABLE [dbo].[customer](
	[customer_id] [bigint] NOT NULL,
	[name] [varchar](100) NULL,
	[credit_line] [decimal](8, 2) NULL,
	[is_vip] [bit] NULL,
	[member_since] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[customer] ADD  CONSTRAINT [PK_customer] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

