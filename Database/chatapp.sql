USE master
GO
IF (EXISTS (SELECT name FROM sys.databases WHERE name = 'ChatApp'))
DROP DATABASE ChatApp
GO
CREATE DATABASE ChatApp
GO
USE ChatApp
GO
CREATE TABLE Account(
	id INT IDENTITY PRIMARY KEY,
	email VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(100) NOT NULL,
	firstName NVARCHAR(20) NOT NULL,
	lastName NVARCHAR(30) NOT NULL,
	birthday DATETIME,
	avatar NVARCHAR(100) DEFAULT 'useravatar.png',
	createdAt DATETIME DEFAULT GETDATE()
)
GO 
CREATE TABLE Conversation(
	id VARCHAR(30) PRIMARY KEY,
	creatorId INT NOT NULL,
	avatar NVARCHAR(100) DEFAULT 'groupavatar.png',
	title NVARCHAR(100),
	createdAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT conversation_creatorId_FK FOREIGN KEY(creatorId) REFERENCES Account(id)
)
GO
CREATE TABLE Participant(
	id INT IDENTITY PRIMARY KEY,
	conversationId VARCHAR(30) NOT NULL,
	userId INT NOT NULL,
	CONSTRAINT participant_userId_FK FOREIGN KEY(userId) REFERENCES Account(id),
	CONSTRAINT participant_conversationId_FK FOREIGN KEY(conversationId) REFERENCES Conversation(id)
)
GO
CREATE TABLE Message(
	id VARCHAR(30) PRIMARY KEY,
	conversationId VARCHAR(30) NOT NULL,
	senderId INT NOT NULL,
	content NTEXT NOT NULL,
	messageType VARCHAR(4) NOT NULL,
	createdAt DATETIME DEFAULT GETDATE(),
	CONSTRAINT message_senderId_FK FOREIGN KEY(senderId) REFERENCES Account(id),
	CONSTRAINT message_conversationId_FK FOREIGN KEY(conversationId) REFERENCES Conversation(id)
)
GO
CREATE TABLE Conversation2(
	id VARCHAR(30) PRIMARY KEY,
	creatorId INT NOT NULL,
	avatar NVARCHAR(100),
	title NVARCHAR(100),
	senderId INT NOT NULL,
	messageType VARCHAR(4),
	content NTEXT,
	createdAt DATETIME,
	CONSTRAINT conversation2_creatorId_FK FOREIGN KEY(creatorId) REFERENCES Account(id),
	CONSTRAINT conversation2_senderId_FK FOREIGN KEY(senderId) REFERENCES Account(id)
)
GO
CREATE TABLE Account2(
	id INT,
	email VARCHAR(50) NOT NULL,
	password VARCHAR(100) NOT NULL,
	firstName NVARCHAR(20) NOT NULL,
	lastName NVARCHAR(30) NOT NULL,
	birthday DATETIME,
	avatar NVARCHAR(100),
	createdAt DATETIME
)
GO
INSERT INTO Account(email, password, firstName, lastName, avatar) VALUES('tuananh@gmail.com','12345678',N'Lê', N'Tuấn Anh','useravatar2.jpg'),
('lenam@gmail.com','12345678',N'Lê', N'Hà Nam', 'useravatar3.jpg'),
('datnguyen@gmail.com','12345678',N'Nguyễn', N'Thành Đạt','useravatar4.jpg'),
('khanhlinh@gmail.com','12345678',N'Trần', N'Khánh Linh', 'useravatar.png'),
('baongoc@gmail.com','12345678',N'Lê', N'Bảo Ngọc','useravatar.png')
GO
INSERT INTO Conversation(id,creatorId, title) VALUES('conversation0001',1, null), ('conversation0002',2, null),('conversation0003',1, N'League Of Legends')
GO
INSERT INTO Participant(conversationId,userId) VALUES('conversation0001',1),('conversation0001',2),('conversation0002',2),
('conversation0002',3),('conversation0003',1),('conversation0003',2),('conversation0003',3),('conversation0003',4)
GO
INSERT INTO Message(id, conversationId, senderId, content, messageType,createdAt) VALUES('message00001','conversation0001',1,N'Tin nhắn 1.','TEXT', '20200612 08:09:11 AM'),
('message00002','conversation0001',2,N'Tin nhắn 2.','TEXT', '20200612 08:09:52 AM'),
('message00003','conversation0001',1,N'Tin nhắn 3.','TEXT', '20200612 08:12:10 AM'),
('message00004','conversation0002',2,N'Tin nhắn 1.','TEXT', '20200615 07:30:11 PM'),
('message00005','conversation0002',3,N'Tin nhắn 2.','TEXT', '20200615 07:31:01 PM'),
('message00006','conversation0002',2,N'Tin nhắn 3.','TEXT', '20200615 07:31:45 PM'),
('message00007','conversation0002',3,N'Tin nhắn 4.','TEXT', '20200615 07:33:02 PM'),
('message00008','conversation0003',1,N'Ashe Cao Bồi_000000000000000_.jpg','FILE', '20200619 03:02:14 PM'),
('message00009','conversation0003',1,N'Ashe Cao Bồi.','TEXT', '20200619 03:02:42 PM'),
('message00010','conversation0003',2,N'yasuomakiem_000000000000001_.jpg','FILE', '20200619 03:04:12 PM'),
('message00011','conversation0003',2,N'Yasuo Ma Kiếm.','TEXT', '20200619 03:04:35 PM'),
('message00012','conversation0003',3,N'vaynesieupham_000000000000002_.jpg','FILE', '20200619 03:05:02 PM'),
('message00013','conversation0003',3,N'Vayne Siêu Phẩm.','TEXT', '20200619 03:05:18 PM'),
('message00014','conversation0003',4,N'garenloanthethanbinh_000000000000003_.jpg','FILE', '20200619 03:05:23 PM'),
('message00015','conversation0003',4,N'Garen Loạn Thế Thần Binh.','TEXT', '20200619 03:05:58 PM')
GO
CREATE PROCEDURE Usp_InsertMessage(@id AS VARCHAR(30), @conversationId AS VARCHAR(30), @senderId AS INT, @content AS NTEXT, @messageType AS VARCHAR(4), @createdAt AS DATETIME)
AS
INSERT INTO Message(id, conversationId, senderId, content, messageType, createdAt) VALUES(@id, @conversationId, @senderId, @content, @messageType, @createdAt)
GO
CREATE PROCEDURE Usp_SearchAccountByEmailOrName(@keyword AS NVARCHAR(50))
AS
SELECT * FROM Account WHERE ((firstName + ' ' + lastName) LIKE '%' + @keyword + '%') OR (email LIKE '%' + @keyword + '%')
GO
CREATE PROCEDURE Usp_GetAccountBySignInInfo(@email AS VARCHAR(50), @password AS VARCHAR(100))
AS
SELECT * FROM Account WHERE email=@email AND password=@password
GO 
CREATE PROCEDURE Usp_GetAccountById(@id AS INT)
AS
SELECT * FROM Account WHERE id = @id
GO
CREATE PROCEDURE Usp_UpdateAccount(@id AS INT, @email AS VARCHAR(50), @password AS VARCHAR(100), @firstName AS NVARCHAR(20), @lastName AS NVARCHAR(30), @birthday AS DATETIME, @avatar AS NVARCHAR(100))
AS
UPDATE Account SET email = @email, password = @password, firstName = @firstName, lastName = @lastName, birthday = @birthday, avatar = @avatar WHERE id = @id
GO
CREATE PROCEDURE Usp_InsertAccount(@email AS VARCHAR(50), @password AS VARCHAR(100), @firstName AS NVARCHAR(20), @lastName AS NVARCHAR(30))
AS
INSERT INTO Account(email, password, firstName, lastName) VALUES(@email, @password, @firstName, @lastName)
GO
CREATE PROCEDURE Usp_GetParticipantsByConversationId(@conversationId AS VARCHAR(30))
AS
SELECT * FROM Participant WHERE conversationId = @conversationId
GO 
CREATE PROCEDURE Usp_InsertParticipant(@userId AS INT, @conversationId AS VARCHAR(30))
AS
INSERT INTO Participant(userId, conversationId) VALUES(@userId, @conversationId)
GO
CREATE PROCEDURE Usp_InsertConversation(@id AS VARCHAR(30), @creatorId AS INT, @avatar AS NVARCHAR(100), @title AS NVARCHAR(100))
AS
INSERT INTO Conversation(id, creatorId,avatar,title) VALUES(@id, @creatorId, @avatar, @title)
GO
CREATE PROCEDURE Usp_GetMessagesByConversationId(@conversationId AS VARCHAR(30), @offset AS INT, @limit AS INT)
AS
BEGIN
WITH Message_CTE AS
(
    SELECT msg.*, acc.firstName, acc.lastName, acc.avatar, ROW_NUMBER() OVER (ORDER BY msg.createdAt DESC) AS rowNum FROM Message AS msg, Account AS acc WHERE msg.conversationId = @conversationId AND msg.senderId = acc.id
)
SELECT id, conversationId, senderId,firstName, lastName, avatar, content, messageType, createdAt FROM Message_CTE WHERE rowNum >= @offset AND rowNum < @offset + @limit
END
GO 
CREATE PROCEDURE Usp_GetAllMessageByConversationId(@conversationId AS VARCHAR(30))
AS
SELECT msg.*, acc.firstName, acc.lastName, acc.avatar FROM Message AS msg, Account AS acc WHERE msg.conversationId = @conversationId AND msg.senderId = acc.id ORDER BY msg.createdAt DESC
GO
CREATE PROCEDURE Usp_InsertToConversations(@uId AS INT)
AS
BEGIN
	DELETE FROM Conversation2
	DECLARE @conversationId VARCHAR(30)
	DECLARE @getid CURSOR
	SET @getid = CURSOR FOR
	SELECT conversationId
	FROM  Participant where userId = @uId
	OPEN @getid
	FETCH NEXT
	FROM @getid INTO @conversationId
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO Conversation2 
		SELECT TOP(1) con.id, con.creatorId, con.avatar, con.title, mes.senderId, mes.messageType, mes.content, mes.createdAt
		FROM Conversation AS con, Message AS mes 
		where con.id = @conversationId AND con.id = mes.conversationId ORDER BY mes.createdAt DESC
		FETCH NEXT
		FROM @getid INTO @conversationId
	END
	CLOSE @getid
	DEALLOCATE @getid
END
GO
CREATE PROCEDURE Usp_GetConversationsByUserId(@id AS INT)
AS
BEGIN
	EXEC Usp_InsertToConversations @uid = @id
	SELECT * FROM Conversation2
END
GO
CREATE PROCEDURE Usp_InsertToAccount2(@cId AS VARCHAR(30))
AS
BEGIN
	DELETE FROM Account2
	DECLARE @accId INT
	DECLARE @getid CURSOR
	SET @getid = CURSOR FOR
	SELECT userId
	FROM  Participant where conversationId = @cId
	OPEN @getid
	FETCH NEXT
	FROM @getid INTO @accId
	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO Account2 
		SELECT * FROM Account WHERE id = @accId
		FETCH NEXT
		FROM @getid INTO @accId
	END
	CLOSE @getid
	DEALLOCATE @getid
END
GO
CREATE PROCEDURE Usp_GetMembersOfConversation(@conversationId AS VARCHAR(30))
AS
BEGIN
 EXEC Usp_InsertToAccount2 @cId = @conversationId
 SELECT * FROM Account2
END

