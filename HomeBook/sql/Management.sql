USE [Management]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTACTS]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CONTACTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](50) NULL,
	[ContactTitle] [varchar](50) NULL,
	[PostalCode] [nchar](10) NULL,
	[Region] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Notes] [nvarchar](max) NULL,
	[Hous_ID] [int] NULL,
	[Status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EXCESS_PAYMENTS]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EXCESS_PAYMENTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NamePayment] [nvarchar](50) NULL,
	[PaymentSumm] [money] NULL,
	[Service_ID] [int] NULL,
	[Contact_ID] [int] NULL,
	[Hous_ID] [int] NULL,
	[Status_ID] [int] NULL,
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_EXCESS_PAYMENTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOUSES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOUSES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Home] [nvarchar](50) NULL,
	[Floor] [nchar](10) NULL,
	[Area] [nchar](10) NULL,
	[Number] [nchar](10) NULL,
	[Percent1] [nchar](10) NULL,
	[People] [nvarchar](10) NULL,
	[Notes] [nvarchar](max) NULL,
	[Phone] [nchar](15) NULL,
	[Email] [nchar](50) NULL,
	[Contact] [nvarchar](50) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_HOME] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NOTES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NOTES](
	[ID] [int] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[File] [float] NULL,
 CONSTRAINT [PK_NOTES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PAYMENTS]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAYMENTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Contact_ID] [int] NULL,
	[Hous_ID] [int] NULL,
	[Income] [money] NULL,
	[Expense] [money] NULL,
	[DatePayment] [datetime] NULL,
	[Note] [nvarchar](max) NULL,
	[TypePayment_ID] [int] NULL,
 CONSTRAINT [PK_PAYMENTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SERVICES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SERVICES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[MeasureID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
	[Quantity] [money] NOT NULL,
	[UserID] [int] NOT NULL,
	[State] [int] NOT NULL,
 CONSTRAINT [PK_ARTICLES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_ARTICLE_NAME] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STATUSES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUSES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_STATUSES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TYPE_PAYMENTS]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPE_PAYMENTS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypePayment] [nchar](10) NULL,
 CONSTRAINT [PK_TYPE_PAYMENTS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TYPES]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TYPES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TYPES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USERS]    Script Date: 30.4.2013 г. 19:57:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USERS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USERS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_User_Name_CODE] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
