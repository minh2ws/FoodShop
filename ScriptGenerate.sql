USE [TheFoodHouse]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategory](
	[idCategory] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__tblCateg__79D361B6C6A08DB3] PRIMARY KEY CLUSTERED 
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCategoryLogs]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCategoryLogs](
	[idEmployee] [nvarchar](20) NOT NULL,
	[idCategory] [nvarchar](50) NOT NULL,
	[status] [nvarchar](20) NULL,
	[modifyDate] [date] NULL,
 CONSTRAINT [PK__tblCateg__55E210BEBF06F284] PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC,
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCustomers]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCustomers](
	[idCustomer] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[phone] [int] NOT NULL,
	[address] [ntext] NULL,
	[point] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmployees]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEmployees](
	[idEmployee] [nvarchar](20) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[role] [nvarchar](20) NOT NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[idOrder] [nvarchar](30) NOT NULL,
	[idCustomer] [int] NULL,
	[idEmployee] [nvarchar](20) NULL,
	[priceSum] [float] NOT NULL,
	[discount] [float] NOT NULL,
	[priceTotal] [float] NOT NULL,
	[orderDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrderDetail]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblOrderDetail](
	[idOrder] [nvarchar](30) NOT NULL,
	[idProduct] [varchar](50) NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK__tblOrder__CD443162314B1D77] PRIMARY KEY CLUSTERED 
(
	[idOrder] ASC,
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProductLogs]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProductLogs](
	[idEmployee] [nvarchar](20) NOT NULL,
	[idProduct] [varchar](50) NOT NULL,
	[status] [nvarchar](20) NULL,
	[modifyDate] [date] NULL,
	[idLog] [varchar](50) NOT NULL,
 CONSTRAINT [PK__tblProdu__2791E13853AEFD29] PRIMARY KEY CLUSTERED 
(
	[idLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 23-Mar-21 7:30:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProducts](
	[idProduct] [varchar](50) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[quantity] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[idCategory] [nvarchar](50) NULL,
 CONSTRAINT [PK__tblProdu__5EEC79D12E207C96] PRIMARY KEY CLUSTERED 
(
	[idProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'1', N'Drinkss')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'2', N'Food')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'29e3c1fe-48dd-4c31-9873-622ae203845d', N'test test test')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'3', N'Toy')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'4', N'Education')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'78dc49c1-0ad9-4e91-8405-d3f8030f3d20', N'test test')
GO
INSERT [dbo].[tblCategory] ([idCategory], [name]) VALUES (N'a135d1e7-60be-43a6-9295-f2dbfab567d4', N'test')
GO
SET IDENTITY_INSERT [dbo].[tblCustomers] ON 

GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (1, N'Ba Dien', 90123456, N'Quan Binh Thanh', 0)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (2, N'Long', 90456123, N'Quan Tan Binh', 100)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (3, N'Phu', 90123789, N'Quan 9', 100)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (4, N'Duc Hoang', 90123456, N'Quan Tan Binh', 0)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (5, N'Ba Dien', 90123645, N'Quan 12', 0)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (6, N'Hoang Long', 90789654, N'quan 10', 0)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (7, N'Tran Trung', 90789625, N'Quan 12', 0)
GO
INSERT [dbo].[tblCustomers] ([idCustomer], [name], [phone], [address], [point]) VALUES (8, N'Han Dau Gau', 90156874, N'Quan 4', 0)
GO
SET IDENTITY_INSERT [dbo].[tblCustomers] OFF
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'1111', N'Newbie', N'12345', N'Warehouse Staff', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'123', N'123', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'123123', N'123123', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'aaaa', N'aaaabc', N'1111', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'aaaaa', N'aaaaa', N'123', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'abc', N'lady', N'222', N'', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'asd', N'asd', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'asdf', N'abcd', N'12345', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'bacinu', N'Le Thi Thuy Bac', N'12345', N'Warehouse Staff', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo', N'Demo', N'123', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo2', N'demo2', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo3', N'demo3', N'123', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo4', N'demo4', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo5', N'demo5', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo6', N'demo6', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo7', N'demo7', N'123', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo8', N'demo8', N'123', N'Warehouse Staff', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'demo9', N'demo9', N'12345', N'Warehouse Staff', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'hanlg', N'Ly Gia Han', N'12345', N'MANAGER', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'hhh', N'hhh', N'1234', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'hjk', N'cds123', N'123', N'Warehouse Staff', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'huyvd', N'Duc Huy', N'123', N'SALESMAN', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'khangnt', N'Nguyen Tran Khang', N'12345', N'MANAGER', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'longpc', N'Pham Can Long', N'12345', N'WAREHOUSE STAFF', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'minhanh', N'minh anh', N'12345', N'WAREHOUSE STAFF', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'minhnt', N'Tran Nhat Minh', N'12345', N'SALESMAN', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'ngan', N'ngan', N'12345', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test', N'test', N'12345', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test2', N'test', N'12345', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test3', N'test', N'12345', N'Salesman', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test4', N'test', N'11111', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test5', N'test', N'123', N'Warehouse Staff', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test6', N'test6', N'123', N'Warehouse Staff', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test7', N'test7', N'123', N'Warehouse Staff', 0)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test8', N'test8', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'test9', N'test9', N'123', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'testwarehouse', N'testttttestwarehouse', N'12345', N'Salesman', 1)
GO
INSERT [dbo].[tblEmployees] ([idEmployee], [name], [password], [role], [status]) VALUES (N'trangnm', N'nguyen minh trang', N'12345', N'Salesman', 1)
GO
INSERT [dbo].[tblOrder] ([idOrder], [idCustomer], [idEmployee], [priceSum], [discount], [priceTotal], [orderDate]) VALUES (N'1', 1, N'huyvd', 1500, 200, 1500, CAST(N'2020-03-15 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'1', N'UPDATE', CAST(N'2021-03-22' AS Date), N'06540ccc-ae69-4300-8c15-fee8c1407814')
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'2', N'INACTIVE', CAST(N'2021-03-23' AS Date), N'25682d9c-60e9-42a6-8df7-512930820a00')
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'1', N'UPDATE', CAST(N'2021-03-22' AS Date), N'256daae2-e004-4743-ad39-e2235f059b5d')
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'1', N'UPDATE', CAST(N'2021-03-23' AS Date), N'618a829c-6638-4f21-b892-5306a9b06b2f')
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'2', N'UPDATE', CAST(N'2021-03-23' AS Date), N'6d5d7b0d-218f-4cd6-9a8b-c2662f0e7e8c')
GO
INSERT [dbo].[tblProductLogs] ([idEmployee], [idProduct], [status], [modifyDate], [idLog]) VALUES (N'longpc', N'1', N'UPDATE', CAST(N'2021-03-23' AS Date), N'cb92f777-7249-45d8-ba82-c431f9479965')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'1', N'Ga Ran', 500, 22, 1, N'2')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'2', N'Ga Chien Gion', 340, 30, 1, N'2')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'3', N'Tra Sua Tran Chau', 400, 15, 1, N'1')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'371bee2e-3596-48f8-8d7d-01c2e230fbea', N'rtbr', 1, 1, 1, N'1')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'6a6a5a52-13cd-4ff1-bbaa-c56e1a03f0a7', N'asas', 1, 2, 1, N'2')
GO
INSERT [dbo].[tblProducts] ([idProduct], [name], [price], [quantity], [status], [idCategory]) VALUES (N'e62b6306-207e-4add-b852-73fc357c007a', N'long', 12, 13, 1, N'1')
GO
ALTER TABLE [dbo].[tblCategoryLogs]  WITH CHECK ADD  CONSTRAINT [FK__tblCatego__idCat__628FA481] FOREIGN KEY([idCategory])
REFERENCES [dbo].[tblCategory] ([idCategory])
GO
ALTER TABLE [dbo].[tblCategoryLogs] CHECK CONSTRAINT [FK__tblCatego__idCat__628FA481]
GO
ALTER TABLE [dbo].[tblCategoryLogs]  WITH CHECK ADD  CONSTRAINT [FK__tblCatego__idEmp__619B8048] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[tblEmployees] ([idEmployee])
GO
ALTER TABLE [dbo].[tblCategoryLogs] CHECK CONSTRAINT [FK__tblCatego__idEmp__619B8048]
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD FOREIGN KEY([idCustomer])
REFERENCES [dbo].[tblCustomers] ([idCustomer])
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD FOREIGN KEY([idEmployee])
REFERENCES [dbo].[tblEmployees] ([idEmployee])
GO
ALTER TABLE [dbo].[tblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__tblOrderD__idOrd__6D0D32F4] FOREIGN KEY([idOrder])
REFERENCES [dbo].[tblOrder] ([idOrder])
GO
ALTER TABLE [dbo].[tblOrderDetail] CHECK CONSTRAINT [FK__tblOrderD__idOrd__6D0D32F4]
GO
ALTER TABLE [dbo].[tblOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__tblOrderD__idPro__6E01572D] FOREIGN KEY([idProduct])
REFERENCES [dbo].[tblProducts] ([idProduct])
GO
ALTER TABLE [dbo].[tblOrderDetail] CHECK CONSTRAINT [FK__tblOrderD__idPro__6E01572D]
GO
ALTER TABLE [dbo].[tblProductLogs]  WITH CHECK ADD  CONSTRAINT [FK__tblProduc__idEmp__656C112C] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[tblEmployees] ([idEmployee])
GO
ALTER TABLE [dbo].[tblProductLogs] CHECK CONSTRAINT [FK__tblProduc__idEmp__656C112C]
GO
ALTER TABLE [dbo].[tblProductLogs]  WITH CHECK ADD  CONSTRAINT [FK__tblProduc__idPro__66603565] FOREIGN KEY([idProduct])
REFERENCES [dbo].[tblProducts] ([idProduct])
GO
ALTER TABLE [dbo].[tblProductLogs] CHECK CONSTRAINT [FK__tblProduc__idPro__66603565]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK__tblProduc__idCat__5AEE82B9] FOREIGN KEY([idCategory])
REFERENCES [dbo].[tblCategory] ([idCategory])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK__tblProduc__idCat__5AEE82B9]
GO

CREATE TRIGGER updateQuantityInTblProduct ON tblOrderDetail AFTER INSERT AS
BEGIN
	UPDATE tblProducts
	SET tblProducts.quantity = tblProducts.quantity - (
		SELECT inserted.quantity
		FROM inserted
		WHERE idProduct = tblProducts.idProduct)
	FROM tblProducts
	JOIN inserted ON tblProducts.idProduct = inserted.idProduct
END