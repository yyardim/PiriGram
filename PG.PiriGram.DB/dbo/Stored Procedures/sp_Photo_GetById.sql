-- =============================================
-- Author:		Yener Yardim
-- Create date: 6/14/2020
-- Description:	Gets Photos by Id
-- =============================================
CREATE PROCEDURE [dbo].[sp_Photo_GetById]
(
	@Id uniqueidentifier
)
as
begin
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
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
