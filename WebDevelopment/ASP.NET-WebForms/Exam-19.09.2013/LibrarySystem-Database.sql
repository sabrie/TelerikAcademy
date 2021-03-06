USE [master]
GO
/****** Object:  Database [LibrarySystem]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE DATABASE [LibrarySystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibrarySystem.mdf', FILENAME = N'D:\01.Telerik\06.WebDevelopment\02.ASP.NET-WebForms\Exam-19.09.2013\LibrarySystem\LibrarySystem\App_Data\LibrarySystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LibrarySystem_log.ldf', FILENAME = N'D:\01.Telerik\06.WebDevelopment\02.ASP.NET-WebForms\Exam-19.09.2013\LibrarySystem\LibrarySystem\App_Data\LibrarySystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LibrarySystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibrarySystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibrarySystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibrarySystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibrarySystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibrarySystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibrarySystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibrarySystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibrarySystem] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibrarySystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibrarySystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibrarySystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibrarySystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LibrarySystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibrarySystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibrarySystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibrarySystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibrarySystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibrarySystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibrarySystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LibrarySystem]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetTokens]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetTokens](
	[Id] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
	[ValidUntilUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetTokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Key] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserManagement]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserManagement](
	[UserId] [nvarchar](128) NOT NULL,
	[DisableSignIn] [bit] NOT NULL,
	[LastSignInTimeUtc] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserManagement] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[RoleId] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[UserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserSecrets]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserSecrets](
	[UserName] [nvarchar](128) NOT NULL,
	[Secret] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserSecrets] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Author] [nvarchar](300) NOT NULL,
	[ISBN] [nvarchar](50) NULL,
	[WebSite] [nvarchar](120) NULL,
	[Description] [ntext] NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201309190837354_InitialCreate', N'Microsoft.AspNet.Identity.EntityFramework.DefaultIdentityDbContext', 0x1F8B0800000000000400DD5CCD72A43610BEA72AEF40714A52B583ED5C365B33BBE5F54FCA95B59DF2D87B75C9A019AB1604018D633F5B0E79A4BC42C48F40E807040318EF65D7465277ABFB93D46A3EFCDF3FFF2E3F3D07BEF504E3048578651F2E0E6C0B6237F410DEAEEC1DD9BC7B6F7FFAF8E30FCB332F78B6BEB27EBFA6FDE8489CACEC4742A20F8E93B88F3000C922406E1C26E1862CDC307080173A470707BF3987870EA4226C2ACBB296373B4C5000B35FE8AF272176614476C0BF0C3DE827C573DAB2CEA45A57208049045CB8B22F4BF9C7497405C9E2C283541879599C65FF9DC7B4EFDF61FCCDB68E7D04A8816BE86F6C0B601C1240A8F91FEE12B8267188B7EB883E00FEED4B0469BF0DF013584CEB43D5DD74860747E90C9D6A602F0FD9E5DCE9ECF319A5E6651E58D937A10FF91EB4CF1FF0A5F6803EFA330E231893971BB829C65D78B6E5D4C739E2C072183726554D1D48620A07DBBA04CF5F20DE92470A94A3F7B6758E9EA1C79E14DEBBC388A2870E22F18EFE7AB5F37DF0E0C3B2DD69D499FEDBA095FE68A4555072059ED0360B89A08E02214E5D9AD8D60DF4B31EC9238A72C82C58EB7DE675EB3C0E83F4A76A58D6707F0BE22D24D4EA50D5BA0E77B12B98B474AAC036869B89EA13F2749C1C7665D7544D1F84301553A384D93BBA5E2D707244F4C70C43851A330C515D60ACB5E6BE0078DD94FCA912BB45D3DEC0FD9EF7A9747E13EF555FC22DC2FA8D2A6BBECF91500F75D5A20C37D7AC0A7993499700832D0CE8F1AB35ABEAA2B44D68561A28F6E96A65F306DFB83C54CB545839BD9747E6F73E6B241B481F3F212F75A8C1FECE3A53F1DD9797A06EEA9556B3FDCD1E3483ECE4464B5C0559C50ED01BB6DC9AEF81DDBE99C66427BEA0F7142569EF35DAE20BCCD47F0EA96701EE2CEC0B48482EE996DE7DEE88CB049E0202D3477B24248DC0E9B809AB20A4DBA87BE1E836FC067B6D7D6F253DF80AFCDD08B981AC057977D4B97E772C755AF3273E40419F78F53A70BEAB9D5E50937932D5313A38324D23E1B0DF2E9459A4DC80AA16E5DEC335EF7D7CADA11BC3DE47579EF2F739BC5A2E0B23A1BA98EDB000D0F9FB38494217659117CA17F78A1AC619F6ACC69B716E327FA7A696EF7C82221FB954FDCAFE459ABE4E6879ADA884AA041EDA220CAEF129F42181D6B19B97024F40E2024F0102AABAFE842207C6696512F827742D9018204C649821ECA208F84D660B830C4FC6D4A852BCD8720A2388D3BA69530C4CF46AAB4C4EA94270549B5F960E07A4767C71497113165419721D61F97DAC23C45477EBBA5851E2C162712809ED8D1559FF446091FD69A2589DFE4F881631136E8AAD362DAE07982F821884BA59872188064490C6828960A4F1F19BC05251396A0AAF58466A8BEA80C78FD2100DBCCC0ED7DE10AB7B612264D567FC2600C525C84DB15465CBF578E6F7B58E479922CB9EF42893F54F8414D99F33434B9E6ED331848E80312B4DC10DA0E1606FBF4F1FD20EF059BCDBE483D790D4ABE1550A5FCB872584D40773EF4B2501D54662204427C068307B13A29450A4710662F8835B298AEFD0222FAB68A94CCA4B5D26E66430D4CDAA58D10662F22B9F4E0EBB100A8238E0C9C12E5E65727D94EF3AC575D076C12B8DAFC14A5A4E6D573A4E8C52446D55D16E8613E76BEDEA99EB2E1E26570F61EE0CD02D93575C36044143CD5E2A18AB5DD0984D1BE7D3C21CF4ABCE387B1EC92BEC55A1DA19AA74B02D216C33B42D8F3359433D27CB57EBD413D6A52B26098B6038DBFB5A66AF4851F60835AB6395076BD9B67472DA59F160E968F869CB4B1045086F39BE5AF1C45AE764B59377EBEE2CB02097E1B889820C565A5B6A22614C5781D04A55534BCF519C905340C003488B7A275E2075EB9A4630B57C3621478D1D3DAC77FA73C11930A5EF2D54A74AE561DA6F9BAEFC6CFE503805E461564A25043E88156F874E427F17607D3EA91F9D5775F9F1AA0A718E21C16E296D949C26DDF0EA11308A4FB52B8C13A332E9EB1E27FD509DB759AD91F7B7AEFEA897C212775E8A2E997FD5B88D19B39EF19A6A5D556F4CC428CD707D15D9DB78C15230858C23A619AB73BC40F6E1BDDF423BD2CBAC317878890DB4A43670BC8905ACA3CA0C0A0EBD12438434091826043A2902B98617263499CB54706C6A20969B670399A286300E5414941B238468C68DB3ED1774055E40F1A8930C9E1423C8E29B661378EE0634DE3EA1E0F01801A061AC2E04D2463FEA06AF93C2516D7841DCE38EB214E8E49FCF0A4EAC0A381E9E54441A6340E9060F970FEA24B102282F475D141D3D8252FD41EC526A2FEB1042BD6159DCFDDB3F9A938A017917DB623918F5C24B4260B0483B2CD67FF9273ECA4A70AC034D13D00626243B1056F6D1C1E191F0815D8F8FDD9C24F1FC397EF1869F40EC3E82582669EDF1411B13FA53009E7FE6259973AC24F7A86FD133FD426C30AF3273F6123BF38F990675D614307CD31FB40CE66DC5F72AAF08FB3D433A878F3D06F39EF25B8E074486FB8EC303049201B9F7AFF49DC4601EAFD1CF3B6C3B4A49F2A70E43BB5B73D599E65387596D12B254E9C385BDC2297F9C30D6A13407BEFF60A1ADD3F90770595FCA7ECE0899924D2FD340A664316A5E718D46C3FFAEA8F7FD78840AEA4B5FCA7E6F4AE2A464FAB9B10EF727D0F7A0B1EBF83DFBB2EE670F81C6D73833C48101F9FD35F9EE531F105342C5F8807875901812DA8738200A826C3F22FCEC43AE7B7933435ABA4C3B13C326F3D1B574F4BC4A4D6F7A0F218D6D9EDDE62F27D454475178B5EA250555935E899E53A952A4A5B4372B30135EA43A4A0D455BB31A35C7787F627CB3D6AE147A3D835EAF8771EF4D39F6CD14FBE6F9A889AA0D44FC161E7EB3B692CB3F295D9F5F3015A3D28499AF2424CF8F902F9969C6BC57D3F6E7CCB8EF3E5179E91BF0F25F8F4EDF7D8263C37440DA7CF7C9D5B63781BD310A2F5E7EFF4CF309EE4FBBD2642641DB4A44FA875E31746B9944D9E7026F4296D00816B12EE2DF9F83047834CD388E09DA0097D066172649F6472EB2EAE2CA3E0B1EA07781AF7724DA113A65183CF8B5426D9A1835E9CFC8FF759B97D751F6E74D86984256D806045EE3CF3BE47BA5DDE78A3AB646449A71FD0EE9F33C9634812370FB524ABA0AB1A1A0C27D65A2780B83C8A7C2926BBC064F506F5BBB0FEB1E5B9E22B08D41901432AAF1F4570A3F2F78FEF83F0637A30F9C580000, N'6.0.0-rc1-20726')
INSERT [dbo].[AspNetUserLogins] ([LoginProvider], [ProviderKey], [UserId]) VALUES (N'Local', N'testUser', N'2f9fbec4-2bf6-4ad4-b0cb-3aa72c78159f')
INSERT [dbo].[AspNetUserManagement] ([UserId], [DisableSignIn], [LastSignInTimeUtc]) VALUES (N'2f9fbec4-2bf6-4ad4-b0cb-3aa72c78159f', 0, CAST(0x0000A23F00A4BE4E AS DateTime))
INSERT [dbo].[AspNetUsers] ([Id], [UserName]) VALUES (N'2f9fbec4-2bf6-4ad4-b0cb-3aa72c78159f', N'testUser')
INSERT [dbo].[AspNetUserSecrets] ([UserName], [Secret]) VALUES (N'testUser', N'AAZC7UlsK4s0UAbupaa4eJDcYVnAGJq+FPgnKD2ADElUmnfUKGvlnIyJY0Xr9eZp5Q==')
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (3, N'Fundamentals of Computer Programming with C#', N'Svetlin Nakov & Co.', N'978-954-400-773-7', N'http://www.introprogramming.info/english-intro-csharp-book/', N'The free book "Fundamentals of Computer Programming with C#" aims to provide novice programmers solid foundation of basic knowledge regardless of the programming language. This book covers the fundamentals of programming that have not changed significantly over the last 10 years. Educational content was developed by an authoritative author team led by Svetlin Nakov and covers topics such as variables conditional statements, loops and arrays, and more complex concepts such as data structures (lists, stacks, queues, trees, hash tables, etc.), and recursion recursive algorithms, object-oriented programming and high-quality code. From the book you will learn how to think as programmers and how to solve efficiently programming problems. You will master the fundamental principles of programming and basic data structures and algorithms, without which you can''t become a software engineer.', 1)
INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (4, N'C# Yellow Book', N'Rob Miles', N'B003UN7WHS', N'http://www.csharpcourse.com/', N'The C# Book is used by the Department of Computer Science in the University of Hull as the basis of the First Year programming course.

We give away a free printed copy to students when they arrive in the department, and we also give a copy away to anyone who comes to see us on an Open Day. This is the 2012 version of the book, which now has yellow flowers on the cover. I''ll find something else yellow for next year. Perhaps a duck.

You can also download the Windows Phone Blue Book, which gives you 160 pages of inside info on Windows Phone development.', 1)
INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (7, N'Database Systems: The Complete Book ', N'Hector Garcia-Molina, Jeff Ullman, and Jennifer Widom', N'978-156-592-744-5', NULL, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eros eros, tristique eleifend leo sit amet, mollis scelerisque odio. Sed et malesuada est. Phasellus id nunc in lectus porta ornare sit amet id odio. Vivamus interdum nulla at ipsum egestas posuere. Aenean sem ipsum, dapibus ac mauris vulputate, sollicitudin ornare orci. Nullam faucibus condimentum risus, mollis vehicula leo fringilla pharetra. Pellentesque ac vehicula enim. Etiam eleifend felis sit amet eros ultricies luctus. Aliquam erat volutpat. Sed varius, est scelerisque consectetur dictum, dui libero euismod tortor, eu sagittis mauris neque sed odio.', 2)
INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (10, N'Beginning ASP.NET 4.5 in C# Coding Skills Kit', N'Imar Spaanjaars', NULL, NULL, N'Nulla tristique dolor eu libero posuere, non laoreet risus posuere. Donec auctor sagittis felis, elementum suscipit odio condimentum in. Sed et purus vel ipsum pretium volutpat. Sed hendrerit fringilla ornare. Etiam luctus massa sit amet tellus gravida fermentum. Aliquam sit amet lorem odio. Nulla et arcu nec ipsum porta adipiscing nec ac quam. Nullam quis enim tristique, interdum elit non, pellentesque ligula.', 15)
INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (11, N'System Administration in nowadays', N'Doncho Minkov', N'123456789', N'123456789', N'Aliquam aliquam, est eget aliquet ornare, ipsum nibh tincidunt turpis, vitae accumsan elit leo sit amet metus. Maecenas sollicitudin nec libero in vulputate. Praesent vitae dolor dui. Aenean vitae lorem sit amet mauris eleifend gravida. Duis in libero nulla. Duis odio turpis, venenatis at nibh in, viverra lobortis justo. Fusce commodo magna a posuere consectetur. Vivamus fermentum est nisi, in volutpat est pellentesque sit amet.', 4)
INSERT [dbo].[Books] ([BookId], [Title], [Author], [ISBN], [WebSite], [Description], [CategoryId]) VALUES (13, N'<br />', N'<br />', N'<br />', N'<br />', N'<br />', 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Programming')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Databases')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'System Administratiorn')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (5, N'Data Structures and Algorithms')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (6, N'Rocket Science')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (13, N'My Category')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (15, N'Web Development')
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (16, N'<br />')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserManagement]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 21.9.2013 г. 17:55:56 ч. ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserManagement]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[AspNetUserManagement] CHECK CONSTRAINT [FK_dbo.AspNetUserManagement_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
USE [master]
GO
ALTER DATABASE [LibrarySystem] SET  READ_WRITE 
GO
