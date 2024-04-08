-- 해당 아티클을 세부적으로 읽어오는 저장 프로시저
CREATE PROCEDURE [dbo].[AnswersDetails]
    @Id Int
As
    --[A] 조회수 카운트 1증가
    Update Answers Set ReadCount = ReadCount + 1 Where Id = @Id
    
    --[B] 모든 항목 조회
    Select * From Answers Where Id = @Id
Go
