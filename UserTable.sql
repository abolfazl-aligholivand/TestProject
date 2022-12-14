USE [TestDataBase]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Age] [int] NULL,
	[Credit] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser] @first_name nvarchar(100), @last_name nvarchar(100), @age int, @credit bigint
AS
INSERT INTO dbo.UserInfo (FirstName, LastName, Age, Credit)
VALUES(@first_name, @last_name, @age, @credit);
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser] @id int
AS
DELETE FROM dbo.UserInfo
WHERE Id = @id;
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById] @Id int
AS
SELECT * FROM dbo.UserInfo 
WHERE Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[SelectAllUsers]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectAllUsers]
AS
SELECT * FROM dbo.UserInfo
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12/6/2022 6:19:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser] @id int, @first_name nvarchar(100), @last_name nvarchar(100), @age int, @credit bigint
AS
UPDATE dbo.UserInfo
SET FirstName = @first_name, LastName=@last_name, Age=@age, Credit=@credit
WHERE Id = @id;
GO
