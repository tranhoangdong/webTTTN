USE [SellManagement]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 15/02/2020 6:08:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [float] NULL,
	[Email] [nvarchar](50) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CartId] [nvarchar](50) NULL,
	[ProductId] [int] NULL,
	[Count] [int] NULL,
	[DateCreate] [datetime] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Time] [datetime] NULL,
	[Contains] [nvarchar](400) NULL,
	[Phone] [float] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [float] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoriteProduct]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_FavoriteProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_HangSanXuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[Total] [decimal](18, 0) NULL,
	[Status] [int] NULL,
	[ReasonCancel] [nvarchar](550) NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 15/02/2020 6:08:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[GraphicsCard] [nvarchar](200) NULL,
	[Status] [nvarchar](200) NULL,
	[Screen] [nvarchar](200) NULL,
	[HardDrive] [nvarchar](50) NULL,
	[Ram] [nvarchar](50) NULL,
	[CPU] [nvarchar](max) NULL,
	[Weight] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[PromotionId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[DateSubmitted] [datetime] NULL,
	[Guarantee] [int] NULL,
	[ManufacturerId] [int] NULL,
	[imageId] [int] NULL,
	[NumberOfView] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Image]    Script Date: 15/02/2020 6:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image1] [nvarchar](200) NULL,
	[Image2] [nvarchar](200) NULL,
	[Image3] [nvarchar](200) NULL,
	[Image4] [nvarchar](200) NULL,
	[Image5] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product_Image_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 15/02/2020 6:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromDay] [datetime] NULL,
	[ToDay] [datetime] NULL,
	[Ratio] [int] NULL,
	[Content] [nvarchar](500) NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Watched]    Script Date: 15/02/2020 6:08:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Watched](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_Da_Xem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status]) VALUES (0, N'Tran', NULL, N'Phuong', N'a@gmail.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (1, N'Lenovo')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (2, N'Thinkpark')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (3, N'Asus')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (4, N'Hp')
INSERT [dbo].[Manufacturer] ([Id], [Name]) VALUES (5, N'Dell')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (1, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 0, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 1, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (2, N'Laptop Lenovo Thinkpad P53', N'Nvidia Quadro T2000 4GB', N'Like new 90%', N'15.6 inch 16:9, LED - IPS - FHD (1920 X 1080)', N' M.2 256 GB PCIe NVMe', N'16 GB DDR4 2666 MHz', N'Intel® Core™ i7 - 9750H (12M Cache), 2.6 Ghz up to 4.5 Ghz', N'1.9', 10, NULL, CAST(4500000 AS Decimal(18, 0)), CAST(N'2019-01-01T00:00:00.000' AS DateTime), 10, 1, 2, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (3, N'Laptop Dell XPS 15 7590', N' NVIDIA® GeForce® GTX 1650 4GB', N'Like new 100%', N'15.6" UHD - 4K UHD (3840 x 2160) Inf inityEdge Anti-Reflective Touc h IPS 100% AdobeRGB 500-Nits', N'512 GB M.2 2280 PCIe SSD', N'16 GB DDR4 2666 MHz', N'Intel® Core™ i7 - 9750H (12M Cache), 2.60 Ghz up to 4.50 Ghz', N'1.0', 2, 2, CAST(51900000 AS Decimal(18, 0)), CAST(N'2020-03-04T00:00:00.000' AS DateTime), 24, 5, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (4, N'Laptop Dell XPS 15 7590', N' NVIDIA® GeForce® GTX 1650 4GB', N'Like new 100%', N'15.6" UHD - 4K UHD (3840 x 2160) Inf inityEdge Anti-Reflective Touc h IPS 100% AdobeRGB 500-Nits', N'512 GB M.2 2280 PCIe SSD', N'16 GB DDR4 2666 MHz', N'Intel® Core™ i7 - 9750H (12M Cache), 2.60 Ghz up to 4.50 Ghz', N'1.0', 2, 2, CAST(51900000 AS Decimal(18, 0)), CAST(N'2020-03-04T00:00:00.000' AS DateTime), 24, 5, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (5, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, NULL, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (6, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 1, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (7, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 2, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (8, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 2, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (9, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 2, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (10, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, NULL, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 1, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (11, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (12, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, NULL, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 1, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (13, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [GraphicsCard], [Status], [Screen], [HardDrive], [Ram], [CPU], [Weight], [Quantity], [PromotionId], [Price], [DateSubmitted], [Guarantee], [ManufacturerId], [imageId], [NumberOfView]) VALUES (14, N'Laptop Lenovo ThinkPad X1 Carbon Gen 3', N' Intel® HD Graphics 5500', N'Like new 90%', N'14 inch 16:9, AG - FHD (1920 x 1080)', N'128 GB SSD', N'4 GB DDR2 2666 MHz', N'Intel® Core™ i5 - 5300U (3M Cache), 2.3 Ghz up to 2.9 Ghz', N'2.3', 20, 1, CAST(9500000 AS Decimal(18, 0)), CAST(N'2020-02-12T00:00:00.000' AS DateTime), 12, 1, 1, 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Product_Image] ON 

INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5]) VALUES (1, N'sanpham1.jpg', N'sanpham2.jpg', N'sanpham7.jpg', N'sanpham4.jpg', N'sanpham6.jpg')
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5]) VALUES (2, N'lap1.jpg', N'lap2.jpg', N'lap3.jpg', N'lap4.jpg', N'lap5.jpg')
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5]) VALUES (3, N'lap6.jpg', N'lap7.jpg', N'lap8.jpg', N'lap10.jpg', N'lap11.jpg')
SET IDENTITY_INSERT [dbo].[Product_Image] OFF
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([Id], [FromDay], [ToDay], [Ratio], [Content]) VALUES (1, CAST(N'2020-02-13T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), 10, N'Được hưởng khuyến mãi nhân dịp lễ tình nhân')
INSERT [dbo].[Promotion] ([Id], [FromDay], [ToDay], [Ratio], [Content]) VALUES (2, CAST(N'2020-02-13T00:00:00.000' AS DateTime), CAST(N'2020-12-12T00:00:00.000' AS DateTime), 5, N'Được hưởng khuyến mãi nhân dịp ngày thành lập công ty')
SET IDENTITY_INSERT [dbo].[Promotion] OFF
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_SanPham] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_SanPham]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_SanPham] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_SanPham]
GO
ALTER TABLE [dbo].[FavoriteProduct]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteProduct_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[FavoriteProduct] CHECK CONSTRAINT [FK_FavoriteProduct_Customer]
GO
ALTER TABLE [dbo].[FavoriteProduct]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteProduct_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[FavoriteProduct] CHECK CONSTRAINT [FK_FavoriteProduct_Product]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_SanPham] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_SanPham]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Product_Image] FOREIGN KEY([imageId])
REFERENCES [dbo].[Product_Image] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Product_Image]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Promotion] FOREIGN KEY([PromotionId])
REFERENCES [dbo].[Promotion] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Promotion]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_HangSanXuat] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_SanPham_HangSanXuat]
GO
ALTER TABLE [dbo].[Watched]  WITH CHECK ADD  CONSTRAINT [FK_Watched_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Watched] CHECK CONSTRAINT [FK_Watched_Customer]
GO
ALTER TABLE [dbo].[Watched]  WITH CHECK ADD  CONSTRAINT [FK_Watched_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Watched] CHECK CONSTRAINT [FK_Watched_Product]
GO
