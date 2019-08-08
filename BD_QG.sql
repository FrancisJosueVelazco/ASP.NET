use BD_QG
go
create table Persona(
codigo int identity primary key,
nombres varchar(100),
apellidos varchar(100),
edad int,
fecha Datetime
)
go

insert into Persona(nombres,apellidos,edad,fecha)values('Francis','Velazco',21,2019/08/12);
insert into Persona(nombres,apellidos,edad,fecha)values('Steven','Lizarzaburu',26,2019/08/12);
insert into Persona(nombres,apellidos,edad,fecha)values('Giampierre','Torres Chilcano',15,2019/08/12);
go
-- --------------SP LISTAR--------------------
create procedure sp_Obtener
as
Select codigo,nombres,apellidos,edad,fecha from Persona
go

exec sp_Obtener
go

-- --------------SP REGISTRAR--------------------
create procedure sq_Registrar
@nombres varchar(100),
@apellidos varchar(100),
@edad int,
@fecha Datetime
as
declare @idPersona int
declare @mensaje varchar(50)
set @mensaje='Registro Exitoso'
set @idPersona=(select max(codigo) from Persona)
insert into Persona(nombres,apellidos,edad,fecha)values(@nombres,@apellidos,@edad,@fecha)
select @mensaje as Mensaje, @idPersona as ID
go

exec sq_Registrar 'Kevin','KAGAma',22,'2019/07/12'
go

create procedure sp_ActualizarPersona
@codigo int,
@nombres varchar(100),
@apellidos varchar(100),
@edad int,
@fecha Datetime
as
declare @idPersona int
declare @Mensaje varchar(100)
set @Mensaje='Modificacion Exitosa'
set @idPersona=(select codigo from Persona where codigo=@codigo)
update Persona set nombres=@nombres,apellidos=@apellidos,edad=@edad,fecha=@fecha where codigo=@codigo 
select @Mensaje as Mensaje, @idPersona as ID
go

exec sp_ActualizarPersona 8,'AAAAA','BBBBB',11,'2018/07/08'
go


create procedure sp_ListarxId
@codigo int
as
select codigo,nombres,apellidos,edad,fecha from Persona where codigo=@codigo
go

exec sp_ListarxId 1

select * from Persona