USE [BuildingManagerDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Apartments]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Apartments](
	[Floor] [int] NOT NULL,
	[Number] [int] NOT NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[Rooms] [int] NOT NULL,
	[Bathrooms] [int] NOT NULL,
	[HasTerrace] [bit] NOT NULL,
	[OwnerEmail] [nvarchar](450) NULL,
 CONSTRAINT [PK_Apartments] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC,
	[Floor] ASC,
	[Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Buildings]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Buildings](
	[Id] [uniqueidentifier] NOT NULL,
	[ManagerId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[ConstructionCompany] [nvarchar](max) NULL,
	[CommonExpenses] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Buildings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invitations]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invitations](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Deadline] [bigint] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Invitations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owners]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owners](
	[Email] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[State] [int] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[BuildingId] [uniqueidentifier] NOT NULL,
	[ApartmentFloor] [int] NOT NULL,
	[ApartmentNumber] [int] NOT NULL,
	[MaintainerStaffId] [uniqueidentifier] NULL,
	[AttendedAt] [bigint] NOT NULL,
	[CompletedAt] [bigint] NOT NULL,
	[Cost] [int] NOT NULL,
	[ManagerId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 02/05/2024 20:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Lastname] [nvarchar](max) NULL,
	[Role] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[user_type] [nvarchar](max) NOT NULL,
	[SessionToken] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240414195043_create-admin-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240415025431_add-categories-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240417223201_create-maintenacestaff-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240420190509_create-building-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240423001314_created-user-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240424000952_ChangeTableNames', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240425175457_create-invitations-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240426224109_invitation-status', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240426234842_user-discriminator', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428012043_add-manager-to-users', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240428184957_create-requests-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240429020029_add-session-token-to-user-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430011930_update-request-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430012827_fix-request-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240430013831_fix-maintainer-in-request-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240501152246_add-attributes-to-request-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240501181449_add-ManagerId-attribute-to-requests-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240501185209_add-ManagerId-FK-to-requests-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240502011628_add-delete-cascade-logic', N'6.0.21')
GO
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 1, 1, N'juan.tejera@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 1, 0, N'franca.chechi@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 3, 2, 1, N'rafael.nunez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 3, 2, 0, N'juan.irabedra@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 4, 2, 1, N'santiago.tonarelli@addinet.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 4, 2, 0, N'mance@msn.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 1, 1, N'rigoberta@outlook.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 1, 0, N'eyfran@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 3, 2, 1, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 3, 2, 1, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 3, 2, 1, N'gabriel.alvez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 3, 2, 0, N'vicky.rosales@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 2, 1, 1, N'rafael.nunez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 2, 1, 0, N'jose.gonzalez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 4, 2, 1, N'santiago.tonarelli@addinet.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 4, 2, 0, N'mati.fernandez@msn.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 2, 1, 1, N'rigoberta@outlook.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 2, 1, 0, N'hernan.santos@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 3, 2, 1, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'fe245736-9e44-4234-01e2-08dc6ae4592c', 3, 2, 1, N'franca.chechi@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'4af23b53-7297-42da-36e4-08dc6aead9e6', 3, 2, 1, N'gabriel.alvez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'4af23b53-7297-42da-36e4-08dc6aead9e6', 3, 2, 0, N'vicky.rosales@yahoo.com')
GO
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [ConstructionCompany], [CommonExpenses]) VALUES (N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', N'00000000-0000-0000-0000-000000000001', N'Torre ORT', N'Mercedes 1243', N'Montevideo', N'Construcciones Montevideanas SA', CAST(3900.00 AS Decimal(18, 2)))
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [ConstructionCompany], [CommonExpenses]) VALUES (N'fe245736-9e44-4234-01e2-08dc6ae4592c', N'00000000-0000-0000-0000-000000000001', N'Edificio Montevideo', N'Av. Italia 5678', N'Montevideo', N'Construcciones Uruguayas SA', CAST(4100.00 AS Decimal(18, 2)))
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [ConstructionCompany], [CommonExpenses]) VALUES (N'4af23b53-7297-42da-36e4-08dc6aead9e6', N'314b0129-d376-4588-b605-08dc6ae6fd00', N'Edificio Prueba', N'Av. Italia 2231', N'Montevideo', N'Construcciones SA', CAST(4100.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'e89b5421-c296-40d2-8a99-08dc6ae4f0da', N'Electricista')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'65f3e49c-e86a-4b56-8a9a-08dc6ae4f0da', N'Fontanero')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'03cf4d97-45cb-4841-8a9b-08dc6ae4f0da', N'Plomero')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'c1763e65-4aa3-4047-8a9c-08dc6ae4f0da', N'Albañil')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'3898f456-b86a-479f-8a9d-08dc6ae4f0da', N'Vecino molesto')
GO
INSERT [dbo].[Invitations] ([Id], [Email], [Name], [Deadline], [Status]) VALUES (N'523ccfa6-c233-45d2-33b2-08dc6ae8bb59', N'notshrek@hotmail.com', N'Shrek', 1716544868, 0)
INSERT [dbo].[Invitations] ([Id], [Email], [Name], [Deadline], [Status]) VALUES (N'd3b2f0b2-8ffb-4b16-33b4-08dc6ae8bb59', N'deleteAdmin@hotmail.com', N'deleteAdmin', 1716544868, 0)
GO
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'elon@tesla.com', N'Elon', N'Musk')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'eyfran@hotmail.com', N'Francisco', N'Bouza')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'franca.chechi@yahoo.com', N'Franca', N'Chechi')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'gabriel.alvez@gmail.com', N'Gabriel', N'Alvez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'hernan.santos@hotmail.com', N'Hernán', N'Santos')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'jose.gonzalez@hotmail.com', N'José', N'González')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'juan.irabedra@hotmail.com', N'Juan', N'Irabedra')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'juan.tejera@gmail.com', N'Juan', N'Tejera')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'mance@msn.com', N'Álvaro', N'Mancebo')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'mati.fernandez@msn.com', N'Matías', N'Fernández')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'rafael.nunez@hotmail.com', N'Rafael', N'Núñez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'rigoberta@outlook.com', N'Rigoberta', N'Machado')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'santiago.tonarelli@addinet.com', N'Santiago', N'Tonarelli')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'vicky.rosales@yahoo.com', N'Victoria', N'Rosales')
GO
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'b9208653-812c-4ccd-2c78-08dc6ae68191', N'Se necesita reparación eléctrica', 2, N'e89b5421-c296-40d2-8a99-08dc6ae4f0da', N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 1, N'854aa0c7-b0b5-49c1-b602-08dc6ae6fd00', 1714682635, 1714682643, 300, N'00000000-0000-0000-0000-000000000001')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'2f5f43cd-ca45-42b1-2c79-08dc6ae68191', N'Se necesita reparación plomérica', 0, N'03cf4d97-45cb-4841-8a9b-08dc6ae4f0da', N'c23093d4-20c2-4c38-56d5-08dc6ae1cad6', 2, 2, NULL, 0, 0, 0, N'00000000-0000-0000-0000-000000000001')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'2794c3c6-2822-4540-2c7a-08dc6ae68191', N'Se necesita reparación fontañeril', 0, N'65f3e49c-e86a-4b56-8a9a-08dc6ae4f0da', N'fe245736-9e44-4234-01e2-08dc6ae4592c', 4, 2, NULL, 0, 0, 0, N'00000000-0000-0000-0000-000000000001')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'7d6f3abe-6310-4c6c-2c7b-08dc6ae68191', N'Se necesita poner una ventana', 0, N'c1763e65-4aa3-4047-8a9c-08dc6ae4f0da', N'fe245736-9e44-4234-01e2-08dc6ae4592c', 5, 1, NULL, 0, 0, 0, N'00000000-0000-0000-0000-000000000001')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'9c9a88d1-3db0-4a9e-2c7c-08dc6ae68191', N'Quiero matar a mi vecino', 0, N'3898f456-b86a-479f-8a9d-08dc6ae4f0da', N'fe245736-9e44-4234-01e2-08dc6ae4592c', 5, 2, NULL, 0, 0, 0, N'00000000-0000-0000-0000-000000000001')
GO
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000000', N'Homero', N'Simpson', 0, N'admin@admin.com', N'admin', N'admin_user', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000001', N'Manager1', N'Apellido', 2, N'manager@gmail.com', N'manager', N'manager_user', N'00000000-0000-0000-0000-000000000001')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'854aa0c7-b0b5-49c1-b602-08dc6ae6fd00', N'José', N'Pedro', 1, N'jp@gmail.com', N'password', N'maintenance_user', N'2771d45d-a693-432d-9868-9440c82e291c')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'1610918b-f24f-4821-b603-08dc6ae6fd00', N'Shrek', N'', 2, N'notshrek@hotmail.com', N'password', N'manager_user', NULL)
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'39cae1b5-e122-4c25-b604-08dc6ae6fd00', N'Admin2', N'Apellido', 0, N'admin2@gmail.com', N'pass', N'admin_user', N'82dfd071-80ed-4762-9f13-b0e4148a37fa')
GO
ALTER TABLE [dbo].[Invitations] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Requests] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [AttendedAt]
GO
ALTER TABLE [dbo].[Requests] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [CompletedAt]
GO
ALTER TABLE [dbo].[Requests] ADD  DEFAULT ((0)) FOR [Cost]
GO
ALTER TABLE [dbo].[Requests] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ManagerId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (N'') FOR [user_type]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Buildings_BuildingId] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Buildings_BuildingId]
GO
ALTER TABLE [dbo].[Apartments]  WITH CHECK ADD  CONSTRAINT [FK_Apartments_Owners_OwnerEmail] FOREIGN KEY([OwnerEmail])
REFERENCES [dbo].[Owners] ([Email])
GO
ALTER TABLE [dbo].[Apartments] CHECK CONSTRAINT [FK_Apartments_Owners_OwnerEmail]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Apartments_BuildingId_ApartmentFloor_ApartmentNumber] FOREIGN KEY([BuildingId], [ApartmentFloor], [ApartmentNumber])
REFERENCES [dbo].[Apartments] ([BuildingId], [Floor], [Number])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Apartments_BuildingId_ApartmentFloor_ApartmentNumber]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Buildings_BuildingId] FOREIGN KEY([BuildingId])
REFERENCES [dbo].[Buildings] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Buildings_BuildingId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users_MaintainerStaffId] FOREIGN KEY([MaintainerStaffId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users_MaintainerStaffId]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users_ManagerId] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users_ManagerId]
GO
