




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
fernandosoto23@hotmaill.com
select * from Usuario
create table Empleado(
	id int not null primary key,
	nombreCompleto varchar(150) not null,
	email varchar(150) unique not null,
	pwd varchar(64)not null,
	telefono varchar(20) not null,
	[admin] char(1) check([admin] = 's' or [admin] = 'n'),
	token char(60) not null unique
);
drop table Usuario
select * from Platillo

select * from Usuario


--codigo
--titulo
--imagen
--precio
--descripcion
--tipo