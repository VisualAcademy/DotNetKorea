-- 게시판 아티클 데이터 저장 
CREATE PROCEDURE [dbo].[SupportsWrite]
	-- 5W1H
    @Name       NVarChar(25), 
    @PostIp     NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NVarChar(Max), 
	@Category   NVarChar(10), 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @FileName   NVarChar(255),
    @FileSize   Int,

	@UserName NVarChar(100)	-- 사용자 아이디
AS
    --[A] Ref 열에 일련번호 생성(현재 저장된 Ref 중 가장 큰 값에 1을 더해서 증가) 및 그룹화
    Declare @MaxRef Int
    Select @MaxRef = Max(IsNull(Ref, 0)) From Supports 
 
    If @MaxRef Is Null
        Set @MaxRef = 1 -- 테이블 생성 후 처음만 비교
    Else
        Set @MaxRef = @MaxRef + 1

	--[B] 만들어진 데이터를 저장하기 
    Insert Supports
    (
        Name, Email, Title, PostIp, Content, Category,  
        Password, Encoding, Homepage, Ref, FileName, FileSize, 
		UserName 
    )
    Values
    (
        @Name, @Email, @Title, @PostIp, @Content, @Category, 
        @Password, @Encoding, @Homepage, @MaxRef, @FileName, @FileSize,
		@UserName
    )
Go
