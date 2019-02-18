-- Main GeekText Script

USE GeekText

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

-------------- CREATE TABLES --------------

DROP TABLE IF EXISTS [dbo].[CreditCard]
DROP TABLE IF EXISTS [dbo].[Address]
DROP TABLE IF EXISTS [dbo].[Author]
DROP TABLE IF EXISTS [dbo].[Book]
DROP TABLE IF EXISTS [dbo].[User]

-- Book Table

CREATE TABLE [dbo].[Book](
	[ISBN] [nvarchar](50) NOT NULL,
	[bookTitle] [nvarchar](max) NULL,
	[bookDescription] [nvarchar](max) NULL,
	[publishingLocation] [nvarchar](max) NULL,
	[publishingYear] [int] NULL,
	[publishingCompany] [nvarchar](50) NULL,
	[bookPrice] [float] NULL,
	[userRating] [float] NULL,
	[userComment] [nvarchar](max) NULL,
	[bookAuthor] [nvarchar](max) NULL,
	[bookGenre] [nvarchar](max) NULL,
	[bookCover] [image] NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Author Table

CREATE TABLE [dbo].[Author](
	[AuthorName] [nvarchar](max) NULL,
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[ISBN] [nvarchar](50) NULL,
	[AuthorBio] [nvarchar](max) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Author]  WITH CHECK ADD  CONSTRAINT [FK_Author_Book] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Book] ([ISBN])
GO

ALTER TABLE [dbo].[Author] CHECK CONSTRAINT [FK_Author_Book]
GO

-- User Table

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

-- Address Table

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

-- CreditCard Table

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

-------------- POPULATE TABLES --------------

-- Add entries as needed:

insert into Book (ISBN, bookTitle, bookDescription, publishingLocation, publishingYear, publishingCompany, userRating, userComment, bookPrice, bookAuthor, bookGenre)
values (0130895725, 'The Iliad', 'The story of the war in troy featuring achilles and his heel', 'Greece', 200, 'Classic Book Company', null, null, 28.99, 'Homer', 'Action'),
	   (0132261197, 'Harry Potter', 'A kid finds out he is a wizard', 'London', 2001, 'Wiley', null, null, 19.99,'J.K Rowling', 'fiction'),
	   (0130895717, 'House of Glass', 'A house made of glass and glass related accessories', 'Scotland', 2004, 'Harper Collins', null , null, 22.99, 'Daniel Lifeson', 'Thriller'),
	   (0135289106, 'Calculus Textbook', 'An introductory Calculus textbook for high schoolers', 'Massachusets', 2008,'Education Books', null, null, 149.99, 'Isaac Newton', 'Mathematics'),
	   (0139163050, 'Charlottes Web', 'A childrens book about a pig and a spider', 'Indiana', 1982, 'Prentice', null, null, 14.99, 'E.B. White', 'Adventure'),
	   (0130284190, 'Rhetoric', 'Lectures by Aristotle concerning the use of rhetoric', 'Rome', 1202, 'Random House', null, null, 20.99, 'Aristotle', 'History');





--update Book 
--set bookCover =
--	(select BulkColumn from openrowset (bulk 'D:\School_D\CEN4083\Rhet.jfif' , Single_Blob) as image)
--where Book.ISBN = 130284190


