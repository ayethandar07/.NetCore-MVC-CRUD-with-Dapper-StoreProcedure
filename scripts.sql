create database DapperMvcDemo;

use DapperMvcDemo;

create table dbo.Person(
Id int primary key identity,
Name nvarchar(100) not null,
Email nvarchar(100) not null,
[Address] nvarchar(200) not null
);

insert into Person 
values ('Aye', 'aye@gmail.com', 'address1');
insert into Person 
values ('Test', 'test@gmail.com', 'address2');

select * from Person;

create procedure sp_create_person(
@name nvarchar(100),
@email nvarchar(100),
@address nvarchar(200)
)
as
begin
	insert into dbo.Person (Name, Email, [Address])
	values (@name, @email, @address)
end


create procedure sp_update_person(
@id int,
@name nvarchar(100),
@email nvarchar(100),
@address nvarchar(200)
)
as
begin
	update dbo.Person
	 set name = @name, email=@email, [address]=@address
	 where id=@id
end


create procedure sp_get_person(
@id int
)
as
begin
	select * from dbo.Person
	 where id=@id
end


create procedure sp_get_people
as
begin
	select * from dbo.Person
end


create procedure sp_delete_person(
@id int
)
as
begin
	delete from dbo.Person where id=@id
end
