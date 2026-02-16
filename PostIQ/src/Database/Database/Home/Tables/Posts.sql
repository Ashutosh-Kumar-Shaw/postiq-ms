CREATE TABLE [Home].[Posts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RepoDetailsId] [bigint] NOT NULL,
	[Source] [varchar](50) NULL,
	[RepoUrl] [varchar](100) NULL,
	[Key] [varchar](100) NULL,
	[Value] [varchar](max) NULL,
	[Ordered] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[PostedOn] [datetime] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [bigint] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [bigint] NULL,
 CONSTRAINT [PK_User.Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



