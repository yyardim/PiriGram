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
	set nocount on;

	select
		c.Id,
		c.Title,
		c.[Description],
		c.DateCreated,
		(
			select
				u.Id,
				u.UserName,
				u.FirstName,
				u.MiddleName,
				u.LastName,
				u.Email,
				u.AvatarUrl,
				u.About
			from
				Users u 
			where 1 = 1
				and c.UserId = u.Id
				and u.UserName = @userName
			for json path,
				WITHOUT_ARRAY_WRAPPER,
				INCLUDE_NULL_VALUES
		) [User],
		(
			select
				p.Id,
				p.Title,
				p.[Subject],
				p.[Sort],
				p.[Latitude],
				p.[Longitude],
				p.[Altitude]
			from
				Photos p
			where 1 = 1
				and c.Id = p.ClipId
			for json path
		) Photos		
	from 
		Clips c
	where 1 = 1
	order by
		c.Id
	for
		json path

end
