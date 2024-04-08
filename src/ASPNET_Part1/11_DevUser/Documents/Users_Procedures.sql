
--[1] 입력 저장 프로시저
Create Proc dbo.WriteUsers
	@UserID VarChar(25),
	@Password VarChar(20)
As
	Insert Into Users Values(@UserID, @Password)
Go

--WriteUsers 'redplus', '1234'
--[2] 출력 저장 프로시저
Create Proc dbo.ListUsers
As
	Select * From Users Order By UID Desc
Go

--ListUsers
--[3] 상세 저장 프로시저
Create Proc dbo.ViewUsers
	@UID Int
As
	Select * From Users Where UID = @UID
Go

--ViewUsers 5
--[4] 수정 저장 프로시저
Create Proc dbo.ModifyUsers
	@UserID VarChar(25),
	@Password VarChar(20),
	@UID Int
As
	Begin Tran
		Update Users
		Set	
			UserID = @UserID,
			[Password] = @Password
		Where UID = @UID
	Commit Tran
Go

--ModifyUsers 'master', '1234', 2
--[5] 삭제 저장 프로시저
Create Proc dbo.DeleteUsers
	@UID Int
As
	Delete Users Where UID = @UID
Go

--DeleteUsers 2
--[6] 검색 저장 프로시저
Create Proc dbo.SearchUsers
	@SearchField VarChar(25),
	@SearchQuery VarChar(25)
As
	Declare @strSql VarChar(255)
	Set @strSql = '
		Select * From Users 
		Where 
			' + @SearchField + ' Like ''%' + @SearchQuery + '%''
	'
	-- Print @strSql
	Exec(@strSql)
Go
--SearchUsers 'UserID', 'admin'
