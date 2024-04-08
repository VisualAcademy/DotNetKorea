-- 게시판 아티클의 검색 결과의 레코드 수 반환
CREATE PROCEDURE [dbo].[SupportsSearchCountAdmin]
    @SearchField NVarChar(25),
    @SearchQuery NVarChar(25)
AS
    Set @SearchQuery = '%' + @SearchQuery + '%'

    Select Count(*)
    From Supports
    Where
    (
        Case @SearchField 
            When 'Name' Then [Name]
            When 'Title' Then [Title]
            When 'Content' Then [Content]
            Else @SearchQuery
        End
    ) 
    Like 
    @SearchQuery
Go
