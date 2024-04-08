-- 게시판 아티클에서 데이터 검색 리스트 
CREATE PROCEDURE [dbo].[AnswersSearchList]
    @SearchField NVarChar(25),
    @SearchQuery NVarChar(25),
    @PageNumber Int = 1,
    @PageSize Int = 10
AS
    Select 
        [Id], 
		[Name], 
		[Email], 
		[Title], 
		[Category], 
		[PostDate],
        [ReadCount], [Ref], [Step], [RefOrder], [AnswerNum], 
        [ParentNum], [CommentCount], [FileName], [FileSize], 
        [DownCount]
    From Answers
    Where ( 
        Case @SearchField 
            When 'Name' Then [Name] 
            When 'Title' Then Title 
            When 'Content' Then Content 
            Else 
            @SearchQuery 
        End 
    ) Like '%' + @SearchQuery + '%'
    Order By Ref Desc, RefOrder Asc
    Offset ((@PageNumber - 1) * @PageSize) Rows Fetch Next @PageSize Rows Only;
Go
