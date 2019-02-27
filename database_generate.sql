
USE GeekText

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

-------------- CREATE TABLES --------------

DROP TABLE IF EXISTS [dbo].[shoppingCart]
DROP TABLE IF EXISTS [dbo].[UserPurchases]
DROP TABLE IF EXISTS [dbo].[BookReview]
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
	[bestSeller] [bit] DEFAULT 0, 
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
	[userFirstName] [nvarchar](50) NULL,
	[userLastName] [nvarchar](50) NULL,
	[userNickName] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[userProfileName] [nvarchar](50) NULL,
	[userProfilePassword] [nvarchar](50) NULL,
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[userCity] [nvarchar](50) NULL,
	[userState] [nchar](10) NULL,
	[userZipCode] [nchar](10) NULL,
	[userStreetAddress] [nvarchar](50) NULL,
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

-- shoppingCard

CREATE TABLE [dbo].[shoppingCart](
	[cartID] [int] NOT NULL,
	[userID] [int] NULL,
	[bookId] [nvarchar](50) NULL,
	[qty] [int] NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_shoppingCart] PRIMARY KEY CLUSTERED 
(
	[cartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[shoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_shoppingCart_Book] FOREIGN KEY([bookId])
REFERENCES [dbo].[Book] ([ISBN])
GO

ALTER TABLE [dbo].[shoppingCart] CHECK CONSTRAINT [FK_shoppingCart_Book]
GO

ALTER TABLE [dbo].[shoppingCart]  WITH CHECK ADD  CONSTRAINT [FK_shoppingCart_User] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([userID])
GO

ALTER TABLE [dbo].[shoppingCart] CHECK CONSTRAINT [FK_shoppingCart_User]
GO

-- BookReview

CREATE TABLE [dbo].[BookReview] (
	[userID] [int] NOT NULL FOREIGN KEY REFERENCES [User](userID),
	[ISBN] [nvarchar](50) NOT NULL FOREIGN KEY REFERENCES [Book](ISBN),
	[reviewText] [nvarchar] (max) NOT NULL,
	[reviewRating] [int] NOT NULL CHECK (reviewRating > 0 AND reviewRating <=5),
	[displayAs] [int] DEFAULT 3
	-- CONSTRAINT PK_BookReview PRIMARY KEY (ISBN, userID)   // Key commented out to allow multiple comments per user on same book for debugging
);

-- UserPurchases

CREATE TABLE [dbo].[UserPurchases] (
	[userID] [int] NOT NULL FOREIGN KEY REFERENCES [User](userID),
	[ISBN] [nvarchar](50) NOT NULL FOREIGN KEY REFERENCES [Book](ISBN)
	CONSTRAINT PK_UserPurchases PRIMARY KEY (userID, ISBN)
);

GO

-------------- TRIGGERS --------------

CREATE or ALTER TRIGGER updateBookRating 
ON BookReview 
AFTER INSERT
AS
BEGIN
	UPDATE Book
	SET userRating = (SELECT AVG(CAST(reviewRating AS FLOAT)) FROM BookReview
					  WHERE Book.ISBN = BookReview.ISBN)
	FROM Book, inserted
	WHERE Book.ISBN = inserted.ISBN;
END
GO


-------------- POPULATE TABLES --------------

-- Books
insert into Book (ISBN, bookTitle, bookDescription, publishingLocation, publishingYear, publishingCompany, userRating, userComment, bookPrice, bookAuthor, bookGenre, bestSeller)
values (0130895725, 'The Iliad', 'The story of the war in troy featuring achilles and his heel', 'Greece', 200, 'Classic Book Company', null, null, 28.99, 'Homer', 'Action', 1),
	   (0132261197, 'Harry Potter', 'A kid finds out he is a wizard', 'London', 2001, 'Wiley', null, null, 19.99,'J.K Rowling', 'fiction', 0),
	   (0130895717, 'House of Glass', 'A house made of glass and glass related accessories', 'Scotland', 2004, 'Harper Collins', null , null, 22.99, 'Daniel Lifeson', 'Thriller', 0),
	   (0135289106, 'Calculus Textbook', 'An introductory Calculus textbook for high schoolers', 'Massachusets', 2008,'Education Books', null, null, 149.99, 'Isaac Newton', 'Mathematics', 0),
	   (0139163050, 'Charlottes Web', 'A childrens book about a pig and a spider', 'Indiana', 1982, 'Prentice', null, null, 14.99, 'E.B. White', 'Adventure', 0),
	   (0130284190, 'Rhetoric', 'Lectures by Aristotle concerning the use of rhetoric', 'Rome', 1202, 'Random House', null, null, 20.99, 'Aristotle', 'History', 0);

-- Users
insert into [User] (userFirstName, userLastName, userNickName, email, userProfileName, userProfilePassword, userCity, userState, userZipCode, userStreetAddress, userCreditCard, userComment)
values ('adminFirst', 'adminLast', 'GeekyAdmin', 'admin@email.com', 'admin', 'password','adminCity', 'adminState', 'adminZip', 'adminStreet',null, null),  -- 1
	   ('John', 'Smith', 'johnSmith001', 'JSmithy@email.com', 'Jsmith', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),		-- 2
	   ('Andre', 'Reyes', 'areyes92', 'AReyes@email.com', 'AReyes', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),			-- 3
	   ('Mathew', 'Vega', 'vegamw13', 'Vega@email.com', 'Matty', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),			-- 4
	   ('Catherine', 'Smith', 'cathys01', 'SmithyCat@email.com', 'catty', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),		-- 5
	   ('Ron', 'Jackson', 'jr1991', 'JackKiller@email.com', 'ShyRonny', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null);			-- 6

-- UserPurchases
insert into [UserPurchases] (userID, ISBN)
values (2, 0130284190),
	   (2, 0135289106),
	   (2, 0132261197),
	   (3, 0130284190),
	   (3, 0130895725),
	   (3, 0139163050),
	   (3, 0132261197),
	   (4, 0135289106),
	   (4, 0130895717),
	   (4, 0130284190),
	   (4, 0130895725),
	   (4, 0139163050),
	   (5, 0130284190),
	   (5, 0132261197),
	   (6, 0130284190);

-- Reviews
insert into [bookReview] (userID, ISBN, reviewText, reviewRating, displayAs) 
values (3, 0130284190,'This was a really entertaining book, I’d highly recommend it. The characters were believable, the plot was interesting. Five stars!', 5, 2),
	   (3, 0130895725, 'Bravo! A courageous and realistic tale of women loving women. Loved the characters and the reality of their lives. Well done!', 4, 2),
	   (3, 0139163050, 'What a sweet, lovely story, with a such a beautiful ending. I will definitely seek out the author’s other works.', 3, 1),
	   (3, 0132261197, 'This was a really entertaining book, I’d highly recommend it. The characters were believable, the plot was interesting. Five stars!', 5, 2),
	   (4, 0135289106, 'The characters are well developed with a storyline that flows from the pages and right into your heart. It had all the elements of a great love story.', 3, 2),
	   (4, 0130895717, 'What a sweet, lovely story, with a such a beautiful ending. I will definitely seek out the author’s other works.', 3, 1),
	   (4, 0130284190, 'The characters are well developed with a storyline that flows from the pages and right into your heart. It had all the elements of a great love story.', 4, 3),
	   (4, 0130895725, 'I really liked the story. This was a slow burn that gave enough background on the two main characters so that you see how they interact with each other and threw in a few surprises along the way!', 5, 1),
	   (4, 0139163050, 'This was a really entertaining book, I’d highly recommend it. The characters were believable, the plot was interesting. Five stars!', 5, 1),
	   (5, 0130284190, 'This had me hooked from the first page. It was a great story from a brilliant writer; you should definitely check this one out.', 4, 2),
	   (5, 0132261197, 'This had me hooked from the first page. It was a great story from a brilliant writer; you should definitely check this one out.', 4, 2),
	   (6, 0130284190, 'What a sweet, lovely story, with a such a beautiful ending. I will definitely seek out the author’s other works.', 3, 1);
	   
-- ShoppingCart
insert into [shoppingCart] (cartID, userID, bookID, qty, Price)
values (1, 1, 0130895725, 1, 29.99);



--update Book 
--set bookCover =
--	(select BulkColumn from openrowset (bulk 'D:\School_D\CEN4083\Rhet.jfif' , Single_Blob) as image)
--where Book.ISBN = 130284190