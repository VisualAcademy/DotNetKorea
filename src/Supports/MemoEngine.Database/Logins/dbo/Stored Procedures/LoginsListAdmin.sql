-- 전체 데이터 조회(게시판 리스트)
CREATE PROCEDURE [dbo].[LoginsListAdmin]
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select 
		* 
    From Logins
    Order By LoginId Desc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
Go
