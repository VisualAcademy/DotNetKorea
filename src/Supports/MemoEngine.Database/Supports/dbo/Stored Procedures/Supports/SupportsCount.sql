-- 특정 아티클 테이블의 전체 레코드 수 반환
CREATE PROCEDURE [dbo].[SupportsCount]
	@UserName NVarChar(100)	-- 사용자 아이디 
AS
	Select Count(*) From Supports Where UserName = @UserName 
Go
