
Create Table Records
(
	Id Int Identity(1, 1) Not Null Primary Key,		-- �Ϸù�ȣ
	Name VarChar(25) Not Null,						-- �̸�
	PhoneNumber VarChar(20) Null,					-- ��ȭ��ȣ
	BirthDate VarChar(12) Null,						-- ��-��-��
	AuthCode VarChar(20) Null,						-- �����ڵ� 

	Field1 VarChar(100) Null,						-- �߰��ʵ�1
	Field2 VarChar(100) Null,						-- �߰��ʵ�2
	Field3 VarChar(100) Null,						-- �߰��ʵ�3
	Field4 VarChar(100) Null						-- �߰��ʵ�4
)
Go
