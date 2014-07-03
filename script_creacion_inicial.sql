
USE [GD1C2014]
GO

GO
CREATE SCHEMA [THE_DISCRETABOY] AUTHORIZATION [gd]
GO

SET LANGUAGE 'Español'
SET DATEFIRST 1
GO

--Funcion con la fecha de migracion

CREATE FUNCTION THE_DISCRETABOY.FechaMigracion() --esta funcion almacena la fecha que se utiliza en la migracion como referencia
RETURNS datetime
AS
BEGIN

RETURN CAST('2014-01-01T12:00:00' as datetime)

END
GO

-- Creación de tablas
CREATE TABLE THE_DISCRETABOY.Empresa (
	usuario nvarchar(20) NOT NULL, --FK --PK
	cuit [nvarchar](50) NOT NULL,
	razon_social [nvarchar](255),
	mail [nvarchar](255),
	telefono [numeric](18),
	direccion numeric(18) NOT NULL, --FK
	ciudad [nvarchar](255),
	nombre_de_contacto [nvarchar](255),
	fecha_creacion [datetime]
);

CREATE TABLE THE_DISCRETABOY.Cliente (
	usuario nvarchar(20) NOT NULL UNIQUE, --FK --PK
	doc_numero [numeric](18, 0),
	doc_tipo varchar(3) NOT NULL CHECK(doc_tipo = 'DNI' OR doc_tipo = 'LE' OR doc_tipo = 'LC'), -- DNI (Documento Nacional de Identidad), LE (Libreta de Enrolamiento), LC (Libreta Civica)
	nombre [nvarchar](255),
	apellido [nvarchar](255),
	mail [nvarchar](255),
	telefono [numeric](18),
	direccion numeric(18) NOT NULL, --FK
	fecha_nacimiento [datetime]
);

CREATE TABLE THE_DISCRETABOY.Direccion (
	id numeric(18) NOT NULL Identity(1,1), --PK
	calle [nvarchar](255),
	numero [numeric](18, 0),
	piso [numeric](18, 0),
	depto [nvarchar](50),
	cod_post [nvarchar](50),
	localidad [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Usuario (
	username nvarchar(20) NOT NULL,--PK
	password char(64) NOT NULL,
	pass_definitiva bit NOT NULL,
	intentos tinyint,
	habilitado bit
);

CREATE TABLE THE_DISCRETABOY.Rol_por_user (
	usuario nvarchar(20) NOT NULL, --FK --PK
	rol numeric(18) NOT NULL	--FK --PK
);

CREATE TABLE THE_DISCRETABOY.Rol(
	cod_rol numeric(18) NOT NULL Identity(1,1), --PK
	nombre varchar(255) NOT NULL,
	habilitado bit
);

CREATE TABLE THE_DISCRETABOY.Funcion_por_rol (
	rol numeric(18) NOT NULL, --FK --PK
	funcion numeric(18) NOT NULL --FK --PK
);

CREATE TABLE THE_DISCRETABOY.Funcion (
	cod_funcion numeric(18) NOT NULL Identity(1,1), --PK
	nombre varchar(255) NOT NULL
);

CREATE TABLE THE_DISCRETABOY.Visibilidad_por_user (
	usuario nvarchar(20) NOT NULL, --FK--PK
	Visibilidad numeric(18) NOT NULL,--FK--PK
	cant_ventas [numeric](18, 0)
);

CREATE TABLE THE_DISCRETABOY.Visibilidad (
	codigo numeric(18) NOT NULL, --PK
	porcentaje [numeric](18, 2) NOT NULL,
	descripcion [nvarchar](255),
	precio_por_pub [numeric](18, 2) NOT NULL,
	habilitado bit DEFAULT 1
);

CREATE TABLE THE_DISCRETABOY.Publicacion (
	id [numeric](18, 0) NOT NULL IDENTITY(1,1), --PK
	estado [numeric](18, 0) NOT NULL, --FK
	Visibilidad numeric(18) NOT NULL, --FK
	usuario nvarchar(20) NOT NULL, --FK
	descripcion [nvarchar](255),
	fecha [datetime],
	fecha_venc [datetime],
	hay_preguntas bit DEFAULT 0
);

CREATE TABLE THE_DISCRETABOY.Estado (
	id [numeric](18,0) NOT NULL IDENTITY(1,1), --PK
	NOMBRE NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE THE_DISCRETABOY.Venta_directa (
	id numeric(18) NOT NULL Identity(1,1), --PK
	stock [numeric](18, 0) NOT NULL,
	publicacion [numeric](18,0) NOT NULL,--FK
	precio numeric(18,2)
);

CREATE TABLE THE_DISCRETABOY.Pregunta (
	id numeric(18) NOT NULL Identity(1,1), --PK
	descripcion [nvarchar](255) NOT NULL,
	cliente nvarchar(20) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL --FK
);

CREATE TABLE THE_DISCRETABOY.Respuesta(
	pregunta numeric (18) NOT NULL, --PK --FK
	descripcion [nvarchar](255) NOT NULL,
	fecha datetime	
);

CREATE TABLE THE_DISCRETABOY.compra (
	id numeric(18) NOT NULL Identity(1,1), --PK
	cliente nvarchar(20) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL, --FK
	fecha [datetime],
	cant_comprada [numeric](18, 0)
);

CREATE TABLE THE_DISCRETABOY.Calificacion (
	id [numeric](18, 0) IDENTITY(1,1), --PK
	compra [numeric](18, 0) NOT NULL, --FK
	cant_estrellas [numeric](18, 0),
	descrip [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Oferta (
	id numeric(18) NOT NULL Identity(1,1), ---PK
	cliente nvarchar(20) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL, --FK
	fecha [datetime],
	monto_ofertado [numeric](18, 2)
);

CREATE TABLE THE_DISCRETABOY.Factura (
	numero [numeric](18, 0) NOT NULL IDENTITY(1,1), --PK
	fecha [datetime],
	total numeric(18,2)
);

CREATE TABLE THE_DISCRETABOY.Renglon_factura (
	factura [numeric](18, 0) NOT NULL, --FK ---PK
	nro_renglon numeric(18) NOT NULL identity(1,1), ---PK
	publicacion [numeric](18, 0), ---FK
	comision_visibilidad numeric(18,2),
	comision_por_unidades numeric(18,2),
	forma_de_pago nvarchar(255) NOT NULL
);

CREATE TABLE THE_DISCRETABOY.Rubro_por_publicacion (
	publicacion [numeric](18, 0) NOT NULL, --FK --PK
	rubro [numeric](18, 0) NOT NULL --FK --PK
);

CREATE TABLE THE_DISCRETABOY.Subasta (
	id [numeric](18, 0) NOT NULL Identity(1,1), --PK
	cantidad [numeric](18, 0),
	publicacion [numeric](18, 0),---FK
	precio_inicial [numeric](18, 2)
);

CREATE TABLE THE_DISCRETABOY.Rubro (
	codigo [numeric](18, 0) NOT NULL Identity(1,1), --PK
	descripcion [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Tarjeta_credito (
	numero [nvarchar](255) NOT NULL, --PK
	nombre [nvarchar](255),
	apellido [nvarchar](255),
	factura [numeric](18, 0) NOT NULL, --FK 
	nro_renglon numeric(18) NOT NULL --FK
);

GO
---------Functions
CREATE FUNCTION THE_DISCRETABOY.f_buscar_PK_direc
(
@calle nvarchar(255),
@CP nvarchar(50),
@departamento nvarchar(50),
@nro numeric(18,0),
@piso numeric(18,0)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (SELECT d.id FROM THE_DISCRETABOY.Direccion d
				WHERE d.calle=@calle and
				d.cod_post=@CP and
				d.depto=@departamento and
				d.numero=@nro and
				d.piso=@piso)
END
GO

CREATE FUNCTION THE_DISCRETABOY.f_get_rol_habilitacion
(
@rol numeric (18,0)
)
RETURNS BIT
AS
BEGIN
RETURN 
(
SELECT r.habilitado from THE_DISCRETABOY.Rol r
WHERE r.cod_rol = @rol
)
END

GO

CREATE PROC THE_DISCRETABOY.rol_habilitacion
(
@rol numeric (18,0)
)
AS
DECLARE @hab bit
SELECT @hab = r.habilitado from THE_DISCRETABOY.Rol r
WHERE r.cod_rol = @rol
RETURN @hab
GO

CREATE FUNCTION THE_DISCRETABOY.f_cod_rol
(
@nombre_rol varchar(255)
)
RETURNS numeric (18,0)
AS
BEGIN
RETURN
(
SELECT R.cod_rol
FROM THE_DISCRETABOY.Rol R
WHERE R.nombre = @nombre_rol
)
END

GO

CREATE FUNCTION THE_DISCRETABOY.f_cod_func
(
@nombre_func varchar(255)
)
RETURNS numeric (18,0)
AS
BEGIN
RETURN
(
SELECT F.cod_funcion
FROM THE_DISCRETABOY.Funcion F
WHERE F.nombre = @nombre_func
)
END

GO
-- CHECK Constraints
ALTER TABLE THE_DISCRETABOY.Rol_por_user ADD CONSTRAINT CHK_rol_habilitado
        CHECK(THE_DISCRETABOY.f_get_rol_habilitacion(ROL)=1)
;

ALTER TABLE THE_DISCRETABOY.Usuario ADD CONSTRAINT CHK_menos_de_cuatro_intentos
        CHECK(INTENTOS<4)
;

-- Create Primary Key Constraints
ALTER TABLE THE_DISCRETABOY.Empresa ADD CONSTRAINT PK_Empresa
        PRIMARY KEY CLUSTERED (usuario)
;

ALTER TABLE THE_DISCRETABOY.Cliente ADD CONSTRAINT PK_Cliente
        PRIMARY KEY CLUSTERED (usuario)
;

ALTER TABLE THE_DISCRETABOY.Direccion ADD CONSTRAINT PK_Direccion
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Usuario ADD CONSTRAINT PK_Usuario
        PRIMARY KEY CLUSTERED (username)
;

ALTER TABLE THE_DISCRETABOY.Rol ADD CONSTRAINT PK_Rol
        PRIMARY KEY CLUSTERED (cod_rol)
;

ALTER TABLE THE_DISCRETABOY.Rol_por_user ADD CONSTRAINT PK_Rol_por_user
        PRIMARY KEY CLUSTERED (usuario,rol)
;

ALTER TABLE THE_DISCRETABOY.Funcion ADD CONSTRAINT PK_Funcion
        PRIMARY KEY CLUSTERED (cod_funcion)
;

ALTER TABLE THE_DISCRETABOY.Funcion_por_rol ADD CONSTRAINT PK_Funcion_por_rol
        PRIMARY KEY CLUSTERED (rol,funcion)
;

ALTER TABLE THE_DISCRETABOY.Visibilidad ADD CONSTRAINT PK_Visibilidad
        PRIMARY KEY CLUSTERED (codigo)
;

ALTER TABLE THE_DISCRETABOY.Visibilidad_por_user ADD CONSTRAINT PK_Visibilidad_por_user
        PRIMARY KEY CLUSTERED (usuario,Visibilidad)
;

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT PK_Publicacion
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Estado ADD CONSTRAINT PK_Estado
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Venta_directa ADD CONSTRAINT PK_Venta_directa
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Pregunta ADD CONSTRAINT PK_Pregunta
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Respuesta ADD CONSTRAINT PK_Respuesta
        PRIMARY KEY CLUSTERED (pregunta)
;

ALTER TABLE THE_DISCRETABOY.compra ADD CONSTRAINT PK_compra
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Oferta ADD CONSTRAINT PK_Oferta
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Calificacion ADD CONSTRAINT PK_Calificacion
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Factura ADD CONSTRAINT PK_Factura
        PRIMARY KEY CLUSTERED (numero)
;

ALTER TABLE THE_DISCRETABOY.Renglon_factura ADD CONSTRAINT PK_Renglon_factura
        PRIMARY KEY CLUSTERED (nro_renglon,factura)
;

ALTER TABLE THE_DISCRETABOY.Subasta ADD CONSTRAINT PK_Subasta
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Rubro ADD CONSTRAINT PK_Rubro
        PRIMARY KEY CLUSTERED (codigo)
;

ALTER TABLE THE_DISCRETABOY.Rubro_por_publicacion ADD CONSTRAINT PK_Rubro_por_publicacion
        PRIMARY KEY CLUSTERED (rubro,publicacion)
;

-- Create Foreign Key Constraints

ALTER TABLE THE_DISCRETABOY.Empresa ADD CONSTRAINT FK_Empresa_user
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Empresa ADD CONSTRAINT FK_Empresa_direccion
        FOREIGN KEY (direccion) REFERENCES THE_DISCRETABOY.Direccion (id)
;

ALTER TABLE THE_DISCRETABOY.Cliente ADD CONSTRAINT FK_Cliente_user
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Cliente ADD CONSTRAINT FK_Cliente_direccion
        FOREIGN KEY (direccion) REFERENCES THE_DISCRETABOY.Direccion (id)
;

ALTER TABLE THE_DISCRETABOY.Rol_por_user ADD CONSTRAINT FK_Rol_por_user_usuario
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Rol_por_user ADD CONSTRAINT FK_Rol_por_user_rol
        FOREIGN KEY (rol) REFERENCES THE_DISCRETABOY.Rol (cod_rol)
;

ALTER TABLE THE_DISCRETABOY.Funcion_por_rol ADD CONSTRAINT FK_Funcion_por_rol_rol
        FOREIGN KEY (rol) REFERENCES THE_DISCRETABOY.Rol (cod_rol)
;

ALTER TABLE THE_DISCRETABOY.Funcion_por_rol ADD CONSTRAINT FK_Funcion_por_rol_funcion
        FOREIGN KEY (funcion) REFERENCES THE_DISCRETABOY.Funcion (cod_funcion)
;

ALTER TABLE THE_DISCRETABOY.Visibilidad_por_user ADD CONSTRAINT FK_Visibilidad_por_user_vISib
        FOREIGN KEY (Visibilidad) REFERENCES THE_DISCRETABOY.Visibilidad (codigo)
;

ALTER TABLE THE_DISCRETABOY.Visibilidad_por_user ADD CONSTRAINT FK_Visibilidad_por_user_usuario
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT FK_Public_visibilidad_por_user
        FOREIGN KEY (usuario,Visibilidad) REFERENCES THE_DISCRETABOY.Visibilidad_por_user (usuario,Visibilidad)
;

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT FK_Public_estado
        FOREIGN KEY (estado) REFERENCES THE_DISCRETABOY.Estado (id)
;

ALTER TABLE THE_DISCRETABOY.Venta_directa ADD CONSTRAINT FK_Venta_directa
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Oferta with check ADD CONSTRAINT FK_Oferta_cli
        FOREIGN KEY (cliente) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Oferta with check ADD CONSTRAINT FK_Oferta_pub
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.compra with check ADD CONSTRAINT FK_Compra_inmed_cli
        FOREIGN KEY (cliente) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.compra with check ADD CONSTRAINT FK_Compra_inmed_pub
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Calificacion with check ADD CONSTRAINT FK_Calif_compra
        FOREIGN KEY (compra) REFERENCES THE_DISCRETABOY.compra (id)
;

ALTER TABLE THE_DISCRETABOY.Pregunta with check ADD CONSTRAINT FK_Pregunta_cli
        FOREIGN KEY (cliente) REFERENCES THE_DISCRETABOY.Usuario (username)
;

ALTER TABLE THE_DISCRETABOY.Pregunta with check ADD CONSTRAINT FK_Pregunta_pub
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Respuesta ADD CONSTRAINT FK_Respuesta_pregunta
		FOREIGN KEY (pregunta) REFERENCES THE_DISCRETABOY.Pregunta (id)
;
ALTER TABLE THE_DISCRETABOY.Renglon_factura ADD CONSTRAINT FK_Renglon_factura_fact
        FOREIGN KEY (factura) REFERENCES THE_DISCRETABOY.Factura (numero)
;

ALTER TABLE THE_DISCRETABOY.Renglon_factura ADD CONSTRAINT FK_Renglon_factura_pub
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Rubro_por_publicacion ADD CONSTRAINT FK_Rubro_por_publicacion_public
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Rubro_por_publicacion ADD CONSTRAINT FK_Rubro_por_publicacion_rubro
        FOREIGN KEY (rubro) REFERENCES THE_DISCRETABOY.Rubro (codigo)
;

ALTER TABLE THE_DISCRETABOY.Subasta ADD CONSTRAINT FK_subasta_public
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Tarjeta_credito ADD CONSTRAINT FK_tarj_cred_renglon_fact
        FOREIGN KEY (nro_renglon,factura) REFERENCES THE_DISCRETABOY.Renglon_factura (nro_renglon,factura)
;

GO

--Create other constraints
---------Triggers
CREATE TRIGGER THE_DISCRETABOY.quitar_rol_inhab_a_users
ON THE_DISCRETABOY.ROL 
FOR UPDATE --Trigger para quitar un rol que haya quedado inhabilitado
AS
IF UPDATE(habilitado)
BEGIN
DELETE FROM THE_DISCRETABOY.Rol_por_user
WHERE
rol=(select cod_rol from DELETED)
END

GO
---------Procedures

--ALTA FUNCION POR ROL
CREATE PROCEDURE THE_DISCRETABOY.alta_funcion_por_rol( 
@funcion numeric(18,0),
@rol numeric(18,0)
)
AS
INSERT INTO THE_DISCRETABOY.Funcion_por_rol
(
rol,
funcion
)
VALUES (
@funcion,
@rol
)

GO

--ALTA FUNCION POR ROL CON LOS NOMBRES
CREATE PROCEDURE THE_DISCRETABOY.alta_funcion_por_rol_nombres
( 
@funcion varchar(255),
@rol varchar(255)
)
AS
BEGIN
DECLARE @CODROL NUMERIC(18,0), @CODFUNCION NUMERIC(18,0)
SET @CODROL = THE_DISCRETABOY.f_cod_rol(@rol)
SET @CODFUNCION = THE_DISCRETABOY.f_cod_func(@funcion)
INSERT INTO THE_DISCRETABOY.Funcion_por_rol
(
rol,
funcion
)
VALUES (
@CODROL,
@CODFUNCION
)
END

GO

--ALTA ROL
CREATE PROCEDURE THE_DISCRETABOY.alta_rol
(
@nombre varchar(255),
@habilitado bit
)
AS
INSERT INTO THE_DISCRETABOY.Rol
(
nombre,
habilitado
)
VALUES
(
@nombre,
@habilitado
)

GO

--BAJA FUNCION  POR ROL
CREATE PROCEDURE THE_DISCRETABOY.baja_funcion_por_rol
(
@rol numeric(18,0),
@funcion numeric(18,0)
)
AS
DELETE FROM THE_DISCRETABOY.Funcion_por_rol
WHERE
rol = @rol AND
funcion = @funcion

GO
--ALTA ROL POR USER
CREATE PROCEDURE THE_DISCRETABOY.alta_rol_por_user
(
@rol numeric(18,0),
@usuario nvarchar(20)
)
AS
INSERT INTO THE_DISCRETABOY.Rol_por_user
(
rol,
usuario
)
VALUES
(
@rol,
@usuario
)

GO
--BAJA ROL POR USER
CREATE PROCEDURE THE_DISCRETABOY.baja_rol_por_user
(
@rol numeric(18,0),
@usuario nvarchar(20)
)
AS
DELETE FROM THE_DISCRETABOY.Rol_por_user
WHERE
rol=@rol AND
usuario=@usuario

GO

--INHABILITACION ROL
CREATE PROCEDURE THE_DISCRETABOY.inhabilitar_rol
(
@rol numeric(18,0)
)
AS
UPDATE THE_DISCRETABOY.Rol
SET habilitado = 0
WHERE
cod_rol=@rol

GO

--HABILITACION ROL
CREATE PROCEDURE THE_DISCRETABOY.habilitar_rol
(
@rol numeric(18,0)
)
AS
UPDATE THE_DISCRETABOY.Rol
SET habilitado = 1
WHERE
cod_rol=@rol

GO

--MODIFICACION NOMBRE DE ROL
CREATE PROCEDURE THE_DISCRETABOY.modificar_rol_nombre
(
@rol numeric(18,0),
@nuevo_nombre varchar(255)
)
AS
UPDATE THE_DISCRETABOY.Rol
SET nombre = @nuevo_nombre
WHERE cod_rol = @rol

GO

--ALTA FUNCION
CREATE PROCEDURE THE_DISCRETABOY.alta_funcion
(@nombre varchar(255))
AS
INSERT INTO THE_DISCRETABOY.Funcion
(nombre)
VALUES
(@nombre)

GO

--CONSULTAR ID DEL ROL
CREATE PROCEDURE THE_DISCRETABOY.get_cod_rol
(
@nombre varchar(255)
)
AS
DECLARE @codigo numeric(18,0)
SELECT
@codigo = R.cod_rol
FROM THE_DISCRETABOY.Rol R
WHERE
R.nombre=@nombre
RETURN @codigo

GO

--TRAER TODAS LAS FUNCIONES
CREATE PROC THE_DISCRETABOY.get_funciones
AS
BEGIN
SELECT cod_funcion AS 'cod_funcion', nombre AS 'nombre'
FROM THE_DISCRETABOY.Funcion
END

GO


CREATE PROC THE_DISCRETABOY.get_roles
AS
BEGIN
SELECT R.cod_rol 'cod_rol', R.nombre 'nombre',
(CASE WHEN R.habilitado=1 THEN 'HABILITADO'
ELSE 'INHABILITADO' END) 'Estado'
FROM THE_DISCRETABOY.Rol R
END

GO

CREATE PROC THE_DISCRETABOY.get_roles_de
(@user nvarchar(20))
AS
BEGIN
SELECT R.cod_rol 'cod_rol', R.nombre 'nombre'
FROM THE_DISCRETABOY.Rol r,THE_DISCRETABOY.Rol_por_user ru
where
r.cod_rol = ru.rol and
ru.usuario = @user
END

GO
--TRAER VISIBILIDADES
CREATE PROC THE_DISCRETABOY.get_visibilidades
AS
BEGIN
SELECT 
V.codigo 'CÓDIGO', 
V.descripcion 'DESCRIPCIÓN',
V.porcentaje 'PORCENTAJE DE LA VENTA',
V.precio_por_pub 'PRECIO POR PUBLICAR',
(CASE WHEN V.habilitado=1 THEN 'HABILITADO' ELSE 'INHABILITADO' END) 'ESTADO'
FROM THE_DISCRETABOY.Visibilidad V 
END

GO

CREATE PROC THE_DISCRETABOY.get_nombre_rol
(@cod numeric (18,0))
AS
BEGIN
SELECT
R.nombre
FROM
THE_DISCRETABOY.Rol R
WHERE
R.cod_rol = @cod
END

GO

CREATE PROC THE_DISCRETABOY.get_funciones_de
(@rol numeric (18,0))
AS
BEGIN
SELECT
FR.funcion
FROM
THE_DISCRETABOY.Funcion_por_rol FR
WHERE FR.rol = @rol
END

GO

CREATE PROC THE_DISCRETABOY.get_funciones_no_de
(@rol numeric (18,0))
AS
BEGIN
SELECT
F.cod_funcion
FROM
THE_DISCRETABOY.Funcion F
WHERE
F.cod_funcion <> ALL (SELECT Funcion from THE_DISCRETABOY.Funcion_por_rol
						WHERE rol = @rol)
END

GO

CREATE PROC THE_DISCRETABOY.get_nombre_funcion
(@cod numeric (18,0))
AS
BEGIN 
SELECT
F.nombre
FROM
THE_DISCRETABOY.Funcion F
WHERE
F.cod_funcion = @cod
END

GO

CREATE PROC THE_DISCRETABOY.existe_nombre_rol
(@nom nvarchar(255))
AS
BEGIN
DECLARE @EXISTE numeric(18,0)
SELECT
@existe = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Rol R
WHERE
@nom = R.nombre
RETURN @existe
END

GO

CREATE PROC THE_DISCRETABOY.existe_username
(@username nvarchar(255))
AS
BEGIN
DECLARE @EXISTE NUMERIC (18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Usuario U
WHERE
@username = U.username
RETURN @EXISTE
END

GO

CREATE PROC THE_DISCRETABOY.tiene_formato_mail
(@cadena nvarchar (255))
AS
BEGIN
IF @cadena LIKE '%@%.%'
	BEGIN
		RETURN 1
	END
	ELSE
		RETURN 0
END

GO

--CORROBORA QUE LA CONTRASEÑA INGRESADA SEA CORRECTA
CREATE PROC THE_DISCRETABOY.corroborar_pass
(
@username nvarchar(255),
@pass char(64)
)
AS
BEGIN
DECLARE @EXITO BIT
SELECT
@EXITO = (CASE WHEN U.password = @pass THEN 1 ELSE 0 END)
FROM
THE_DISCRETABOY.Usuario U
WHERE
U.USERNAME = @username
RETURN @EXITO
END

GO

--INCREMENTAR CANTIDAD DE INTENTOS DE INGRESO DEL USUARIO
CREATE PROC THE_DISCRETABOY.increm_intent_fallidos_usuario
(@usuario nvarchar(20))
AS
UPDATE THE_DISCRETABOY.Usuario
SET intentos += 1
WHERE username=@usuario

GO

--RETORNAR LA CANTIDAD DE INTENTOS
CREATE PROC THE_DISCRETABOY.intentos_de
(@usuario nvarchar(20))
AS
DECLARE @intentos tinyint
SELECT TOP 1
@intentos = U.intentos
FROM
THE_DISCRETABOY.Usuario U
WHERE U.username = @usuario
RETURN @intentos

GO

--RESETEAR CONTADOR DE INTENTOS FALLIDOS
CREATE PROC THE_DISCRETABOY.reset_intentos
(@usuario nvarchar(20))
AS
UPDATE THE_DISCRETABOY.Usuario
SET intentos=0
WHERE username=@usuario

GO

--PEDIR LISTADO DE NOMBRES DE FUNCIONES
CREATE PROC THE_DISCRETABOY.get_funciones_nombres
AS
SELECT
F.nombre
FROM
THE_DISCRETABOY.Funcion F

GO

--BUSCAR EN ROLES
CREATE PROC THE_DISCRETABOY.get_roles_buscando
(@nombre_a_buscar nvarchar(255))
AS
BEGIN
SELECT R.cod_rol 'cod_rol', R.nombre 'nombre'
FROM THE_DISCRETABOY.Rol R
WHERE R.nombre LIKE '%'+@nombre_a_buscar+'%'
END

GO
--BUSCAR PUBLICACIONES
CREATE PROC THE_DISCRETABOY.get_publicaciones_buscando
(@descrip nvarchar(255))
AS
BEGIN
SELECT 
P.id 'ID',
P.descripcion 'DESCRIPCION',
(
SELECT TOP 1
E.NOMBRE
FROM
THE_DISCRETABOY.Estado E
WHERE
E.id = P.estado
)'ESTADO',
P.fecha 'CREACION',
P.fecha_venc 'VENCIMIENTO',
'Compra inmediata' 'TIPO',
V.stock 'STOCK'
FROM THE_DISCRETABOY.Publicacion P, THE_DISCRETABOY.Venta_directa V, THE_DISCRETABOY.Visibilidad VI
WHERE 
P.descripcion LIKE '%'+@descrip+'%' AND 
V.publicacion = P.id AND 
VI.codigo = P.Visibilidad

UNION

SELECT 
P.id 'ID',
P.descripcion 'DESCRIPCION',
(
SELECT TOP 1
E.NOMBRE
FROM
THE_DISCRETABOY.Estado E
WHERE
E.id = P.estado
)'ESTADO',
P.fecha 'CREACION',
P.fecha_venc 'VENCIMIENTO',
'Subasta' 'TIPO',
S.cantidad 'STOCK'
FROM THE_DISCRETABOY.Publicacion P, THE_DISCRETABOY.Subasta S, THE_DISCRETABOY.Visibilidad VI
WHERE 
P.descripcion LIKE '%'+@descrip+'%' AND 
S.publicacion = P.id AND 
VI.codigo = P.Visibilidad

END

GO
--BUSCAR PUBLICACION POR VENTA DIRECTA
CREATE PROC THE_DISCRETABOY.get_publicacion_de_venta_directa
(
@IDDELTIPO NUMERIC(18,0)
)
AS
SELECT TOP 1
V.publicacion
FROM
THE_DISCRETABOY.Venta_directa V
WHERE
V.id = @IDDELTIPO

GO
--BUSCAR PUBLICACION POR SUBASTA
CREATE PROC THE_DISCRETABOY.get_publicacion_de_subasta
(
@IDDELTIPO NUMERIC(18,0)
)
AS
SELECT TOP 1
S.publicacion
FROM
THE_DISCRETABOY.Subasta S
WHERE
S.id = @IDDELTIPO

GO
--BUSCAR CODIGO DE ULTIMA PUBLICACION
CREATE PROC THE_DISCRETABOY.ultima_publicacion
AS
BEGIN
DECLARE @ULTIMAPUBLICACION NUMERIC(18,0)
SELECT
@ULTIMAPUBLICACION = MAX(P.ID)
FROM
THE_DISCRETABOY.Publicacion P
RETURN @ULTIMAPUBLICACION
END

GO
--BUSCAR LAS DE UN USER EN PARTICULAR
CREATE PROC THE_DISCRETABOY.get_publics_de_user_buscando
(@descrip nvarchar(255),@USUARIO NVARCHAR(20))
AS
BEGIN
SELECT 
P.id 'ID',
P.descripcion 'DESCRIPCION',
(
SELECT TOP 1
E.NOMBRE
FROM
THE_DISCRETABOY.Estado E
WHERE
E.id = P.estado
)'ESTADO',
P.fecha 'CREACION',
P.fecha_venc 'VENCIMIENTO',
'Compra inmediata' 'TIPO',
V.stock 'STOCK'
FROM THE_DISCRETABOY.Publicacion P, THE_DISCRETABOY.Venta_directa V, THE_DISCRETABOY.Visibilidad VI, THE_DISCRETABOY.Visibilidad_por_user VU
WHERE 
P.descripcion LIKE '%'+@descrip+'%' AND 
P.USUARIO = @USUARIO AND 
V.publicacion = P.id

UNION

SELECT 
P.id 'ID',
P.descripcion 'DESCRIPCION',
(
SELECT TOP 1
E.NOMBRE
FROM
THE_DISCRETABOY.Estado E
WHERE
E.id = P.estado
)'ESTADO',
P.fecha 'CREACION',
P.fecha_venc 'VENCIMIENTO',
'Subasta' 'TIPO',
S.cantidad 'STOCK'
FROM THE_DISCRETABOY.Publicacion P, THE_DISCRETABOY.Subasta S
WHERE 
P.descripcion LIKE '%'+@descrip+'%' AND 
P.USUARIO = @USUARIO AND 
S.publicacion = P.id
END

GO
--GET CODIGO DE FUNCION
CREATE PROC THE_DISCRETABOY.get_cod_funcion
(@nombre NVARCHAR(255))
AS
BEGIN
SELECT TOP 1
F.cod_funcion
FROM
THE_DISCRETABOY.Funcion F
WHERE
F.nombre = @nombre
END

GO

--GET ROLES POR HABILITACION
CREATE PROC THE_DISCRETABOY.get_roles_por_habilitacion
(@ESTADO bit)
AS
BEGIN
SELECT
R.nombre,
R.cod_rol
FROM
THE_DISCRETABOY.Rol R
WHERE
R.habilitado = @ESTADO
END

GO

--GET COD NOMBRE ROLES
CREATE PROC THE_DISCRETABOY.get_cod_nombre_roles
AS
BEGIN
SELECT
R.cod_rol as 'cod_rol',
R.nombre as 'nombre'
FROM
THE_DISCRETABOY.Rol R
END

GO

--GET HABILITACION USER
CREATE PROC THE_DISCRETABOY.habilitado_user
(@usuario nvarchar(20))
AS
BEGIN
DECLARE @estado bit
SELECT TOP 1
@estado = U.habilitado
FROM
THE_DISCRETABOY.Usuario U
WHERE U.username = @usuario
RETURN @estado
END

GO

--HABILITAR USER
CREATE PROC THE_DISCRETABOY.habilitar_user
(@usuario nvarchar(20))
AS
UPDATE THE_DISCRETABOY.Usuario
SET habilitado = 1
WHERE username=@usuario

GO

--INHABILITAR USER
CREATE PROC THE_DISCRETABOY.inhabilitar_user
(@usuario nvarchar(20))
AS
UPDATE THE_DISCRETABOY.Usuario
SET habilitado = 0
WHERE username=@usuario

GO

--ALTA USUARIO
CREATE PROC THE_DISCRETABOY.alta_usuario
(
@username nvarchar(20),
@password char(64),
@pass_definitiva bit
)
AS
INSERT INTO THE_DISCRETABOY.Usuario
(
username,
password,
pass_definitiva,
intentos,
habilitado
)
VALUES
(
@username,
@password,
@pass_definitiva,
0,
1
)

GO
--ALTA CLIENTE
CREATE PROC THE_DISCRETABOY.alta_cliente
(
@user nvarchar(20),
@doc_numero numeric (18,0),
@doc_tipo varchar(3),
@Nombre nvarchar(255),
@apellido nvarchar(255),
@mail nvarchar(255),
@telefono numeric(18,0),
@direccion numeric(18,0),
@fecha_nac datetime
)
AS
INSERT INTO THE_DISCRETABOY.Cliente
(
usuario,
doc_numero,
doc_tipo,
nombre,
apellido,
mail,
telefono,
direccion,
fecha_nacimiento
)
VALUES
(
@user,
@doc_numero,
@doc_tipo,
@Nombre,
@apellido,
@mail,
@telefono,
@direccion,
@fecha_nac
)

GO

--ALTA DIRECCION
CREATE PROC THE_DISCRETABOY.alta_direccion
(
@calle nvarchar(255),
@numero numeric(18,0),
@piso numeric(18,0),
@depto nvarchar(50),
@CP nvarchar(50),
@localidad nvarchar(255)
)
AS
INSERT INTO THE_DISCRETABOY.Direccion
(
calle,
numero,
piso,
depto,
cod_post,
localidad
)
VALUES
(
@calle,
@numero,
@piso,
@depto,
@CP,
@localidad
)

GO

--RETORNAR PK DE DIRECCION
CREATE PROC THE_DISCRETABOY.get_id_direccion
(
@calle nvarchar(255),
@CP nvarchar(50),
@departamento nvarchar(50),
@nro numeric(18,0),
@piso numeric(18,0),
@localidad nvarchar(255)
)
AS
BEGIN
DECLARE @ID NUMERIC(18,0) 
SELECT TOP 1 
@ID = d.id 
FROM THE_DISCRETABOY.Direccion d
WHERE
(d.calle=@calle and
d.cod_post=@CP and
d.depto=@departamento and
d.numero=@nro and
d.piso=@piso and
d.localidad = @localidad)
RETURN @ID
END

GO

--ALTA EMPRESA
CREATE PROC THE_DISCRETABOY.alta_empresa
(
@usuario nvarchar(20),
@cuit nvarchar(50),
@razon_social nvarchar(255),
@mail nvarchar(255),
@telefono numeric(18,0),
@direccion numeric (18,0),
@ciudad nvarchar (255),
@nombre_de_contacto nvarchar(255),
@fecha_creacion datetime
)
AS
INSERT INTO THE_DISCRETABOY.Empresa
(
usuario,
cuit,
razon_social,
mail,
telefono,
direccion,
ciudad,
nombre_de_contacto,
fecha_creacion
)
VALUES
(
@usuario ,
@cuit,
@razon_social,
@mail,
@telefono,
@direccion,
@ciudad,
@nombre_de_contacto,
@fecha_creacion
)

GO

CREATE PROC THE_DISCRETABOY.get_hash_password
(@USER NVARCHAR(20))
AS
SELECT TOP 1
U.password
FROM
THE_DISCRETABOY.Usuario U
WHERE U.username = @USER

GO

CREATE PROC THE_DISCRETABOY.cambiar_password
(
@USER NVARCHAR(20),
@PASSNUEVA CHAR(64)
)
AS
UPDATE THE_DISCRETABOY.Usuario
SET password = @PASSNUEVA , pass_definitiva = 1
WHERE username = @USER

GO

CREATE PROC THE_DISCRETABOY.existe_telefono_cliente
(@telefono numeric (18,0))
AS
BEGIN
DECLARE @EXISTE NUMERIC (18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Cliente C
WHERE
@telefono = C.telefono
RETURN @EXISTE
END

GO

CREATE PROC THE_DISCRETABOY.existe_telefono_cliente_exceptuando_a
(
@telefono numeric (18,0),
@user nvarchar(20)
)
AS
BEGIN
DECLARE @EXISTE NUMERIC (18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Cliente C
WHERE
@telefono = C.telefono and
@user != C.usuario
RETURN @EXISTE
END

GO
--PARA FIJARSE SI CUANDO SE CAMBIA UNA EMPRESA NO SE LE ASIGEN UN TEL. YA USADO
CREATE PROC THE_DISCRETABOY.existe_telefono_empresa_exceptuando_a
(
@telefono numeric (18,0),
@user nvarchar(20)
)
AS
BEGIN
DECLARE @EXISTE NUMERIC (18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Empresa C
WHERE
@telefono = C.telefono and
@user != C.usuario
RETURN @EXISTE
END

GO
--PARA SABER SI YA REGISTRARON ESE CUIT
CREATE PROC THE_DISCRETABOY.existe_cuit_exceptuando_a
(
@cuit nvarchar(255),
@user nvarchar(20)
)
AS
BEGIN
DECLARE @EXISTE NUMERIC (18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Empresa E
WHERE
@cuit = e.cuit and
@user != E.usuario
RETURN @EXISTE
END

GO
--PARA SABER SI YA EXISTE ALGUIEN CON ESE DOCUMENTO
CREATE PROC THE_DISCRETABOY.existe_tipo_y_numero_doc
(
@TIPO VARCHAR(3),
@NRO NUMERIC (18,0)
)
AS
BEGIN
DECLARE @EXISTE NUMERIC(18,0)
SELECT 
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Cliente C
WHERE
C.doc_tipo = @TIPO AND
C.doc_numero = @NRO
RETURN @EXISTE
END

GO
--PARA SABER SI EL COD DE VISIBILIDAD NO ESTÁ USADO
CREATE PROC THE_DISCRETABOY.existe_cod_visibilidad
(@COD numeric(18,0))
AS
BEGIN
DECLARE @EXISTE NUMERIC(18,0)
SELECT 
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Visibilidad V
WHERE
V.codigo = @COD
RETURN @EXISTE
END

GO
--CHEQUEA SI YA HAY OTRO CON TAL COMBINACION PARA CUANDO SE QUIERE CAMBIAR
CREATE PROC THE_DISCRETABOY.existe_tipo_y_numero_doc_exceptuando_a
(
@TIPO VARCHAR(3),
@NRO NUMERIC (18,0),
@user nvarchar(20)
)
AS
BEGIN
DECLARE @EXISTE NUMERIC(18,0)
SELECT 
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Cliente C
WHERE
C.doc_tipo = @TIPO AND
C.doc_numero = @NRO AND
C.usuario != @user
RETURN @EXISTE
END

GO
--RETORNAR PASSWORDPERMANENTE
CREATE PROC THE_DISCRETABOY.password_permanente
(@user nvarchar(20))
AS
BEGIN
DECLARE @PERMANENCIA BIT
SELECT TOP 1
@PERMANENCIA = U.pass_definitiva
FROM
THE_DISCRETABOY.Usuario U
WHERE U.username = @user
RETURN @PERMANENCIA
END

GO

--RETORNA SI ESXISTE LA RAZON SOCIAL
CREATE PROC THE_DISCRETABOY.existe_razon_social
(@RAZON NVARCHAR(255))
AS
BEGIN
DECLARE @EXISTE NUMERIC(18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Empresa E
WHERE E.razon_social = @RAZON
RETURN @EXISTE
END

GO

--RETORNA SI EXISTE EL CUIT
CREATE PROC THE_DISCRETABOY.existe_cuit
(@CUIT NVARCHAR(50))
AS
BEGIN
DECLARE @EXISTE NUMERIC(18,0)
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Empresa E
WHERE E.cuit = @CUIT
RETURN @EXISTE
END

GO

--TRAIGO FILA DEL CLIENTE
CREATE PROC THE_DISCRETABOY.get_data_cliente
(@USER NVARCHAR(20))
AS
BEGIN
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Cliente C
WHERE
C.usuario = @USER
END

GO
--TRAIGO FILA DE LA EMPRESA
CREATE PROC THE_DISCRETABOY.get_data_empresa
(@USER NVARCHAR(20))
AS
BEGIN
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Empresa E
WHERE
E.usuario = @USER
END

GO
--TRAIGO FILA DE DIRECCION
CREATE PROC THE_DISCRETABOY.get_data_direccion
(@id nvarchar(18))
AS
BEGIN
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Direccion D
WHERE
D.id = @id
END

GO

CREATE PROC THE_DISCRETABOY.get_clientes_buscando
(
@nombre nvarchar(255),
@ape nvarchar(255),
@tipo varchar(3),
@numero nvarchar(255),
@email nvarchar(255)
)
AS
BEGIN
SELECT
C.usuario 'Usuario',
C.nombre 'Nombre',
C.apellido 'Apellido',
C.doc_tipo 'Tipo',
C.doc_numero 'Número',
C.mail 'Mail',
(CASE WHEN U.habilitado=1 THEN 'HABILITADO'
ELSE 'INHABILITADO' END)'Estado'
FROM
THE_DISCRETABOY.Cliente C,THE_DISCRETABOY.Usuario U
WHERE
C.nombre LIKE '%'+@nombre+'%' AND
C.apellido LIKE '%'+@ape+'%' AND
C.doc_tipo LIKE '%'+@tipo+'%' AND
C.doc_numero LIKE '%'+@numero+'%' AND
C.mail LIKE '%'+@email+'%' AND
U.username=C.usuario
END

GO

--BUSCAR EMPRESAS
CREATE PROC THE_DISCRETABOY.get_empresas_buscando
(
@razon nvarchar(255),
@cuit nvarchar(255),
@email nvarchar(255)
)
AS
BEGIN
SELECT
E.usuario 'USUARIO',
E.razon_social 'RAZON SOCIAL',
E.cuit 'CUIT',
E.mail 'E-MAIL',
(CASE WHEN U.habilitado=1 THEN 'HABILITADO'
ELSE 'INHABILITADO' END)'ESTADO ACTUAL'
FROM
THE_DISCRETABOY.Empresa E,THE_DISCRETABOY.Usuario U
WHERE 
U.username = E.usuario AND
E.razon_social LIKE '%'+@razon+'%' AND
(E.cuit = @cuit OR @cuit='')AND
E.mail LIKE '%'+@email+'%'
END

GO
--EDITAR UN CLIENTE
CREATE PROC THE_DISCRETABOY.editar_cliente
(
@user nvarchar(20), 
@nombre nvarchar(255),
@apellido nvarchar(255),
@tipoDoc varchar(3), 
@nroDoc numeric(18,0),
@mail nvarchar(255),
@telefono numeric(18,0),
@fechaNac datetime
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Cliente
SET
apellido = @apellido,
nombre = @nombre,
doc_tipo = @tipoDoc,
doc_numero = @nroDoc,
mail = @mail,
telefono = @telefono,
fecha_nacimiento = @fechaNac
WHERE
usuario = @user
END

GO
--EDITAR UNA EMPRESA
CREATE PROC THE_DISCRETABOY.editar_empresa
(
@user nvarchar(20), 
@RS nvarchar(255),
@mail nvarchar(255),
@telefono numeric(18,0),
@ciudad nvarchar(255),
@cuit nvarchar(255),
@nombre_contacto nvarchar(255),
@fechaCreacion datetime
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Empresa
SET
razon_social = @RS,
mail = @mail,
telefono = @telefono,
ciudad = @ciudad,
cuit = @cuit,
nombre_de_contacto = @nombre_contacto,
fecha_creacion = @fechaCreacion
WHERE
usuario = @user
END

GO
--EDITAR UNA DIRECCION
CREATE PROC THE_DISCRETABOY.editar_direccion
(
@id numeric(18,0), 
@calle nvarchar(255),
@numero numeric(18,0),
@piso numeric(18,0), 
@depto nvarchar(50),
@cp nvarchar(50),
@localidad nvarchar(255)
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Direccion
SET
calle = @calle,
numero = @numero,
piso = @piso,
depto = @depto,
cod_post = @cp,
localidad = @localidad
WHERE
id = @id
END

GO
--DAR DE ALTA UNA NUEVA VISIBILIDAD
CREATE PROC THE_DISCRETABOY.alta_visibilidad
(
@cod numeric(18,0),
@desc nvarchar(255),
@prec numeric(18,2),
@porc numeric(18,2)
)
AS
BEGIN
INSERT INTO THE_DISCRETABOY.Visibilidad
(
codigo,
descripcion,
precio_por_pub,
porcentaje
)
VALUES
(
@cod,
@desc,
@prec,
@porc
)
END

GO
--HACER VISIBILIDAD POR USER
CREATE PROC THE_DISCRETABOY.alta_visibilidad_por_user
(
@VISI NUMERIC(18,0),
@USER NVARCHAR(20)
)
AS
INSERT INTO THE_DISCRETABOY.Visibilidad_por_user
(
Visibilidad,
usuario,
cant_ventas
)
VALUES
(
@VISI,
@USER,
0
)

GO
--EDITAR VISIBILIDAD
CREATE PROC THE_DISCRETABOY.editar_visibilidad
(
@cod numeric(18,0),
@desc nvarchar(255),
@prec numeric(18,2),
@porc numeric(18,2)
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Visibilidad
SET descripcion = @desc,
precio_por_pub = @prec,
porcentaje = @porc
WHERE
codigo = @cod
END

GO
--BUSCAR VISIBILIDADES
CREATE PROC THE_DISCRETABOY.get_visibilidades_buscando
(@descrip NVARCHAR(255))
AS
BEGIN
SELECT
V.codigo 'CÓDIGO',
V.descripcion 'DESCRIPCIÓN',
V.porcentaje 'PORCENTAJE',
V.precio_por_pub 'PRECIO POR PUBLICACIÓN',
(CASE WHEN V.habilitado=1 THEN 'HABILITADO'
ELSE 'INHABILITADO' END)'ESTADO ACTUAL'
FROM
THE_DISCRETABOY.Visibilidad V
WHERE V.descripcion LIKE '%'+@descrip+'%'
END

GO
--TRAER DATA DE VISIBILIDAD
CREATE PROC THE_DISCRETABOY.get_data_visibilidad
(@COD NUMERIC(18,0))
AS
BEGIN
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Visibilidad V
WHERE
V.codigo = @COD
END

GO
--TRAER DATA DE VISIBILIDAD POR DESCRIPCION
CREATE PROC THE_DISCRETABOY.get_data_visi_con_descrip
(@DESCRIP NVARCHAR(255))
AS
BEGIN
SELECT TOP 1
*
FROM THE_DISCRETABOY.Visibilidad
WHERE descripcion = @DESCRIP
END

GO
--INHABILITAR VISIBILIDAD
CREATE PROC THE_DISCRETABOY.inhabilitar_visibilidad
(@cod numeric(18,0))
AS
BEGIN
UPDATE THE_DISCRETABOY.Visibilidad
SET habilitado = 0
WHERE
codigo = @cod
END

GO

--TRAER RUBROS
CREATE PROC THE_DISCRETABOY.get_rubros
AS
BEGIN
SELECT *
FROM
THE_DISCRETABOY.Rubro R
END

GO
--TRAER RUBROS DE UNA PUBLICACION INDIVIDUAL
CREATE PROC THE_DISCRETABOY.get_rubros_de
(@PUBLI NUMERIC(18,0))
AS
BEGIN
SELECT
R.codigo,
R.descripcion
FROM
THE_DISCRETABOY.Rubro_por_publicacion RP,
THE_DISCRETABOY.Rubro R
WHERE
RP.rubro = R.codigo AND
RP.publicacion = @PUBLI
END

GO

--ALTA PUBLICACION
CREATE PROC THE_DISCRETABOY._alta_publicacion --PARA SER UTILIZADO EN EL ALTA DE VENTA DIRECTA O SUBASTA
(
@ESTADO NVARCHAR(255),
@VISI NUMERIC(18,0),
@USUARIO NVARCHAR(20),
@DESCRI NVARCHAR(255),
@FECHA DATETIME,
@VENCIMIENTO DATETIME,
@HAY_PREGUNTAS BIT
)
AS
BEGIN
INSERT INTO THE_DISCRETABOY.Publicacion
(
estado,
Visibilidad,
usuario,
descripcion,
fecha,
fecha_venc,
HAY_PREGUNTAS
)
VALUES
(
(
SELECT TOP 1
E.id
FROM
THE_DISCRETABOY.Estado E
WHERE
E.NOMBRE = @ESTADO
),
@VISI,
@USUARIO,
@DESCRI,
@FECHA,
@VENCIMIENTO,
@HAY_PREGUNTAS
)
END

GO
--TRAER EL ID DE LA ULTIMA INSERCION
CREATE PROC THE_DISCRETABOY.id_ultima_insercion
AS
SELECT @@IDENTITY

GO
--ALTA RUBRO POR PUBLICACION
CREATE PROC THE_DISCRETABOY.alta_rubro_por_publicacion
(
@RUBRO NVARCHAR(255),
@PUBLI NUMERIC(18,0)
)
AS
BEGIN
DECLARE @CODIGORUBRO NUMERIC(18,0)
SELECT TOP 1
@CODIGORUBRO = R.codigo
FROM
THE_DISCRETABOY.Rubro R
WHERE R.descripcion=@RUBRO

INSERT INTO THE_DISCRETABOY.Rubro_por_publicacion
(rubro,publicacion)
VALUES
(@CODIGORUBRO,@PUBLI)
END

GO
--ALTA VENTA DIRECTA
CREATE PROC THE_DISCRETABOY.alta_venta_directa
(
@PRECIO NUMERIC(18,2),
@ESTADO NVARCHAR(255),
@VISI NUMERIC(18,0),
@USUARIO NVARCHAR(20),
@DESCRI NVARCHAR(255),
@FECHA DATETIME,
@VENCIMIENTO DATETIME,
@STOCK NUMERIC(18,0),
@HAY_PREGUNTAS BIT
)
AS
BEGIN
EXEC THE_DISCRETABOY._alta_publicacion @ESTADO,@VISI,@USUARIO,@DESCRI,@FECHA,@VENCIMIENTO,@HAY_PREGUNTAS
INSERT INTO THE_DISCRETABOY.Venta_directa
(
precio,
publicacion,
stock
) 
VALUES 
(
@PRECIO,
(SELECT @@IDENTITY),
@STOCK
)
END

GO
--ALTA SUBASTA
CREATE PROC THE_DISCRETABOY.alta_subasta
(
@PRECIO_INICIAL NUMERIC(18,2),
@ESTADO NVARCHAR(255),
@VISI NUMERIC(18,0),
@USUARIO NVARCHAR(20),
@DESCRI NVARCHAR(255),
@FECHA DATETIME,
@VENCIMIENTO DATETIME,
@CANTIDAD NUMERIC(18,0),
@HAY_PREGUNTAS BIT
)
AS
BEGIN
EXEC THE_DISCRETABOY._alta_publicacion @ESTADO,@VISI,@USUARIO,@DESCRI,@FECHA,@VENCIMIENTO,@HAY_PREGUNTAS
INSERT INTO THE_DISCRETABOY.Subasta
(
precio_inicial,
publicacion,
cantidad
) 
VALUES 
(
@PRECIO_INICIAL,
(SELECT @@IDENTITY),
@CANTIDAD
)
END

GO
--TRAER UNA FILA DE PUBLICACION
CREATE PROC THE_DISCRETABOY.get_fila_publicacion
(@ID NUMERIC(18,0))
AS
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Publicacion P
WHERE
P.id = @ID

GO
--BUSCAR SUABSTA DADA UNA PUBLICACION
CREATE PROC THE_DISCRETABOY.subasta_por_pub
(@PUB NUMERIC (18,0))
AS
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Subasta S
WHERE
S.publicacion = @PUB

GO
--BUSCAR VENTA DIRECTA DADA UNA PUBLICACION
CREATE PROC THE_DISCRETABOY.venta_dir_por_pub
(@PUB NUMERIC (18,0))
AS
SELECT TOP 1
*
FROM
THE_DISCRETABOY.Venta_directa V
WHERE
V.publicacion = @PUB

GO
--DICE SI UNA PUBLICACION ESTÁ FINCALIZADA
CREATE FUNCTION THE_DISCRETABOY.ESTA_FINALIZADA
(
@PUBLI NUMERIC(18,0)
)
RETURNS BIT
AS
BEGIN

RETURN (SELECT CASE WHEN THE_DISCRETABOY.get_estado_publi(@PUBLI) = 'Finalizada' THEN 1 ELSE 0 END)

END

GO
--DICE SI UNA SUBASTA TIENE OFERTAS
CREATE FUNCTION THE_DISCRETABOY.TIENE_OFERTAS
(@PUBLI NUMERIC(18,0))
RETURNS BIT 
AS
BEGIN
DECLARE @TIENE BIT
SELECT
@TIENE = (CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END)
FROM
THE_DISCRETABOY.OFERTA O
WHERE 
O.PUBLICACION = @PUBLI
RETURN @TIENE
END

GO
--EDITAR PUBLICACION
CREATE PROC THE_DISCRETABOY.editar_publicacion
(
@ID NUMERIC(18,0),
@VISI NUMERIC(18,0),
@ESTADO NVARCHAR(255),
@HAYPREGUNTAS BIT
)
AS
BEGIN

UPDATE THE_DISCRETABOY.Publicacion
SET 
Visibilidad = @VISI,
estado = 
(
SELECT TOP 1
E.ID
FROM
THE_DISCRETABOY.Estado E
WHERE
E.NOMBRE = @ESTADO
),
hay_preguntas = @HAYPREGUNTAS
WHERE
id = @ID

IF ((@ESTADO = 'Finalizada') AND (THE_DISCRETABOY.ES_VENTA_DIRECTA(@ID) = 0) AND (THE_DISCRETABOY.TIENE_OFERTAS(@ID) = 1))
BEGIN
INSERT INTO THE_DISCRETABOY.compra
(
publicacion,
cliente,
cant_comprada,
fecha
)
SELECT TOP 1
S.publicacion,
O.cliente,
S.cantidad,
O.fecha
FROM
THE_DISCRETABOY.Subasta S,
THE_DISCRETABOY.Oferta O
WHERE 
S.publicacion = O.publicacion AND
THE_DISCRETABOY.F_SUBASTA_PRECIO_ACTUAL(S.id) = O.monto_ofertado AND
S.publicacion = @ID
END

END

GO
--EDITAR SUBASTA
CREATE PROC THE_DISCRETABOY.editar_subasta
(
@ID NUMERIC(18,0),
@PRECIO NUMERIC(18,2),
@STOCK NUMERIC(18,0)
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Subasta
SET
precio_inicial = @PRECIO,
cantidad = @STOCK
WHERE
id = @ID
END

GO
--EDITAR VENTA DIRECTA
CREATE PROC THE_DISCRETABOY.editar_venta_directa
(
@ID NUMERIC(18,0),
@PRECIO NUMERIC(18,2),
@STOCK NUMERIC(18,0)
)
AS
BEGIN
UPDATE THE_DISCRETABOY.Venta_directa
SET
precio = @PRECIO,
stock = @STOCK
WHERE
id = @ID
END

GO
--BAJA RUBRO POR PUBLICACION
CREATE PROC THE_DISCRETABOY.baja_rubro_por_publicacion
(
@RUBRO NUMERIC(18,0),
@PUBLICACION NUMERIC(18,0)
)
AS
DELETE FROM THE_DISCRETABOY.Rubro_por_publicacion
WHERE
rubro = @RUBRO AND
Publicacion = @PUBLICACION

GO
--ALTA RUBRO POR PUBLICACION
CREATE PROC THE_DISCRETABOY.alta_rubro_cod_por_publicacion
(
@RUBRO NUMERIC(18,0),
@PUBLICACION NUMERIC(18,0)
)
AS
INSERT INTO THE_DISCRETABOY.Rubro_por_publicacion
(
rubro,
publicacion
)
VALUES
(
@RUBRO,
@PUBLICACION
)

GO
--BUSCAR PREGUNTAS PARA UNA PERSONA
CREATE PROC THE_DISCRETABOY.get_pregs_para_buscando
(
@DESCRIP nvarchar(255),
@USUARIO NVARCHAR(20)
)
AS
SELECT
PUB.id 'CODIGO PUBLICACION',
PUB.descripcion 'PUBLICACION',
PREG.id 'CODIGO PREGUNTA',
PREG.descripcion 'PREGUNTA',
PREG.cliente 'CLIENTE PREGUNTADOR'
FROM
THE_DISCRETABOY.Pregunta PREG,
THE_DISCRETABOY.Publicacion PUB
WHERE
PREG.publicacion = PUB.id AND
PUB.usuario = @USUARIO AND
PREG.descripcion LIKE '%'+@DESCRIP+'%' AND
PREG.id != ALL 
(
SELECT 
R.pregunta 
FROM 
THE_DISCRETABOY.Respuesta R
)

GO
--BUSCAR PREGUNTAS RESPONDIDAS PARA UNA PERSONA
CREATE PROC THE_DISCRETABOY.get_pregs_respondidas_para_buscando
(
@DESCRIP nvarchar(255),
@USUARIO NVARCHAR(20)
)
AS
SELECT
PUB.id 'CODIGO PUBLICACION',
PUB.descripcion 'PUBLICACION',
PREG.id 'CODIGO PREGUNTA',
PREG.descripcion 'PREGUNTA',
PREG.cliente 'CLIENTE PREGUNTADOR'
FROM
THE_DISCRETABOY.Pregunta PREG,
THE_DISCRETABOY.Publicacion PUB,
THE_DISCRETABOY.Respuesta RES
WHERE
PREG.publicacion = PUB.id AND
PREG.id = RES.pregunta AND
(
PUB.usuario = @USUARIO OR
PREG.cliente = @USUARIO
) AND
PREG.descripcion LIKE '%'+@DESCRIP+'%'

GO
--ALTA RESPUESTA
CREATE PROC THE_DISCRETABOY.alta_respuesta
(
@PREGUNTA NUMERIC(18,0),
@RESPUESTA NVARCHAR(255)
)
AS
INSERT INTO THE_DISCRETABOY.Respuesta
(
pregunta,
fecha,
descripcion
)
VALUES
(
@PREGUNTA,
(SELECT CURRENT_TIMESTAMP),
@RESPUESTA
)

GO
--PRECIO ACTUAL DE LA SUBASTA
CREATE PROC THE_DISCRETABOY.precio_actual_subasta
(
@SUBASTA NUMERIC(18,0)
)
AS
SELECT TOP 1
MAX(O.monto_ofertado) 'PRECIO ACTUAL'
FROM
THE_DISCRETABOY.Subasta S, 
THE_DISCRETABOY.Oferta O
WHERE
S.publicacion = O.publicacion AND
S.id = @SUBASTA
GROUP BY 
S.publicacion

UNION

SELECT TOP 1
S.precio_inicial 'PRECIO ACTUAL'
FROM
THE_DISCRETABOY.Subasta S
WHERE
S.id = @SUBASTA AND
S.publicacion != ALL 
(
SELECT
O.publicacion
FROM
THE_DISCRETABOY.Oferta O
)

GO
--TRAE LA DESCRIPCION DE UNA RESPUESTA
CREATE PROC THE_DISCRETABOY.get_descripcion_respuesta
(
@COD NUMERIC(18,0)
)
AS
BEGIN
SELECT TOP 1
R.descripcion
FROM
THE_DISCRETABOY.Respuesta R
WHERE
R.pregunta = @COD
END

GO
--GET PUBLICACIONES PARA COMPRAR/OFERTAR ORDENADAS
CREATE PROC THE_DISCRETABOY.get_publics_a_ver
(
@USUARIO nvarchar(20),
@DESCRIPCION NVARCHAR(255),
@RUBRO NVARCHAR(255)
)
AS
SELECT
P.id 'CODIGO',
P.descripcion 'DESCRIPCION',
'Subasta' 'TIPO',
V.precio_por_pub 'PRECIO POR PUBLICAR'
FROM
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Subasta S,
THE_DISCRETABOY.Visibilidad V,
THE_DISCRETABOY.Rubro_por_publicacion RP,
THE_DISCRETABOY.Rubro R
WHERE
P.usuario != @USUARIO AND
P.id = S.publicacion AND
DATEDIFF(DAY,P.fecha_venc,GETDATE())<0 AND
V.codigo = P.Visibilidad AND
P.descripcion LIKE '%'+@DESCRIPCION+'%' AND
R.codigo = RP.rubro AND
RP.publicacion = P.id AND
R.descripcion LIKE '%'+@RUBRO+'%' AND
P.estado = (
SELECT TOP 1
E.id
FROM
THE_DISCRETABOY.Estado E
WHERE
E.NOMBRE = 'Publicada'
)

UNION

SELECT
P.id 'CODIGO',
P.descripcion 'DESCRIPCION',
'Venta directa' 'TIPO',
VI.precio_por_pub 'PRECIO POR PUBLICAR'
FROM
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Venta_directa V,
THE_DISCRETABOY.Visibilidad VI,
THE_DISCRETABOY.Rubro_por_publicacion RP,
THE_DISCRETABOY.Rubro R
WHERE
P.usuario != @USUARIO AND
P.id = V.publicacion AND
DATEDIFF(DAY,P.fecha_venc,GETDATE())<0 AND
V.stock>0 AND
VI.codigo = P.Visibilidad AND
P.descripcion LIKE '%'+@DESCRIPCION+'%' AND
R.codigo = RP.rubro AND
RP.publicacion = P.id AND
R.descripcion LIKE '%'+@RUBRO+'%' AND
P.estado = 
(
SELECT TOP 1
E.id
FROM
THE_DISCRETABOY.Estado E
WHERE
E.NOMBRE = 'Publicada'
)
ORDER BY [PRECIO POR PUBLICAR] DESC,CODIGO DESC

GO
--ALTA PREGUNTA
CREATE PROC THE_DISCRETABOY.alta_pregunta
(
@CLIENTE NVARCHAR(20),
@PUBLICACION NUMERIC(18,0),
@DESCRIPCION NVARCHAR(255)
)
AS
INSERT INTO THE_DISCRETABOY.Pregunta
(cliente,publicacion,descripcion)
VALUES
(
@CLIENTE,
@PUBLICACION,
@DESCRIPCION
)

GO
--ALTA OFERTA
CREATE PROC THE_DISCRETABOY.alta_oferta
(
@CLIENTE NVARCHAR(20),
@PUBLICACION NUMERIC(18,0),
@MONTO NUMERIC(18,2)
)
AS
INSERT INTO THE_DISCRETABOY.Oferta
(
cliente,
publicacion,
fecha,
monto_ofertado
)
VALUES
(
@CLIENTE,
@PUBLICACION,
GETDATE(),
@MONTO
)

GO
--SABER SI UN USUARIO ES CLIENTE
CREATE PROC THE_DISCRETABOY.es_cliente
(@USERNAME NVARCHAR(20))
AS
BEGIN
DECLARE @EXISTE BIT
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Cliente C
WHERE
C.usuario = @USERNAME
RETURN @EXISTE
END

GO
--SABER SI UN USUARIO ES EMPRESA
CREATE PROC THE_DISCRETABOY.es_empresa
(@USERNAME NVARCHAR(20))
AS
BEGIN
DECLARE @EXISTE BIT
SELECT
@EXISTE = CASE WHEN COUNT (*)>0 THEN 1 ELSE 0 END
FROM
THE_DISCRETABOY.Empresa E
WHERE
E.usuario = @USERNAME
RETURN @EXISTE
END

GO
--SE REGISTRA UNA COMPRA
CREATE PROC THE_DISCRETABOY.alta_compra
(
@CLIENTE NVARCHAR(20),
@PUBLICACION NUMERIC(18,0),
@CANTIDAD NUMERIC(18,0)
)
AS
INSERT INTO THE_DISCRETABOY.compra
(cliente,publicacion,fecha,cant_comprada)
VALUES
(
@CLIENTE,
@PUBLICACION,
GETDATE(),
@CANTIDAD
)

GO
--TRIGGER PARA DECREMENTAR EL STOCK
CREATE FUNCTION THE_DISCRETABOY.ES_VENTA_DIRECTA
(@PUB NUMERIC(18,0))
RETURNS BIT 
AS
BEGIN
DECLARE @ES BIT

SELECT
@ES = (CASE WHEN COUNT(*)>0 THEN 1 ELSE 0 END)
FROM
THE_DISCRETABOY.VENTA_DIRECTA V
WHERE
V.PUBLICACION = @PUB

RETURN @ES
END

GO

CREATE TRIGGER THE_DISCRETABOY.decrementar_stock_por_compra
ON THE_DISCRETABOY.compra
AFTER INSERT
AS
BEGIN
IF THE_DISCRETABOY.ES_VENTA_DIRECTA((SELECT TOP 1 PUBLICACION FROM INSERTED)) = 1
UPDATE THE_DISCRETABOY.Venta_directa
SET stock = stock - (SELECT TOP 1 cant_comprada FROM INSERTED)
END

GO
--FUNCION PARA CONOCER EL PRECIO ACTUAL DE UNA SUBASTA
CREATE FUNCTION THE_DISCRETABOY.f_subasta_precio_actual
(@SUBASTA NUMERIC(18,0))
RETURNS NUMERIC (18,2)
AS
BEGIN
DECLARE @VALUE NUMERIC(18,2)

SET @VALUE =
(
SELECT TOP 1
MAX(O.monto_ofertado) 'PRECIO ACTUAL'
FROM
THE_DISCRETABOY.Subasta S, 
THE_DISCRETABOY.Oferta O
WHERE
S.publicacion = O.publicacion AND
S.id = @SUBASTA
GROUP BY 
S.publicacion

UNION

SELECT TOP 1
S.precio_inicial 'PRECIO ACTUAL'
FROM
THE_DISCRETABOY.Subasta S
WHERE
S.id = @SUBASTA AND
S.publicacion != ALL 
(
SELECT
O.publicacion
FROM
THE_DISCRETABOY.Oferta O
)
)

RETURN @VALUE
END

GO
--Tomar las compras que se debe calificar
CREATE PROC THE_DISCRETABOY.compras_a_calificar
(@CLIENTE NVARCHAR(20))
AS
SELECT
C.id 'CODIGO'
FROM
THE_DISCRETABOY.compra C
WHERE 
C.cliente = @CLIENTE AND
(
SELECT
COUNT(*)
FROM
THE_DISCRETABOY.Calificacion CA
WHERE
CA.COMPRA = C.id
)=0

GO
--TOMAR UNA CANTIDAD A PARTIR DE UN CODIGO
CREATE PROC THE_DISCRETABOY.get_pack_compras_a_calificar
(@CLIENTE NVARCHAR(20),@BASE NUMERIC(18,0))
AS
SELECT TOP 10
C.id 'CODIGO',
'COMPRA' 'TIPO'
FROM
THE_DISCRETABOY.compra C
WHERE 
C.cliente = @CLIENTE AND
C.id > @BASE AND
(
SELECT
COUNT(*)
FROM
THE_DISCRETABOY.Calificacion CA
WHERE
CA.COMPRA = C.id
)=0

ORDER BY 1

GO
--GET DATA COMPRA
CREATE PROC THE_DISCRETABOY.get_data_compra
(@CODIGO NUMERIC(18,0))
AS
SELECT TOP 1
*
FROM
THE_DISCRETABOY.compra C
WHERE
C.id = @CODIGO

GO
--ALTA CALIFICACION
CREATE PROC THE_DISCRETABOY.alta_calificacion
(
@COMPRA NUMERIC(18,0),
@ESTRELLAS NUMERIC(18,0),
@DESCRIP NVARCHAR(255)
)
AS
INSERT INTO THE_DISCRETABOY.Calificacion
(
compra ,
cant_estrellas,
descrip
)
VALUES
(
@COMPRA,
@ESTRELLAS,
@DESCRIP
)

GO
--COMPRAS QUE PARTICIPA UN USUARIO
CREATE PROC THE_DISCRETABOY.compras_con_user
(@USUARIO NVARCHAR(20))
AS
SELECT
P.usuario 'VENDEDOR',
COM.cliente 'COMPRADOR',
P.descripcion 'PUBLICACION',
V.precio 'PRECIO',
COM.fecha 'FECHA',
CASE WHEN CAL.descrip IS NOT NULL THEN CAL.descrip ELSE 'Sin calificar.' END 'COMENTARIO',
CAL.cant_estrellas 'ESTRELLAS'
FROM
THE_DISCRETABOY.compra COM
LEFT JOIN THE_DISCRETABOY.Publicacion P ON
COM.publicacion = P.id
LEFT JOIN THE_DISCRETABOY.Venta_directa V ON
P.id = V.publicacion
LEFT JOIN THE_DISCRETABOY.Calificacion CAL ON
CAL.compra = COM.id 
WHERE
((P.usuario = @USUARIO) OR (COM.cliente = @USUARIO))

GO
--OFERTAS QUE PARTICIPA UN USUARIO
CREATE PROC THE_DISCRETABOY.ofertas_con_user
(@USUARIO NVARCHAR(20))
AS
SELECT
P.usuario 'VENDEDOR',
OFE.cliente 'OFERTANTE',
P.descripcion 'PUBLICACION',
OFE.monto_ofertado 'MONTO OFRECIDO',
OFE.fecha 'FECHA',
(
CASE 
WHEN 
(
(OFE.monto_ofertado = THE_DISCRETABOY.f_subasta_precio_actual(SUB.id)) AND
(P.fecha_venc < GETDATE() OR THE_DISCRETABOY.ESTA_FINALIZADA(P.id) = 1) 
) 
THEN 'GANADA' 
ELSE 'NO GANADA' END
) 'RESULTADO'
FROM
THE_DISCRETABOY.Oferta OFE,
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.SUBASTA SUB
WHERE
OFE.publicacion = P.id AND
SUB.publicacion = P.id AND
OFE.cliente = @USUARIO 

GO
--GET SIGUIENTE A FACTURAR
CREATE PROC THE_DISCRETABOY.siguiente_publi_a_facturar
(@USUARIO NVARCHAR(20))
AS
SELECT
P.id
FROM
THE_DISCRETABOY.Publicacion P
WHERE
P.usuario = @USUARIO AND
P.id != ALL
(
SELECT 
R.publicacion
FROM
THE_DISCRETABOY.Renglon_factura R
)
ORDER BY
P.fecha

GO
--GET COMISIONES DE UNIDADES VENDIDAS DE UNA PUBLICACION VENTA DIRECTA
--Como siempre que se devuelve un decimal, se trae en un DataTable.
CREATE PROC THE_DISCRETABOY.comisiones_compras_inmediatas
(@PUBLI NUMERIC(18,0))
AS
SELECT
SUM(CI.cant_comprada*V.precio)
FROM
THE_DISCRETABOY.compra CI,
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Venta_directa V,
THE_DISCRETABOY.Visibilidad VI
WHERE
CI.publicacion = P.id AND
P.id = V.publicacion AND
P.id = @PUBLI AND
P.Visibilidad = VI.codigo
GROUP BY
P.id

GO
--GET COMISIONES DE UNIDADES VENDIDAS DE UNA PUBLICACION SUBASTA
CREATE PROC THE_DISCRETABOY.comision_subasta
(@PUBLI NUMERIC(18,0))
AS
SELECT
THE_DISCRETABOY.f_subasta_precio_actual(S.id)*(VI.porcentaje)
FROM
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Visibilidad VI,
THE_DISCRETABOY.Subasta S
WHERE
P.Visibilidad = VI.codigo AND
S.publicacion = P.id AND
P.id = @PUBLI

GO
--ALTA TARJETA
CREATE PROC THE_DISCRETABOY.alta_tarjeta
(
@NUMERO NVARCHAR(255),
@NOMBRE NVARCHAR(255),
@APELLIDO NVARCHAR(255),
@FACTURA NUMERIC(18),
@NRO_DE_RENGLON NUMERIC(18)
)
AS
INSERT INTO THE_DISCRETABOY.Tarjeta_credito
(
numero,
nombre,
apellido,
factura,
nro_renglon
)
VALUES
(
@NUMERO,
@NOMBRE,
@APELLIDO,
@FACTURA,
@NRO_DE_RENGLON
)

GO
--GET NUMERO ULTIMA FACTURA
CREATE PROC THE_DISCRETABOY.ultima_factura
AS
BEGIN
DECLARE @ULTIMA NUMERIC(18,0)
SELECT
@ULTIMA = MAX(F.numero)
FROM
THE_DISCRETABOY.Factura F
RETURN @ULTIMA
END

GO
--ALTA RENGLON
CREATE PROC THE_DISCRETABOY.alta_renglon
(
@FACTURA NUMERIC(18,0),
@NRO_RENGLON NUMERIC(18,0),
@PUBLI NUMERIC(18,0),
@COMI_VISI NUMERIC(18,2),
@COMI_UNIDADES NUMERIC(18,2),
@FORMA_DE_PAGO NVARCHAR(255)
)
AS
BEGIN
SET IDENTITY_INSERT THE_DISCRETABOY.Renglon_factura ON
INSERT INTO THE_DISCRETABOY.Renglon_factura
(
factura,
nro_renglon,
publicacion,
comision_visibilidad,
comision_por_unidades,
forma_de_pago
)
VALUES
(
@FACTURA,
@NRO_RENGLON,
@PUBLI,
@COMI_VISI,
@COMI_UNIDADES,
@FORMA_DE_PAGO
)
END

GO
--ALTA FACTURA
CREATE PROC THE_DISCRETABOY.alta_factura
AS
INSERT INTO THE_DISCRETABOY.Factura
(fecha,total)
VALUES
(GETDATE(),0)

GO

--TRIGGER PARA ACTUALIZAR EL TOTAL DE LA FACTURA
CREATE TRIGGER THE_DISCRETABOY.actualizar_total_factura
ON THE_DISCRETABOY.Renglon_factura
AFTER INSERT
AS
BEGIN
UPDATE THE_DISCRETABOY.Factura
SET TOTAL = TOTAL + (SELECT TOP 1 COMISION_POR_UNIDADES+COMISION_VISIBILIDAD FROM INSERTED)
WHERE
NUMERO=(select TOP 1 FACTURA from INSERTED)
END

GO
--GET ANIOS DE LAS PUBLICACIONES
CREATE PROC THE_DISCRETABOY.anios_publicaciones
AS
SELECT
DISTINCT YEAR(P.fecha)
FROM
THE_DISCRETABOY.Publicacion P

GO
--PROCEDIMIENTOS PARA LOS TOP 5
CREATE PROC THE_DISCRETABOY.vendedores_con_mas_no_vendidos_en_mes
(
@ANIO NUMERIC(18,0),
@VISI NVARCHAR(255),
@MES NUMERIC(18,0)
)
AS
SELECT TOP 5
U.username 'USUARIO',
SUM(V.stock) 'STOCK SIN VENDER'
FROM
THE_DISCRETABOY.Usuario U, 
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Venta_directa V,
THE_DISCRETABOY.Visibilidad VI
WHERE
P.usuario = U.username AND
MONTH(P.fecha) = @MES AND
V.publicacion = P.id AND
P.Visibilidad = VI.codigo AND
VI.descripcion LIKE '%'+@VISI+'%'
GROUP BY 
U.username
ORDER BY 
SUM(V.stock) DESC

GO

CREATE PROC THE_DISCRETABOY.vendedores_con_mas_no_vendidos
(
@ANIO NUMERIC(18,0),
@TRIME NUMERIC(18,0),
@VISI NVARCHAR(255)
)
AS
SELECT TOP 5
U.username 'USUARIO',
SUM(V.stock) 'STOCK SIN VENDER'
FROM
THE_DISCRETABOY.Usuario U, 
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Venta_directa V,
THE_DISCRETABOY.Visibilidad VI
WHERE
P.usuario = U.username AND
V.publicacion = P.id AND
P.Visibilidad = VI.codigo AND
VI.descripcion LIKE '%'+@VISI+'%' AND
YEAR(P.fecha) = @ANIO AND
MONTH(P.fecha)<=(@TRIME*3) AND
MONTH(P.fecha)>((@TRIME-1)*3)
GROUP BY 
U.username
ORDER BY 
SUM(V.stock) DESC

GO

CREATE PROC THE_DISCRETABOY.vendedores_con_mas_facturacion
(
@ANIO NUMERIC(18,0),
@TRIME NUMERIC(18,0)
)
AS
SELECT TOP 5
P.usuario 'USUARIO',
SUM(F.total) 'TOTAL FACTURADO'
FROM
THE_DISCRETABOY.Renglon_factura R,
THE_DISCRETABOY.Publicacion P,
THE_DISCRETABOY.Factura F
WHERE
R.publicacion = P.id AND
R.factura = F.numero AND
YEAR(P.fecha) = @ANIO AND
MONTH(P.fecha)<=(@TRIME*3) AND
MONTH(P.fecha)>((@TRIME-1)*3)
GROUP BY 
P.usuario
ORDER BY
SUM(F.total) DESC

GO

CREATE FUNCTION THE_DISCRETABOY.f_get_promedio_califs
(@USER NVARCHAR(20))
RETURNS DECIMAL
AS
BEGIN
DECLARE @PROM DECIMAL
SELECT 
@PROM = AVG(C.cant_estrellas)
FROM
THE_DISCRETABOY.Calificacion C,
THE_DISCRETABOY.compra CO,
THE_DISCRETABOY.Publicacion P
WHERE
C.compra = CO.id AND 
CO.PUBLICACION = P.ID AND
P.USUARIO = @USER

RETURN @PROM
END

GO

CREATE PROC THE_DISCRETABOY.vendedores_con_mayor_califs
(
@ANIO NUMERIC(18,0),
@TRIME NUMERIC(18,0)
)
AS
BEGIN
SELECT TOP 5
P.usuario 'USUARIO',
AVG(CA.cant_estrellas) 'PROMEDIO'
FROM
THE_DISCRETABOY.Calificacion CA,
THE_DISCRETABOY.compra CO,
THE_DISCRETABOY.Publicacion P
WHERE
CA.compra = CO.id AND 
CO.PUBLICACION = P.ID AND
YEAR(P.fecha) = @ANIO AND
MONTH(P.fecha)<=(@TRIME*3) AND
MONTH(P.fecha)>((@TRIME-1)*3)
GROUP BY
P.usuario
ORDER BY
AVG(CA.cant_estrellas) DESC
END

GO

CREATE PROC THE_DISCRETABOY.clientes_con_mas_sin_calif
(
@ANIO NUMERIC(18,0),
@TRIME NUMERIC(18,0)
)
AS
SELECT TOP 5
CO.cliente 'CLIENTE',
COUNT(CO.id) 'CANTIDAD SIN CALIFICAR'
FROM
THE_DISCRETABOY.compra CO
LEFT JOIN THE_DISCRETABOY.Calificacion CA ON
CO.id = CA.COMPRA 
LEFT JOIN THE_DISCRETABOY.Publicacion P ON
P.id = CO.publicacion
WHERE
CA.cant_estrellas IS NULL AND
YEAR(P.fecha) = @ANIO AND
MONTH(P.fecha)<=(@TRIME*3) AND
MONTH(P.fecha)>((@TRIME-1)*3)
GROUP BY
CO.cliente
ORDER BY
COUNT(CO.id) DESC

GO
--RETORNA EL NOMBRE DE UN ESTADO
CREATE PROC THE_DISCRETABOY.get_nombre_estado
(@CODIGO NUMERIC(18,0))
AS
SELECT TOP 1
E.NOMBRE
FROM
THE_DISCRETABOY.Estado E
WHERE
E.id = @CODIGO

GO
--RETORNA EL CODIGO DE UN ESTADO
CREATE PROC THE_DISCRETABOY.get_cod_estado
(@NOMBRE NVARCHAR(255))
AS
BEGIN
DECLARE @COD NUMERIC(18,0)
SELECT TOP 1
@COD = E.id
FROM
THE_DISCRETABOY.Estado E
WHERE
E.NOMBRE = @NOMBRE
RETURN @COD
END

GO
--RETORNA LOS ROLES QUE PUEDEN ASIGNARSE A UN USUARIO
CREATE PROC THE_DISCRETABOY.get_roles_habilitados_no_de
(@USER NVARCHAR(20))
AS
SELECT
R.cod_rol,
R.nombre
FROM
THE_DISCRETABOY.Rol R 
LEFT JOIN THE_DISCRETABOY.Rol_por_user RU ON
(
RU.rol = R.cod_rol AND
RU.usuario = @USER 
)
WHERE
RU.usuario IS NULL AND
R.habilitado = 1
GROUP BY
R.cod_rol,
R.nombre

GO
/* ****** Migrar datos existentes ******* */

--CARGO DIRECCIONES
INSERT INTO THE_DISCRETABOY.Direccion
(
calle,
numero,
piso,
depto,
cod_post
)
SELECT 
m.Cli_Dom_Calle as calle,
m.Cli_Nro_Calle as numero,
m.Cli_piso as piso,
m.Cli_Depto as depto,
m.Cli_Cod_Postal as cod_post
FROM gd_esquema.Maestra m
GROUP BY m.Cli_Dom_Calle,m.Cli_Nro_Calle,m.Cli_piso,m.Cli_Depto,m.Cli_Cod_Postal
HAVING Cli_Dom_Calle IS NOT NULL

UNION

SELECT 
m.Publ_Empresa_Dom_Calle as calle,
m.Publ_Empresa_Nro_Calle as numero,
m.Publ_Empresa_piso as piso,
m.Publ_Empresa_Depto as depto,
m.Publ_Empresa_Cod_Postal as cod_post
FROM gd_esquema.Maestra m
GROUP BY Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,Publ_Empresa_piso,Publ_Empresa_Depto,Publ_Empresa_Cod_Postal
HAVING Publ_Empresa_Dom_Calle IS NOT NULL

UNION

SELECT 
m.Publ_Cli_Dom_Calle as calle,
m.Publ_Cli_Nro_Calle as numero,
m.Publ_Cli_piso as piso,
m.Publ_Cli_Depto as depto,
m.Publ_Cli_Cod_Postal as cod_post	
FROM gd_esquema.Maestra m
GROUP BY Publ_Cli_Dom_Calle,Publ_Cli_Nro_Calle,Publ_Cli_piso,Publ_Cli_Depto,Publ_Cli_Cod_Postal
HAVING Publ_Cli_Dom_Calle IS NOT NULL	
GO

--CARGO usuarios de clientes
INSERT INTO THE_DISCRETABOY.Usuario
(
username,
password,
pass_definitiva,
intentos,
habilitado
)
SELECT 
	'Clie_'+CAST(m.Cli_Dni as nvarchar(20)) as username,--Se determina que el nombre de los preexIStentes será Clie más el dni.
	'e00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29',--La password es UTNFRBA	
	0,
	0,
	1
FROM gd_esquema.Maestra m
GROUP BY m.Cli_Dni
HAVING m.Cli_Dni IS NOT NULL
;
GO

--CARGO usuarios de Empresas
INSERT INTO THE_DISCRETABOY.Usuario
(
username,
password,
pass_definitiva,
intentos,
habilitado
)
SELECT 
	'Empre_'+CAST(m.Publ_Empresa_Cuit as nvarchar(50)) as username,--Se determina que el nombre de los preexIStentes será Empre_ más el CUIT.
	'e00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29',--La password es UTNFRBA	
	0,
	0,
	1
FROM gd_esquema.Maestra m
GROUP BY m.Publ_Empresa_Cuit
HAVING m.Publ_Empresa_Cuit IS NOT NULL
;
GO

--CARGO clientes
INSERT INTO THE_DISCRETABOY.Cliente
(
apellido,
direccion,
doc_numero,
doc_tipo,
fecha_nacimiento,
mail,
nombre,
telefono,
usuario
)
SELECT 
m.Cli_Apeliido,
D.id,
m.Cli_Dni,
'DNI',
m.Cli_Fecha_Nac,
m.Cli_Mail,
m.Cli_Nombre,
NULL,
'Clie_'+CAST(m.Cli_Dni as nvarchar(20))
FROM 
gd_esquema.Maestra M,THE_DISCRETABOY.Direccion D
WHERE
m.Cli_Dom_Calle = D.calle AND
m.Cli_Cod_Postal = D.cod_post AND
m.Cli_Depto = D.depto AND
m.Cli_Nro_Calle = D.numero AND
m.Cli_piso = D.piso
GROUP BY 
m.Cli_Apeliido,m.Cli_Dni,m.Cli_Fecha_Nac,m.Cli_Mail,m.Cli_Nombre,m.Cli_Dni,D.id
HAVING 
m.Cli_Dni IS NOT NULL

UNION

SELECT 
m.Publ_Cli_Apeliido,
D.id,
m.Publ_Cli_Dni,
'DNI',
m.Publ_Cli_Fecha_Nac,
m.Publ_Cli_Mail,
m.Publ_Cli_Nombre,
NULL,
'Clie_'+CAST(m.Publ_Cli_Dni as nvarchar(20))
FROM 
gd_esquema.Maestra M,THE_DISCRETABOY.Direccion D
WHERE
m.Publ_Cli_Dom_Calle = D.calle AND
m.Publ_Cli_Cod_Postal = D.cod_post AND
m.Publ_Cli_Depto = D.depto AND
m.Publ_Cli_Nro_Calle = D.numero AND
m.Publ_Cli_piso = D.piso
GROUP BY 
m.Publ_Cli_Apeliido,
m.Publ_Cli_Dni,
m.Publ_Cli_Fecha_Nac,
m.Publ_Cli_Mail,
m.Publ_Cli_Nombre,
m.Publ_Cli_Dni,
D.id
HAVING 
m.Publ_Cli_Dni IS NOT NULL

GO

--CARGO empresas
INSERT INTO THE_DISCRETABOY.Empresa
(
usuario,
cuit,
razon_social,
mail,
telefono,
direccion,
ciudad,
nombre_de_contacto,
fecha_creacion
)

SELECT 
'Empre_'+CAST(m.Publ_Empresa_Cuit as nvarchar(50)),
m.Publ_Empresa_Cuit,
m.Publ_Empresa_Razon_Social,
m.Publ_Empresa_Mail,
NULL,
THE_DISCRETABOY.f_buscar_PK_direc(m.Publ_Empresa_Dom_Calle,
m.Publ_Empresa_Cod_Postal,
m.Publ_Empresa_Depto,
m.Publ_Empresa_Nro_Calle,
m.Publ_Empresa_piso),
NULL,
NULL,
m.Publ_Empresa_Fecha_Creacion
FROM 
gd_esquema.Maestra m
GROUP BY 
m.Publ_Empresa_Cuit,
m.Publ_Empresa_Razon_Social,
m.Publ_Empresa_Mail,
m.Publ_Empresa_Fecha_Creacion,
m.Publ_Empresa_Dom_Calle,
m.Publ_Empresa_Cod_Postal,
m.Publ_Empresa_Depto,
m.Publ_Empresa_Nro_Calle,
m.Publ_Empresa_piso
HAVING 
m.Publ_Empresa_Cuit IS NOT NULL
GO

--CARGO Visibilidades

INSERT INTO THE_DISCRETABOY.Visibilidad
(codigo,
descripcion,
porcentaje,
precio_por_pub
)
SELECT 
m.Publicacion_Visibilidad_Cod,
m.Publicacion_Visibilidad_Desc,
m.Publicacion_Visibilidad_Porcentaje,
m.Publicacion_Visibilidad_Precio
FROM 
gd_esquema.Maestra m
WHERE 
M.Publicacion_Visibilidad_Cod IS NOT NULL
GROUP BY 
m.Publicacion_Visibilidad_Cod,
m.Publicacion_Visibilidad_Desc,
m.Publicacion_Visibilidad_Porcentaje,
m.Publicacion_Visibilidad_Precio

GO
--CARGO Visibilidades POR USUARIOS
INSERT INTO THE_DISCRETABOY.Visibilidad_por_user
(
Visibilidad,
usuario,
cant_ventas
)
(
SELECT
M.Publicacion_Visibilidad_Cod,
C.usuario,
0
FROM
gd_esquema.Maestra M,THE_DISCRETABOY.Cliente C
WHERE M.Publ_Cli_Dni=C.doc_numero
GROUP BY 
M.Publicacion_Visibilidad_Cod,
C.usuario

UNION

SELECT
M.Publicacion_Visibilidad_Cod,
E.usuario,
0
FROM
gd_esquema.Maestra M,THE_DISCRETABOY.Empresa E
WHERE M.Publ_Empresa_Cuit=E.cuit
GROUP BY 
M.Publicacion_Visibilidad_Cod,
E.usuario
)

GO
--CARGO ESTADOS
INSERT INTO THE_DISCRETABOY.Estado(NOMBRE)VALUES('Borrador')
INSERT INTO THE_DISCRETABOY.Estado(NOMBRE)VALUES('Publicada')
INSERT INTO THE_DISCRETABOY.Estado(NOMBRE)VALUES('Pausada')
INSERT INTO THE_DISCRETABOY.Estado(NOMBRE)VALUES('Finalizada')

--CARGO PUBLICACIONES
SET IDENTITY_INSERT THE_DISCRETABOY.Publicacion ON
INSERT INTO THE_DISCRETABOY.Publicacion
(
id,
estado,
Visibilidad,
usuario,
descripcion,
fecha,
fecha_venc
)
SELECT
M.Publicacion_Cod,
(
SELECT TOP 1
E.ID
FROM
THE_DISCRETABOY.ESTADO E
WHERE
E.NOMBRE = M.PUBLICACION_ESTADO
),
M.Publicacion_Visibilidad_Cod,
'Empre_'+CAST(m.Publ_Empresa_Cuit as nvarchar(50)),
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc
FROM gd_esquema.Maestra M
WHERE M.Publicacion_Cod IS NOT NULL AND M.Publ_Empresa_Cuit IS NOT NULL
GROUP BY 
M.Publicacion_Cod,
M.Publicacion_Estado,
M.Publicacion_Visibilidad_Cod,
M.Publ_Empresa_Cuit,
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc

UNION

SELECT
M.Publicacion_Cod,
(
SELECT TOP 1
E.ID
FROM
THE_DISCRETABOY.ESTADO E
WHERE
E.NOMBRE = M.PUBLICACION_ESTADO
),
M.Publicacion_Visibilidad_Cod,
'Clie_'+cast(M.Publ_Cli_Dni as nvarchar(20)),
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc
FROM gd_esquema.Maestra M
WHERE M.Publicacion_Cod IS NOT NULL AND M.Publ_Cli_Dni IS NOT NULL
GROUP BY 
M.Publicacion_Cod,
M.Publicacion_Estado,
M.Publicacion_Visibilidad_Cod,
M.Publ_Cli_Dni,
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc

SET IDENTITY_INSERT THE_DISCRETABOY.Publicacion OFF
GO

--CARGO COMPRAS
INSERT INTO THE_DISCRETABOY.compra
(
cliente,
publicacion,
fecha,
cant_comprada
)
SELECT
'Clie_'+CAST(m.Cli_Dni as nvarchar(20)),
M.Publicacion_Cod,
M.Compra_Fecha,
M.Compra_Cantidad
FROM gd_esquema.Maestra M
WHERE M.Compra_Cantidad IS NOT NULL
GROUP BY
M.Cli_Dni,
M.Publicacion_Cod,
M.Compra_Fecha,
M.Compra_Cantidad

GO
--CARGO CALIFICACIONES
SET IDENTITY_INSERT THE_DISCRETABOY.Calificacion ON
INSERT INTO THE_DISCRETABOY.Calificacion
(
id,
compra,
cant_estrellas,
descrip
)
SELECT 
DISTINCT 
m.Calificacion_Codigo,
(
SELECT TOP 1
COM.id
FROM
THE_DISCRETABOY.compra COM
WHERE
COM.fecha = M.Compra_Fecha AND
COM.publicacion = M.Publicacion_Cod AND
COM.cliente = 'Clie_'+CAST(M.Cli_Dni as nvarchar(20))
),
m.Calificacion_Cant_Estrellas,
m.Calificacion_Descripcion
FROM gd_esquema.Maestra m
WHERE 
m.Calificacion_Codigo IS NOT NULL

SET IDENTITY_INSERT THE_DISCRETABOY.Calificacion OFF
GO
--CARGO FACTURAS
SET IDENTITY_INSERT THE_DISCRETABOY.Factura ON
INSERT INTO THE_DISCRETABOY.Factura
(
numero,
fecha,
total
)
SELECT
M.Factura_Nro,
M.Factura_Fecha,
M.Factura_Total
FROM gd_esquema.Maestra M
WHERE M.Factura_Nro IS NOT NULL
GROUP BY
M.Factura_Nro,
M.Factura_Fecha,
M.Factura_Total

GO
SET IDENTITY_INSERT THE_DISCRETABOY.Factura OFF

--CARGO OFERTAS
INSERT INTO THE_DISCRETABOY.Oferta
(
cliente,
publicacion,
fecha,
monto_ofertado
)
SELECT
'Clie_'+CAST(M.Cli_Dni as nvarchar(20)),
M.Publicacion_Cod,
M.Oferta_Fecha,
M.Oferta_Monto
FROM
gd_esquema.Maestra M
WHERE M.Oferta_Fecha IS NOT NULL

GO

--CARGO RUBROS
INSERT INTO THE_DISCRETABOY.Rubro
(
descripcion
)
SELECT
M.Publicacion_Rubro_Descripcion
FROM
gd_esquema.Maestra M
GROUP BY
M.Publicacion_Rubro_Descripcion

GO

--CARGO RUBROS POR PUBLICACION
INSERT INTO THE_DISCRETABOY.Rubro_por_publicacion
(
rubro,
publicacion
)
SELECT
R.codigo,
M.Publicacion_Cod
FROM gd_esquema.Maestra M,THE_DISCRETABOY.Rubro R
WHERE R.descripcion=M.Publicacion_Rubro_Descripcion AND
M.Publicacion_Cod IS NOT NULL AND
M.Publicacion_Rubro_Descripcion IS NOT NULL
GROUP BY
R.codigo,
M.Publicacion_Cod

GO

--CARGO SUBASTAS
INSERT INTO THE_DISCRETABOY.Subasta
(
cantidad,
publicacion
)
SELECT
M.Publicacion_Stock,
M.Publicacion_Cod
FROM gd_esquema.Maestra M
WHERE M.Publicacion_Tipo = 'Subasta'
GROUP BY
M.Publicacion_Cod,
M.Publicacion_Stock

GO
--CARGO LAS COMPRAS PARA QUIENES GANARON LAS SUBASTAS
CREATE FUNCTION THE_DISCRETABOY.get_estado_publi
(@PUBLI NUMERIC(18,0))
RETURNS NVARCHAR(255)
AS
BEGIN
DECLARE @ESTADO NVARCHAR(255)
SELECT TOP 1
@ESTADO = E.NOMBRE
FROM
THE_DISCRETABOY.PUBLICACION P
LEFT JOIN THE_DISCRETABOY.ESTADO E ON
P.ESTADO = E.ID
WHERE P.ID = @PUBLI
RETURN @ESTADO
END

GO

INSERT INTO THE_DISCRETABOY.compra
(
publicacion,
cliente,
cant_comprada,
fecha
)
SELECT
S.publicacion,
O.cliente,
S.cantidad,
O.fecha
FROM
THE_DISCRETABOY.Subasta S,
THE_DISCRETABOY.Oferta O
WHERE 
S.publicacion = O.publicacion AND
THE_DISCRETABOY.ESTA_FINALIZADA(O.publicacion) = 1 AND
THE_DISCRETABOY.F_SUBASTA_PRECIO_ACTUAL(S.id) = O.monto_ofertado

GO
--CARGO RENGLONES DE FACTURAS
INSERT INTO THE_DISCRETABOY.Renglon_factura
(
factura,
publicacion,
forma_de_pago
)
SELECT
M.Factura_Nro,
M.Publicacion_Cod,
M.Forma_Pago_Desc
FROM gd_esquema.Maestra M
WHERE
M.Factura_Nro IS NOT NULL
GROUP BY
M.Factura_Nro,
M.Publicacion_Cod,
M.Forma_Pago_Desc

GO

--CARGO VENTAS DIRECTAS
INSERT INTO THE_DISCRETABOY.Venta_directa
(
publicacion,
stock
)
SELECT
M.Publicacion_Cod,
MIN(M.Publicacion_Stock)
FROM
gd_esquema.Maestra M
WHERE M.Publicacion_Tipo='Compra inmediata'
GROUP BY
M.Publicacion_Cod

GO

--Alta roles default.
EXEC THE_DISCRETABOY.alta_rol 'Empresa', 1
EXEC THE_DISCRETABOY.alta_rol 'Administrativo', 1
EXEC THE_DISCRETABOY.alta_rol 'Cliente', 1

--****************Generacion de usuarion admin**********************
INSERT INTO THE_DISCRETABOY.Usuario
(
username,
password,
pass_definitiva,
habilitado,
intentos
)
VALUES
(
'admin',
'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',--w23e
1,
1,
0
)

--			Creacion de su rol "Administrador General"
EXEC THE_DISCRETABOY.alta_rol
'Administrador General',
1
--			Se asignan todas las funciones exIStentes
INSERT INTO THE_DISCRETABOY.Funcion_por_rol
(
funcion,
rol
)
SELECT
F.cod_funcion,
R.cod_rol
FROM THE_DISCRETABOY.Funcion F,THE_DISCRETABOY.Rol R
WHERE R.nombre = 'Administrador General'

GO
--			Se determina la asignacion de todas las funciones creadas en el futuro
Create trigger THE_DISCRETABOY.tr_asignar_funcion_a_admin
on THE_DISCRETABOY.Funcion
after insert
as
BEGIN

    set nocount on;

    declare
    @rol_admin numeric(18,0),
    @funcion_nueva numeric(18,0)

    select @funcion_nueva = cod_funcion 
    from inserted

    SET @rol_admin = THE_DISCRETABOY.f_cod_rol('Administrador General')

    begin
        insert into THE_DISCRETABOY.funcion_por_rol values(@rol_admin, @funcion_nueva)
    end
END

GO
--			Se le asigna el rol de Administrador General al admin
INSERT INTO THE_DISCRETABOY.Rol_por_user
(
rol,
usuario
)
SELECT
R.cod_rol,
'admin'
FROM
THE_DISCRETABOY.Rol R
WHERE 
R.nombre = 'Administrador General'

--CREACION FUNCIONES
--FUNCIONES COMUNES A TODOS
EXEC THE_DISCRETABOY.alta_funcion 'Publicar'
EXEC THE_DISCRETABOY.alta_funcion 'Editar publicación'
EXEC THE_DISCRETABOY.alta_funcion 'Gestionar preguntas'
EXEC THE_DISCRETABOY.alta_funcion 'Facturar publicaciones'
EXEC THE_DISCRETABOY.alta_funcion 'Listado estadístico'
--LAS ASIGNO A LOS ROLES
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Publicar','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Publicar','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Editar publicación','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Editar publicación','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Gestionar preguntas','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Gestionar preguntas','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Facturar publicaciones','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Facturar publicaciones','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Listado estadístico','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Listado estadístico','Empresa'
--FUNCIONES NO PARA EMPRESAS
EXEC THE_DISCRETABOY.alta_funcion 'Calificar vendedor'
EXEC THE_DISCRETABOY.alta_funcion 'Historial de cliente'
EXEC THE_DISCRETABOY.alta_funcion 'Comprar/ Ofertar'
--LAS ASIGNO A LOS ROLES
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Calificar vendedor','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Historial de cliente','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Comprar/ Ofertar','Cliente'
--FUNCIONES SOLO PARA EL ADMINISTRADOR GENERAL
EXEC THE_DISCRETABOY.alta_funcion 'ABM de Rol'
EXEC THE_DISCRETABOY.alta_funcion 'ABM de Cliente'
EXEC THE_DISCRETABOY.alta_funcion 'ABM de Empresa'
EXEC THE_DISCRETABOY.alta_funcion 'ABM de Visibilidad'


GO
--CARGO ROLES DE USUARIOS CREADOS DE CLIENTES
INSERT INTO THE_DISCRETABOY.Rol_por_user
(
rol,
usuario
)
SELECT
THE_DISCRETABOY.f_cod_rol('Cliente'),
C.usuario
FROM
THE_DISCRETABOY.Cliente C,THE_DISCRETABOY.Usuario U
WHERE C.usuario=U.username

GO
--CARGO ROLES DE USUARIOS CREADOS DE EMPRESAS
INSERT INTO THE_DISCRETABOY.Rol_por_user
(
rol,
usuario
)
SELECT
THE_DISCRETABOY.f_cod_rol('Empresa'),
E.usuario
FROM
THE_DISCRETABOY.Empresa E,THE_DISCRETABOY.Usuario U
WHERE E.usuario=U.username

GO