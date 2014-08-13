autobill
========

## Auto calculate money for PES game

## Environment
    
    1. IDE Visual Studio 2010
    2. SQL 2005
    3. .Net 4
    4. Language C# - Winform
    
## Set up db
    1. database: autobill
    2. sql connection string : setup in ~/App.config
    3. tables: users and bill
        3.1 
            USE [autobill]
            GO
            /****** Object:  Table [dbo].[users]    Script Date: 08/13/2014 20:10:00 ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[users](
                [id] [int] IDENTITY(1,1) NOT NULL,
                [username] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
                [password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
             CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
            (
                [username] ASC
            )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY]

        3.2 
            USE [autobill]
            GO
            /****** Object:  Table [dbo].[bill]    Script Date: 08/13/2014 20:10:46 ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[bill](
                [id] [int] IDENTITY(1,1) NOT NULL,
                [gametype] [int] NOT NULL,
                [hands] [int] NOT NULL,
                [totalprice] [int] NULL,
             CONSTRAINT [PK_bill] PRIMARY KEY CLUSTERED 
            (
                [id] ASC
            )WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY]
    4. prepare data: insert into table users(username, password) values('a', 'a')