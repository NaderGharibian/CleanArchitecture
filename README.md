![image](https://user-images.githubusercontent.com/11174278/229805871-aa708043-afbd-4514-b295-a38876f1e361.png)





## Simple CRUD

![image](https://user-images.githubusercontent.com/11174278/229807097-56092c70-2e46-4052-9666-08cb0c7f1468.png)


 ##FAST WAY 
 ________________
 
 ``` sql
 Create DATABASE TestDB

USE [TestDB]
GO

/****** Object:  Table [dbo].[TCustomer]    Script Date: 2023/03/12 23:40:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[DateOfBirth] [nvarchar](50) NOT NULL,
	[BankAccountNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__TCustome__3214EC078FADFB39] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
_________________________________________________
