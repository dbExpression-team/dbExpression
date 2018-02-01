USE [MsSqlTest]
GO
INSERT [dbo].[TypeCode] ([Name], [Key], [Value], [FriendlyName], [Description]) VALUES (N'AddressType', N'Shipping', 0, N'Shipping', N'Shipping Address')
GO
INSERT [dbo].[TypeCode] ([Name], [Key], [Value], [FriendlyName], [Description]) VALUES (N'AddressType', N'Mailing', 1, N'Mailing', N'Mailing Address')
GO
INSERT [dbo].[TypeCode] ([Name], [Key], [Value], [FriendlyName], [Description]) VALUES (N'AddressType', N'Billing', 2, N'Billing', N'Billing Address')
GO
