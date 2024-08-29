alter proc sp_RegistrarUsuario(
    @usua_nombre varchar(100),
    @usua_apellido varchar(100),
    @usua_correo varchar(100),
    @usua_clave varchar(100),
    @usua_activo bit,
    @usua_mensaje varchar(500) output,
    @usua_resultado int output
)
as
begin
    set @usua_resultado = 0
    
    if not exists (select * from Usuario where usua_correo = @usua_correo)
    begin
        insert into Usuario(usua_nombre, usua_apellido, usua_correo, usua_clave, usua_activo)
        values (@usua_nombre, @usua_apellido, @usua_correo, @usua_clave, @usua_activo);

        set @usua_resultado = scope_identity();
        set @usua_mensaje = 'Usuario registrado exitosamente';
    end
    else
        set @usua_mensaje = 'El correo del usuario ya existe';
end

alter proc sp_EditarUsuario(
    @usua_id int,
    @usua_nombre varchar(100),
    @usua_apellido varchar(100),
    @usua_correo varchar(100),
    @usua_clave varchar(100) = NULL,  -- Hacer que la clave sea opcional
    @usua_activo bit,
    @usua_mensaje varchar(500) output,
    @usua_resultado int output
)
as
begin
    set @usua_resultado = 0
 
    if not exists (select * from Usuario where usua_correo = @usua_correo and usua_id != @usua_id)
    begin
        update Usuario
        set
            usua_nombre = @usua_nombre,
            usua_apellido = @usua_apellido,
            usua_correo = @usua_correo,
            usua_activo = @usua_activo,
            usua_clave = ISNULL(@usua_clave, usua_clave)  -- Solo actualiza la clave si se proporciona una nueva
        where usua_id = @usua_id;

        set @usua_resultado = 1;
    end
    else
        set @usua_mensaje = 'El correo del usuario ya existe';
end

select * from Categoria

alter proc sp_RegistrarCategoria(
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as
begin
SET @Resultado = 0
IF NOT EXISTS (SELECT * FROM Categoria WHERE cate_descrip = @Descripcion)
begin
insert into Categoria(cate_descrip,cate_activo) values
(@Descripcion,@Activo)

SET @Resultado = SCOPE_IDENTITY()
end
else
set @Mensaje = 'La categoria ya existe'
end


alter proc sp_EditarCategoria(
@IdCategoria int,
@Descripcion varchar(100),
@Activo bit,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
SET @Resultado = 0
IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE cate_descrip = @Descripcion and cate_id != @IdCategoria)
begin
update top (1) CATEGORIA set
cate_descrip = @Descripcion,
cate_activo = @Activo
where cate_id = @IdCategoria

SET @Resultado = 1
end
else
set @Mensaje = 'La categoria ya existe'
end



alter proc sp_EliminarCategoria(
@IdCategoria int,
@Mensaje varchar(500) output,
@Resultado bit output
)
as
begin
SET @Resultado = 0
IF NOT EXISTS (select * from PRODUCTO p
inner join CATEGORIA c on c.cate_id = p.prod_cate_id
where p.prod_cate_id = @IdCategoria)
begin
delete top (1) from CATEGORIA where cate_id = @IdCategoria
SET @Resultado = 1
end
else
set @Mensaje = 'La categoria se encuentra relacionada a un producto'
end 

alter proc sp_RegistrarMarca(
@marc_descrip varchar(100),
@marc_activo bit,
@marc_mensaje varchar(500) output,
@marc_resultado int output
)
as
begin
	set @marc_resultado = 0
	if not exists (select * from Marca where marc_descrip = @marc_descrip)
	begin
		insert into Marca(marc_descrip, marc_activo) values
		(@marc_descrip, @marc_activo)

		set @marc_resultado = SCOPE_IDENTITY()
	end
	else
	 set @marc_mensaje = 'La marca ya existe'
end

alter proc sp_EditarMarca(
@marc_id int,
@marc_descrip varchar(100),
@marc_activo bit,
@marc_mensaje varchar(500) output,
@marc_resultado bit output
)
as
begin
	set @marc_resultado = 0
	if not exists (select * from Marca where marc_descrip = @marc_descrip and marc_id != @marc_id)
	begin

		update top (1) Marca set
		marc_descrip = @marc_descrip,
		marc_activo = @marc_activo
		where marc_id = @marc_id

		set @marc_resultado = 1
	end
	else
	 set @marc_mensaje = 'La marca ya existe'
end

alter proc sp_EliminarMarca(
@marc_id int,
@marc_mensaje varchar(500) output,
@marc_resultado bit output
)
as
begin
	set @marc_resultado = 0
	if not exists (select * from Producto p
	inner join Marca m on m.marc_id = p.prod_marc_id
	where p.prod_marc_id = @marc_id)
	begin
		delete top (1) from Marca where marc_id = @marc_id
		set @marc_resultado = 1
	end
	else
	 set @marc_mensaje = 'La marca se encuentra relacionada a un producto'
end

alter proc sp_RegistrarProducto(
@prod_nombre varchar(100),
@prod_descripcion varchar(100),
@prod_cate_id varchar(100),
@prod_marc_id varchar(100),
@prod_precio decimal(10,2),
@prod_stock int,
@prod_activo bit,
@prod_mensaje varchar(500) output,
@prod_resultado int output
)
as
begin
	set @prod_resultado = 0
	if not exists (select * from Producto where prod_nombre = @prod_nombre)
	begin
		insert into Producto(prod_nombre, prod_descripcion, prod_marc_id, prod_cate_id, prod_precio, prod_stock, prod_activo) values
		(@prod_nombre, @prod_descripcion, @prod_marc_id, @prod_cate_id, @prod_precio, @prod_stock, @prod_activo)

		set @prod_resultado = scope_identity()
	end
	else
	 set @prod_mensaje = 'El producto ya existe'
end

alter proc sp_EditarProducto(
@prod_id int,
@prod_nombre varchar(100),
@prod_descripcion varchar(100),
@prod_cate_id varchar(100),
@prod_marc_id varchar(100),
@prod_precio decimal(10,2),
@prod_stock int,
@prod_activo bit,
@proc_mensaje varchar(500) output,
@proc_resultado int output
)
as
begin
	set @proc_resultado = 0
	if not exists (select * from Producto where prod_nombre = @prod_nombre and prod_id != @prod_id)
	begin

		update Producto set
		prod_nombre = @prod_nombre,
		prod_descripcion = @prod_descripcion,
		prod_marc_id = @prod_marc_id,
		prod_cate_id = @prod_cate_id,
		prod_precio = @prod_precio,
		prod_stock = @prod_stock,
		prod_activo = @prod_activo
		where prod_id = @prod_id

		set @proc_resultado = 1
	end
	else
	 set @proc_mensaje = 'El producto ya existe'
end

alter proc sp_EliminarProducto(
@prod_id int,
@prod_mensaje varchar(500) output,
@prod_resultado bit output
)
as
begin
	set @prod_resultado = 0
	if not exists (select * from Detalle_venta dv
	inner join Producto p on p.prod_id = dv.deve_prod_id
	where p.prod_id = @prod_id)
	begin
		delete top (1) from Producto where prod_id = @prod_id
		set @prod_resultado = 1
	end
	else
	 set @prod_resultado = 'El producto se encuetra relacionado a una venta'
end

select * from Producto

select p.prod_id, p.prod_nombre, p.prod_descripcion,
m.marc_id, m.marc_descrip,c.cate_id, c.cate_descrip,
p.prod_precio, p.prod_stock, p.prod_ruta_imagen, p.prod_nomb_imagen, p.prod_activo
from Producto p
inner join Marca m on m.marc_id = p.prod_marc_id
inner join Categoria c on c.cate_id = p.prod_cate_id