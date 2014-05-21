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
	usuario numeric(18) NOT NULL, --FK ---PK
	cuit [nvarchar](50) NOT NULL,
	razon_social [nvarchar](255),
	mail [nvarchar](255),
	telefono [numeric](18),
	direccion numeric(18) NOT NULL, ---FK
	ciudad [nvarchar](255),
	nombre_de_contacto [nvarchar](255),
	fecha_creacion [datetime]
);

CREATE TABLE THE_DISCRETABOY.Cliente (
	usuario numeric(18) NOT NULL UNIQUE, --FK ---PK
	doc_numero [numeric](18, 0),
	doc_tipo varchar(3) NOT NULL CHECK(doc_tipo = 'DNI' OR doc_tipo = 'LE' OR doc_tipo = 'LC'), -- DNI (Documento Nacional de Identidad), LE (Libreta de Enrolamiento), LC (Libreta Civica)
	nombre [nvarchar](255),
	aprellido [nvarchar](255),
	mail [nvarchar](255),
	telefono [numeric](18),
	direccion numeric(18) NOT NULL, ---FK
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
	id numeric(18) NOT NULL Identity(1,1), --PK
	username nvarchar(20) NOT NULL,
	password binary(32) NOT NULL,
	intentos tinyint,
	habilitado bit
);

CREATE TABLE THE_DISCRETABOY.Rol_por_user (
	usuario numeric(18) NOT NULL, --FK ---PK
	rol numeric(18) NOT NULL	--FK ---PK
);

CREATE TABLE THE_DISCRETABOY.Rol(
	cod_rol numeric(18) NOT NULL Identity(1,1), --PK
	nombre varchar(255) NOT NULL,
	habilitado bit
);

CREATE TABLE THE_DISCRETABOY.Funcion_por_rol (
	rol numeric(18) NOT NULL, --FK ---PK
	funcion numeric(18) NOT NULL --FK ---PK
);

CREATE TABLE THE_DISCRETABOY.Funcion (
	cod_funcion numeric(18) NOT NULL Identity(1,1), --PK
	nombre varchar(255) NOT NULL
);

CREATE TABLE THE_DISCRETABOY.Visibilidad_por_user (
	usuario numeric(18) NOT NULL, --FK---pk
	visibilidad numeric(18) NOT NULL,--FK---pk
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
	visibilidad numeric(18),---FK
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
	id numeric(18) NOT NULL Identity(1,1), ---PK
	cliente numeric(18) NOT NULL, --FK
	publicacion [numeric](18, 0) NOT NULL --FK
);

CREATE TABLE THE_DISCRETABOY.Pregunta (
	id numeric(18) NOT NULL Identity(1,1), --PK
	descripcion [nvarchar](255) NOT NULL,
	cliente_por_pub numeric(18) NOT NULL, ---FK
);

CREATE TABLE THE_DISCRETABOY.Compra_inmediata (
	id numeric(18) NOT NULL Identity(1,1), --PK
	cliente_por_pub numeric(18), ---FK
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
	cliente_por_pub numeric(18) NOT NULL, --FK
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
	nro_renglon numeric(18) NOT NULL, ---PK
	publicacion [numeric](18, 0), ---FK
	forma_de_pago numeric(18) ---fk
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
	precio_actual [numeric](18, 2),
	ultima_oferta numeric(18) NOT NULL,---FK
	publicacion [numeric](18, 0)---FK
);

CREATE TABLE THE_DISCRETABOY.Rubro (
	codigo [numeric](18, 0) NOT NULL Identity(1,1), --PK
	descripcion [nvarchar](255)
);

-- CHECK Constraints

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
        PRIMARY KEY CLUSTERED (id)
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
        PRIMARY KEY CLUSTERED (usuario,visibilidad)
;

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT PK_Publicacion
        PRIMARY KEY CLUSTERED (id)
;

ALTER TABLE THE_DISCRETABOY.Cliente_por_publicacion ADD CONSTRAINT PK_Cliente_por_publicacion
        PRIMARY KEY CLUSTERED (id)
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
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (id)
;

ALTER TABLE THE_DISCRETABOY.Empresa ADD CONSTRAINT FK_Empresa_direccion
        FOREIGN KEY (direccion) REFERENCES THE_DISCRETABOY.Direccion (id)
;

ALTER TABLE THE_DISCRETABOY.Cliente ADD CONSTRAINT FK_Cliente_user
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (id)
;

ALTER TABLE THE_DISCRETABOY.Cliente ADD CONSTRAINT FK_Cliente_direccion
        FOREIGN KEY (direccion) REFERENCES THE_DISCRETABOY.Direccion (id)
;

ALTER TABLE THE_DISCRETABOY.Publicacion ADD CONSTRAINT FK_Public_visib
        FOREIGN KEY (visibilidad) REFERENCES THE_DISCRETABOY.Visibilidad (codigo)
;

ALTER TABLE THE_DISCRETABOY.Rol_por_user ADD CONSTRAINT FK_Rol_por_user_usuario
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (id)
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

ALTER TABLE THE_DISCRETABOY.Visibilidad_por_user ADD CONSTRAINT FK_Visibilidad_por_user_visib
        FOREIGN KEY (visibilidad) REFERENCES THE_DISCRETABOY.Visibilidad (codigo)
;

ALTER TABLE THE_DISCRETABOY.Visibilidad_por_user ADD CONSTRAINT FK_Visibilidad_por_user_usuario
        FOREIGN KEY (usuario) REFERENCES THE_DISCRETABOY.Usuario (id)
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
        FOREIGN KEY (cliente_por_pub) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Oferta with check ADD CONSTRAINT FK_Oferta_calif
        FOREIGN KEY (calificacion) REFERENCES THE_DISCRETABOY.Calificacion (id)
;

ALTER TABLE THE_DISCRETABOY.Compra_inmediata with check ADD CONSTRAINT FK_Compra_inmed_clien_pub
        FOREIGN KEY (cliente_por_pub) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (id)
;

ALTER TABLE THE_DISCRETABOY.Compra_inmediata with check ADD CONSTRAINT FK_Compra_inmed_calif
        FOREIGN KEY (calificacion) REFERENCES THE_DISCRETABOY.Calificacion (id)
;

ALTER TABLE THE_DISCRETABOY.Pregunta with check ADD CONSTRAINT FK_Pregunta
        FOREIGN KEY (cliente_por_pub) REFERENCES THE_DISCRETABOY.Cliente_por_publicacion (id)
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

ALTER TABLE THE_DISCRETABOY.Subasta ADD CONSTRAINT FK_subasta_ult_oferta
        FOREIGN KEY (ultima_oferta) REFERENCES THE_DISCRETABOY.Oferta (id)
;

ALTER TABLE THE_DISCRETABOY.Subasta ADD CONSTRAINT FK_subasta_public
        FOREIGN KEY (publicacion) REFERENCES THE_DISCRETABOY.Publicacion (id)
;

--Create other constraints


/* ****** Migrar datos existentes ******* */

--Calificaciones

INSERT INTO THE_DISCRETABOY.Calificacion
        (
        id,
        cant_estrellas,
        descrip
        )
        
        select distinct m.Calificacion_Codigo as id,
				m.Calificacion_Cant_Estrellas as cant_estrellas,
				m.Calificacion_Descripcion as descrip
		from gd_esquema.Maestra m
			where m.Calificacion_Codigo is not NULL
;

