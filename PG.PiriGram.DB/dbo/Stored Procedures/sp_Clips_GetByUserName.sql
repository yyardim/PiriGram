-- =============================================
-- Author:		Yener Yardim
-- Create date: 6/21/2020
-- Description:	Gets Cips by UserId
--				exec sp_Clips_GetByUserName @userName = 'yyardim'
-- =============================================

if exists ( select 1 from sys.objects where object_id = object_id(N'sp_Clips_GetByUserName') and type in (N'P', N'PC') )
begin
	drop procedure [dbo].[sp_Clips_GetByUserName]
end
go

create procedure [dbo].[sp_Clips_GetByUserName]
(
	@userName nvarchar(50)
)
as
begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	set nocount on;

	/* temp tables */
	begin
		if OBJECT_ID('tempdb..#UserClips') is not null drop table #UserClips
		create table #UserClips (
			Id				uniqueidentifier,
			Title			nvarchar(100),
			[Description]	nvarchar(2000),
			DateCreated		datetime,
			photoId			uniqueidentifier,
			photoTitle		nvarchar(100),
			[Subject]		nvarchar(100),
			[Sort]			smallint,
			[Latitude]		decimal(9,6),
			[Longitude]		decimal(9,6),
			[Altitude]		decimal(9,6),
			userId			uniqueidentifier,
			UserName		nvarchar(50),
			FirstName		nvarchar(50),
			LastName		nvarchar(50),
			Email			nvarchar(40),
			AvatarUrl		nvarchar(100)
		);
	end

	--	Populate #UserClips List of Clips for the @User fetched by the @UserName
	insert into #UserClips (
			Id,
			Title,
			[Description],
			DateCreated,
			photoId,
			photoTitle,
			[Subject],
			[Sort],
			[Latitude],
			[Longitude],
			[Altitude],
			userId,
			UserName,
			FirstName,
			LastName,
			Email,
			AvatarUrl)
	select
		c.Id,
		c.Title,
		c.[Description],
		c.DateCreated,
		p.Id,
		p.Title,
		p.[Subject],
		p.[Sort],
		p.[Latitude],
		p.[Longitude],
		p.[Altitude],
		u.Id,
		u.UserName,
		u.FirstName,
		u.LastName,
		u.Email,
		u.AvatarUrl
	from 
		Clips c
		inner join Photos p on c.Id = p.ClipId
		inner join Users u on c.UserId = u.Id

	-- Return Results
	select
		Id,
		Title,
		[Description],
		DateCreated,
		photoId as 'Id',
		photoTitle as 'Title',
		[Subject],
		[Sort],
		[Latitude],
		[Longitude],
		[Altitude],
		userId as 'Id',
		UserName,
		FirstName,
		LastName,
		Email,
		AvatarUrl
	from
		#UserClips

	-- Cleanup
	drop table #UserClips

end
