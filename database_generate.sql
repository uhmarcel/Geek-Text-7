
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
	   (0132261197, 'Harry Potter', 'A kid finds out he is a wizard', 'London', 2001, 'Wiley', null, null, 19.99,'J.K Rowling', 'fiction', 1),
	   (0130895717, 'House of Glass', 'A house made of glass and glass related accessories', 'Scotland', 2004, 'Harper Collins', null , null, 22.99, 'Daniel Lifeson', 'Thriller', 0),
	   (0135289106, 'Calculus Textbook', 'An introductory Calculus textbook for high schoolers', 'Massachusets', 2008,'Education Books', null, null, 149.99, 'Isaac Newton', 'Mathematics', 0),
	   (0139163050, 'Charlottes Web', 'A childrens book about a pig and a spider', 'Indiana', 1982, 'Prentice', null, null, 14.99, 'E.B. White', 'Adventure', 0),
	   (0130284190, 'Rhetoric', 'Lectures by Aristotle concerning the use of rhetoric', 'Rome', 1202, 'Random House', null, null, 20.99, 'Aristotle', 'History', 0),
	   (014026886, 'The Odyssey', 'The story of Odysseus journey home after the war', 'Greece', 1992, 'Penguin Classics', null, null, 22.99, 'Homer', 'Action', 1);

-- Users
insert into [User] (userFirstName, userLastName, userNickName, email, userProfileName, userProfilePassword, userCity, userState, userZipCode, userStreetAddress, userCreditCard, userComment)
values ('adminFirst', 'adminLast', 'GeekyAdmin', 'admin@email.com', 'admin', 'password','adminCity', 'adminState', 'adminZip', 'adminStreet',null, null),	-- 1
	   ('John', 'Smith', 'johnSmith001', 'JSmithy@email.com', 'Jsmith', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),		-- 2
	   ('Andre', 'Reyes', 'areyes92', 'AReyes@email.com', 'AReyes', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),			-- 3
	   ('Mathew', 'Vega', 'vegamw13', 'Vega@email.com', 'Matty', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),				-- 4
	   ('Catherine', 'Smith', 'cathys01', 'SmithyCat@email.com', 'catty', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null),	-- 5
	   ('Ron', 'Jackson', 'jr1991', 'JackKiller@email.com', 'ShyRonny', 'password', 'adminCity', 'adminState', 'adminZip', 'adminStreet', null, null);		-- 6
-- UserPurchases
insert into [UserPurchases] (userID, ISBN)
values (2, 0130284190), (2, 0135289106), (2, 0132261197),													 
	   (3, 0130284190), (3, 0130895725), (3, 0139163050), (3, 0132261197),		
	   (4, 0135289106), (4, 0130895717), (4, 0130284190), (4, 0130895725), (4, 0139163050),	
	   (5, 0130284190), (5, 0132261197),																
	   (6, 0130284190);
	   	   
insert into [UserPurchases] (userID, ISBN)  -- Set admin as owner of all books
	   SELECT userID, ISBN
	   FROM [User], [Book]
	   WHERE userProfileName = 'admin';
	   
-- Reviews
insert into [bookReview] (userID, ISBN, reviewText, reviewRating, displayAs) 
values (3, 0130284190, 'This was a really entertaining book, I’d highly recommend it. The characters were believable, the plot was interesting. Five stars!', 5, 2),
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
	   (6, 0130284190, 'What a sweet, lovely story, with a such a beautiful ending. I will definitely seek out the author’s other works.', 3, 1),
	   (6,  014026886, 'What a sweet, lovely story, with a such a beautiful ending. I will definitely seek out the author’s other works.', 3, 1);
	   
--Authors
 Insert into Author (AuthorName, ISBN, AuthorBio)
  values ('Aristotle', '130284190','Aristotle (c. 384 B.C. to 322 B.C.) was an Ancient Greek philosopher and scientist who is still considered one of the greatest thinkers in politics, psychology and ethics. When Aristotle turned 17, he enrolled in Plato’s Academy. In 338, he began tutoring Alexander the Great. In 335, Aristotle founded his own school, the Lyceum, in Athens, where he spent most of the rest of his life studying, teaching and writing.' ),
		 ('Daniel Lifeson', '130895717','Daniel Lifeson is an American fiction author. Though his second novel, Only Revolutions (2006), was nominated for the National Book Award, Danielewski is most widely known for his debut novel House of Glass (2000), which garnered a considerable cult following and won the New York Public Library Young Lions Fiction Award. He has published one novella, The Fifty Year Sword, which until rereleased by Pantheon in the United States in 2012, remained relatively obscure due to only 2000 copies being published in the Netherlands (2005, De Bezige Bij). His latest project is The Familiar, an ambitious 27-volume serial novel whose first installment, The Familiar, Volume 1: One Rainy Day in May, was released on May 12, 2015.' ),
		 ('Homer', '130895725','The Greek poet Homer was born sometime between the 12th and 8th centuries BC, possibly somewhere on the coast of Asia Minor. He is famous for the epic poems The Iliad and The Odyssey, which have had an enormous effect on Western culture, but very little is known about their alleged author.' ),
		 ('J.K Rowling', '132261197','Joanne Rowling (born July 31, 1965), who goes by the pen name J.K. Rowling, is a British author and screenwriter best known for her seven-book Harry Potter children''s book series. J.K. Rowling was living in Edinburgh, Scotland, and struggling to get by as a single mom before her first book, Harry Potter and the Sorcerer''s Stone, was published. The children''s fantasy novel became an international hit and Rowling became an international literary sensation in 1999 when the first three installments of Harry Potter took over the top three slots of The New York Times best-seller list after achieving similar success in her native United Kingdom. ' ),
		 ('Isaac Newton', '135289106',' Isaac Newton was born at Woolsthorpe near Grantham in Lincolnshire, England on 4 January 1643. His father died before he was born and in 1645 his mother married a clergyman from North Welham in Leicestershire. She went to live with him while Isaac Newton lived with his grandmother. His mother returned to Woolsthorpe in 1656 when her second husband died and Isaac Newton went to live with her again. From the age of 12 to 14 Isaac Newton went to Grantham Grammar School. During this time he lodged with an apothecary and his family. Then in 1659 Isaac had to leave to help his mother on the family farm. Isaac was not in the slightest bit interested in running a farm and in 1660 he went to the grammar school again. In 1661 he went to Trinity College Cambridge. Isaac Newton obtained a BA in 1665. In 1666 Isaac Newton was forced to flee Cambridge because of an outbreak of the plague and he returned temporarily to Woolsthorpe. He returned to university in 1667.' ),
		 ('E.B. White', '139163050','E.B. White was born in New York in 1899. In 1927, White joined The New Yorker magazine as writer and contributing editor—a position he would hold for the rest of his career. He wrote three books for children, including Stuart Little (1945) and Charlotte''s Web (1952). In 1959 he revised The Elements of Style by the late William Strunk Jr., which became a standard style manual for writers. White, who earned a Pulitzer Prize special citation in 1978, passed away at his home in Maine in 1985.' );
	   
-- ShoppingCart
insert into [shoppingCart] (cartID, userID, bookID, qty, Price)
values (1, 1, 0130895725, 1, 29.99);


-- IMPORTANT
-- Change path to the location of your BookImages folder below

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\Rhet.jfif', Single_Blob) as image)
where Book.ISBN = 130284190

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\houseofleaves.jfif' , Single_Blob) as image)
where Book.ISBN = 130895717

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\theiliad.jfif' , Single_Blob) as image)
where Book.ISBN = 130895725

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\harryp.jfif' , Single_Blob) as image)
where Book.ISBN = 132261197

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\calc.jpg' , Single_Blob) as image)
where Book.ISBN = 135289106

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\web.jpg' , Single_Blob) as image)
where Book.ISBN = 139163050

update Book 
set bookCover =
	(select BulkColumn from openrowset (bulk 'C:\Users\Red_K\Desktop\BookImages\9780199360314.jfif' , Single_Blob) as image)
where Book.ISBN = 14026886