﻿--[2] 코멘트 테이블 생성
Create Table dbo.NoteComments
(
	Id			Int Identity(1, 1) Not Null Primary Key,	-- 일련번호
	BoardName	NVarChar(50) Null,							-- 게시판이름(확장) : Notice, Free, Qna
	BoardId		Int Not Null,								-- 해당 게시판의 게시물 번호
	Name		NVarChar(25) Not Null,						-- 작성자
	Opinion		NVarChar(4000) Not Null,					-- 코멘트 내용
	PostDate	SmallDateTime Default(GetDate()),			-- 작성일
	Password	NVarChar(20) Not Null						-- 코멘트 삭제용 암호
)
Go