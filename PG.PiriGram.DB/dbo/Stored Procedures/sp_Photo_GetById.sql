-- =============================================
-- Author:		Yener Yardim
-- Create date: 6/14/2020
-- Description:	Gets Photos by Id
--				exec sp_Photo_GetById @Id = '33206379-C183-4E22-9AB9-163EE84B05AC'
-- =============================================

if exists ( select 1 from sys.objects where object_id = object_id(N'sp_Photo_GetById') and type in (N'P', N'PC') )
begin
	drop procedure [dbo].[sp_Photo_GetById]
end
go

create procedure [dbo].[sp_Photo_GetById]
(
	@Id uniqueidentifier
)
as
begin
	set nocount on;

	select
		Id,
		ClipId,
		Title,
		[Subject],
		[Sort],
		Rating,
		Tags,
		Comments,
		DateTaken,
		Dimensions,
		Width,
		Height,
		CameraMaker,
		CameraModel,
		Latitude,
		Longitude,
		Altitude,
		Size,
		DateCreated,
		DateModified
	from
		[dbo].[Photos]
	where 1 = 1
		and Id = @Id
end
