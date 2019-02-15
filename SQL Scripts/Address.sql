USE [GeekText]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 2/14/2019 10:40:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Address](
	[City] [nvarchar](50) NULL,
	[State] [nchar](10) NULL,
	[ZipCode] [nchar](10) NULL,
	[UserID] [int] NOT NULL,
	[streetAddress] [nvarchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([userID])
GO

ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_User]
GO


