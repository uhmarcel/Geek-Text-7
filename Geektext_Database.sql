# Database generation script
# We can build this as the main script for the database, so that we can pull the latest version
# of the script from github, and have it update our databases. 

DROP DATABASE IF EXISTS GeekText;
CREATE DATABASE GeekText;
USE GeekText;

# Database Tables:
# I added this tables just as reference to build upon

CREATE TABLE Book (
	bookID INTEGER AUTO_INCREMENT,
    title CHAR(40) NOT NULL,
    description TEXT(400),
    price DECIMAL(8,2),
    #rating DECIMAL(1,1)
    #publisherID 
    PRIMARY KEY(bookID)
);

CREATE TABLE Author (
	authorID INTEGER AUTO_INCREMENT,
    firstName CHAR(16) NOT NULL,
    lastName CHAR(16) NOT NULL,
    #shortBio
    PRIMARY KEY(authorID)
);

CREATE TABLE WroteBy ( 
	bookId INTEGER AUTO_INCREMENT,
    authorID DECIMAL(4,0),
    PRIMARY KEY(bookID, authorID)
);  # Note: This table can be deleted if we decide to only allow 1 author per book, which would make everything easier

# to add:
# CREATE TABLE User ()
# CREATE TABLE Comment ()
# CREATE TABLE Publisher ()
# ...


# Populate:
# Examples to have in the database for testing

INSERT INTO Book VALUES (1, 'A Deepness in the Sky', 'Random book description', 20.99);
INSERT INTO Book VALUES (2, 'The Edge', 'This book is about bla', 14.99);
INSERT INTO Book VALUES (3, 'Harry Potter and the Globet of Fire', 'Wizards n stuff', 74.19);
INSERT INTO Book VALUES (4, 'Harry Potter and the Prisoner of Azkaban', 'More Wizards n stuff', 43.90);

INSERT INTO Author VALUES (1, 'Vernor', 'Vintage');
INSERT INTO Author VALUES (2, 'Dick', 'Francis');
INSERT INTO Author VALUES (3, 'J.K.', 'Rowling');

INSERT INTO WroteBy VALUES (1, 1);
INSERT INTO WroteBy VALUES (2, 2);
INSERT INTO WroteBy VALUES (3, 3);
INSERT INTO WroteBy VALUES (4, 3);

    
    


