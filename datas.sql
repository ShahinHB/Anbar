USE [Anbar]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'88398599-d5a3-4a01-9618-b1a9808f2eab', N'Admin', N'ADMIN', N'c5391e6d-7352-49a6-801d-2983fbd6856f')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc7d1386-9f8d-4010-a77f-223a263424d9', N'Moderator', N'MODERATOR', N'1d865862-fe10-4255-bd64-27f60c55134b')
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Name], [SurName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7a60e30b-38b9-4791-a3e4-5214fa2ab247', N'CustomUser', NULL, NULL, N'Shahin', N'SHAHIN', NULL, NULL, 0, N'AQAAAAEAACcQAAAAEGiBMIXL/U0PnpGTZ2etjVeJQlRICv/Y/4C5Hpb4D+FX7uY8Yc0ZZIIMmmk8Qk4cpA==', N'DNIL63OIB5S5JU4III65EPDNGZFLIO7G', N'fc71f1e1-a69a-4e65-9bf3-4ee6fed4e4a9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [Discriminator], [Name], [SurName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd959d58b-617d-46a3-84ce-1e6965167636', N'CustomUser', NULL, NULL, N'Ramiz', N'RAMIZ', NULL, NULL, 0, N'AQAAAAEAACcQAAAAELnIkOMbGVSKBViKaDJVGYGG22ICMKv/Ws0GZFWnAQaVMLElwzm95JaLJDCs7xXULg==', N'W7GBFQWMKNHCOC55H3OOJRXU5E4OMTFE', N'b7448434-a007-4176-9663-0ce96c6e4346', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a60e30b-38b9-4791-a3e4-5214fa2ab247', N'88398599-d5a3-4a01-9618-b1a9808f2eab')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd959d58b-617d-46a3-84ce-1e6965167636', N'bc7d1386-9f8d-4010-a77f-223a263424d9')
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Quantity], [SalePrice], [BuyingPrice], [AddingDate], [Profit]) VALUES (3, N'Alma', 5, 6, 1, CAST(N'2022-02-03T00:18:31.0000000' AS DateTime2), 25)
SET IDENTITY_INSERT [dbo].[Products] OFF
