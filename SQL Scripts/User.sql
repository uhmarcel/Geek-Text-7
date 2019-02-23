USE [GeekText]
GO

/****** Object:  Table [dbo].[User]    Script Date: 2/14/2019 10:42:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[userFIrstName] [nvarchar](50) NULL,
	[userLastName] [nvarchar](50) NULL,
	[userNickName] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[userProfileName] [nvarchar](50) NULL,
	[userProfilePassword] [nvarchar](50) NULL,
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userShippingAddress] [nvarchar](50) NULL,
	[userCreditCard] [nvarchar](50) NULL,
	[userComment] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


