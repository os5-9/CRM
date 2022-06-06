USE [TravelAgency]
GO
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (1, N'Самойлова Татьяна Борисова', N'7304', N'546364', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2010-12-28' AS Date), N'730-003', NULL, CAST(N'1990-12-18' AS Date), N'улица Краснопролетарская дом 3 квартира 20', N'Женский', N'+7(432)111-11-11', N'damochka3@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (2, N'Карамазов Дмитрий Аркадьевич', N'7314', N'563666', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2020-12-31' AS Date), N'730-003', NULL, CAST(N'2000-12-31' AS Date), N'улица Ступенчатая дом 4 квартира 50', N'Мужской', N'+7(567)457-45-74', N'standtrack@yandex.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (3, N'Иванов Степан Константинович', N'7394', N'453534', N'Отделом УФМС России по Ульяновской области в Засвияжсвом районе гор. Ульяновска', CAST(N'2000-12-08' AS Date), N'730-000', NULL, CAST(N'1980-12-08' AS Date), N'улица Рябикова дом 7 квартира 120', N'Мужской', N'+7(345)342-53-53', N'ivanovstepka@gmail.com', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (4, N'Иванова Екатерина Дмитриевна', N'7309', N'325234', N'Отделом УФМС России по Ульяновской области в Засвияжсвом районе гор. Ульяновска', CAST(N'2015-12-25' AS Date), N'730-000', NULL, CAST(N'1995-12-23' AS Date), N'улица Карла Маркса дом 50 квартира 40', N'Женский', N'+7(346)287-56-82', N'kate2134315@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (10, N'Шарамарова Галина Егоровна', N'7317', N'689375', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2017-08-12' AS Date), N'730-003', NULL, CAST(N'2003-07-12' AS Date), N'улица Краснопролетарская дом 18 квартира 35', N'Женский', N'+7(367)598-26-75', N'dsfgsedrfg@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (11, N'Пушкин Александр Сергеевич', N'7316', N'345987', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2022-05-14' AS Date), N'730-003', NULL, CAST(N'2002-04-12' AS Date), N'улица Заречная дом 1 квартира 140', N'Мужской', N'+7(327)627-13-54', N'genius@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (12, N'Грачевская Ирина Николаевна', N'7394', N'634567', N'Отделом УФМС России по Ульяновской области в Засвияжсвом районе гор. Ульяновска', CAST(N'2000-08-21' AS Date), N'730-000', NULL, CAST(N'1980-08-11' AS Date), N'улица Подорожная дом 15 квартира 199', N'Женский', N'+7(876)342-89-73', N'iro4ka@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (13, N'Красочкина Ирина Александровна', N'7313', N'459836', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2019-10-28' AS Date), N'730-003', NULL, CAST(N'1999-10-23' AS Date), N'улица Красок дом 5 квартира 26', N'Женский', N'+7(625)143-87-34', N'colors@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (14, N'Карапузов Георгий Николаевич', N'7311', N'687356', N'Отделом УФМС России по Ульяновской области в Заволжском районе гор. Ульяновска', CAST(N'2017-08-20' AS Date), N'730-003', NULL, CAST(N'1997-08-14' AS Date), N'улица Карамазова дом 15 квартира 241', N'Мужской', N'+7(547)821-34-78', N'carapuzzz@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (15, N'Мукина Анастасия Дмитриевна', N'7316', N'554326', N'Отделом УФМС России по Ульяновской области в Засвияжсвом районе гор. Ульяновска', CAST(N'2022-02-20' AS Date), N'730-000', NULL, CAST(N'2002-02-15' AS Date), N'улица Калнина дом 8 квартира 12', N'Женский', N'+7(000)-531-48-47', N'nasteM@mail.ru', 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (16, N'Прохорова Алёна Сергеевна', NULL, NULL, NULL, NULL, NULL, N'III-АМ 232323', CAST(N'2016-04-10' AS Date), N'улица Рябикова дом 9 квартира 103', N'Женский', NULL, NULL, 1)
INSERT [dbo].[Clients] ([ID], [FullName], [PassportS], [PassportN], [Whom], [TakedDay], [CodeUnit], [BirthCertificateNumber], [BDay], [Address], [Gender], [Msisdn], [Email], [IsExists]) VALUES (17, N'Прохоров Анатолий Максимович', N'7301', N'223423', N'Отделом УФМС России по Ульяновской области в Засвияжсвом районе гор. Ульяновска', CAST(N'2021-02-26' AS Date), N'730-000', NULL, CAST(N'2001-02-23' AS Date), N'улица Рябикова дом 9 квартира 103', N'Мужской', NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Clients] OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (2, N'Кукурузкин Сергей Александрович', N'corn', N'corn', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (3, N'Зубенко Михаил Петрович', N'mafin', N'mafin', 1, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (4, N'Кузьмин Александр Андреевич', N'asdfghlkhklsfdfs', N'asdfghlkhklsfdfs', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (7, N'Кукурузкин Кирилл Алексеевич', N'hsdfg', N'hsdfg', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (11, N'Алапаев Григорий Сергеевич', N'manager', N'manager', 0, 1)
INSERT [dbo].[Staff] ([ID], [FullName], [Login], [Password], [IsAdmin], [IsExists]) VALUES (12, N'Костромской Даниил Максимович', N'max', N'max', 0, 1)
SET IDENTITY_INSERT [dbo].[Staff] OFF
GO
SET IDENTITY_INSERT [dbo].[Tours] ON 

INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (42, N'Владимир', N'Россия', 10000, 2, CAST(N'2022-01-13' AS Date), CAST(N'2022-01-20' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (43, N'Волгоград', N'Россия', 10000, 1, CAST(N'2022-01-13' AS Date), CAST(N'2022-01-20' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (44, N'Воронеж', N'Россия', 11000, 1, CAST(N'2022-01-14' AS Date), CAST(N'2022-01-28' AS Date), 2, 44, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (45, N'Казань', N'Россия', 20000, 1, CAST(N'2022-01-14' AS Date), CAST(N'2022-01-31' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (46, N'Алтай', N'Россия', 20000, 2, CAST(N'2022-01-14' AS Date), CAST(N'2022-01-28' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (47, N'Екатеринбург', N'Россия', 11000, 2, CAST(N'2022-01-14' AS Date), CAST(N'2022-01-31' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (48, N'Иркутск', N'Россия', 16000, 1, CAST(N'2022-01-16' AS Date), CAST(N'2022-01-23' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (49, N'Йошкар-Ола', N'Россия', 11000, 1, CAST(N'2022-01-16' AS Date), CAST(N'2022-01-23' AS Date), 2, 20, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (50, N'Великий Новгород', N'Россия', 12000, 2, CAST(N'2022-03-14' AS Date), CAST(N'2022-03-21' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (51, N'Калининград', N'Россия', 20000, 2, CAST(N'2022-03-14' AS Date), CAST(N'2022-03-21' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (52, N'Санкт-Петербург', N'Россия', 18000, 1, CAST(N'2022-03-20' AS Date), CAST(N'2022-03-27' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (53, N'Ростов-на-Дону', N'Россия', 12000, 2, CAST(N'2022-03-20' AS Date), CAST(N'2022-03-27' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (54, N'Кострома', N'Россия', 12000, 2, CAST(N'2022-05-25' AS Date), CAST(N'2022-05-28' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (55, N'Москва', N'Россия', 12000, 2, CAST(N'2022-05-25' AS Date), CAST(N'2022-06-04' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (56, N'Муром', N'Россия', 12000, 2, CAST(N'2022-05-25' AS Date), CAST(N'2022-05-28' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (57, N'Мурманск', N'Россия', 23000, 2, CAST(N'2022-05-25' AS Date), CAST(N'2022-06-04' AS Date), 2, 45, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (58, N'Казань', N'Россия', 20000, 1, CAST(N'2022-05-27' AS Date), CAST(N'2022-05-29' AS Date), 1, 6, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (59, N'Красноярск', N'Россия', 22000, 2, CAST(N'2022-05-27' AS Date), CAST(N'2022-05-29' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (60, N'Нижний Новгород', N'Россия', 10000, 2, CAST(N'2022-05-29' AS Date), CAST(N'2022-06-05' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (61, N'Казань', N'Россия', 20000, 1, CAST(N'2022-05-29' AS Date), CAST(N'2022-06-05' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (62, N'Алтай', N'Россия', 20000, 2, CAST(N'2022-05-29' AS Date), CAST(N'2022-06-05' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (63, N'Рязань', N'Россия', 10000, 2, CAST(N'2022-05-29' AS Date), CAST(N'2022-06-05' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (64, N'Самара', N'Россия', 13000, 1, CAST(N'2022-06-09' AS Date), CAST(N'2022-06-11' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (65, N'Санкт-Петербург', N'Россия', 18000, 1, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-20' AS Date), 2, 20, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (66, N'Калининград', N'Россия', 20000, 2, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-20' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (67, N'Псков', N'Россия', 9000, 2, CAST(N'2022-06-13' AS Date), CAST(N'2022-06-20' AS Date), 2, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (68, N'Муром', N'Россия', 12000, 1, CAST(N'2022-07-01' AS Date), CAST(N'2022-07-11' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (69, N'Нижний Новгород', N'Россия', 10000, 2, CAST(N'2022-07-09' AS Date), CAST(N'2022-07-11' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (70, N'Калининград', N'Россия', 20000, 2, CAST(N'2022-08-12' AS Date), CAST(N'2022-08-16' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (71, N'Мурманск', N'Россия', 23000, 2, CAST(N'2022-08-12' AS Date), CAST(N'2022-08-16' AS Date), 1, 10, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (72, N'Москва', N'Россия', 12000, 2, CAST(N'2022-11-14' AS Date), CAST(N'2022-11-20' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (73, N'Красноярск', N'Россия', 22000, 2, CAST(N'2022-11-14' AS Date), CAST(N'2022-11-20' AS Date), 2, 45, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (74, N'Казань', N'Россия', 20000, 1, CAST(N'2022-11-20' AS Date), CAST(N'2022-12-20' AS Date), 1, 6, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (75, N'Кострома', N'Россия', 14400, 2, CAST(N'2022-11-21' AS Date), CAST(N'2022-11-29' AS Date), 1, 2, 1, 1)
INSERT [dbo].[Tours] ([ID], [City], [Country], [Price], [State], [Departure], [Arrival], [Type], [Tickets], [IsExists], [IsApproved]) VALUES (76, N'Йошкар-Ола', N'Россия', 11000, 2, CAST(N'2022-11-21' AS Date), CAST(N'2022-11-29' AS Date), 1, 10, 1, 1)
SET IDENTITY_INSERT [dbo].[Tours] OFF
GO
SET IDENTITY_INSERT [dbo].[Track] ON 

INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (32, 2, 2, NULL, 44, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (33, 2, 4, N'10|12|13|', 47, CAST(N'2022-06-06' AS Date), 4, 44000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (35, 2, 3, N'4|10|', 62, CAST(N'2022-06-06' AS Date), 3, 60000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (36, 2, 4, NULL, 58, CAST(N'2022-06-06' AS Date), 1, 20000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (37, 2, 3, NULL, 46, CAST(N'2022-06-06' AS Date), 1, 20000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (38, 2, 4, NULL, 53, CAST(N'2022-06-06' AS Date), 1, 12000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (39, 2, 1, NULL, 44, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (40, 2, 2, NULL, 44, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (41, 2, 3, NULL, 42, CAST(N'2022-06-06' AS Date), 1, 10000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (42, 2, 4, NULL, 47, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (43, 2, 3, NULL, 44, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (44, 2, 2, NULL, 56, CAST(N'2022-06-06' AS Date), 1, 12000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (45, 2, 3, NULL, 44, CAST(N'2022-06-06' AS Date), 1, 11000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (46, 2, 3, NULL, 54, CAST(N'2022-06-06' AS Date), 1, 12000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (47, 2, 1, NULL, 58, CAST(N'2022-06-06' AS Date), 1, 20000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (48, 2, 3, N'4|10|', 76, CAST(N'2022-06-06' AS Date), 3, 33000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (49, 2, 17, N'16|', 76, CAST(N'2022-06-06' AS Date), 2, 22000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (50, 2, 17, N'16|', 65, CAST(N'2022-06-06' AS Date), 2, 36000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (51, 2, 17, N'16|', 53, CAST(N'2022-06-06' AS Date), 2, 24000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (52, 2, 17, N'16|', 47, CAST(N'2022-06-06' AS Date), 2, 22000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (53, 2, 17, N'16|', 66, CAST(N'2022-06-06' AS Date), 2, 40000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (54, 2, 2, NULL, 63, CAST(N'2022-06-06' AS Date), 1, 10000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (55, 2, 17, N'16|', 60, CAST(N'2022-06-06' AS Date), 2, 20000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (56, 2, 17, N'16|', 49, CAST(N'2022-06-06' AS Date), 2, 22000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (57, 2, 17, N'16|', 74, CAST(N'2022-06-06' AS Date), 2, 40000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (58, 2, 17, N'16|', 62, CAST(N'2022-06-06' AS Date), 2, 40000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (59, 2, 17, N'16|', 67, CAST(N'2022-06-06' AS Date), 2, 18000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (60, 2, 17, N'16|', 59, CAST(N'2022-06-06' AS Date), 2, 44000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (61, 2, 2, NULL, 56, CAST(N'2022-06-06' AS Date), 1, 12000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (62, 2, 17, N'16|', 48, CAST(N'2022-06-06' AS Date), 2, 32000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (63, 2, 17, N'16|', 42, CAST(N'2022-06-06' AS Date), 2, 20000, 1)
INSERT [dbo].[Track] ([ID], [StaffID], [ClientID], [Ward], [TourID], [ContractDate], [TicketsAmount], [TotalCost], [IsExists]) VALUES (64, 2, 17, N'16|', 63, CAST(N'2022-06-06' AS Date), 2, 20000, 1)
SET IDENTITY_INSERT [dbo].[Track] OFF
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202205281052010_InitialCreate', N'TourOperatorManagement.Models.AgencyModel', 0x1F8B0800000000000400ED5DDB6EE4B8117D0F907F10F494045EB7EDC9EC2646F72E3C6D7BD1C8F88269CF226F035A62B785D12D22DB7123D82FDB877C527E21A46ECDAB444A6AD99E35FC6293AC53BC54158B5415FDBFDFFE3BFDE9290A9D4798A1208967EEF1E191EBC0D84BFC205ECFDC0D5E7DF737F7A71FFFF887E9851F3D39BF54EDDED17684324633F701E3F4743241DE038C003A8C022F4B50B2C2875E124D809F4C4E8E8EFE3E393E9E4002E1122CC7997EDAC4388860FE07F9739EC41E4CF1068457890F435496939A658EEA5C8308A2147870E6DE259BEC268519C049760562B086118CF16141E83A67610048A796305CB90E88E304034CBA7CFA19C125CE9278BD4C490108EFB62924ED562044B01CCAE9AEB9E9A88E4EE8A8263BC20ACADB209C449680C7EFCA699A88E49D26DBADA7914CE4059970BCA5A3CE2773E6CEC380CC1B993191D7E93CCC68BB96A93E2C010E1C75B3835A5A8850D19F0367BE09F12683B3186E7006C203E776731F06DE3FE0F62EF90AE359BC0943B6D3A4DBA48E2B2045B7594298E1ED27B82A87B238779D094F3711096B3286A618E522C6EF4E5CE79A3007F721AC65829991251919FC19C6748CD0BF0518C38C2CE975124389B3C0E792C0D2DF2A6E4408896AB9CE1578FA08E3357E98B9E457D7B90C9EA05F95943DF81C0744130911CE36AD8C6E01426992E16503A7BF0EC8E7BA81CFF703F0F9700EB6158B7332ED7741D44A73E6FB194468EF734D44C18759039B1F0660728502E4C70D4C8E8798E68B0804610393F747033059A08BA700E17A613E6CB14C730D1E8375AE6F02F55D06BCAFAEF30986792D7A08D2C2C05726E84BD9E2324BA24F49B8336E45C5972531501ED5C044557B07B235C47C77A6939DBD6CB4A225E7AE3634277FB3A08D7C9618AC5612B3669A62852D89E82AD8F24962B20E1EA606CAD658DD05DE5788D159941067C8B2A31884F304D951F553C2DA5DE8AE8695A2A9D5B05252D30EE562A1EC4E5E2377862996BAC2D6D976848A8D7A5EF21AB9234CB1D411B64ED51163C3544E4F57C39493FF8E0DD3C287F98CBE18F7EE63B20E9A9C81E19CC87F2799BF77460B74E647BB01296DD1484E8481B9101D089529E9E63E14B6A3B3FB40C9DFB4B4554BE7791BFDB1E8FD00123DA7DB78B67736B759E041AB7D9F082BB6A3388729C8A8A0589FBFB22C7804A1B527445ADB394085EB34BCFB235BA934CD9247E877343A4431F3E9D7FB0745F597D210F04E025BA7F414B8065DFC9662E6355DA395EA8EED6A94DD62AAAD3BA535D306CE9468A6558E5667335DAD631F5B5D60BC00833D277DB237D905D51867BE1697AADBA544470FDE584355E2A754E1CE3258A86B1F09A4EDDEE4EF55C99F911956C99EC24A7792BC4A527A18BF1AE205C8DE4B77560D8E94C74743DCCAB61D2987E16270A41C86D13C89A82435F03919E832FB1CC641934BA8D3AC3384122FC88584BDA5299D1A9EE945EC3B0D07D16288F5F1950C93684B9012FD207C67EED1E1E1B1340E3564EDC0ED204B278B87FC8B8447540A6654A6E965648C8892063196F52F88BD2005A17E340289A1D2D269AEC1C51A7282A19F6862AC1FB009D7FAEA59665D73102C49DBA44C278C14340B87E47CE89653EF89306BCAB8B056B2A23F88F0E012EE4002A31B9CC9FAA9DC0C2BB9D10DDE5078E4B3E288A2C3F80D4D6BAB7222F8952DBC4E6BA1511D12C713197958A3098C3C7013D6C52C3F9BB4A0965D4879CE6E594E032191BE838CB30B294633C22EA418B0916494DF259F4536F86F7BBAA5D47C6FDF2D66FDF9D04A4234DF0FC79111E598469012E5A08D8C57FDD17B0449293C5CFAFD9B50C0ACBA005EC3D8DBE6873EC561F13382E5791195AEB6B8F0147309B1F8CD79E74E8BE224890E8F50CA87445F96B75097AEB5445D96B7F12E4CA2CCBB2837A0AEFC352544556980536C2D4A14D5AE236130170012085327A03082234C69758BCBB4507C8B1365B8F94454F7B95E3649099ACF3F0C805A3A26FC800C062BDF1ECA236E76F2CDDC7CB6EB5AC93073EA05287955BBCD027B87A59E039DB76AE2AF0A9DD67852ADDEE99EC68EF4E2AE75BC5A5DAFB6BEB63A5A7B1077210C481E6E832F61E04D303DD6987F03DFA1C7B0AB5B9D7ACFABEBA693224CBD2C984E34F1ECD32B90A641BC66E2DBCB12675904B7CFBF5BDA877A4705C6C4438A88EFBAB7352762ACC11A0AB5C5D1E732C8108D6503F7805E8BCDFD486AC6EEF09A5DA3E2C46FE2F24A553B49D59EFEBE539BD6C073854F54225D920152827CAC50213712A543330D400832C5BDEF3C093751AC77EDF4D4BB9B5C1663576A8EC40477B3504CB13DD6B51AEBDA06AB08D266618A1273843A649B05A90BCD71AA906C16A62A3347A962AE5994AACC1CA58CA96641CA22738C5DB802277F75A98C349D08E22F1D022495134C9FA8C146FAAD33E65DB55B8967A0DB1ABAFD68767D31CC42686F8BF538BB231B0BA43FC8E991AA4B0216477771D0D01F2E9E99EB135763D12F3ECA99EB1E5F6533D63AFE991F6E5DFC0DEA5971AA194ECF9478067AA6A17BE93B68F9B19385298BEC76CEE253A6B87116A536525786BFF24257167E83D2AB3BD975DE25547826BB849A6E3FD25B849D725654F1FDBF11A10A2AE54D71596821B945D42827B64591D59E276E0A9A4F5C7A0C26B294C5618A2D3CC72AD894F31CAB428BDD24BF2EE03612E505420342158EAAD8DDF6ABCD0DF6A50E5C154C4C5DFEA26C43796735AC8150831A5A091DB15E557DC965527D4CD423C81B9D6E937BC685CA7563D86552411A2E929AF477BC44BBEBF8E1D6488B69B0480DB46F1EA39D275046B7F1E25B16DAEC0C55F41ABF2F54A5234BB274A92A36A9B9D797ABC225EAB4BCD06C7F3944BAE12C9AB80E99A2C7C0A7B79BCB2DC2303AA40D0E97FF0A8B83F8AE01D18D6005112E0250DD93A3E313E1C59197F3FAC704213F545C083381BDCAEBD0318268033AA95208AD5D586CFC0832EF01647F8AC0D39F59B44E8F655468E27319DD60AF1B61BFB785659FC2F0738FDB8E5E7816A3D7CCF14F5F28C7F7832D26FFD28512F3D87AD2B8872D9498341AD80E53CC21C341BC15645986B17C4BE25528A3F026430E21857B2C88A43CCDDCFFE434A7CEE29F5F4AB203E726234274EA1C39BFDA2E81F8B28329EB8AAE0FEFEA3ED58E7341D56BCC8A5726BAD801E58B13ADF2AB9A07E1FD890E18FB5525C525E568AAD49AFEF19C1B1F97F3D17B0B65F33A7A8109CF011809C3E8E659114AFD5A658A4D8857BB3EEFED8D1497FF3E102A97EEDE4124B8E4778B6D0AC33E065B4AA0EFE4B5F1C9F49D0CFE36B51E7C9121DA6393E473F3C75263A54D1192F787B707AA4BC2B13260BBF86DAA7DC4CA27B64F577E9B1B696E349762AF7637D179287292E700CE4A5F509DDFD21757483F55C29E743972F2D9A6BD6C588F04D4DE39A765B8E59869A6A3E4F468C295BE8164D2E1F24765A8FD678B8E97EF67C6EA15A5830E95013AEEB26B3E233EEBA2BF86A4CEFE799CA35A76F3C91FCDB2BF9E04CD017232C75D6D7DACFF33AEF70B48B494B335C4F5B24EA52CBE86CE5CFF3E21CB5BB89603E559AAA00749C154010F929DA9ECF1B0899B3A16432676EA780C99F6A9E2F16C59A19689A09CDCBE8EDCCFAEE99E32E10B4DEEEC96CFB9BFE10D93BF699BB2B937C11C3A4BD33A31B3FFD02C3231E5E020B21533FF7C8878012858EF20E8BF228AA1C76DC2759B45BC4A2A6F40E851D5448C6C8018F864873ECB70B0021E26D51E44287F98EC17106E208D53B887FE22BED9E07483C99061741F72B1DDD4A768E29FA79BF27D9EDEA4F94382430C817433A0DF1E6EE20F9B20F4EB7E5FCA37833A08EAAC94D78D742D31BD765C6F6B24F941461D50397DB58F7507A334A4D6EF265E8247D8A56F9F11FC08D7C0DB56315E7A90F685E0A77D7A1E807506225462ECE8C99F4486FDE8E9C7FF035FB5D792836B0000, N'6.2.0-61023')
GO
SET IDENTITY_INSERT [dbo].[Operators] ON 

INSERT [dbo].[Operators] ([ID], [FullName], [Login], [Password], [Comment], [IsDenied]) VALUES (2, N'Тест', N'тест', N'тест', N'тест', 1)
INSERT [dbo].[Operators] ([ID], [FullName], [Login], [Password], [Comment], [IsDenied]) VALUES (3, N'testing', N'test', N'test', N'test 2', 1)
INSERT [dbo].[Operators] ([ID], [FullName], [Login], [Password], [Comment], [IsDenied]) VALUES (4, N'testing', N'test', N'test', N'test 2', 1)
INSERT [dbo].[Operators] ([ID], [FullName], [Login], [Password], [Comment], [IsDenied]) VALUES (5, N'E5RY', N'ERTYET', N'TYRYR', N'YRYR', 0)
SET IDENTITY_INSERT [dbo].[Operators] OFF
GO
