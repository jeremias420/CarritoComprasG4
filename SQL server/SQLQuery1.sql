CREATE DATABASE BDCARRITO

go

use CarritoCompraG4

go

Create table Categoria(
cate_id int primary key identity,
cate_descrip varchar(100),
cate_activo bit default 1,
cate_fecha_registro datetime default getdate()
)
go

Create table Marca(
marc_id int primary key identity,
marc_descrip varchar(100),
marc_activo bit default 1,
marc_fecha_registro datetime default getdate()
)
go

Create table Producto(
prod_id int primary key identity,
prod_nombre varchar(500),
prod_descripcion varchar(500),
prod_cate_id int references Marca(marc_id),
prod_marc_id int references Categoria(cate_id),
prod_precio decimal(10,2) default 0,
prod_stock int,
prod_ruta_imagen varchar(100),
prod_nomb_imagen varchar(100),
prod_activo bit default 1,
prod_fecha_registro datetime default getdate()
)
go

Create table Cliente(
clie_id int primary key identity,
clie_nombre varchar(100),
clie_apellido varchar(100),
clie_correo varchar(100),
clie_clave varchar(150),
clie_restablecer bit default 0,
clie_fecha_registro datetime default getdate()
)
go

Create table Carrito(
carr_id int primary key identity,
carr_clie_id int references Cliente(clie_id),
carr_prod_id int references Producto(prod_id),
carr_cantidad int,
)
go

Create table Venta(
vent_id int primary key identity,
vent_clie_id int references CLiente(clie_id),
vent_total_prod int,
vent_monto_total decimal(10,2),
vent_contacto varchar(50),
vent_distrito_id varchar(50),
vent_telefono varchar(50),
vent_direccion varchar(500),
vent_transaccion_id varchar(50),
vent_fecha_venta datetime default getdate()
)
go

Create table Detalle_venta(
deve_id int primary key identity,
deve_vent_id int references Venta(vent_id),
deve_prod_id int references Producto(prod_id),
deve_cantidad int,
deve_total decimal(10,2)
)
go

Create table Usuario(
usua_id int primary key identity,
usua_nombre varchar(100),
usua_apellido varchar(100),
usua_correo varchar(100),
usua_clave varchar(150),
usua_restablecer bit default 1,
usua_activo bit default 1,
usua_fecha_registro datetime default getdate()
)
go

Create table Departamento(
depa_id varchar(2) not null,
depa_descripcion varchar(45) not null,
)
go

Create table Provincia(
prov_id varchar(4) not null,
prov_descripcion varchar(45) not null,
prov_depa_id varchar(2) not null
)
go

Create table Distrito(
dist_id varchar(6) not null,
dist_descripcion varchar(45) not null,
dist_prov_id varchar(4) not null,
dist_depa_id varchar(2) not null
)
go

select * from Usuario
select usua_nombre, usua_apellido, usua_correo, usua_clave, usua_restablecer, usua_activo from Usuario
insert into Usuario(usua_nombre, usua_apellido, usua_correo, usua_clave) values
('Rodrigo','de la Cruz','rodridelacruz45@gmail.com','8k2JfztfIblWYDr'),
('Alberto','Hernandez','alber156@gmail.com','6zg9NxFojPQsdsF'),
('Lucas','Gonzalez','lucas_gonzalez@gmail.com','CqM1ffRIq4jTb9T')

select * from Categoria
insert into Categoria(cate_descrip) values
('Tecnologia'),
('Muebles'),
('Deportes')

insert into Marca(marc_descrip) values
('Motorola'),
('Nike'),
('Valenciana')

select * from Departamento

insert into Departamento(depa_id, depa_descripcion) values
('1','Gualeguaychu'),
('2','Resistencia'),
('3','Formosa')

insert into Provincia(prov_descripcion, prov_depa_id) values
('Entre Rios','1'),
('Chaco','2'),
('Formosa','3')

insert into Distrito( dist_descripcion, dist_depa_id, dist_prov_id) values
('La Palermo', '1', '1'),
('Villa Alta','2','2'),
('San Miguel', '3', '3')


select usua_nombre, usua_apellido, usua_correo, usua_clave, usua_restablecer, usua_activo from Usuario