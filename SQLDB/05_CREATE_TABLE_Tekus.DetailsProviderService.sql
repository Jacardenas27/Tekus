USE [Tekus]
GO

/****** Object:  Table [Tekus].[DetailsProviderService]    Script Date: 31/08/2024 7:03:57 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Tekus].[DetailsProviderService](
	[id] [uniqueidentifier] NOT NULL,
	[idProvider] [uniqueidentifier] NOT NULL,
	[idService] [uniqueidentifier] NOT NULL,
	[costPerHour] [float] NOT NULL,
 CONSTRAINT [PK_DetailsProviderService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [Tekus].[DetailsProviderService]  WITH CHECK ADD  CONSTRAINT [FK_DetailsProviderService_Provider] FOREIGN KEY([idProvider])
REFERENCES [Tekus].[Provider] ([id])
GO

ALTER TABLE [Tekus].[DetailsProviderService] CHECK CONSTRAINT [FK_DetailsProviderService_Provider]
GO

ALTER TABLE [Tekus].[DetailsProviderService]  WITH CHECK ADD  CONSTRAINT [FK_DetailsProviderService_Services] FOREIGN KEY([idService])
REFERENCES [Tekus].[Services] ([id])
GO

ALTER TABLE [Tekus].[DetailsProviderService] CHECK CONSTRAINT [FK_DetailsProviderService_Services]
GO

