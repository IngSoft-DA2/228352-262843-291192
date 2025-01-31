USE [BuildingManagerDB]
GO
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000001', N'Rafael', N'Núñez', 3, N'ccadmin@gmail.com', N'ccadmin', N'constructionCompanyAdmin_user', N'a2832dac-fc49-401b-99d7-b35eba050f33')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000002', N'Manager2', N'Apellido', 2, N'manager2@gmail.com', N'manager', N'manager_user', N'423428fc-67d8-4f9d-93a3-0c61d1545ec1')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000003', N'Pepe', N'Argento', 3, N'pepearg@gmail.com', N'ccadmin', N'constructionCompanyAdmin_user', N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'00000000-0000-0000-0000-000000000004', N'Homero', N'Simpson', 0, N'admin@admin.com', N'admin', N'admin_user', N'6c514dd4-dd5f-45dd-bf5d-493dd35b3146')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'e2ae22ef-646c-42cf-4bcd-08dc8801d17f', N'José', N'Pedro', 1, N'jp@gmail.com', N'password', N'maintenance_user', N'67f77035-4eb2-4c18-8671-d9358f58712b')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'f92d0b7f-418a-42b0-4bce-08dc8801d17f', N'María', N'Roberta', 1, N'mr@gmail.com', N'password', N'maintenance_user', N'3b175a0c-6f3f-490f-bebf-011964c3def5')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'1be142b0-6c45-4c0e-710d-08dc88341020', N'test', N'test2', 3, N'test@gmail.com', N'test', N'constructionCompanyAdmin_user', N'2c23bdc0-11b6-4623-82a0-041fc414aed8')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'c370798c-0b37-4b3c-710e-08dc88341020', N'Franca', N'Chechi', 3, N'fchiqui@gmail.com', N'fran', N'constructionCompanyAdmin_user', N'43ad2c18-10bc-49b8-9ef5-2f7f6cfefafe')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'5f76c4b9-9f06-438e-3035-08dc88ac1e6b', N'Admin2', N'Apellido2', 0, N'admin2@admin.com', N'admin', N'admin_user', NULL)
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'51710fe5-4beb-42eb-3a2e-08dc88b21e93', N'Juanito', N'', 2, N'juanito@gmail.com', N'juanito', N'manager_user', NULL)
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'84322974-00b2-46ca-3a2f-08dc88b21e93', N'Ester', N'', 2, N'ester@gmail.com', N'ester', N'manager_user', NULL)
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'9008ed9e-59e4-47e2-8141-08dc897fc162', N'Silvia Pírez', N'', 3, N'silvia@gmail.com', N'silvia', N'constructionCompanyAdmin_user', N'820f5a22-76eb-4f11-8877-aa6610d4d95d')
INSERT [dbo].[Users] ([Id], [Name], [Lastname], [Role], [Email], [Password], [user_type], [SessionToken]) VALUES (N'2284fb75-5f89-4441-8142-08dc897fc162', N'Test Manager', N'', 2, N'testman@gmail.com', N'testman', N'manager_user', N'aa0635c7-325b-4ba7-a0dc-2f9859246ce8')
GO
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (N'6f96db51-fea3-4716-d2b2-08dc8800f7a6', N'Electricista', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (N'3182497d-e395-4ac9-d2b3-08dc8800f7a6', N'Fontanero', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (N'ef0fc38c-1145-4558-d2b4-08dc8800f7a6', N'Plomero', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (N'ebe02747-aada-4507-d2b5-08dc8800f7a6', N'Albañil', NULL)
INSERT [dbo].[Categories] ([Id], [Name], [ParentId]) VALUES (N'cb126b6b-7f77-4756-d2b6-08dc8800f7a6', N'Vecino molesto', NULL)
GO
INSERT [dbo].[ConstructionCompanies] ([Id], [Name]) VALUES (N'00000000-0000-0000-0000-000000000037', N'Construcciones Montevideanas SA')
INSERT [dbo].[ConstructionCompanies] ([Id], [Name]) VALUES (N'00000000-0000-0000-0000-000000000038', N'Construcciones Uruguayas SA')
INSERT [dbo].[ConstructionCompanies] ([Id], [Name]) VALUES (N'2fabdb6f-73df-4e20-0b42-08dc883741d5', N'ConstructoresAnónimos')
INSERT [dbo].[ConstructionCompanies] ([Id], [Name]) VALUES (N'54b07a08-b7cd-4dd8-0b43-08dc883741d5', N'Empresa de ladrillos')
GO
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'be8fd058-959d-449a-a8f8-08dc8596602b', N'00000000-0000-0000-0000-000000000002', N'Torre ORT', N'Mercedes 1243', N'Montevideo', CAST(4000.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000037')
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'788cdcdc-07d1-4880-17f5-08dc8982373f', N'00000000-0000-0000-0000-000000000002', N'Edificio Montevideo', N'Av. Italia 5678', N'Montevideo', CAST(4100.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000037')
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'b342fb17-bcb3-4474-17f6-08dc8982373f', N'51710fe5-4beb-42eb-3a2e-08dc88b21e93', N'Edificio Libertador', N'Libertador 3456', N'Montevideo', CAST(3500.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000037')
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'947297aa-9ac2-49e0-17f7-08dc8982373f', NULL, N'Edificio Central', N'18 de Julio 1234', N'Montevideo', CAST(4200.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000038')
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'37850bb1-abc4-41bf-17f8-08dc8982373f', NULL, N'Edificio Punta Carretas', N'Ellauri 567', N'Montevideo', CAST(4500.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000038')
INSERT [dbo].[Buildings] ([Id], [ManagerId], [Name], [Address], [Location], [CommonExpenses], [ConstructionCompanyId]) VALUES (N'3a8f6521-7b6b-410c-17f9-08dc8982373f', N'00000000-0000-0000-0000-000000000002', N'Edificio Buceo', N'Rambla República de México 289', N'Montevideo', CAST(3800.00 AS Decimal(18, 2)), N'00000000-0000-0000-0000-000000000037')
GO
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'alicia.mendez@gmail.com', N'Alicia', N'Mendez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'ana.rodriguez@gmail.com', N'Ana', N'Rodríguez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'andres.ortiz@gmail.com', N'Andrés', N'Ortiz')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'carlos.lopez@gmail.com', N'Carlos', N'López')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'claudia.ramirez@gmail.com', N'Claudia', N'Ramirez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'david.morales@gmail.com', N'David', N'Morales')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'elon@tesla.com', N'Elon', N'Musk')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'eyfran@hotmail.com', N'Francisco', N'Bouza')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'fernando.silva@gmail.com', N'Fernando', N'Silva')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'franca.chechi@yahoo.com', N'Franca', N'Chechi')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'gabriel.alvez@gmail.com', N'Gabriel', N'Alvez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'hernan.santos@hotmail.com', N'Hernán', N'Santos')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'jose.gonzalez@hotmail.com', N'José', N'González')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'juan.irabedra@hotmail.com', N'Juan', N'Irabedra')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'juan.perez@gmail.com', N'Juan', N'Perez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'juan.tejera@gmail.com', N'Juan', N'Tejera')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'luis.sanchez@gmail.com', N'Luis', N'Sánchez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'mance@msn.com', N'Álvaro', N'Mancebo')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'maria.gonzalez@gmail.com', N'María', N'Gonzalez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'mariana.gomez@gmail.com', N'Marina', N'Gomez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'marta.garcia@gmail.com', N'Marta', N'García')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'mati.fernandez@msn.com', N'Matías', N'Fernández')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'nom@gmail.com', N'Nom', N'Ape')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'nom2@gmail.com', N'Nom2', N'Ape2')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'nom3@gmail.com', N'Nom3', N'Ape3')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'pedro.gonzalez@gmail.com', N'Pedro', N'Gonzalez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'rafa@gmail.com', N'Rafa', N'Nu')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'rafael.nunez@hotmail.com', N'Rafael', N'Núñez')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'rigoberta@outlook.com', N'Rigoberta', N'Machado')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'roberto.diaz@gmail.com', N'Roberto', N'Díaz')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'santiago.tonarelli@addinet.com', N'Santiago', N'Tonarelli')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'test@test.com', N'Test', N'Test')
INSERT [dbo].[Owners] ([Email], [Name], [LastName]) VALUES (N'vicky.rosales@yahoo.com', N'Victoria', N'Rosales')
GO
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 1, 1, N'juan.tejera@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 1, 0, N'franca.chechi@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'be8fd058-959d-449a-a8f8-08dc8596602b', 3, 2, 1, N'rafael.nunez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'be8fd058-959d-449a-a8f8-08dc8596602b', 3, 2, 0, N'juan.irabedra@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'be8fd058-959d-449a-a8f8-08dc8596602b', 4, 2, 1, N'santiago.tonarelli@addinet.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'be8fd058-959d-449a-a8f8-08dc8596602b', 4, 2, 0, N'mance@msn.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 1, 1, N'rigoberta@outlook.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 1, 1, N'eyfran@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'be8fd058-959d-449a-a8f8-08dc8596602b', 3, 2, 1, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'be8fd058-959d-449a-a8f8-08dc8596602b', 3, 2, 0, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 3, 2, 1, N'gabriel.alvez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 3, 2, 0, N'vicky.rosales@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 2, 1, 1, N'rafael.nunez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 2, 1, 0, N'jose.gonzalez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 4, 2, 1, N'santiago.tonarelli@addinet.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 4, 2, 0, N'mati.fernandez@msn.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 2, 1, 1, N'rigoberta@outlook.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 2, 1, 0, N'hernan.santos@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 3, 2, 1, N'elon@tesla.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'788cdcdc-07d1-4880-17f5-08dc8982373f', 3, 2, 1, N'franca.chechi@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 2, 1, 1, N'carlos.lopez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 2, 1, 0, N'claudia.ramirez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 3, 2, 1, N'david.morales@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 3, 2, 0, N'fernando.silva@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 4, 2, 1, N'maria.gonzalez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 4, 2, 0, N'pedro.gonzalez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 2, 1, 1, N'marta.garcia@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 2, 1, 0, N'andres.ortiz@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 3, 2, 1, N'mariana.gomez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'b342fb17-bcb3-4474-17f6-08dc8982373f', 3, 2, 1, N'alicia.mendez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 2, 1, 1, N'ana.rodriguez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 2, 1, 0, N'roberto.diaz@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 3, 2, 1, N'nom@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 3, 2, 0, N'nom2@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 4, 2, 1, N'nom3@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 4, 2, 0, N'juan.perez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 2, 1, 1, N'luis.sanchez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 2, 1, 0, N'test@test.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 3, 2, 1, N'juan.irabedra@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'947297aa-9ac2-49e0-17f7-08dc8982373f', 3, 2, 1, N'rafael.nunez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 3, 2, 1, N'maria.gonzalez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 3, 2, 0, N'mati.fernandez@msn.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 2, 1, 1, N'gabriel.alvez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 2, 1, 0, N'fernando.silva@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 4, 2, 1, N'alicia.mendez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 4, 2, 0, N'pedro.gonzalez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 2, 1, 1, N'nom@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 2, 1, 0, N'nom2@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 3, 2, 1, N'nom3@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'37850bb1-abc4-41bf-17f8-08dc8982373f', 3, 2, 1, N'rafa@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 1, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 3, 2, 1, N'vicky.rosales@yahoo.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (1, 2, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 3, 2, 0, N'jose.gonzalez@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 1, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 2, 1, 1, N'santiago.tonarelli@addinet.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (2, 2, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 2, 1, 0, N'luis.sanchez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 1, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 4, 2, 1, N'claudia.ramirez@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (3, 2, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 4, 2, 0, N'david.morales@gmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 1, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 2, 1, 1, N'hernan.santos@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (4, 2, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 2, 1, 0, N'rigoberta@outlook.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 1, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 3, 2, 1, N'eyfran@hotmail.com')
INSERT [dbo].[Apartments] ([Floor], [Number], [BuildingId], [Rooms], [Bathrooms], [HasTerrace], [OwnerEmail]) VALUES (5, 2, N'3a8f6521-7b6b-410c-17f9-08dc8982373f', 3, 2, 1, N'elon@tesla.com')
GO
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'9c463c5b-c070-4946-1c73-08dc88018e52', N'Se necesita reparación eléctrica', 2, N'6f96db51-fea3-4716-d2b2-08dc8800f7a6', N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 1, N'e2ae22ef-646c-42cf-4bcd-08dc8801d17f', 1717886517, 1717886626, 4000, N'00000000-0000-0000-0000-000000000002')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'9e657988-df47-4ac7-1c74-08dc88018e52', N'Se necesita reparación plomérica', 0, N'ef0fc38c-1145-4558-d2b4-08dc8800f7a6', N'be8fd058-959d-449a-a8f8-08dc8596602b', 2, 2, N'f92d0b7f-418a-42b0-4bce-08dc8801d17f', 0, 0, 0, N'00000000-0000-0000-0000-000000000002')
INSERT [dbo].[Requests] ([Id], [Description], [State], [CategoryId], [BuildingId], [ApartmentFloor], [ApartmentNumber], [MaintainerStaffId], [AttendedAt], [CompletedAt], [Cost], [ManagerId]) VALUES (N'58dcc5dc-07b0-45cc-1c78-08dc88018e52', N'Se necesita reparación fontañeril', 2, N'3182497d-e395-4ac9-d2b3-08dc8800f7a6', N'be8fd058-959d-449a-a8f8-08dc8596602b', 4, 2, N'e2ae22ef-646c-42cf-4bcd-08dc8801d17f', 1717889333, 1717889381, 5600, N'00000000-0000-0000-0000-000000000002')
GO
INSERT [dbo].[CompanyAdminAssociations] ([ConstructionCompanyAdminId], [ConstructionCompanyId]) VALUES (N'00000000-0000-0000-0000-000000000001', N'00000000-0000-0000-0000-000000000037')
INSERT [dbo].[CompanyAdminAssociations] ([ConstructionCompanyAdminId], [ConstructionCompanyId]) VALUES (N'00000000-0000-0000-0000-000000000003', N'00000000-0000-0000-0000-000000000038')
INSERT [dbo].[CompanyAdminAssociations] ([ConstructionCompanyAdminId], [ConstructionCompanyId]) VALUES (N'1be142b0-6c45-4c0e-710d-08dc88341020', N'2fabdb6f-73df-4e20-0b42-08dc883741d5')
INSERT [dbo].[CompanyAdminAssociations] ([ConstructionCompanyAdminId], [ConstructionCompanyId]) VALUES (N'c370798c-0b37-4b3c-710e-08dc88341020', N'54b07a08-b7cd-4dd8-0b43-08dc883741d5')
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240525150346_constructionCompany', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240525182924_constructionCompanyAdminDiscriminator', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240525215655_associationTableForContructionCompanies', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530182530_company-id-in-building', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530194616_managerid-in-building-can-be-null', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530195059_managerId-is-fk-in-building-table', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606010019_AddManagerNameToBuilding', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606014602_RemoveManagerNameFromBuilding', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240608175826_RequestBuilding', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240608180807_InvitationWithRole', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240609042748_CategoryParent', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240609055353_categoryParentEntity', N'6.0.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240609151556_OnDeleteManagerSetNullOnBuilding', N'6.0.21')
GO
INSERT [dbo].[Invitations] ([Id], [Email], [Name], [Deadline], [Status], [Role]) VALUES (N'7c69e7be-0ca8-42db-64f8-08dc88b3df9b', N'pepito@gmail.com', N'Pepito', 1718107803, 2, 3)
INSERT [dbo].[Invitations] ([Id], [Email], [Name], [Deadline], [Status], [Role]) VALUES (N'daf0f33e-e43a-42ba-1cc5-08dc897fbcfd', N'silvia@gmail.com', N'Silvia Pírez', 1718938800, 0, 3)
INSERT [dbo].[Invitations] ([Id], [Email], [Name], [Deadline], [Status], [Role]) VALUES (N'fa4a8bea-0abe-4b47-1cc6-08dc897fbcfd', N'testman@gmail.com', N'Test Manager', 1718852400, 0, 2)
GO
