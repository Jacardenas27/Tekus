USE [Tekus]
GO

/****** Object:  Table [Tekus].[DetailsServiceCountry] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Tekus].[DetailsServiceCountry](
	[id] [uniqueidentifier] NULL,
	[idService] [uniqueidentifier] NULL,
	[countryCode] [varchar](2) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Tekus].[DetailsServiceCountry]  WITH CHECK ADD  CONSTRAINT [FK_DetailsServiceCountry_Services] FOREIGN KEY([idService])
REFERENCES [Tekus].[Services] ([id])
GO

ALTER TABLE [Tekus].[DetailsServiceCountry] CHECK CONSTRAINT [FK_DetailsServiceCountry_Services]
GO


