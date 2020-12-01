USE [infoUser]
GO
/****** Object:  Table [dbo].[TieuSu]    Script Date: 12/1/2020 8:32:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuSu](
	[ID] [nvarchar](10) NOT NULL,
	[IDUser] [nvarchar](10) NULL,
	[Info] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/1/2020 8:32:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[DateofBirth] [date] NULL,
	[info] [nvarchar](100) NULL,
	[Sex] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TieuSu] ([ID], [IDUser], [Info]) VALUES (N'1', N'1', N'Cuoc doi thiet qua bat cong')
INSERT [dbo].[TieuSu] ([ID], [IDUser], [Info]) VALUES (N'2', N'2', N'khong co gi de kho')
INSERT [dbo].[Users] ([ID], [Name], [DateofBirth], [info], [Sex]) VALUES (N'1', N'nguyen thi teo', CAST(N'1999-10-13' AS Date), N'co mot khuyet diem la 20 cm', 1)
INSERT [dbo].[Users] ([ID], [Name], [DateofBirth], [info], [Sex]) VALUES (N'2', N'nguyen van luyen', CAST(N'1998-11-13' AS Date), N'co mot khuyet diem la 10 cm', 1)
INSERT [dbo].[Users] ([ID], [Name], [DateofBirth], [info], [Sex]) VALUES (N'3', N'nguyen ngoc truc my', CAST(N'1999-11-15' AS Date), N'co mot khuyet diem la de thuong', 0)
ALTER TABLE [dbo].[TieuSu]  WITH CHECK ADD FOREIGN KEY([IDUser])
REFERENCES [dbo].[Users] ([ID])
GO
