-- 해당 아티클을 수정하는 저장 프로시저: 수정이 완료되면 1을 그렇지 않으면 0을 반환 
CREATE PROCEDURE [dbo].[AnswersModify]
    @Name       NVarChar(25), 
    @ModifyIp   NVarChar(15), 
    @Title      NVarChar(150), 
    @Content    NVarChar(Max),
	@Category	NVarChar(50), 

    @Email      NVarChar(100), 
    @Password   NVarChar(255), 
    @Encoding   NVarChar(10), 
    @Homepage   NVarChar(100),
    @FileName	NVarChar(255),
    @FileSize	Int,    
    @Id Int
As
	-- 번호와 암호가 맞으면 수정을 진행 
    Declare @cnt Int
    Select @cnt = Count(*) From Answers Where Id = @Id And Password = @Password

    If @cnt > 0 -- 번호와 암호가 맞는게 있다면...
    Begin
        Update Answers 
        Set 
            Name = @Name,					Email = @Email, 
            Title = @Title,					ModifyIp = @ModifyIp, 
            ModifyDate = GetDate(),			Content = @Content, 
            Encoding = @Encoding,			Homepage = @Homepage, 
            FileName = @FileName,			FileSize = @FileSize
        Where Id = @Id

        Select '1'
    End
    Else
	Begin
        Select '0'
	End
Go
