CREATE TABLE [Categories] (
	[CategoryId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryName] varchar(255) NOT NULL,
	[Description] varchar(255),
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL
);

CREATE TABLE [Forums] (
	[Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[CategoryId] int NOT NULL,
	[Image] varchar(255)
);

CREATE TABLE [Threads] (
	[Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Title] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[ForumId] int NOT NULL,
	[UserId] int NOT NULL
);

CREATE TABLE [Posts] (
	[Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Content] TEXT NOT NULL,
	[ThreadId] int NOT NULL,
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UserId] int NOT NULL
);

CREATE TABLE [Users] (
	[Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Username] varchar(20) NOT NULL,
	[Password] varchar(255) NOT NULL,
	CONSTRAINT Username UNIQUE (Username)
);

CREATE TABLE [Login] (
	[UserId] int NOT NULL,
	[Password] varchar(16)
);

CREATE TABLE [dbo].[Employee](    
    [Id] [int] IDENTITY(1,1) NOT NULL,    
    [Name] [nvarchar](50) NULL,    
    [Position] [nvarchar](50) NULL,    
    [Office] [nvarchar](50) NULL,    
    [Age] [int] NULL,    
    [Salary] [int] NULL,    
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED     
( [Id] ASC )
WITH (
	PAD_INDEX = OFF,
	STATISTICS_NORECOMPUTE = OFF, 
	IGNORE_DUP_KEY = OFF, 
	ALLOW_ROW_LOCKS = ON, 
	ALLOW_PAGE_LOCKS = ON) 
	ON [PRIMARY]    
) ON [PRIMARY]   
