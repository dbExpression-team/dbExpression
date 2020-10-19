SET NOCOUNT ON;
GO
TRUNCATE TABLE [dbo].[Person_Address];
GO
TRUNCATE TABLE [dbo].[PurchaseLine];
GO
DELETE FROM [dbo].[Address];
GO
DELETE FROM [dbo].[Purchase];
GO
DELETE FROM [dbo].[Person];
GO
DELETE FROM [dbo].[Product];
GO
DELETE FROM [sec].[Person];
GO

SET IDENTITY_INSERT [dbo].[Person] ON;

INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (1, 'Kenny', 'McCormick', 1, '1/1/1996', 10000, 2016, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (2, 'Butters', 'Stotch', 1, '2/1/1996', 10000, 2016, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (3, 'Kyle', 'Broflovski', 1, '3/1/1996', 10000, 2016, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (4, 'Bebe', 'Stevens', 2, '4/1/1996', 10000, 2016, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (5, 'Wendy', 'Testaburge', 2, '5/1/1996', 10000, 2016, '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (6, 'Stan', 'Marsh', 1, '6/1/1996', 10000, 2016, '1/1/2017', '6/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (7, 'Jimmy', 'Valmer', 1, '7/1/1996', 10000, 2016, '1/1/2017', '7/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (8, 'Clyde', 'Donovan', 1, '8/1/1996', 10000, 2016, '1/1/2017', '8/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (9, 'Eric', 'Cartman', 1, '9/1/1996', 10000, 2016, '1/1/2017', '9/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (10, 'Craig', 'Tucker', 1, '10/1/1996', 10000, 2016, '1/1/2017', '10/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (11, 'Timmy', 'Burch', 1, '1/1/1996', 10000, 2016, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (12, 'Scott', 'Malkinson', 1, '2/1/1996', 20000, 2016, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (13, 'Heidi', 'Turner', 2, '3/1/1996', 20000, 2016, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (14, 'Nichole', 'Daniels', 2, '4/1/1996', 20000, 2016, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (15, 'Annie', 'Knitts', 2, '5/1/1996', 20000, 2016, '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (16, 'Bradley', 'Biggle', 1, '7/1/1996', 20000, 2016, '1/1/2017', '7/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (17, 'David', 'Rodriguez', 1, '8/1/1996', 20000, 2016, '1/1/2017', '8/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (18, 'Jason', 'White', 1, '9/1/1996', 20000, 2016, '1/1/2017', '9/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (19, 'Jenny', 'Simons', 2, '10/1/1996', 20000, 2016, '1/1/2017', '10/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (20, 'Kevin', 'Stoley', 1, '1/1/1996', 20000, 2016, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (21, 'Leroy', 'Mullins', 1, '2/1/1996', 20000, 2016, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (22, 'Marcus', 'Preston', 1, '3/1/1996', 30000, NULL, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (23, 'Millie', 'Larson', 2, '4/1/1996', 30000, NULL, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (24, 'Pip', 'Pirrup', 1, '5/1/1996', 30000, NULL, '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (25, 'Powder', 'Turner', 2, '6/1/1996', 30000, NULL, '1/1/2017', '6/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (26, 'Adam', 'Borque', 1, '7/1/1996', 30000, NULL, '1/1/2017', '7/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (27, 'Alex', 'Glick', 1, '8/1/1996', 30000, NULL, '1/1/2017', '8/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (28, 'Allen', 'Varcas', 1, '9/1/1996', 30000, NULL, '1/1/2017', '9/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (29, 'Allie', 'Nelson', 2, '10/1/1996', 30000, NULL, '1/1/2017', '10/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (30, 'Baahir', 'Hakeem', 1, '1/1/1996', 30000, NULL, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (31, 'Bill', 'Allen', 1, '2/1/1996', 30000, NULL, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (32, 'Billy', 'Circlovich', 1, '3/1/1996', 40000, NULL, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (33, 'Billy', 'Miller', 1, '4/1/1996', 40000, NULL, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (34, 'Chris', 'Donnely', 1, '5/1/1996', 40000, NULL, '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (35, 'Damien', 'Thorn', 1, '6/1/1996', 40000, NULL, '1/1/2017', '6/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (36, 'Daniel', 'Tanner', 1, '7/1/1996', 40000, NULL, '1/1/2017', '7/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (37, 'David', 'Weatherhea', 1, '8/1/1996', 40000, NULL, '1/1/2017', '8/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (38, 'Davin', 'Miller', 1, '9/1/1996', 40000, NULL, '1/1/2017', '9/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (39, 'Emily', 'Marx', 2, '10/1/1996', 40000, NULL, '1/1/2017', '10/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (40, 'Emmett', 'Hollis', 1, '1/1/1997', 40000, NULL, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (41, 'Estella', 'Havesham', 2, '2/1/1997', 40000, NULL, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (42, 'Fosse', 'O''Donnelle', 1, '3/1/1997', NULL, NULL, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (43, 'Lisa', 'Smith', 2, '4/1/1997', NULL, NULL, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (44, 'Liane', 'Cartman', 2, '1/1/1976', NULL, NULL, '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (45, 'Randy', 'Marsh', 1, '2/1/1976', NULL, NULL, '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (46, 'Sharon', 'Marsh', 2, '3/1/1976', NULL, NULL, '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (47, 'Marvin', 'Marsh', 1, '4/1/1976', NULL, NULL, '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (48, 'Sheila', 'Broflovski', 2, '5/1/1976', NULL, NULL, '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (49, 'Gerald', 'Broflovski', 1, '6/1/1976', NULL, NULL, '1/1/2017', '6/1/2018');
INSERT INTO [dbo].[Person] ([Id], [FirstName], [LastName], [GenderType], [BirthDate], [CreditLimit], [YearOfLastCreditLimitReview], [DateCreated], [DateUpdated]) VALUES (50, 'Murrey', 'Broflovski', 1, '7/1/1976', NULL, NULL, '1/1/2017', '7/1/2018');

SET IDENTITY_INSERT [dbo].[Person] OFF;
SET IDENTITY_INSERT [dbo].[Address] ON;

INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (1, 1, '100 1st St', 'Principal''s office', 'South Park', 'CO', '80456', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (2, 2, '2015 Anywhere Ln', NULL, 'South Park', 'CO', '80456', '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (3, 2, 'US Highway 285', 'Box 13', 'South Park', 'CO', '80432', '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (4, 2, '123 Elm St', NULL, 'South Park', 'CO', '80440', '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (5, 2, '1640 Riverside Drive', NULL, 'Hill Valley', 'CA', '92307', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (6, 2, '1630 Revello Drive', NULL, 'Sunnydale', 'CA', '94043', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (7, 2, '1329 Carroll Ave', NULL, 'Los Angeles', 'CA', '90001', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (8, 2, '84 Beacon Street', NULL, 'Boston', 'MA', '02101', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (9, 2, '10 Stigwood Avenue', NULL, 'New York City', 'NY', '10001', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (10, 2, '320 Fowler Street', NULL, 'Lynbrook', 'NY', '10002', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (11, 2, '31 Spooner Street', NULL, 'Quahog', 'RI', '02801', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (12, 2, '1882 Gerard Street', NULL, 'San Francisco', 'CA', '94016', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (13, 2, '510 Glenview', NULL, 'Detroit', 'MI', '48127', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (14, 2, '9764 Jeopardy Lane', NULL, 'Chicago', 'IL', '60007', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (15, 2, '714 Delaware', NULL, 'Lanford', 'IL', '61525', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (16, 2, '129 West 81st Street', 'Apartment 5A', 'New York', 'NY', '10003', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (17, 2, '2630 Hegal Place', 'Apt. 42', 'Alexandria', 'VA', '23242', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (18, 2, '3170 W. 53 Rd.', '#35', 'Annapolis', 'MD', '21401', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (19, 2, '101407 Graymalkin Lane', NULL, 'Salem Center', 'NY', '10004', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (20, 2, '25 Eagle Road', NULL, 'Dorchester Center', 'MA', '02124', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (21, 2, '642 Woodland Street', NULL, 'Brookline', 'MA', '02446', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (22, 2, '26 Oklahoma Ave.', NULL, 'Glasgow', 'KY', '42141', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (23, 2, '55 Wintergreen St.', NULL, 'Downers Grove', 'IL', '60515', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (24, 2, '175 Cedar St.', NULL,' Marlton', 'NJ', '08053', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (25, 2, '8704 Canal Lane', NULL, 'Dover', 'NH', '03820', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (26, 2, '8626 Ketch Harbour St.', NULL, 'Oceanside', 'NY', '11572', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (27, 2, '8573 Del Monte St.', NULL, 'La Porte', 'IN', '46350', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (28, 2, '8776 Rockwell Lane', NULL, 'Middleton', 'WI', '53562', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (29, 2, '58 Stonybrook St.', NULL, 'Oviedo', 'FL', '32765', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (30, 1, '851 Spruce Street', NULL, 'Media', 'PA', '19063', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (31, 1, '8331 West State St.', NULL, 'Boca Raton', 'FL', '33428', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Address] ([Id], [AddressType], [Line1], [Line2], [City], [State], [Zip], [DateCreated], [DateUpdated]) VALUES (32, 1, '172 Thompson Ave.', NULL, 'Glenside', 'PA', '19038', '1/1/2017', '1/1/2018');

SET IDENTITY_INSERT [dbo].[Address] OFF;
SET IDENTITY_INSERT [dbo].[Person_Address] ON;

INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (1, 2, 2, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (2, 3, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (3, 3, 3, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (4, 5, 4, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (5, 6, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (6, 6, 5, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (7, 8, 6, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (8, 9, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (9, 9, 7, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (10, 11, 8, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (11, 12, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (12, 12, 9, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (13, 14, 10, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (14, 15, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (15, 15, 11, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (16, 17, 12, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (17, 18, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (18, 18, 13, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (19, 20, 14, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (20, 21, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (21, 21, 15, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (22, 23, 16, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (23, 24, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (24, 24, 17, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (25, 26, 18, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (26, 27, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (27, 27, 19, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (28, 29, 20, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (29, 30, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (30, 30, 21, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (31, 32, 22, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (32, 33, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (33, 33, 23, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (34, 35, 24, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (35, 36, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (36, 36, 25, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (37, 38, 26, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (38, 39, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (39, 39, 27, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (40, 41, 28, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (41, 42, 1, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (42, 42, 29, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (43, 44, 7, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (44, 44, 30, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (45, 45, 5, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (46, 45, 31, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (47, 46, 5, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (48, 47, 5, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (49, 48, 3, '1/1/2017');		
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (50, 49, 3, '1/1/2017');
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (51, 49, 32, '1/1/2017');	
INSERT INTO [dbo].[Person_Address] ([Id], [PersonId], [AddressId], [DateCreated]) VALUES (52, 50, 3, '1/1/2017');		

SET IDENTITY_INSERT [dbo].[Person_Address] OFF;
SET IDENTITY_INSERT [dbo].[Product] ON;

INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (1, 'PlayMonster Yeti in My Spaghetti', NULL, 9.99, 7.81, 100, 12.3, 10.0, 1.8, NULL, 1.5, NULL, NULL, '<p>The simple game play has an amusing theme that kids and families love! Who ever pictured a yeti in spaghetti? It''s just too fun!<br />Put the noodles across the bowl, set Yeti on top, then start pulling noodles! Just don''t let Yeti fall all the way into the bowl!</p>', '1/1/2017', '1/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (2, 'L.O.L. Surprise! Glam Glitter Series Doll', 1, 13.95, 9.99, 1000, 3.5, 3.5, 3.5, NULL, 1.3, NULL, NULL, '<p>In a world where babies run everything little rockers Rebel against nap time and Teacher''s pets become class presidents with "free pizza Fridays!" in this world, all work is play and nothing is dull Cruz it''s<br /> all a Lil'' surprising and outrageous! unbox 7 surprises with each L.O.L. Surprise! glam glitter doll. L.O.L. Surprise! glam glitter includes series 2 dolls dressed with chrome and glitter finishes from head to<br /> toe! look for Kitty Queen and other fan favas from series 2 in all-new outfits! collect all 12 characters.</p>', '1/1/2017', '2/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (3, 'LEGO City Advent Calendar', 1, 22.99, 22.99, 10000, 9.8, 13.2, 2.3, NULL, 2.8, NULL, NULL, '<p>Ring in the holiday season with the fun 60201 LEGO City Advent Calendar. There are 24 different buildable presents, one for each day of the holiday season, including a space shuttle, race car, drone,<br /> robot, Christmas tree, monster truck and much more. This LEGO City set includes 5 LEGO minifigures and a dog figure.</p>', '1/1/2017', '3/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (4, 'Fire TV Stick, streaming media player', 2, 39.99, 39.99, 200, 4.2, 1.1, 0.6, NULL, 1.0, '10:00', '23:00', '<p><li>Our best-selling Fire TV Stick, with the 1st Gen Alexa Voice Remote.</li><li>Enjoy tens of thousands of channels, apps, and Alexa skills with access to over 500,000 movies and TV episodes. Enjoy favorites from Netflix, Prime Video, Hulu, HBO, SHOWTIME, NBC, and more.</li><li>Access millions of websites such as YouTube, Facebook, and Reddit with browsers like Silk and Firefox.</li></p>', '1/1/2017', '4/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (5, 'Digital Alarm Clock with Large 1.4" Display', 2, 14.95, 10.69, 2000, 3.7, 9.5, 3.9, 1.8, 2.0, NULL, NULL, '<p>Sometimes you just need something simple that''s easy to use. RCA has you covered with an affordable, streamlined alarm clock that offers snooze, a simple interface, a large 1.4-inch display, and No Worry battery back-up that lets you rest easy too.</p>', '1/1/2017', '5/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (6, 'Wyze Cam 1080p HD Indoor Wireless Smart Home Camera', 2, 27.98, 27.98, 20000, 7.5, 3.5, 2.9, 1.2, 1.5, NULL, NULL, '<p>Wyze Cam v2 delivers fast, clear, live stream footage direct to your smartphone via the Wyze App (iOS and Android), day or night. With motion and sound detection you can receive an alert anytime your Wyze Cam v2 detects sound and motion, and view up to 14 days of saved alert videos for free - no monthly fees or subscription required. Use the Wyze Cam v2''s new Motion Tagging feature to easily identify motion in both live stream and playback video modes.</p>', '1/1/2017', '6/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (7, 'The Wonky Donkey', 3, 7.99, 5.11, 300, 11.0, 8.5, NULL, 0.7, 1.0, NULL, NULL, '<p>Kids will love this cumulative and hysterical read-aloud!</p>', '1/1/2017', '7/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (8, 'Diary of a Wimpy Kid Book 13', 3, 13.95, 8.37, 3000, 11.0, 8.5, NULL, 0.5, 1.0, NULL, NULL, '<p>When snow shuts down Greg Heffley''s middle school, his neighborhood transforms into a wintry battlefield. Rival groups fight over territory, build massive snow forts, and stage epic snowball fights. And in the crosshairs are Greg and his trusty best friend, Rowley Jefferson.</p>', '1/1/2017', '8/1/2018');
INSERT INTO [dbo].[Product] ([Id], [Name], [ProductCategoryType], [ListPrice], [Price], [Quantity], [Height], [Width], [Depth], [Weight], [ShippingWeight], [ValidStartTimeOfDayForPurchase], [ValidEndTimeOfDayForPurchase], [Description], [DateCreated], [DateUpdated]) VALUES (9, 'Turkey Trouble', 3, 15.99, 7.99, 30000, 12.0, 10.0, NULL, 0.8, 1.0, NULL, NULL, '<p>Turkey is in trouble. Bad trouble. The kind of trouble where it''s almost Thanksgiving . . . and you''re the main<br />course. But Turkey has an idea--what if he doesn''t look like a turkey? What if he looks like another animal instead?</p>', '1/1/2017', '9/1/2018');

SET IDENTITY_INSERT [dbo].[Product] OFF;
SET IDENTITY_INSERT [dbo].[Purchase] ON;

INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (1, 2, 7.81, '11/1/2017', '11/8/2017', '11/15/2017', 'F31923DA-A046-4117-87E2-685281259D81', 'CreditCard', 'Web', '11/1/2017', '11/8/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (2, 3, 27.98, '11/1/2017', '11/8/2017', '11/15/2017', 'A152EBC6-AB79-4E7F-B322-DD3D36748FBF', 'CreditCard', 'Web', '11/1/2017', '11/8/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (3, 6, 5.11, '11/1/2017', '11/8/2017', '11/15/2017', 'FF35ABB5-2BE2-4031-B756-48C91B34EC59', 'CreditCard', 'InPerson', '11/1/2017', '11/8/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (4, 9, 15.62, '11/2/2017', '11/9/2017', '11/16/2017', 'EA46423E-8D98-40FF-B018-FED24A5BBC0C', 'PayPal', 'InPerson', '11/2/2017', '11/9/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (5, 12, 55.96, '11/2/2017', '11/9/2017', '11/22/2017', NULL, 'PayPal', 'Web', '11/2/2017', '11/9/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (6, 15, 10.22, '11/2/2017', '11/9/2017', '11/22/2017', NULL, 'PayPal', 'Web', '11/2/2017', '11/9/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (7, 2, 29.05, '11/3/2017', '11/10/2017', '11/25/2017', NULL, 'PayPal', 'Web', '11/3/2017', '11/10/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (8, 3, 53.40, '11/3/2017', '11/10/2017', '11/25/2017', NULL, 'PayPal', 'Web', '11/3/2017', '11/10/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (9, 6, 7.00, '11/3/2017', '11/10/2017', NULL, NULL, 'ACH', NULL, '11/3/2017', '11/10/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (10, 2, 9.00, '11/4/2017', '11/11/2017', NULL, NULL, 'ACH', NULL, '11/4/2017', '11/11/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (11, 3, 20.00, '11/4/2017', '11/11/2017', NULL, NULL, 'ACH', NULL, '11/4/2017', '11/11/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (12, 6, 30.00, '11/4/2017', '11/11/2017', NULL, NULL, 'ACH', NULL, '11/4/2017', '11/11/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (13, 9, 10.00, '11/5/2017', NULL, NULL, NULL, 'CreditCard', 'InPerson', '11/5/2017', '11/5/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (14, 12, 9.00, '11/5/2017', NULL, NULL, NULL, 'CreditCard', 'InPerson', '11/5/2017', '11/5/2017');
INSERT INTO [dbo].[Purchase] ([Id], [PersonId], [TotalPurchaseAmount], [PurchaseDate], [ShipDate], [ExpectedDeliveryDate], [TrackingIdentifier], [PaymentMethodType], [PaymentSourceType], [DateCreated], [DateUpdated]) VALUES (15, 15, 18.00, '11/5/2017', NULL, NULL, NULL, 'CreditCard', 'Web', '11/5/2017', '11/5/2017');

SET IDENTITY_INSERT [dbo].[Purchase] OFF;
SET IDENTITY_INSERT [dbo].[PurchaseLine] ON;

INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (1, 1, 1, 7.81, 1, '11/1/2017', '11/1/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (2, 2, 4, 27.98, 1, '11/1/2017', '11/1/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (3, 3, 7, 5.11, 1, '11/1/2017', '11/1/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (4, 4, 1, 7.81, 2, '11/2/2017', '11/2/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (5, 5, 4, 27.98, 2, '11/2/2017', '11/2/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (6, 6, 7, 5.11, 2, '11/2/2017', '11/2/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (7, 7, 2, 9.99, 1, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (8, 7, 5, 10.69, 1, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (9, 7, 8, 8.37, 1, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (10, 8, 1, 7.81, 3, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (11, 8, 2, 9.99, 3, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (12, 9, 1, 7.00, 1, '11/3/2017', '11/3/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (13, 10, 2, 9.00, 1, '11/4/2017', '11/4/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (14, 11, 3, 20.00, 1, '11/4/2017', '11/4/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (15, 12, 4, 30.00, 1, '11/4/2017', '11/4/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (16, 13, 5, 10.00, 1, '11/6/2017', '11/6/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (17, 14, 6, 9.00, 1, '11/6/2017', '11/6/2017');
INSERT INTO [dbo].[PurchaseLine] ([Id], [PurchaseId], [ProductId], [PurchasePrice], [Quantity], [DateCreated], [DateUpdated]) VALUES (18, 15, 7, 9.00, 2, '11/6/2017', '11/6/2017');

SET IDENTITY_INSERT [dbo].[PurchaseLine] OFF;