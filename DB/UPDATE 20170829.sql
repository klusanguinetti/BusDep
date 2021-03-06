USE [BusDep]
GO

TRUNCATE TABLE [dbo].[Menu];
GO

SET IDENTITY_INSERT [dbo].[Menu] ON 

GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(1 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Mis Datos', N'#!Profile/PrivateProfile', N'fa fa-male', NULL, CAST(1 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(2 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Antecedentes', N'#!History/SportsHistory/List', N'fa fa-address-book-o', NULL, CAST(3 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(3 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'AutoEvaluación', N'#!Evaluation/SelfAppraisal', N'fa fa-star', NULL, CAST(4 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(4 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Cambio de Password', N'#!/Account/PasswordChange', N'fa fa-lock', NULL, CAST(5 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(5 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Certificaciones', N'', N'icon-folder-close', NULL, CAST(6 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(6 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Ofertas', N'', N'icon-hourglass', NULL, CAST(7 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(7 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), NULL, N'Mis Datos', N'#!Profile/PrivateProfileEntrenador', N'icon-home', NULL, CAST(1 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(8 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), NULL, N'AutoEvaluación', N'#!Evaluation/SelfAppraisal', N'fa fa-star', NULL, CAST(2 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(9 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), NULL, N'Cambio de Password', N'#!/Account/PasswordChange', N'fa fa-lock', NULL, CAST(3 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(10 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), NULL, N'Certificaciones', N'', N'icon-folder-close', NULL, CAST(4 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(11 AS Numeric(10, 0)), CAST(10 AS Numeric(10, 0)), NULL, N'Ofertas', N'', N'icon-hourglass', NULL, CAST(5 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(12 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Mis Datos', N'#!Profile/PrivateProfileIntermediario', N'icon-home', NULL, CAST(1 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(13 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'AutoEvaluación', N'#!Evaluation/SelfAppraisal', N'fa fa-star', NULL, CAST(2 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(14 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Cambio de Password', N'#!/Account/PasswordChange', N'fa fa-lock', NULL, CAST(3 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(15 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Certificaciones', N'', N'icon-folder-close', NULL, CAST(4 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(16 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Ofertas', N'', N'icon-hourglass', NULL, CAST(5 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(17 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Mis Datos', N'#!Profile/PrivateProfileClub', N'icon-home', NULL, CAST(1 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(18 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'AutoEvaluación', N'#!Evaluation/SelfAppraisal', N'fa fa-star', NULL, CAST(2 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(19 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Cambio de Password', N'#!/Account/PasswordChange', N'fa fa-lock', NULL, CAST(3 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(20 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Certificaciones', N'', N'icon-folder-close', NULL, CAST(4 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(21 AS Numeric(10, 0)), CAST(11 AS Numeric(10, 0)), NULL, N'Ofertas', N'', N'icon-hourglass', NULL, CAST(5 AS Numeric(2, 0)), N'A')
GO
INSERT [dbo].[Menu] ([MenuId], [TipoUsuarioId], [ParentMenuId], [Descripcion], [Url], [Icono], [Img], [Orden], [Estado]) VALUES (CAST(22 AS Numeric(10, 0)), CAST(9 AS Numeric(10, 0)), NULL, N'Datos Deportivos', N'#!/Profile/SportData', N'fa fa-futbol-o', NULL, CAST(2 AS Numeric(2, 0)), N'A')
GO
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
