
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

-- Create Tables
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
	precio_por_pub [numeric](18, 2) NOT NULL
);

CREATE TABLE THE_DISCRETABOY.Publicacion (
	id [numeric](18, 0) NOT NULL, --PK
	estado [nvarchar](255),
	Visibilidad numeric(18),--FK
	descripcion [nvarchar](255),
	fecha [datetime],
	fecha_venc [datetime]
);

CREATE TABLE THE_DISCRETABOY.Venta_directa (
	id numeric(18) NOT NULL Identity(1,1), --PK
	stock [numeric](18, 0) NOT NULL,
	publicacion [numeric](18,0) NOT NULL---FK
);

CREATE TABLE THE_DISCRETABOY.Cliente_por_publicacion (
	cliente nvarchar(20) NOT NULL, --FK --PK
	publicacion [numeric](18, 0) NOT NULL --FK --PK
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

CREATE TABLE THE_DISCRETABOY.Compra_inmediata (
	id numeric(18) NOT NULL Identity(1,1), --PK
	cliente nvarchar(20) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL, --FK
	fecha [datetime],
	cant_comprada [numeric](18, 0),
	calificacion [numeric](18, 0) ---FK
);

CREATE TABLE THE_DISCRETABOY.Calificacion (
	id [numeric](18, 0) NOT NULL, --PK
	cant_estrellas [numeric](18, 0),
	descrip [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Oferta (
	id numeric(18) NOT NULL Identity(1,1), ---PK
	cliente nvarchar(20) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL, --FK
	fecha [datetime],
	monto_ofertado [numeric](18, 2),
	calificacion [numeric](18, 0) default NULL ---FK
);

CREATE TABLE THE_DISCRETABOY.Factura (
	numero [numeric](18, 0) NOT NULL, --PK
	fecha [datetime],
	total [numeric](18, 2)
);

CREATE TABLE THE_DISCRETABOY.Renglon_factura (
	factura [numeric](18, 0) NOT NULL, --FK ---PK
	nro_renglon numeric(18) NOT NULL Identity(1,1), ---PK
	publicacion [numeric](18, 0), ---FK
	forma_de_pago numeric(18) ---FK
);

CREATE TABLE THE_DISCRETABOY.Forma_de_pago (
	id numeric(18) NOT NULL Identity(1,1), ---PK
	descripcion [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Rubro_por_publicacion (
	publicacion [numeric](18, 0) NOT NULL, --FK---pk
	rubro [numeric](18, 0) NOT NULL --FK---pk
);

CREATE TABLE THE_DISCRETABOY.Subasta (
	id [numeric](18, 0) NOT NULL Identity(1,1), --PK
	cantidad [numeric](18, 0),
	publicacion [numeric](18, 0)---FK
);

CREATE TABLE THE_DISCRETABOY.Rubro (
	codigo [numeric](18, 0) NOT NULL Identity(1,1), --PK
	descripcion [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Tarjeta_credito (
	numero [numeric](16, 0) NOT NULL, --PK
	nombre [nvarchar](255),
	apellido [nvarchar](255),
	valido_desde datetime NOT NULL,
	valido_hasta datetime NOT NULL,
	cod_segur [nvarchar](5),
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

-- UNIQUE Constraints ...

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

ALTER TABLE THE_DISCRETABOY.Cliente_por_publicacion ADD CONSTRAINT PK_Cliente_por_publicacion
        PRIMARY KEY CLUSTERED (cliente,publicacion)
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

ALTER TABLE THE_DISCRETABOY.Compra_inmediata ADD CONSTRAINT PK_Compra_inmediata
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

ALTER TABLE THE_DISCRETABOY.Forma_de_pago ADD CONSTRAINT PK_Forma_de_pago
        PRIMARY KEY CLUSTERED (id)
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

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT FK_Public_vISib
        FOREIGN KEY (Visibilidad) REFERENCES THE_DISCRETABOY.Visibilidad (codigo)
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

ALTER TABLE THE_DISCRETABOY.Venta_directa ADD CONSTRAINT FK_Venta_directa
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Cliente_por_publicacion ADD CONSTRAINT FK_Cliente_por_publicacion_cliente
        FOREIGN KEY (cliente) REFERENCES THE_DISCRETABOY.Cliente (usuario)
;

ALTER TABLE THE_DISCRETABOY.Cliente_por_publicacion ADD CONSTRAINT FK_Cliente_por_publicacion_public
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Oferta with check ADD CONSTRAINT FK_Oferta_cli_pub
        FOREIGN KEY (cliente,publicacion) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (cliente,publicacion)
;

ALTER TABLE THE_DISCRETABOY.Oferta with check ADD CONSTRAINT FK_Oferta_calif
        FOREIGN KEY (calificacion) REFERENCES THE_DISCRETABOY.Calificacion (id)
;

ALTER TABLE THE_DISCRETABOY.Compra_inmediata with check ADD CONSTRAINT FK_Compra_inmed_clien_pub
        FOREIGN KEY (cliente,publicacion) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (cliente,publicacion)
;

ALTER TABLE THE_DISCRETABOY.Compra_inmediata with check ADD CONSTRAINT FK_Compra_inmed_calif
        FOREIGN KEY (calificacion) REFERENCES THE_DISCRETABOY.Calificacion (id)
;

ALTER TABLE THE_DISCRETABOY.Pregunta with check ADD CONSTRAINT FK_Pregunta
        FOREIGN KEY (cliente,publicacion) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (cliente,publicacion)
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

ALTER TABLE THE_DISCRETABOY.Renglon_factura ADD CONSTRAINT FK_Reng_fact_forma_pago
        FOREIGN KEY (forma_de_pago) REFERENCES THE_DISCRETABOY.Forma_de_pago (id)
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

/* ****** Migrar datos existentes ******* */

--CARGO CALIFICACIONES
INSERT INTO THE_DISCRETABOY.Calificacion
(
id,
cant_estrellas,
descrip
)

SELECT 
DISTINCT m.Calificacion_Codigo as id,
m.Calificacion_Cant_Estrellas as cant_estrellas,
m.Calificacion_Descripcion as descrip
FROM gd_esquema.Maestra m
WHERE m.Calificacion_Codigo IS NOT NULL

GO

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

--CARGO PUBLICACIONES
INSERT INTO THE_DISCRETABOY.Publicacion
(
id,
estado,
Visibilidad,
descripcion,
fecha,
fecha_venc
)
SELECT
M.Publicacion_Cod,
M.Publicacion_Estado,
M.Publicacion_Visibilidad_Cod,
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc
FROM gd_esquema.Maestra M
WHERE M.Publicacion_Cod IS NOT NULL
GROUP BY 
M.Publicacion_Cod,
M.Publicacion_Estado,
M.Publicacion_Visibilidad_Cod,
M.Publicacion_Descripcion,
M.Publicacion_Fecha,
M.Publicacion_Fecha_Venc

GO

--CARGO CLIENTES POR PUBLICACIONES
INSERT INTO THE_DISCRETABOY.Cliente_por_publicacion
(
cliente,
publicacion
)
SELECT
'Clie_'+cast(M.Cli_Dni as nvarchar(20)),
M.Publicacion_Cod
FROM gd_esquema.Maestra M
WHERE M.Publicacion_Cod IS NOT NULL  AND M.Cli_Dni IS NOT NULL
GROUP BY
M.Publicacion_Cod,
M.Cli_Dni

GO


--CARGO COMPRAS INMEDIATAS
INSERT INTO THE_DISCRETABOY.Compra_inmediata
(
cliente,
publicacion,
fecha,
cant_comprada,
calificacion
)
SELECT
'Clie_'+CAST(m.Cli_Dni as nvarchar(20)),
M.Publicacion_Cod,
M.Compra_Fecha,
M.Compra_Cantidad,
M.Calificacion_Codigo
FROM gd_esquema.Maestra M
WHERE M.Compra_Cantidad IS NOT NULL

GO

--CARGO FACTURAS
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

--CARGO OFERTAS
INSERT INTO THE_DISCRETABOY.Oferta
(
cliente,
publicacion,
fecha,
monto_ofertado,
calificacion
)
SELECT
'Clie_'+CAST(M.Cli_Dni as nvarchar(20)),
M.Publicacion_Cod,
M.Oferta_Fecha,
M.Oferta_Monto,
M.Calificacion_Codigo
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

--CARGO FORMAS DE PAGO
INSERT INTO THE_DISCRETABOY.Forma_de_pago
(
descripcion
)
SELECT
M.Forma_Pago_Desc
FROM gd_esquema.Maestra M
WHERE M.Forma_Pago_Desc IS NOT NULL
GROUP BY M.Forma_Pago_Desc

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
FP.id
FROM gd_esquema.Maestra M,THE_DISCRETABOY.Forma_de_pago FP
WHERE
M.Factura_Nro IS NOT NULL AND
FP.descripcion=M.Forma_Pago_Desc
GROUP BY
M.Factura_Nro,
M.Publicacion_Cod,
FP.id

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
EXEC THE_DISCRETABOY.alta_funcion 'Rendir compras'
EXEC THE_DISCRETABOY.alta_funcion 'Listado estadístico'
--LAS ASIGNO A LOS ROLES
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Publicar','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Publicar','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Editar publicación','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Editar publicación','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Gestionar preguntas','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Gestionar preguntas','Empresa'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Rendir compras','Cliente'
EXEC THE_DISCRETABOY.alta_funcion_por_rol_nombres 'Rendir compras','Empresa'
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