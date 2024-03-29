USE [master]
GO
/****** Object:  Database [Web_Music_v3]    Script Date: 11.02.2024 13:42:35 ******/
CREATE DATABASE [Web_Music_v3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Web_Music_v2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Web_Music_v2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Web_Music_v2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Web_Music_v2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Web_Music_v3] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Web_Music_v3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Web_Music_v3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Web_Music_v3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Web_Music_v3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Web_Music_v3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Web_Music_v3] SET ARITHABORT OFF 
GO
ALTER DATABASE [Web_Music_v3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Web_Music_v3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Web_Music_v3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Web_Music_v3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Web_Music_v3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Web_Music_v3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Web_Music_v3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Web_Music_v3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Web_Music_v3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Web_Music_v3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Web_Music_v3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Web_Music_v3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Web_Music_v3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Web_Music_v3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Web_Music_v3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Web_Music_v3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Web_Music_v3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Web_Music_v3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Web_Music_v3] SET  MULTI_USER 
GO
ALTER DATABASE [Web_Music_v3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Web_Music_v3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Web_Music_v3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Web_Music_v3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Web_Music_v3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Web_Music_v3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Web_Music_v3] SET QUERY_STORE = OFF
GO
USE [Web_Music_v3]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[User_Id] [int] NOT NULL,
	[IsVisible] [bit] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumTrack]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumTrack](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Album_Id] [int] NOT NULL,
	[Track_Id] [int] NOT NULL,
 CONSTRAINT [PK_AlbumTrack] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumUser]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Album_Id] [int] NOT NULL,
 CONSTRAINT [PK_AlbumUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PlaylistUser]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlaylistUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Track_Id] [int] NOT NULL,
 CONSTRAINT [PK_User_Tracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Path_File] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tracks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11.02.2024 13:42:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 

INSERT [dbo].[Album] ([Id], [Title], [Author], [User_Id], [IsVisible]) VALUES (7, N'Вдохновение', N'MACAN', 2, 0)
INSERT [dbo].[Album] ([Id], [Title], [Author], [User_Id], [IsVisible]) VALUES (8, N'Природа', N'Eminem', 2, 1)
INSERT [dbo].[Album] ([Id], [Title], [Author], [User_Id], [IsVisible]) VALUES (9, N'Мой альбом', N'Stalker', 2021, 0)
INSERT [dbo].[Album] ([Id], [Title], [Author], [User_Id], [IsVisible]) VALUES (10, N'Время', N'Stalker', 2021, 0)
SET IDENTITY_INSERT [dbo].[Album] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumTrack] ON 

INSERT [dbo].[AlbumTrack] ([Id], [Album_Id], [Track_Id]) VALUES (2017, 10, 8)
SET IDENTITY_INSERT [dbo].[AlbumTrack] OFF
GO
SET IDENTITY_INSERT [dbo].[AlbumUser] ON 

INSERT [dbo].[AlbumUser] ([Id], [User_Id], [Album_Id]) VALUES (2023, 2, 7)
INSERT [dbo].[AlbumUser] ([Id], [User_Id], [Album_Id]) VALUES (2024, 2, 8)
INSERT [dbo].[AlbumUser] ([Id], [User_Id], [Album_Id]) VALUES (2026, 2021, 10)
SET IDENTITY_INSERT [dbo].[AlbumUser] OFF
GO
SET IDENTITY_INSERT [dbo].[PlaylistUser] ON 

INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2029, 1, 8)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2030, 1, 9)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2033, 2, 8)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2034, 2, 9)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2035, 2, 10)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2036, 2, 12)
INSERT [dbo].[PlaylistUser] ([Id], [User_Id], [Track_Id]) VALUES (2037, 2021, 8)
SET IDENTITY_INSERT [dbo].[PlaylistUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Track] ON 

INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (8, N'All Night', N'Mishlawi', N'~/mp3/Mishlawi - All Night.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (9, N'Lie Draco', N'Dancin''(kron0 slowed)', N'~/mp3/Dancin''(kron0 slowed) - Lil Drako.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (10, N'Obsession (feat. Steven Aderinto & DuoViolins)', N'Consoul Trainin feat. Steven Aderinto, DuoViolins', N'~/mp3/Consoul Trainin feat. Steven Aderinto, DuoViolins - Obsession (feat. Steven Aderinto & DuoViolins).mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (12, N'Smack That', N'Akon feat. Eminem', N'~/mp3/Akon feat. Eminem - Smack That.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (13, N'Dangerous (feat. Sam Martin)', N'David Guetta feat. Sam Martin', N'~/mp3/David Guetta feat. Sam Martin - Dangerous (feat. Sam Martin).mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (14, N'Beggin (Uscar Version)', N'Madcon', N'~/mp3/Madcon - Beggin (Uscar Version).mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (15, N'NOBODY BELIEVES IN YOU', N'Неизвестен', N'~/mp3/Неизвестен - NOBODY BELIEVES IN YOU.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (16, N'Moking bird', N'Eminem', N'~/mp3/Eminem - Moking bird.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (17, N'Space Cadet', N'Metro Boomin feat. Gunna', N'~/mp3/Metro Boomin feat. Gunna - Space Cadet.mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (18, N'In The Water (The Walking Dead OST)', N'Anadel', N'~/mp3/Anadel - In The Water (The Walking Dead OST).mp3')
INSERT [dbo].[Track] ([Id], [Title], [Author], [Path_File]) VALUES (19, N'Enemy from the series Arcane League of Legends', N'Imagine Dragons, JID, Arcane, League Of Legends', N'~/mp3/Imagine Dragons, JID, Arcane, League Of Legends - Enemy (from the series Arcane League of Legends) (from the series Arcane League of Legends).mp3')
SET IDENTITY_INSERT [dbo].[Track] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [IsAdmin]) VALUES (1, N'Admin', N'ISMvKXpXpadDiUoOSoAfww==', N'Admin', 1)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [IsAdmin]) VALUES (2, N'User', N'7hHLsZBS5AsHqsDKBgwj7g==', N'User', 0)
INSERT [dbo].[User] ([Id], [Login], [Password], [Email], [IsAdmin]) VALUES (2021, N'Stalker', N'tZxnvxlqR1gZHkL3ZnDOug==', N'druian.oleg@yandex.ru', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[AlbumTrack]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTrack_Album] FOREIGN KEY([Album_Id])
REFERENCES [dbo].[Album] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlbumTrack] CHECK CONSTRAINT [FK_AlbumTrack_Album]
GO
ALTER TABLE [dbo].[AlbumTrack]  WITH CHECK ADD  CONSTRAINT [FK_AlbumTrack_Track] FOREIGN KEY([Track_Id])
REFERENCES [dbo].[Track] ([Id])
GO
ALTER TABLE [dbo].[AlbumTrack] CHECK CONSTRAINT [FK_AlbumTrack_Track]
GO
ALTER TABLE [dbo].[AlbumUser]  WITH CHECK ADD  CONSTRAINT [FK_AlbumUser_Album] FOREIGN KEY([Album_Id])
REFERENCES [dbo].[Album] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AlbumUser] CHECK CONSTRAINT [FK_AlbumUser_Album]
GO
ALTER TABLE [dbo].[AlbumUser]  WITH CHECK ADD  CONSTRAINT [FK_AlbumUser_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[AlbumUser] CHECK CONSTRAINT [FK_AlbumUser_User]
GO
ALTER TABLE [dbo].[PlaylistUser]  WITH CHECK ADD  CONSTRAINT [FK_PlaylistUser_Auth] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistUser] CHECK CONSTRAINT [FK_PlaylistUser_Auth]
GO
ALTER TABLE [dbo].[PlaylistUser]  WITH CHECK ADD  CONSTRAINT [FK_User_Tracks_Tracks] FOREIGN KEY([Track_Id])
REFERENCES [dbo].[Track] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaylistUser] CHECK CONSTRAINT [FK_User_Tracks_Tracks]
GO
USE [master]
GO
ALTER DATABASE [Web_Music_v3] SET  READ_WRITE 
GO
