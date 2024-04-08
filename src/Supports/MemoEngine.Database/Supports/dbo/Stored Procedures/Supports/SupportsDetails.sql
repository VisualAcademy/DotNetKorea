-- 해당 아티클을 세부적으로 읽어오는 저장 프로시저
CREATE PROCEDURE [dbo].[SupportsDetails]
    @Id Int,
	@UserName NVarChar(100)	-- 사용자 아이디
As
    --[A] 조회수 카운트 1증가
    Update Supports Set ReadCount = ReadCount + 1 Where Id = @Id And UserName = @UserName
    
    --[B] 모든 항목 조회
    Select * From Supports Where Id = @Id And UserName = @UserName 
Go
