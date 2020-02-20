CREATE TABLE [Categories] (
	[CategoryID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CategoryName] varchar(255) NOT NULL,
	[Description] varchar(255),
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL
);

CREATE TABLE [Forums] (
	[ForumID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ForumName] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[CreatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[UpdatedOn] datetime2(7) DEFAULT GETUTCDATE() NOT NULL,
	[CategoryID] int NOT NULL,
	[ForumImageURL] varchar(255)
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
	[PasswordHash] varbinary(max) NOT NULL,
	[PasswordSalt] varbinary(max) NOT NULL,
	CONSTRAINT Username UNIQUE (Username)
);

CREATE TABLE [Login] (
	[UserId] int NOT NULL,
	[Password] varchar(16)
);
