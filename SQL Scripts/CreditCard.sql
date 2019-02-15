USE [GeekText]
GO

/****** Object:  Table [dbo].[CreditCard]    Script Date: 2/14/2019 10:41:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CreditCard](
	[CreditCardNumber] [nvarchar](50) NULL,
	[cvv] [int] NULL,
	[expirationDate] [nchar](10) NULL,
	[userID] [int] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CreditCard]  WITH CHECK ADD  CONSTRAINT [FK_CreditCard_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO

ALTER TABLE [dbo].[CreditCard] CHECK CONSTRAINT [FK_CreditCard_User]
GO


