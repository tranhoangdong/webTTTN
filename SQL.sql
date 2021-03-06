USE [TTTN]
GO
/****** Object:  Table [dbo].[Accessories]    Script Date: 21/06/2020 1:38:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Price] [decimal](18, 0) NULL,
	[Image] [nvarchar](200) NULL,
	[Description1] [nvarchar](max) NULL,
	[Description2] [nvarchar](max) NULL,
	[Description3] [nvarchar](max) NULL,
	[Description4] [nvarchar](max) NULL,
	[Description5] [nvarchar](max) NULL,
	[Description6] [nvarchar](max) NULL,
	[Description7] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[KeyWord] [nvarchar](200) NULL,
	[Manufacture] [nvarchar](50) NULL,
	[Quantity] [int] NOT NULL,
	[IdCategoryAccessories] [int] NULL,
 CONSTRAINT [PK_Accessories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
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
/****** Object:  Table [dbo].[Category]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryAccessorie]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryAccessorie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
 CONSTRAINT [PK_CategoryAccessorie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Time] [datetime] NULL,
	[Email] [nvarchar](50) NULL,
	[Contains] [nvarchar](400) NULL,
	[Phone] [float] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 21/06/2020 1:39:00 PM ******/
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
	[Phone] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Points] [int] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailsProducts]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailsProducts](
	[Id] [int] NOT NULL,
	[TouchGlass] [nvarchar](400) NULL,
	[ScreenTechnology] [nvarchar](400) NULL,
	[ScreenSize] [nvarchar](400) NULL,
	[TheResolution] [nvarchar](50) NULL,
	[CameraFeature] [nvarchar](max) NULL,
	[FlashLight] [nvarchar](200) NULL,
	[VideoCall] [nvarchar](200) NULL,
	[Film] [nvarchar](200) NULL,
	[ExternalMemoryCardSupport] [nvarchar](200) NULL,
	[MaximumCardSupport] [nvarchar](200) NULL,
	[Weight] [nvarchar](50) NULL,
	[BatteryType] [nvarchar](200) NULL,
	[FMRadio] [nvarchar](50) NULL,
	[ImageDetial] [nvarchar](200) NULL,
 CONSTRAINT [PK_DetailsProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FavoriteProduct]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavoriteProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[Status] [int] NULL,
	[CategoryId] [int] NULL,
	[AccessoriesId] [int] NULL,
 CONSTRAINT [PK_FavoriteProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gift]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gift](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_Gift] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[image] [nvarchar](200) NULL,
 CONSTRAINT [PK_HangSanXuat] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[OrderDate] [datetime] NULL,
	[Total] [decimal](18, 0) NOT NULL,
	[Status] [int] NULL,
	[ReasonCancel] [nvarchar](550) NULL,
	[CustomerId] [int] NULL,
	[ProvisionalAmount] [decimal](18, 0) NOT NULL,
	[DateProcessing] [datetime] NULL,
	[AdminId] [int] NULL,
	[PointsUse] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 21/06/2020 1:39:00 PM ******/
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
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[FrontCamera] [nvarchar](200) NULL,
	[RearCamera] [nvarchar](200) NULL,
	[Ram] [nvarchar](50) NULL,
	[CPU] [nvarchar](max) NULL,
	[InternalMemory] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[Sim] [nvarchar](200) NULL,
	[Battery] [nvarchar](200) NULL,
	[OperatingSystem] [nvarchar](200) NULL,
	[PromotionId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[DateSubmitted] [datetime] NULL,
	[GiftId] [int] NULL,
	[Guarantee] [int] NULL,
	[ManufacturerId] [int] NULL,
	[NumberOfView] [int] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Image]    Script Date: 21/06/2020 1:39:00 PM ******/
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
	[IdProducts] [int] NULL,
 CONSTRAINT [PK_Product_Image_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 21/06/2020 1:39:00 PM ******/
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
/****** Object:  Table [dbo].[Watched]    Script Date: 21/06/2020 1:39:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Watched](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[DateTime] [datetime] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Da_Xem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accessories] ON 

INSERT [dbo].[Accessories] ([Id], [Name], [Price], [Image], [Description1], [Description2], [Description3], [Description4], [Description5], [Description6], [Description7], [CategoryId], [KeyWord], [Manufacture], [Quantity], [IdCategoryAccessories]) VALUES (1, N'Pin sạc dự phòng 10.000mAh Power IQ 2.0 AnkerPower CoreIIA1230 Đen
', CAST(1000000 AS Decimal(18, 0)), N'sac-du-phong.jpg', N'Dung lượng Pin: 10.000 mAh', N'Thời gian sạc đầy :9 - 10 giờ (dùng Adapter 1A)3 - 4 giờ (dùng 9V/2A or 12V/1.5A)5 - 6 giờ (dùng Adapter 2A)', N'Nguồn vào:Micro USB: 5V - 2A, 9V - 2A , Nguồn ra :USB: 5V - 3A, 9V - 2A, 12V - 1.5A', N'Lõi Pin: 	Pin Li-Ion', N'Kích thước::Dày 2 cm - Rộng 6 cm - Dài 9.5 cm', N'Trọng lượng:211g', N'Sản xuất tại:Trung Quốc', 2, N'Iphone', N'Trung Quốc', 0, 2)
INSERT [dbo].[Accessories] ([Id], [Name], [Price], [Image], [Description1], [Description2], [Description3], [Description4], [Description5], [Description6], [Description7], [CategoryId], [KeyWord], [Manufacture], [Quantity], [IdCategoryAccessories]) VALUES (6, N'Cáp Lightning 1m Xmobile LTL-01X Xanh rêu
', CAST(117000 AS Decimal(18, 0)), N'cap-lightning-1m.jpg', N'Chức năng: SạcTruyền dữ liệu', N'Đầu ra:Lightning: 5V - 2.1A', N'Độ dài dây:', N'1 m', N'Thương hiệu của:Thế Giới Di Động', N'', NULL, 2, N'Vsmart', N'	Trung Quốc
', 0, 5)
INSERT [dbo].[Accessories] ([Id], [Name], [Price], [Image], [Description1], [Description2], [Description3], [Description4], [Description5], [Description6], [Description7], [CategoryId], [KeyWord], [Manufacture], [Quantity], [IdCategoryAccessories]) VALUES (7, N'Ốp lưng OPPO A91 ', CAST(12000 AS Decimal(18, 0)), N'op-lung-oppo-a91.jpg', N'Kiểu dáng thời trang và đẹp mắt', N'Thiết kế vừa vặn và ôm sát thân máy', N'Dễ dàng tháo/lắp ốp vào máy', NULL, NULL, NULL, NULL, 2, N'Oppo', N'Trung Quốc', 7, 1)
INSERT [dbo].[Accessories] ([Id], [Name], [Price], [Image], [Description1], [Description2], [Description3], [Description4], [Description5], [Description6], [Description7], [CategoryId], [KeyWord], [Manufacture], [Quantity], [IdCategoryAccessories]) VALUES (8, N'Miếng dán lưng Galaxy S20 Ultra
', CAST(12000 AS Decimal(18, 0)), N'mieng-dan-lung-galaxy-s20-ultra.jpg', N'Chống trầy xước tối ưu mặt lưng điện thoại Galaxy S20 Ultra.', N'Làm giảm các dấu vân tay và vết ố.', N'Chất liệu Nhật Bản và đóng gói tại Đài Loan.', NULL, NULL, NULL, NULL, 2, N'SamSung', N'Việt Nam', 20, 4)
INSERT [dbo].[Accessories] ([Id], [Name], [Price], [Image], [Description1], [Description2], [Description3], [Description4], [Description5], [Description6], [Description7], [CategoryId], [KeyWord], [Manufacture], [Quantity], [IdCategoryAccessories]) VALUES (9, N'Loa Bluetooth JBL Pulse 4 Đen

', CAST(490000 AS Decimal(18, 0)), N'loa-bluetooth.jpg', N'Thiết kế ấn tượng với hiệu ứng LED 360 độ hoàn hảo.', N'Âm thanh đặt trưng của công nghệ JBL Signature Sound, cho âm trầm mạnh mẽ.', N'Công suất lên đến 20 W, cho âm thanh chất lượng, sống động.', NULL, N'Với tính năng PartyBoost của JBL, giúp bạn kết nối các loa lại dễ dàng với nhau.', N'Điều khiển hiệu ứng đèn LED thông qua app JBL Connect.', N'Thiết kế chuẩn chống nước IPX7, giúp loa hoạt động trong mọi điều kiện.', 2, N'Iphone, Vsmart, Oppo, SamSung', N'Trung Quốc', 17, 6)
SET IDENTITY_INSERT [dbo].[Accessories] OFF
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([Id], [Name], [Phone], [Email], [Account], [Password], [Status]) VALUES (1, N'Phương', N'8.52015e+008', N'a@gmail.com', N'phuongtran', N'123', 0)
INSERT [dbo].[Admin] ([Id], [Name], [Phone], [Email], [Account], [Password], [Status]) VALUES (3, N'Thành Nhã', N'7.80367e+009', N'a@gmail.com', N'nha', N'123', 2)
INSERT [dbo].[Admin] ([Id], [Name], [Phone], [Email], [Account], [Password], [Status]) VALUES (4, N'Khánh Trân', N'7.80367e+009', N'tran123@gmail.com', N'tran', N'123', 1)
INSERT [dbo].[Admin] ([Id], [Name], [Phone], [Email], [Account], [Password], [Status]) VALUES (5, N'phuong', N'121212', N'a@gmail.com', N'phuonga', N'1', 1)
INSERT [dbo].[Admin] ([Id], [Name], [Phone], [Email], [Account], [Password], [Status]) VALUES (6, N'trần thị hảo', N'4.5679e+007', N'a@gmail.com', N'hảo', N'1', 1)
SET IDENTITY_INSERT [dbo].[Admin] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (1, N'Điện Thoại')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (2, N'Linh Kiện ')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[CategoryAccessorie] ON 

INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (1, N'Ốp lưng')
INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (2, N'Pin')
INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (3, N'Sạc dự phòng')
INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (4, N'Miếng dán lưng')
INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (5, N'Cáp sạc')
INSERT [dbo].[CategoryAccessorie] ([Id], [Name]) VALUES (6, N'Loa')
SET IDENTITY_INSERT [dbo].[CategoryAccessorie] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (2, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1006, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1007, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1008, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1010, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1011, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1013, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1014, 52, N'Khánh Trân ', CAST(N'2020-05-22T21:19:46.980' AS DateTime), N'tranlun@gmail.com', N'Sản phẩm rất tốt  nha mn !!! ', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1016, 51, N'Phương', CAST(N'2020-06-09T12:13:35.080' AS DateTime), N'phuonghiepsi@gmail.com', N'aaa', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1017, 51, N'Phương', CAST(N'2020-06-09T12:13:38.253' AS DateTime), N'phuonghiepsi@gmail.com', N'aaa', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1018, 55, N'Phương', CAST(N'2020-06-09T18:01:45.533' AS DateTime), N'phuonghiepsi@gmail.com', N'Tốt', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1019, 52, N'Nhã', CAST(N'2020-06-11T15:21:27.900' AS DateTime), N'a@gmail.com', N'Sản phẩm ok', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1021, 50, N'a', CAST(N'2020-06-13T11:22:29.117' AS DateTime), N'a@gmail.com', N'aaa', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1025, 50, N'a', CAST(N'2020-06-21T11:55:36.913' AS DateTime), N'a@gmail.com', N'aa', 852015499, NULL)
INSERT [dbo].[Comment] ([Id], [ProductId], [Name], [Time], [Email], [Contains], [Phone], [CategoryId]) VALUES (1026, 51, N'A', CAST(N'2020-06-21T12:51:19.627' AS DateTime), N'dien@agmail.com', N'aaaaa', 234, NULL)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (1, N'phuong', N'123', N'Phương', N'phuonghiepsi@gmail.com', N'12121', 1, 8322)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (2, N'tran', N'123', N'Khánh Trân', N'Tran123@gmail.com', N'122', 1, 0)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (6, N'dien', N'123', N'PhươngHS', N'phuonghiepsi@gmail.com', N'1234', 1, 1487)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (12, N'phuonghs', N'123', N'tphuong', N'dien@agmail.com', N'1324', 1, 0)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (13, N'nha', N'123', N'Nhã', N'phuonghiepsi@gmail.com', N'12345', 1, 2793)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (14, N'aman', N'1122', N'Phạm Thành Nhã', N'a@gmail.com', N'1221', 1, 2087)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (15, N'dien1', N'123', N'Điền', N'dien@gmail.com', N'0123', 1, 0)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (16, N'tvtoan', N'123', N'Nhã', N'dien@gmail.com', N'01324', 1, 3904)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (17, N'nvtduong', N'123', N'Thùy Dương', N'phuonghiepsi@gmail.com', N'013245', 1, 6126)
INSERT [dbo].[Customer] ([Id], [Account], [Password], [Name], [Email], [Phone], [Status], [Points]) VALUES (18, N'nva', N'123', N'A', N'dien@agmail.com', N'0234', 1, 2316)
SET IDENTITY_INSERT [dbo].[Customer] OFF
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (50, N'Kính cường lực oleophobic (ion cường lực)', N'IPS LCD', N'6.1"', N'828 x 1792 Pixels', N'	Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD 1080p@120fps, Quay phim FullHD 1080p@240fps, Quay phim 4K 2160p@24fps, Quay phim 4K 2160p@30fps, Quay phim 4K 2160p@60fps', N'3 đèn LED 2 tông màu', N'Có', N'H.264(MPEG4-AVC)', N'Không', N'Apple GPU 4 nhân', N'194 g', N'Pin chuẩn Li-Ion', N'Không', N'iphone-11-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (51, N'Kính cường lực oleophobic (ion cường lực)', N'IPS LCD', N'6.1"', N'828 x 1792 Pixels', N'Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD 1080p@120fps, Quay phim FullHD 1080p@240fps, Quay phim 4K 2160p@24fps, Quay phim 4K 2160p@30fps, Quay phim 4K 2160p@60fps', N'4 đèn LED (2 tông màu)', N'Có', N'H.264(MPEG4-AVC)', N'Không', N'Apple GPU 4 nhân', N'194 g', N'Pin chuẩn Li-Ion', N'Không', N'iphone-11-128gb-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (52, N'Kính cường lực oleophobic (ion cường lực)', N'IPS LCD', N'6.1"', N'828 x 1792 Pixels', N'	Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD 1080p@120fps, Quay phim FullHD 1080p@240fps, Quay phim 4K 2160p@24fps, Quay phim 4K 2160p@30fps, Quay phim 4K 2160p@60fps', N'4 đèn LED (2 tông màu)', N'Có', N'H.264(MPEG4-AVC)', N'Không', N'Apple GPU 4 nhân', N'194 g', N'Pin chuẩn Li-Ion', N'Không', N'iphone-11-256gb-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (53, N'Kính cường lực oleophobic (ion cường lực)', N'OLED', N'6.5"', N'1242 x 2688 Pixels', N'	Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD 1080p@120fps, Quay phim FullHD 1080p@240fps, Quay phim 4K 2160p@24fps, Quay phim 4K 2160p@30fps, Quay phim 4K 2160p@60fps', N'4 đèn LED (2 tông màu)', N'Có', N'H.264(MPEG4-AVC)', N'Không', N'Apple GPU 4 nhân', N'226 g', N'Pin chuẩn Li-Ion', N'Không', N'iphone-11-pro-max-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (54, N'Kính cường lực oleophobic (ion cường lực)', N'OLED', N'6.5"', N'1242 x 2688 Pixels', N'Quay phim HD 720p@30fps, Quay phim FullHD 1080p@30fps, Quay phim FullHD 1080p@60fps, Quay phim FullHD 1080p@120fps, Quay phim FullHD 1080p@240fps, Quay phim 4K 2160p@24fps, Quay phim 4K 2160p@30fps, Quay phim 4K 2160p@60fps', N'4 đèn LED (2 tông màu)', N'Có', N'	H.264(MPEG4-AVC)', N'Không', N'Apple GPU 4 nhân', N'226 g', N'Pin chuẩn Li-Ion', N'Không', N'iphone-11-pro-max-512gb-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (55, N'Kính cường lực Corning Gorilla Glass 3', N'Super AMOLED', N'6.7"', N'Full HD+ (1080 x 2400 Pixels)', N'Quay phim FullHD 1080p@30fps, Quay phim HD 720p@960fps, Quay phim FullHD 1080p@60fps, Quay phim 4K 2160p@30fps', N'Có', N'Có', N'	H.265, 3GP, MP4, AVI, WMV, H.264(MPEG4-AVC), DivX, WMV9, Xvid', N'MicroSD, hỗ trợ tối đa 1 TB', N'Adreno 640', N'186 g', N'Pin chuẩn Li-Ion', N'Không', N'samsung-galaxy-s10-lite-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1066, N'Kính cường lực Corning Gorilla Glass 6', N'Dynamic AMOLED 2X', N'6.2"', N'2K+ (1440 x 3200 Pixels)', N'Góc siêu rộng (Ultrawide),', N'Có', N'Có', N'Quay phim HD 720p@960fps', N'MicroSD, hỗ trợ tối đa 1 TB', N'MicroSD, hỗ trợ tối đa 1 TB', N'163 g', N'Pin chuẩn Li-Ion', N'không', N'samsung-galaxy-s20-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1067, N'Mặt kính cong 2.5D', N'IPS LCD', N'6.2"', N'HD+ (720 x 1440 Pixels)', N'Quay phim FullHD 1080p@30fps', N'Có', N'Hỗ trợ VideoCall thông qua ứng dụng', N'Quay phim FullHD 1080p@30fps', N'MicroSD, hỗ trợ tối đa 256 GB', N'MicroSD, hỗ trợ tối đa 256 GB', N'170 g', N'Pin chuẩn Li-Ion', N'không', N'vsmart-bee-3-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1068, N'Kính cường lực Corning Gorilla Glass 3', N'TFT LCD', N'6.5"', N'Full HD+ (1080 x 2400 Pixels)', N'Góc siêu rộng (Ultrawide)', N'Có', N'Có', N'Góc siêu rộng (Ultrawide)', N'MicroSD, hỗ trợ tối đa 1 TB', N'MicroSD, hỗ trợ tối đa 256 GB', N'192 g', N'Pin chuẩn Li-Ion', N'không', N'oppo-a92-note (1).jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1069, N'Kính cường lực Corning Gorilla Glass 3', N'TFT LCD', N'6.5"', N'Full HD+ (1080 x 2400 Pixels)', N'Quay phim HD 720p@30fps', N'Có', N'Hỗ trợ VideoCall thông qua ứng dụng', N'Quay phim HD 720p@960fps', N'MicroSD, hỗ trợ tối đa 256 GB', N'MicroSD, hỗ trợ tối đa 256 GB', N'170 g', N'Pin chuẩn Li-Ion', N'không', N'oppo-a52-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1070, N'Kính cường lực Corning Gorilla Glass 6', N'Sunlight Super AMOLED', N'6.4"', N'2K+ (1440 x 3200 Pixels)', N'Quay phim FullHD 1080p@30fps', N'Có', N'Hỗ trợ VideoCall thông qua ứng dụng', N'Quay phim HD 720p@960fps', N'MicroSD, hỗ trợ tối đa 1 TB', N'MicroSD, hỗ trợ tối đa 1 TB', N'192 g', N'Pin chuẩn Li-Ion', N'không', N'oppo-reno3-pro-note.jpg')
INSERT [dbo].[DetailsProducts] ([Id], [TouchGlass], [ScreenTechnology], [ScreenSize], [TheResolution], [CameraFeature], [FlashLight], [VideoCall], [Film], [ExternalMemoryCardSupport], [MaximumCardSupport], [Weight], [BatteryType], [FMRadio], [ImageDetial]) VALUES (1071, N'Kính cường lực Corning Gorilla Glass 3', N'Sunlight Super AMOLED', N'6.5"', N'Full HD+ (1080 x 2400 Pixels)', N'Góc siêu rộng (Ultrawide),', N'Có', N'Hỗ trợ VideoCall thông qua ứng dụng', N'Quay phim FullHD 1080p@30fps', N'MicroSD, hỗ trợ tối đa 256 GB', N'Khoảng 109 GB', N'163 g', N'Pin chuẩn Li-Ion', N'không', N'oppo-reno2-f-note-2.jpg')
SET IDENTITY_INSERT [dbo].[FavoriteProduct] ON 

INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (59, 1, 50, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (60, 1, 51, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (61, 1, NULL, 1, 2, 1)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (62, 1, 52, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (63, 1, NULL, 1, 2, 6)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (64, 1, NULL, 1, 2, 7)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (65, 1, NULL, 1, 2, 8)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (66, 1, NULL, 0, 2, 9)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (67, 1, 54, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (68, 1, NULL, 0, 2, 9)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (69, 1, NULL, 1, 2, 1)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (70, 1, 55, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (71, 1, 53, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (72, 13, 50, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (73, 13, 51, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (74, 18, NULL, 1, 2, 1)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (75, 18, NULL, 1, 2, 6)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (76, 18, NULL, 1, 2, 7)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (77, 18, 1066, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (78, 18, 55, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (79, 18, 54, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (80, 18, 52, 1, 1, NULL)
INSERT [dbo].[FavoriteProduct] ([Id], [CustomerId], [ProductId], [Status], [CategoryId], [AccessoriesId]) VALUES (81, 18, 51, 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[FavoriteProduct] OFF
SET IDENTITY_INSERT [dbo].[Gift] ON 

INSERT [dbo].[Gift] ([Id], [Content]) VALUES (1, N'Bộ sản phẩm gồm : Sạc, tai nghe , cây lấy Sim , cáp , sách hướng dẫn , hộp')
INSERT [dbo].[Gift] ([Id], [Content]) VALUES (2, N'Bộ sản phẩm gồm : Sạc, tai nghe , cây lấy Sim , cáp , sách hướng dẫn , hộp')
SET IDENTITY_INSERT [dbo].[Gift] OFF
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name], [image]) VALUES (1, N'Iphone', N'icon-iphone.jpg')
INSERT [dbo].[Manufacturer] ([Id], [Name], [image]) VALUES (2, N'SamSung', N'icon-samsung.png')
INSERT [dbo].[Manufacturer] ([Id], [Name], [image]) VALUES (3, N'Oppo', N'icon-oppo.png')
INSERT [dbo].[Manufacturer] ([Id], [Name], [image]) VALUES (4, N'Vsmart', N'icon-Vsmart.png')
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1023, N'qq', N'852015499', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-05-26T22:29:31.983' AS DateTime), CAST(20871000 AS Decimal(18, 0)), 2, N'k muatao bi khug', 1, CAST(20871000 AS Decimal(18, 0)), CAST(N'2020-06-12T12:22:59.970' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1025, N'qq', N'852015499', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-05-27T18:31:23.183' AS DateTime), CAST(20671000 AS Decimal(18, 0)), 0, NULL, 1, CAST(20871000 AS Decimal(18, 0)), NULL, NULL, 1000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1026, N'đường a', N'1234345', N'Sóc Trăng 1', N'phuonghiepsideptrai@gmail.com', CAST(N'2020-05-27T21:17:23.633' AS DateTime), CAST(12391000 AS Decimal(18, 0)), 0, NULL, 1, CAST(12591000 AS Decimal(18, 0)), CAST(N'2020-05-31T22:26:10.130' AS DateTime), 1, 1000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1027, N'Đường 3/2', N'852015499', N'Sóc Trăng', N'phuonghiepsi@gmail.com', CAST(N'2020-05-28T22:37:13.303' AS DateTime), CAST(77627000 AS Decimal(18, 0)), 2, N'không mua', 1, CAST(78027000 AS Decimal(18, 0)), CAST(N'2020-05-31T22:49:03.760' AS DateTime), 1, 2000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1028, N'Bánh Sèo', N'123', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-06-09T12:41:45.690' AS DateTime), CAST(38073000 AS Decimal(18, 0)), 2, N'aaaaaaaaaa', 1, CAST(38773000 AS Decimal(18, 0)), CAST(N'2020-06-12T12:16:46.867' AS DateTime), 1, 3500)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1029, N'Mới nha ', N'852015499', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-06-12T12:15:56.463' AS DateTime), CAST(18533000 AS Decimal(18, 0)), 2, NULL, 1, CAST(19533000 AS Decimal(18, 0)), NULL, NULL, 5000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1030, N'nhà ma', N'852015499', N'Cần Thơ', N'si@gmail.com', CAST(N'2020-06-12T13:51:49.653' AS DateTime), CAST(37591000 AS Decimal(18, 0)), 3, N'không thích mua', 1, CAST(37791000 AS Decimal(18, 0)), CAST(N'2020-06-12T13:54:25.540' AS DateTime), 1, 1000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1031, N'Số 10, đường Võ Thị Sáu', N'852015499', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-12T14:48:23.047' AS DateTime), CAST(42932000 AS Decimal(18, 0)), 2, NULL, 1, CAST(43132000 AS Decimal(18, 0)), CAST(N'2020-06-16T08:25:53.217' AS DateTime), 1, 1000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1032, N'Mới nha ', N'852015499', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-06-15T12:37:49.983' AS DateTime), CAST(12000 AS Decimal(18, 0)), 3, N'không muốn mua', 1, CAST(12000 AS Decimal(18, 0)), CAST(N'2020-06-15T12:39:19.933' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1033, N'Mới nha ', N'1253262015', N'Cần Thơ', N'Tran123@gmail.com', CAST(N'2020-06-15T22:53:48.133' AS DateTime), CAST(40022000 AS Decimal(18, 0)), 3, N'a', 2, CAST(40022000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:57:15.180' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1034, N'178 Võ Thị Sáu', N'852015499', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-16T08:08:54.513' AS DateTime), CAST(35342000 AS Decimal(18, 0)), 2, NULL, 1, CAST(39042000 AS Decimal(18, 0)), CAST(N'2020-06-16T08:20:24.300' AS DateTime), 1, 18500)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1046, N'Mới nha ', N'01324', N'Cần Thơ', N'dien@agmail.com', CAST(N'2020-06-17T12:30:34.207' AS DateTime), CAST(35712000 AS Decimal(18, 0)), 0, NULL, 12, CAST(35712000 AS Decimal(18, 0)), NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1047, N'Hà Nội', N'012345', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-19T10:53:49.293' AS DateTime), CAST(129000 AS Decimal(18, 0)), 0, NULL, 13, CAST(129000 AS Decimal(18, 0)), NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1048, N'Hà Nội', N'12345', N'Cần Thơ', N'phuonghiepsi@gmail.com', CAST(N'2020-06-19T10:55:34.750' AS DateTime), CAST(23133000 AS Decimal(18, 0)), 0, NULL, 13, CAST(23133000 AS Decimal(18, 0)), NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1049, N'Mới nha ', N'12345', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-19T10:56:06.560' AS DateTime), CAST(27931000 AS Decimal(18, 0)), 2, NULL, 13, CAST(27931000 AS Decimal(18, 0)), CAST(N'2020-06-19T10:56:43.050' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1050, N'Hà Nội', N'12345', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-19T11:00:26.313' AS DateTime), CAST(14566500 AS Decimal(18, 0)), 3, N'k thich', 13, CAST(14866500 AS Decimal(18, 0)), CAST(N'2020-06-19T11:01:06.580' AS DateTime), 1, 1500)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1051, N'Hà Nội', N'012345656', N'Cần Thơ', N'a@gmail.com', CAST(N'2020-06-19T11:02:59.817' AS DateTime), CAST(20871000 AS Decimal(18, 0)), 2, NULL, 14, CAST(20871000 AS Decimal(18, 0)), CAST(N'2020-06-19T11:09:22.923' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1052, N'Mới nha ', N'0123567', N'Bạc Liêu', N'dien@gmail.com', CAST(N'2020-06-19T11:30:40.943' AS DateTime), CAST(69363000 AS Decimal(18, 0)), 0, NULL, 15, CAST(69363000 AS Decimal(18, 0)), NULL, NULL, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1053, N'Hà Nội', N'01324', N'Cần Thơ', N'dien@gmail.com', CAST(N'2020-06-19T12:54:02.327' AS DateTime), CAST(39042000 AS Decimal(18, 0)), 2, NULL, 16, CAST(39042000 AS Decimal(18, 0)), CAST(N'2020-06-19T12:59:02.897' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1054, N'Mới nha ', N'01324', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-21T12:06:48.733' AS DateTime), CAST(61263000 AS Decimal(18, 0)), 2, NULL, 17, CAST(61263000 AS Decimal(18, 0)), CAST(N'2020-06-21T12:14:37.543' AS DateTime), 1, 0)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1055, N'Hà Nội', N'01324', N'Bạc Liêu', N'phuonghiepsi@gmail.com', CAST(N'2020-06-21T12:16:59.057' AS DateTime), CAST(11391000 AS Decimal(18, 0)), 3, N'không thích mua', 17, CAST(12591000 AS Decimal(18, 0)), CAST(N'2020-06-21T12:17:17.377' AS DateTime), 1, 6000)
INSERT [dbo].[Order] ([Id], [Address], [Phone], [City], [Email], [OrderDate], [Total], [Status], [ReasonCancel], [CustomerId], [ProvisionalAmount], [DateProcessing], [AdminId], [PointsUse]) VALUES (1056, N'Hà Nội', N'0234', N'Cần Thơ', N'dien@agmail.com', CAST(N'2020-06-21T12:48:17.910' AS DateTime), CAST(23157000 AS Decimal(18, 0)), 2, NULL, 18, CAST(23157000 AS Decimal(18, 0)), CAST(N'2020-06-21T12:49:55.347' AS DateTime), 1, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1066, 1023, 51, 1, CAST(20871000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1068, 1025, 51, 1, CAST(20871000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1072, 1026, 55, 1, CAST(12591000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1073, 1027, 52, 1, CAST(23121000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1074, 1027, 8, 2, CAST(12000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1075, 1027, 53, 2, CAST(27441000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1077, 1028, 55, 3, CAST(12591000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1078, 1028, 1, 1, CAST(1000000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1080, 1029, 8, 1, CAST(12000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1081, 1029, 50, 1, CAST(19521000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1082, 1030, 54, 1, CAST(37791000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1097, 1046, 52, 1, CAST(23121000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1098, 1046, 55, 1, CAST(12591000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1099, 1047, 6, 1, CAST(117000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1100, 1047, 8, 1, CAST(12000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1101, 1048, 7, 1, CAST(12000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1102, 1048, 52, 1, CAST(23121000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1103, 1049, 53, 1, CAST(27441000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1104, 1049, 9, 1, CAST(490000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1105, 1050, 1066, 1, CAST(14866500 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1106, 1051, 51, 1, CAST(20871000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1107, 1052, 52, 3, CAST(23121000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1108, 1053, 50, 2, CAST(19521000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1111, 1054, 50, 1, CAST(19521000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1112, 1054, 51, 2, CAST(20871000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1114, 1055, 55, 1, CAST(12591000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1115, 1056, 52, 1, CAST(23121000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductId], [Quantity], [UnitPrice], [CategoryId]) VALUES (1116, 1056, 7, 3, CAST(12000 AS Decimal(18, 0)), 2)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (50, N'iPhone 11', 1, N'12 MP', N'Chính 12 MP & Phụ 12 MP', N'4 GB', N'Apple A13 Bionic 6 nhân', N'64 GB', 10, N'1 eSIM & 1 Nano SIM, Hỗ trợ 4G', N'	3110 mAh, có sạc nhanh', N'iOS 13', 1, CAST(21690000 AS Decimal(18, 0)), CAST(N'2020-05-25T00:00:00.000' AS DateTime), 1, 12, 1, 100)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (51, N'iPhone 11', 1, N'12 MP', N'Chính 12 MP & Phụ 12 MP', N'	4 GB', N'Apple A13 Bionic 6 nhân', N'128 GB', 9, N'1 eSIM & 1 Nano SIM, Hỗ trợ 4G', N'	3110 mAh, có sạc nhanh', N'iOS 13', 1, CAST(23190000 AS Decimal(18, 0)), CAST(N'2020-05-12T00:00:00.000' AS DateTime), 1, 12, 1, 82)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (52, N'iPhone 11', 1, N'12 MP', N'Chính 12 MP & Phụ 12 MP', N'4 GB', N'Apple A13 Bionic 6 nhân', N'256 GB', 5, N'1 eSIM & 1 Nano SIM, Hỗ trợ 4G', N'3110 mAh, có sạc nhanh', N'iOS 13', 1, CAST(25690000 AS Decimal(18, 0)), CAST(N'2020-04-25T00:00:00.000' AS DateTime), 1, 12, 1, 65)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (53, N'iPhone 11 Pro Max', 1, N'12 MP', N'3 camera 12 MP', N'4 GB', N'Apple A13 Bionic 6 nhân', N'64 GB', 16, N'1 eSIM & 1 Nano SIM, Hỗ trợ 4G', N'3969 mAh, có sạc nhanh', N'iOS 13', 1, CAST(30490000 AS Decimal(18, 0)), CAST(N'2020-04-13T00:00:00.000' AS DateTime), NULL, 12, 1, 16)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (54, N'iPhone 11 Pro Max', 1, N'12 MP', N'3 camera 12 MP', N'4 GB', N'Apple A13 Bionic 6 nhân', N'512 GB', 10, N'1 eSIM & 1 Nano SIM, Hỗ trợ 4G', N'3969 mAh, có sạc nhanh', N'iOS 13', 1, CAST(41990000 AS Decimal(18, 0)), CAST(N'2020-04-01T00:00:00.000' AS DateTime), 1, 12, 1, 25)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (55, N'Samsung Galaxy S10 Lite', 1, N'32 MP', N'Chính 48 MP & Phụ 12 MP, 5 MP', N'8 GB', N'Snapdragon 855 8 nhân', N'128 GB', 9, N'2 SIM Nano (SIM 2 chung khe thẻ nhớ), Hỗ trợ 4G', N'4500 mAh, có sạc nhanh', N'Android 10', 1, CAST(13990000 AS Decimal(18, 0)), CAST(N'2020-04-24T00:00:00.000' AS DateTime), 1, 12, 1, 28)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1066, N'Samsung Galaxy S20', 1, N'10 MP', N'Chính 12 MP & Phụ 64 MP, 12 MP', N'128 GB', N'Exynos 990 8 nhân', N'128 GB', 8, N'	2 SIM Nano (SIM 2 chung khe thẻ nhớ)', N'4000 mAh, có sạc nhanh', N'Android 10', 2, CAST(17490000 AS Decimal(18, 0)), CAST(N'2020-06-15T13:25:30.703' AS DateTime), 1, 24, 2, 7)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1067, N'Vsmart Bee 3', 1, N'5 MP', N'8 MP', N'2 GB', N'MediaTek MT6739WW 4 nhân', N'16GB', 9, N' 2 Nano SIM, Hỗ trợ 4G', N'3000 mAh', N'Android 9', 2, CAST(1590000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:19:40.923' AS DateTime), 1, 12, 4, 2)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1068, N'OPPO A92', 1, N'16 MP', N'Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP', N'8 GB', N'Snapdragon 665 8 nhân', N'128 GB', 10, N' 2 Nano SIM, Hỗ trợ 4G', N'5000 mAh, có sạc nhanh', N'Android 10', NULL, CAST(6990000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:28:01.510' AS DateTime), NULL, 24, 3, 0)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1069, N'OPPO A52', 1, N'16 MP', N'Chính 12 MP & Phụ 8 MP, 2 MP, 2 MP', N'8 GB', N'Snapdragon 665 8 nhân', N'128 GB', 10, N' 2 Nano SIM, Hỗ trợ 4G', N'4000 mAh, có sạc nhanh', N'Android 10', 1, CAST(5990000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:33:47.247' AS DateTime), 1, 24, 3, 3)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1070, N'OPPO Reno3 Pro', 1, N'Chính 44 MP & Phụ 2 MP', N'	Chính 64 MP & Phụ 13 MP, 8 MP, 2 MP', N'8 GB', N'Snapdragon 665 8 nhân', N'256 GB', 10, N' 2 Nano SIM, Hỗ trợ 4G', N'5000 mAh, có sạc nhanh', N'Android 10', 1, CAST(13990000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:39:34.587' AS DateTime), 1, 24, 3, 2)
INSERT [dbo].[Product] ([Id], [Name], [CategoryId], [FrontCamera], [RearCamera], [Ram], [CPU], [InternalMemory], [Quantity], [Sim], [Battery], [OperatingSystem], [PromotionId], [Price], [DateSubmitted], [GiftId], [Guarantee], [ManufacturerId], [NumberOfView]) VALUES (1071, N'OPPO Reno2 F', 1, N'16 MP', N'Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP', N'8 GB', N'Snapdragon 665 8 nhân', N'128 GB', 10, N'2 SIM Nano (SIM 2 chung khe thẻ nhớ)', N'5000 mAh, có sạc nhanh', N'Android 9.0 (Pie)', 1, CAST(7490000 AS Decimal(18, 0)), CAST(N'2020-06-15T22:48:37.117' AS DateTime), 1, 10, 3, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[Product_Image] ON 

INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (13, N'iphone-11-red-2-400x460-400x460.png', N'iphone-11-tim-5-180x125.jpg', N'iphone-11-den-1-1-180x125.jpg', N'iphone-11-vang-1-1-180x125.jpg', N'iphone-11-trang-1-1-180x125.jpg', 50)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (14, N'iphone-11-128gb-green-400x460.png', N'iphone-11-128gb-tim-1-1-180x125.jpg', N'iphone-11-128gb-black-200-180x125.png', N'iphone-11-128gb-white-200-180x125.png', N'iphone-11-128gb-red-200-180x125.png', 51)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (15, N'iphone-11-256gb-black-400x460.png', N'iphone-11-256gb-green-200-180x125.png', N'iphone-11-128gb-black-200-180x125.png', N'iphone-11-128gb-white-200-180x125.png', N'iphone-11-128gb-red-200-180x125.png', 52)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (16, N'iphone-11-pro-max-black-400x460.png', N'iphone-11-pro-max-black-200-180x125.png', N'iphone-11-pro-max-gold-200-180x125.png', N'iphone-11-pro-max-green-200-180x125.png', N'iphone-11-pro-max-white-200-180x125.png', 53)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (17, N'iphone-11-pro-max-512gb-gold-400x460.png', N'iphone-11-pro-max-512gb-white-200-180x125.png', N'iphone-11-pro-max-512gb-green-200-180x125.png', N'iphone-11-pro-max-512gb-gold-200-180x125.png', N'iphone-11-pro-max-512gb-black-200-180x125.png', 54)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (18, N'samsung-galaxy-s10-lite-blue-chi-tiet-400x460.png', N'samsung-galaxy-s10-lite-den-1-180x125.jpg', N'samsung-galaxy-s10-lite-den-11-180x125.jpg', N'samsung-galaxy-s10-lite-den-10-180x125.jpg', N'samsung-galaxy-s10-lite-den-12-180x125.jpg', 55)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1029, N'samsung-galaxy-s20-400x460-hong-400x460.png', N'samsung-galaxy-s20-xam-1-180x125.jpg', N'samsung-galaxy-s20-xam-4-180x125.jpg', N'samsung-galaxy-s20-xam-6-180x125.jpg', N'samsung-galaxy-s20-xam-10-180x125.jpg', 1066)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1030, N'vsmart-bee-3-den-11-180x125.jpg', N'vsmart-bee-3-den-10-180x125.jpg', N'vsmart-bee-3-den-8-180x125.jpg', N'vsmart-bee-3-den-5-180x125.jpg', N'vsmart-bee-3-den-2-180x125.jpg', 1067)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1031, N'oppo-a92-den-10-180x125.jpg', N'oppo-a92-den-9-180x125.jpg', N'oppo-a92-den-7-180x125.jpg', N'oppo-a92-den-6-180x125.jpg', N'oppo-a92-den-5-180x125 (1).jpg', 1068)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1032, N'oppo-a52-den-4-180x120.jpg', N'oppo-a52-den-7-180x120.jpg', N'oppo-a52-den-6-180x120.jpg', N'oppo-a52-den-10-180x120.jpg', N'oppo-a52-den-11-180x120.jpg', 1069)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1033, N'oppo-reno3-pro-den-4-180x125.jpg', N'oppo-reno3-pro-den-6-180x125.jpg', N'oppo-reno3-pro-den-9-180x125.jpg', N'oppo-reno3-pro-den-10-180x125.jpg', N'oppo-reno3-pro-den-11-180x125.jpg', 1070)
INSERT [dbo].[Product_Image] ([Id], [Image1], [Image2], [Image3], [Image4], [Image5], [IdProducts]) VALUES (1034, N'oppo-reno2-f-white-400x460-400x460.png', N'oppo-reno2-f-trang-4-180x125.jpg', N'oppo-reno2-f-xanh-12-180x125.jpg', N'oppo-reno2-f-trang-12-180x125.jpg', N'oppo-reno2-f-trang-11-180x125.jpg', 1071)
SET IDENTITY_INSERT [dbo].[Product_Image] OFF
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([Id], [FromDay], [ToDay], [Ratio], [Content]) VALUES (1, CAST(N'2020-05-15T00:00:00.000' AS DateTime), CAST(N'2020-12-15T00:00:00.000' AS DateTime), 10, N'Khuyến mãi dành riêng cho khách hàng')
INSERT [dbo].[Promotion] ([Id], [FromDay], [ToDay], [Ratio], [Content]) VALUES (2, CAST(N'2020-05-15T00:00:00.000' AS DateTime), CAST(N'2020-12-15T00:00:00.000' AS DateTime), 15, N'Khuyến mãi dành riêng cho khách hàng')
SET IDENTITY_INSERT [dbo].[Promotion] OFF
SET IDENTITY_INSERT [dbo].[Watched] ON 

INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (9, 1, 50, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (10, 1, 52, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (11, 1, 6, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (12, 1, 8, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (13, 1, 50, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (14, 1, 50, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (15, 1, 55, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (16, 1, 54, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (17, 1, 55, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (18, 1, 51, CAST(N'2020-06-11T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (19, 1, 51, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (20, 1, 51, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (21, 1, 52, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (22, 1, 51, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (23, 1, 51, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (24, 1, 54, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (25, 1, 54, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (26, 1, 54, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (27, 1, 54, CAST(N'2020-06-12T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (28, 1, 10, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (29, 1, 52, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (30, 1, 51, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (31, 1, 54, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (32, 1, 54, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (33, 1, 54, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (34, 1, 54, CAST(N'2020-06-13T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (35, 1, 51, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (36, 1, 50, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (37, 1, 52, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (38, 1, 52, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (39, 1, 51, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (40, 1, 50, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (41, 2, 50, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (42, 2, 50, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (43, 2, 1071, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (44, 2, 6, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (45, 2, 8, CAST(N'2020-06-15T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (46, 1, 6, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (47, 1, 6, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (48, 1, 7, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (49, 1, 8, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (50, 1, 55, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (51, 1, 55, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (52, 1, 50, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (53, 1, 50, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (54, 1, 50, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (55, 1, 50, CAST(N'2020-06-16T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (56, 1, 50, CAST(N'2020-06-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (57, 6, 52, CAST(N'2020-06-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (59, 6, 52, CAST(N'2020-06-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (60, 12, 53, CAST(N'2020-06-17T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (61, 13, 53, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (62, 13, 9, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (63, 13, 1066, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (64, 13, 1066, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (65, 13, 1066, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (66, 15, 52, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (67, 15, 52, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (68, 15, 6, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (69, 15, 8, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (70, 16, 1, CAST(N'2020-06-19T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (71, 13, 1, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (72, 13, 6, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (73, 13, 7, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (74, 13, 7, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (75, 17, 55, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (76, 17, 55, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (77, 18, 51, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (78, 18, 51, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Watched] ([Id], [CustomerId], [ProductId], [DateTime], [CategoryId]) VALUES (79, 18, 51, CAST(N'2020-06-21T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Watched] OFF
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK_Accessories_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK_Accessories_Category]
GO
ALTER TABLE [dbo].[Accessories]  WITH CHECK ADD  CONSTRAINT [FK_Accessories_CategoryAccessorie] FOREIGN KEY([IdCategoryAccessories])
REFERENCES [dbo].[CategoryAccessorie] ([Id])
GO
ALTER TABLE [dbo].[Accessories] CHECK CONSTRAINT [FK_Accessories_CategoryAccessorie]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Category]
GO
ALTER TABLE [dbo].[DetailsProducts]  WITH CHECK ADD  CONSTRAINT [FK_DetailsProducts_Product] FOREIGN KEY([Id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[DetailsProducts] CHECK CONSTRAINT [FK_DetailsProducts_Product]
GO
ALTER TABLE [dbo].[FavoriteProduct]  WITH CHECK ADD  CONSTRAINT [FK_FavoriteProduct_Accessories] FOREIGN KEY([AccessoriesId])
REFERENCES [dbo].[Accessories] ([Id])
GO
ALTER TABLE [dbo].[FavoriteProduct] CHECK CONSTRAINT [FK_FavoriteProduct_Accessories]
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
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Admin] FOREIGN KEY([AdminId])
REFERENCES [dbo].[Admin] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Admin]
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
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Gift] FOREIGN KEY([GiftId])
REFERENCES [dbo].[Gift] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Gift]
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
ALTER TABLE [dbo].[Product_Image]  WITH CHECK ADD  CONSTRAINT [FK_Product_Image_Product] FOREIGN KEY([IdProducts])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Product_Image] CHECK CONSTRAINT [FK_Product_Image_Product]
GO
ALTER TABLE [dbo].[Watched]  WITH CHECK ADD  CONSTRAINT [FK_Watched_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Watched] CHECK CONSTRAINT [FK_Watched_Customer]
GO
