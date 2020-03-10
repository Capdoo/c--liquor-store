use Practica2
select * from Productos;

/*Creacion del procedimiento almacenado MostrarProductos*/
create procedure MostrarProductos
as
select * from Productos;
go

/*Creacion del procedimiento almacenado Insertar*/
create procedure InsertarProductos
@nombre nvarchar (100),
@descripcion nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int
as
insert into Productos values (@nombre,@descripcion,@marca,@precio,@stock)
go

/*Creacion del procedimiento almacenado Editar*/
create procedure EditarProductos
@nombre nvarchar (100),
@descripcion nvarchar (100),
@marca nvarchar (100),
@precio float,
@stock int,
@id int
as
update Productos set Nombre=@nombre,Descripcion=@descripcion, Marca=@marca, Precio=@precio, Stock=@stock
where Id=@id
go

/*Pruebas de los procedimientos */
exec MostrarProductos
exec InsertarProductos 'FourLoko','1 litro','Monster',9.00,50
exec EditarProductos 'Pizza','familiar','TelePizza',50,10,11
