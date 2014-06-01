USE [GD1C2014]
GO

--BEGIN TRAN DEFINICION_TABLAS
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
	aprellido [nvarchar](255),
	mail [nvarchar](255),
	telefono [numeric](18),
	direccion numeric(18) NOT NULL, --FK
	fecha_nacimiento [datetime]
);

CREATE TABLE THE_DISCRETABOY.Direccion (
	id numeric(18) NOT NULL Identity(1,1), --PK
	calle [nvarchar](255),
	numero [numeric](18, 0),
	pISo [numeric](18, 0),
	depto [nvarchar](50),
	cod_post [nvarchar](50),
	localidad [nvarchar](255)
);

CREATE TABLE THE_DISCRETABOY.Usuario (
	username nvarchar(20) NOT NULL,--PK
	password binary(32) NOT NULL,
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
@pISo numeric(18,0)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN (SELECT d.id FROM THE_DISCRETABOY.Direccion d
				WHERE d.calle=@calle and
				d.cod_post=@CP and
				d.depto=@departamento and
				d.numero=@nro and
				d.pISo=@pISo)
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

CREATE PROC THE_DISCRETABOY.get_funciones
AS
BEGIN
SELECT cod_funcion 'CodigoFuncion', nombre 'Nombre'
FROM THE_DISCRETABOY.Funcion
END

GO

CREATE PROC THE_DISCRETABOY.get_roles
AS
BEGIN
SELECT R.cod_rol 'CodigoRol', R.nombre 'Nombre'
FROM THE_DISCRETABOY.Rol R
END

GO

--INCREMENTAR CANTIDAD DE INTENTOS DE INGRESO DEL USUARIO
CREATE PROC THE_DISCRETABOY.increm_intent_fallidos_usuario
(@usuario nvarchar(20))
AS
UPDATE THE_DISCRETABOY.Usuario
SET intentos=intentos+1
WHERE username=@usuario

GO

CREATE PROC THE_DISCRETABOY.traer_roles
AS
SELECT * FROM THE_DISCRETABOY.Rol

GO
/* ****** Migrar datos exIStentes ******* */

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
pISo,
depto,
cod_post
)
SELECT 
m.Cli_Dom_Calle as calle,
m.Cli_Nro_Calle as numero,
m.Cli_PISo as pISo,
m.Cli_Depto as depto,
m.Cli_Cod_Postal as cod_post
FROM gd_esquema.Maestra m
GROUP BY m.Cli_Dom_Calle,m.Cli_Nro_Calle,m.Cli_PISo,m.Cli_Depto,m.Cli_Cod_Postal
HAVING Cli_Dom_Calle IS NOT NULL

UNION

SELECT 
m.Publ_Empresa_Dom_Calle as calle,
m.Publ_Empresa_Nro_Calle as numero,
m.Publ_Empresa_PISo as pISo,
m.Publ_Empresa_Depto as depto,
m.Publ_Empresa_Cod_Postal as cod_post
FROM gd_esquema.Maestra m
GROUP BY Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,Publ_Empresa_PISo,Publ_Empresa_Depto,Publ_Empresa_Cod_Postal
HAVING Publ_Empresa_Dom_Calle IS NOT NULL

UNION

SELECT 
m.Publ_Cli_Dom_Calle as calle,
m.Publ_Cli_Nro_Calle as numero,
m.Publ_Cli_PISo as pISo,
m.Publ_Cli_Depto as depto,
m.Publ_Cli_Cod_Postal as cod_post	
FROM gd_esquema.Maestra m
GROUP BY Publ_Cli_Dom_Calle,Publ_Cli_Nro_Calle,Publ_Cli_PISo,Publ_Cli_Depto,Publ_Cli_Cod_Postal
HAVING Publ_Cli_Dom_Calle IS NOT NULL	
GO

--CARGO usuarios de clientes
INSERT INTO THE_DISCRETABOY.Usuario
(
username,
password,
intentos,
habilitado
)
SELECT 
	'Clie_'+CAST(m.Cli_Dni as nvarchar(20)) as username,--Se determina que el nombre de los preexIStentes será Clie más el dni.
	0xe00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29,--La password es UTNFRBA	
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
intentos,
habilitado
)
SELECT 
	'Empre_'+CAST(m.Publ_Empresa_Cuit as nvarchar(50)) as username,--Se determina que el nombre de los preexIStentes será Empre_ más el CUIT.
	0xe00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29,--La password es UTNFRBA	
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
aprellido,
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
m.Cli_PISo = D.pISo
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
m.Publ_Cli_PISo = D.pISo
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
m.Publ_Empresa_PISo),
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
m.Publ_Empresa_PISo
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

--CARGO VisibilidadES POR USUARIOS
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
habilitado,
intentos
)
VALUES
(
'admin',
0xe6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7,--w23e
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
CREATE TRIGGER THE_DISCRETABOY.asignar_funcion_a_admin
ON THE_DISCRETABOY.Funcion
FOR INSERT --Trigger para que las funciones creadas se le asignen al rol Administrador General.
AS
BEGIN
DECLARE @rol_admin numeric(18,0) = THE_DISCRETABOY.f_cod_rol('Administrador General')
EXEC THE_DISCRETABOY.alta_funcion_por_rol
cod_funcion,
@rol_admin
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