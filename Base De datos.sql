




create database SekyhRestaurante

create table tipoMenu(
	Codigo int not null primary key identity(1,1),
	Nombre varchar(150) not null
);

create table Platillo(
	Codigo varchar(20) not null primary key,
	titulo varchar(150) not null,
	imagen varchar(150),
	precio numeric(12,2) not null check(precio>0),
	descripcion varchar(2000),
	tipoMenu int references tipoMenu(codigo) on delete no action on update no action 
);
create table Usuario(
	id int not null primary key identity(1,1),
	nombreCompleto varchar(150) not null,
	NombreUsuario varchar(150) unique not null,
	email varchar(150) unique not null,
	pwd varchar(64)not null,
	telefono varchar(20) not null,
	activo char(1) check(activo = 's' or activo = 'n'),
	token varchar(64) unique 
);	


create table Empleado(
	id int not null primary key,
	nombreCompleto varchar(150) not null,
	email varchar(150) unique not null,
	pwd varchar(64)not null,
	telefono varchar(20) not null,
	[admin] char(1) check([admin] = 's' or [admin] = 'n'),
	token char(60) not null unique
);
alter table Usuario add [Admin] char(1) check([Admin] = 's' or [Admin] = 'n')

drop table Usuario
select * from Platillo

select * from Usuario


--codigo
--titulo
--imagen
--precio
--descripcion
--tipo



--Creando Procedimientos de almacenado

ALTER PROCEDURE spAddUser(
	@nombreCompleto varchar(150),
	@NombreUsuario varchar(150),
	@email varchar(150),
	@pwd varchar(64),
	@telefono varchar(20)
)
as
begin
	
	INSERT INTO Usuario(nombreCompleto,nombreUsuario,email,pwd,telefono,activo,[Admin])
	VALUES(@nombreCompleto,@NombreUsuario,@email,@pwd,@telefono,'s','n')
	
end

spAddUser 'Antonio','Concha','Antonio@gmail.com','1234','66237712123'

SELECT * FROM usuario