--[3] 해당 글을 세부적으로 읽어오는 저장 프로시저 : ViewNote
Create Procedure dbo.ViewNote
	@Id Int
As
	Update Notes Set ReadCount = ReadCount + 1 Where Id = @Id
	
	Select * From Notes Where Id = @Id
Go
