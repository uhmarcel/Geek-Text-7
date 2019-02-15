USE [GeekText]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 2/14/2019 10:41:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[ISBN] [nvarchar](50) NOT NULL,
	[bookTitle] [nvarchar](max) NULL,
	[bookDescription] [nvarchar](max) NULL,
	[publishingLocation] [nvarchar](max) NULL,
	[publishingYear] [int] NULL,
	[publsihingCompany] [nvarchar](50) NULL,
	[bookPrice] [float] NULL,
	[userRating] [float] NULL,
	[userComment] [nvarchar](max) NULL,
	[bookAuthor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


