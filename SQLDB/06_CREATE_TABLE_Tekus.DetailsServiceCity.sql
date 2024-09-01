USE [Tekus]
GO

/****** Object:  Table [Tekus].[DetailsServiceCity] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Tekus].[DetailsServiceCity](
	[id] [uniqueidentifier] NULL,
	[idService] [uniqueidentifier] NULL,
	[cityCode] [varchar](2) NULL
) ON [PRIMARY]
GO

ALTER TABLE [Tekus].[DetailsServiceCity]  WITH CHECK ADD  CONSTRAINT [FK_DetailsServiceCity_Services] FOREIGN KEY([idService])
REFERENCES [Tekus].[Services] ([id])
GO

ALTER TABLE [Tekus].[DetailsServiceCity] CHECK CONSTRAINT [FK_DetailsServiceCity_Services]
GO


