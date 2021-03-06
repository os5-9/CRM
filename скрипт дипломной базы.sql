USE [master]
GO
CREATE DATABASE [TravelAgency]
Go
USE [TravelAgency]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ID] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[PassportS] [nvarchar](4) NULL,
	[PassportN] [nvarchar](6) NULL,
	[BDay] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[Gender] [nvarchar](7) NULL,
	[Msisdn] [nvarchar](16) NULL,
	[Email] [nvarchar](50) NULL,
	[IsExists] [tinyint] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[ID] [int] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsAdmin] [tinyint] NULL,
	[IsExists] [tinyint] NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tours]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[ID] [int] NOT NULL,
	[City] [nvarchar](45) NULL,
	[Country] [nvarchar](45) NULL,
	[Price] [int] NULL,
	[State] [int] NULL,
	[Departure] [date] NULL,
	[Arrival] [date] NULL,
	[Type] [int] NULL,
	[IsExists] [tinyint] NULL,
 CONSTRAINT [PK_Tours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourStates]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourStates](
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TourStates] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TourType]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TourType](
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TourType] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Track]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Track](
	[ID] [int] NOT NULL,
	[StaffID] [int] NULL,
	[ClientID] [int] NULL,
	[TransportID] [int] NULL,
	[TourID] [int] NULL,
	[ContractDate] [date] NULL,
	[IsExists] [tinyint] NULL,
 CONSTRAINT [PK_Track] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transports]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transports](
	[ID] [int] NOT NULL,
	[Type] [int] NULL,
	[RegNumber] [nvarchar](50) NULL,
	[ProductionYear] [int] NULL,
	[IsExists] [tinyint] NULL,
 CONSTRAINT [PK_Transports] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransportType]    Script Date: 14.04.2022 23:44:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportType](
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_TransportType] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (1, N'Самойлова Татьяна Борисова', N'7304', N'546364', CAST(N'1990-12-18' AS Date), N'улица Какая-то дом не знаю квартира 20', N'Женский', N'+7(432)111-11-11', N'damochka3@mail.ru', 0)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (2, N'Карамазов Дмитрий Аркадьевич', N'7314', N'563666', CAST(N'2000-12-31' AS Date), N'улица Ступенчатая дом 4 квартира 50', N'Мужской', N'+7(567)457-45-74', N'standtrack@yandex.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (3, N'Иванов Степан Константинович', N'7394', N'453534', CAST(N'1980-12-08' AS Date), N'улица Рябикова дом 7 квартира 120', N'Мужской', N'+7(345)342-53-53', N'ivanovstepka@gmail.com', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (4, N'Иванова Екатерина Дмитриевна', N'7309', N'325234', CAST(N'1995-12-23' AS Date), N'улица Карла Маркса дом 50 квартира 40', N'Женский', N'+7(346)287-56-82', N'kate2134315@mail.ru', 0)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (10, N'Шарамарова Галина Егоровна', N'7317', N'689375', CAST(N'2003-07-12' AS Date), N'улица Тюленева дом 18 квартира 35', N'Женский', N'+7(367)598-26-75', N'dsfgsedrfg@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (11, N'Коткин Виталий Сергеевич', N'7316', N'345987', CAST(N'2002-04-10' AS Date), N'улица Заречная дом 9 квартира 14', N'Мужской', N'+7(327)627-13-54', N'kotkotkot@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (12, N'Грачевская Ирина Николаевна', N'7394', N'634567', CAST(N'1980-08-11' AS Date), N'улица Подорожная дом 15 квартира 199', N'Женский', N'+7(876)342-89-73', N'iro4ka@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (13, N'Красочкина Ирина Александровна', N'7313', N'459836', CAST(N'1999-10-23' AS Date), N'улица Красок дом 5 квартира 26', N'Женский', N'+7(625)143-87-34', N'colors@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (14, N'Карапузов Георгий Николаевич', N'7311', N'687356', CAST(N'1997-08-14' AS Date), N'улица Карамазова дом 15 квартира 241', N'Мужской', N'+7(547)821-34-78', N'carapuzzz@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (15, N'Мукина Анастасия Дмитриевна', N'7316', N'554326', CAST(N'2002-06-16' AS Date), N'улица Калнина дом 5 квартира 12', N'Женский', N'+7(768)531-48-47', N'naste@mail.ru', 1)
GO
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (1, N'Иванов Иван Иванович', N'admin', N'admin', 1, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (2, N'Кукурузкин Сергей Александрович', N'corn', N'698d51a19d8a121ce581499d7b701668', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (3, N'Зубенко Михаил Петрович', N'mafin', N'9a12f40900db5295d47b4dec0b2e9d9e', 1, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (4, N'Кузьмин Александр Андреевич', N'cu', N'a4dbfd6aef3b4045fe61aa0146debdf8', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (7, N'Кукурузкин Кирилл Алексеевич', N'hsdfg', N'912ec803b2ce49e4a541068d495ab570', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (11, N'Алапаев Григорий Сергеевич', N'manager', N'1d0258c2440a8d19e716292b231e3190', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (12, N'Костромской Даниил Максимович', N'max', N'2ffe4e77325d9a7152f7086ea7aa5114', 0, 1)
GO
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (1, N'Лондон', N'Великобритания', 40000.0000, 2, CAST(N'2020-11-20' AS Date), CAST(N'2020-12-20' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (2, N'Нью-Йорк', N'США', 20000.0000, 1, CAST(N'2021-06-13' AS Date), CAST(N'2021-06-20' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (3, N'Шарм-эль-Шейх', N'Египет', 35300.0000, 1, CAST(N'2021-07-01' AS Date), CAST(N'2021-07-11' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (4, N'Казань', N'Россия', 10000.0000, 1, CAST(N'2021-03-20' AS Date), CAST(N'2021-03-27' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (5, N'Алтай', N'Россия', 62000.0000, 2, CAST(N'2020-11-21' AS Date), CAST(N'2020-11-29' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (6, N'Тунис', N'Тунис', 58000.0000, 2, CAST(N'2020-11-14' AS Date), CAST(N'2020-11-20' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (7, N'Родос', N'Греция', 48000.0000, 1, CAST(N'2020-08-12' AS Date), CAST(N'2020-08-16' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (8, N'Никосия', N'Кипр', 45000.0000, 1, CAST(N'2020-06-10' AS Date), CAST(N'2020-06-20' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (13, N'Дубай', N'ОАЭ', 450000.0000, 2, CAST(N'2021-01-13' AS Date), CAST(N'2021-01-20' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (14, N'Сеул', N'Южная Корея', 120000.0000, 2, CAST(N'2021-01-14' AS Date), CAST(N'2021-01-28' AS Date), 2, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (15, N'Атолл Шавиани', N'Мальдивы', 260000.0000, 1, CAST(N'2021-03-14' AS Date), CAST(N'2021-03-21' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (16, N'Пусан', N'Южная Корея', 30000.0000, 2, CAST(N'2021-01-14' AS Date), CAST(N'2021-01-31' AS Date), 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [IsExists]) VALUES (17, N'Париж', N'Франция', 120000.0000, 2, CAST(N'2021-01-16' AS Date), CAST(N'2021-01-23' AS Date), 1, 1)
GO
INSERT [dbo].[TourStates] ([Code], [Name]) VALUES (1, N'Обычная')
INSERT [dbo].[TourStates] ([Code], [Name]) VALUES (2, N'Горячая')
GO
INSERT [dbo].[TourType] ([Code], [Name]) VALUES (1, N'Прямой полет')
INSERT [dbo].[TourType] ([Code], [Name]) VALUES (2, N'С пересадками')
GO
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (1, 3, 2, 2, 6, CAST(N'2020-10-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (2, 3, 3, 5, 5, CAST(N'2020-10-10' AS Date), 0)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (3, 1, 12, 2, 6, CAST(N'2020-10-10' AS Date), 0)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (4, 4, 2, 5, 6, CAST(N'2020-10-11' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (5, 1, 11, 1, 1, CAST(N'2020-10-11' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (6, 4, 11, 1, 1, CAST(N'2020-10-12' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (7, 4, 1, 1, 1, CAST(N'2020-10-12' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (8, 1, 11, 3, 4, CAST(N'2020-12-12' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (9, 3, 10, 5, 5, CAST(N'2020-12-12' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (10, 1, 1, 3, 3, CAST(N'2021-06-16' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (11, 1, 4, 4, 3, CAST(N'2021-06-17' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (12, 4, 3, 3, 15, CAST(N'2021-02-17' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (13, 3, 10, 3, 14, CAST(N'2021-01-07' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (14, 1, 13, 7, 13, CAST(N'2021-01-07' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (15, 1, 11, 7, 3, CAST(N'2021-04-20' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (16, 1, 4, 3, 3, CAST(N'2021-04-20' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (17, 1, 11, 1, 14, CAST(N'2021-01-09' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (18, 3, 3, 2, 15, CAST(N'2021-03-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (19, 3, 4, 5, 4, CAST(N'2021-03-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (20, 11, 11, 1, 14, CAST(N'2021-01-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (21, 3, 12, 7, 2, CAST(N'2021-05-18' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (22, 11, 14, 3, 5, CAST(N'2020-10-21' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (23, 11, 15, 1, 13, CAST(N'2021-01-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (24, 11, 13, 7, 5, CAST(N'2020-11-19' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (25, 4, 11, 5, 6, CAST(N'2020-11-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (26, 1, 13, 1, 15, CAST(N'2021-03-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (27, 11, 14, 7, 16, CAST(N'2021-01-08' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (28, 4, 15, 7, 16, CAST(N'2021-01-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (29, 12, 15, 4, 17, CAST(N'2021-01-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (30, 4, 2, 4, 2, CAST(N'2021-05-10' AS Date), 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [TransportID], [TourID], [ContractDate], [IsExists]) VALUES (31, 11, 4, 4, 1, CAST(N'2020-10-20' AS Date), 1)
GO
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (1, 1, N'RA-93480', 2017, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (2, 2, N'301-450', 2020, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (3, 3, N'кс108т', 2020, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (4, 2, N'124314', 2017, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (5, 2, N'3412', 2020, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (6, 3, N'ус544с', 2020, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (7, 1, N'wettwtwt', 2020, 0)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (8, 3, N'вс432т', 2018, 1)
INSERT [dbo].[Transports] ([ID], [Type], [RegNumber], [ProductionYear], [IsExists]) VALUES (9, 3, N'вт293с', 2020, 1)
GO
INSERT [dbo].[TransportType] ([Code], [Name]) VALUES (1, N'Самолёт')
INSERT [dbo].[TransportType] ([Code], [Name]) VALUES (2, N'Поезд')
INSERT [dbo].[TransportType] ([Code], [Name]) VALUES (3, N'Автобус')
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_Tours_TourStates] FOREIGN KEY([State])
REFERENCES [dbo].[TourStates] ([Code])
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_Tours_TourStates]
GO
ALTER TABLE [dbo].[Tours]  WITH CHECK ADD  CONSTRAINT [FK_Tours_TourType] FOREIGN KEY([Type])
REFERENCES [dbo].[TourType] ([Code])
GO
ALTER TABLE [dbo].[Tours] CHECK CONSTRAINT [FK_Tours_TourType]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Clients]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([ID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Staff]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Tours] FOREIGN KEY([TourID])
REFERENCES [dbo].[Tours] ([ID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Tours]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_Track_Transports] FOREIGN KEY([TransportID])
REFERENCES [dbo].[Transports] ([ID])
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_Track_Transports]
GO
ALTER TABLE [dbo].[Transports]  WITH CHECK ADD  CONSTRAINT [FK_Transports_TransportType] FOREIGN KEY([Type])
REFERENCES [dbo].[TransportType] ([Code])
GO
ALTER TABLE [dbo].[Transports] CHECK CONSTRAINT [FK_Transports_TransportType]
GO
USE [master]
GO
ALTER DATABASE [TravelAgency] SET  READ_WRITE 
GO
