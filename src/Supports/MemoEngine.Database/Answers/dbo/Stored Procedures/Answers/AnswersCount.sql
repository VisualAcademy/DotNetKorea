-- 특정 아티클 테이블의 전체 레코드 수 반환
CREATE PROCEDURE [dbo].[AnswersCount]
AS
	Select Count(*) From Answers
Go
