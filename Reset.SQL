USE [GD2C2013]
GO

BEGIN TRAN
GO
--  Drop Foreign Key Constraints 
ALTER TABLE CUATRO_QUESOS.Afiliados DROP CONSTRAINT FK_Afiliados_Planes
;

ALTER TABLE CUATRO_QUESOS.Afiliados DROP CONSTRAINT FK_Nro_Conyuge
;

ALTER TABLE CUATRO_QUESOS.Afiliados DROP CONSTRAINT FK_Nro_Titular
;

ALTER TABLE CUATRO_QUESOS.Bonos DROP CONSTRAINT FK_Bonos_Afiliados
;

ALTER TABLE CUATRO_QUESOS.Bonos DROP CONSTRAINT FK_Bonos_Usuarios
;

ALTER TABLE CUATRO_QUESOS.Bonos DROP CONSTRAINT FK_Bonos_Compra
;

ALTER TABLE CUATRO_QUESOS.Bonos DROP CONSTRAINT FK_Bonos_Planes_Medicos
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan DROP CONSTRAINT FK_Afiliado
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan DROP CONSTRAINT FK_Plan_Destino
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan DROP CONSTRAINT FK_Plan_Origen
;

ALTER TABLE CUATRO_QUESOS.Cancelaciones DROP CONSTRAINT FK_Cancelaciones_Turnos
;


ALTER TABLE CUATRO_QUESOS.Compra DROP CONSTRAINT FK_Compra_Afiliados
;

ALTER TABLE CUATRO_QUESOS.Consultas DROP CONSTRAINT FK_Consultas_Bonos
;
ALTER TABLE CUATRO_QUESOS.Consultas DROP CONSTRAINT FK_Consultas_Turnos
;


ALTER TABLE CUATRO_QUESOS.Dias_Atencion DROP CONSTRAINT FK_Dias_Atencion_Medicos
;

ALTER TABLE CUATRO_QUESOS.Especialidades DROP CONSTRAINT FK_Especialidades_Tipos_Especialidades
;


ALTER TABLE CUATRO_QUESOS.Especialidades_Medicos DROP CONSTRAINT FK_Especialidades_Medicos_Especialidades
;


ALTER TABLE CUATRO_QUESOS.Especialidades_Medicos DROP CONSTRAINT FK_Especialidades_Medicos_Medicos
;


ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta DROP CONSTRAINT FK_Medicamentos_Por_Consulta_Bonos
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta DROP CONSTRAINT FK_Medicamentos_Por_Consulta_Consultas
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta DROP CONSTRAINT FK_Medicamentos_Por_Consulta_Medicamentos
;

ALTER TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades DROP CONSTRAINT FK_Roles_Por_Funcionalidades_Funcionalidades
;

ALTER TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades DROP CONSTRAINT FK_Roles_Por_Funcionalidades_Roles
;

ALTER TABLE CUATRO_QUESOS.Turnos DROP CONSTRAINT FK_Turnos_Afiliados
;

ALTER TABLE CUATRO_QUESOS.Turnos DROP CONSTRAINT FK_Turnos_Especialidades
;

ALTER TABLE CUATRO_QUESOS.Turnos DROP CONSTRAINT FK_Turnos_Medicos
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Por_Rol DROP CONSTRAINT FK_Usuarios_Por_Rol_Roles
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Por_Rol DROP CONSTRAINT FK_Usuarios_Por_Rol_Usuarios
;


--  Drop Tables, Stored Procedures and Views 

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Afiliados') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Afiliados
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Bonos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Bonos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Cambios_Plan') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Cambios_Plan
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Cancelaciones') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Cancelaciones
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Compra') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Compra
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Consultas') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Consultas
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Dias_Atencion') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Dias_Atencion
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Especialidades') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Especialidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Especialidades_Medicos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Especialidades_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Funcionalidades') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Funcionalidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicamentos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicamentos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicamentos_Por_Consulta') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Planes_Medicos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Planes_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Roles') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Roles
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Roles_Por_Funcionalidades') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Tipos_Especialidades') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Tipos_Especialidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Turnos') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Turnos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios_Por_Rol') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios_Por_Rol
;

DROP SCHEMA [CUATRO_QUESOS]
GO

COMMIT