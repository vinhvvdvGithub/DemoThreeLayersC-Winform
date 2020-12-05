exec SP_InsertUser  N'4' , N'Teo thi buoi' ,'19991013',N'Chim cuc ngan',1
go
use infoUser

exec SP_ListUser

exec SP_InsertUser N'1' , N'Teo thi buoi1' ,'19991013',N'Chim cuc dai',1

exec SP_InsertUser N'2' , N'Teo thi buoi2' ,'19991013',N'Chim cuc ngan',0

exec SP_InsertUser N'3' , N'Teo thi buoi3' ,'19991013',N'Chim cuc rong',1

exec SP_InsertUser N'4' , N'Teo thi buoi4' ,'19991013',N'Chim cuc hep',0

exec SP_DeleteUser N'5' 

drop proc SP_DeleteUser

create proc SP_DeleteUser (@id nvarchar(10) ,@idUser nvarchar(10))
	as 
		delete from TieuSu  where ID=@id AND IDUser =@idUser;
	go


delete from TieuSu where ID=2

insert into TieuSu(ID,IDUser,Info)
values( N'1', N'1',N'Chim cuc dai')
go

insert into TieuSu(ID,IDUser,Info)
values( N'2', N'2',N'Chim cuc ngan')
go

insert into TieuSu(ID,IDUser,Info)
values( N'3', N'3',N'Chim cuc hep')
go
select * from TieuSu
exec SP_DeleteUser N'1',N'1'
delete from Users where ID=1