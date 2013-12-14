USE [GD2C2013]
GO

BEGIN TRAN
GO
CREATE SCHEMA [CUATRO_QUESOS] AUTHORIZATION [gd]
GO

SET LANGUAGE 'Español'
SET DATEFIRST 1
GO

-- Funcion con la fecha de migracion

CREATE FUNCTION CUATRO_QUESOS.FechaMigracion() --esta funcion almacena la fecha que se utiliza en la migracion como referencia
RETURNS datetime
AS
BEGIN

RETURN CAST('2014-01-01T12:00:00' as datetime)

END
GO

-- Create Tables
CREATE TABLE CUATRO_QUESOS.Afiliados (
        Nro_Afiliado numeric(18) NOT NULL,
        Nombre varchar(255) NOT NULL,
        Apellido varchar(255) NOT NULL,
        Sexo char(1) NOT NULL CHECK(Sexo = 'M' OR Sexo = 'F' OR Sexo = '-'), --puede ser M (masculino), F (femenino), o '-' (indefinido o migrado)
        Tipo_Doc varchar(3) NOT NULL CHECK(Tipo_Doc = 'DNI' OR Tipo_Doc = 'LE' OR Tipo_Doc = 'LC'), -- DNI (Documento Nacional de Identidad), LE (Libreta de Enrolamiento), LC (Libreta Civica)
        Nro_Doc numeric(18) NOT NULL,
        Direccion varchar(255) NOT NULL,
        Mail varchar(255), --puede o no tener mail, se decidio que no es obligatorio tenerlo
        Telefono numeric(18) NOT NULL,
        Fecha_Nac datetime NOT NULL,
        Cod_Plan numeric(18) NOT NULL,
        Estado_Civil varchar(255) NOT NULL,
        Nro_Titular numeric(18) DEFAULT NULL,
        Nro_Conyuge numeric(18)DEFAULT NULL,
        Fecha_Baja datetime DEFAULT NULL,
        Nro_Consulta int DEFAULT 0, --por default no tiene consultas realizadas cuando se crea
        CantFamiliaresACargo tinyint NOT NULL DEFAULT 0 --por default no tiene familiares a cargo cuando se crea
)
;

CREATE TABLE CUATRO_QUESOS.Agendas_Medicos(
		Id_Medico numeric(18) NOT NULL,
		Fecha_Hora datetime NOT NULL,
		Nro_Turno numeric(18)
)
;


CREATE TABLE CUATRO_QUESOS.Bonos ( --La tabla bonos se modelo con estrategia SINGLE TABLE, discriminando el tipo de bono por el campo Tipo_Bono
        Numero numeric(18) NOT NULL,
        Fecha_Impresion datetime NOT NULL,
        Nro_Afiliado numeric(18) NOT NULL,
        Cod_Plan numeric(18) NOT NULL,
        Id_Compra numeric(18),
        Tipo_Bono varchar(255) NOT NULL,
        Fecha_Vencimiento datetime,
        Fecha_Prescripcion_Medica datetime DEFAULT NULL, 
        Nro_Consulta int,
        Nro_Usuario numeric(18)
)
;

CREATE TABLE CUATRO_QUESOS.Cambios_Plan (
		Id_Cambio numeric(18) NOT NULL Identity(1,1),
        Nro_Afiliado numeric(18) NOT NULL,
        Fecha datetime NOT NULL,
        Plan_Origen numeric(18) NOT NULL,
        Plan_Destino numeric(18) NOT NULL,
        Motivo varchar(255)
)
;

CREATE TABLE CUATRO_QUESOS.Cancelaciones (
        Nro_Turno numeric(18) NOT NULL,
        Tipo varchar(255) NOT NULL,
        Motivo varchar(255)
)
;

CREATE TABLE CUATRO_QUESOS.Compra (
        Id_Compra numeric(18) NOT NULL Identity(1,1), --configuro el ID como autoincremental con identity
        Nro_Afiliado numeric(18) NOT NULL,
        Fecha datetime NOT NULL,
        Cantidad_Comprada_Consulta numeric(18),
        Cantidad_Comprada_Farmacia numeric(18),
        Monto numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Consultas (
        Id_Consulta numeric(18) NOT NULL Identity(1,1),
        Nro_Turno numeric(18) NOT NULL,
        Fecha_Llegada datetime,
        Fecha_Atencion datetime,
        Sintomas varchar(255) NOT NULL,
        Enfermedades varchar(255) NOT NULL,
        Nro_Bono_Consulta numeric(18) NOT NULL,
        Tipo_Bono varchar(255) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Dias_Atencion (
        Id_Medico numeric(18) NOT NULL,
        Dia_Semana tinyint NOT NULL, --lunes: 1, martes: 2, miercoles: 3, jueves: 4, viernes: 5, sabado: 6, domingo: 7
        Hora_Desde time(4) NOT NULL,
        Hora_Hasta time(4) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Especialidades (
        Codigo numeric(18) NOT NULL,
        Descripcion varchar(255) NOT NULL,
        Tipo_Codigo numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Especialidades_Medicos (
        Id_Medico numeric(18) NOT NULL,
        Cod_Especialidad numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Funcionalidades (
        Id_Funcionalidad numeric(18) NOT NULL Identity(1,1),
        Descripcion varchar(255)
)
;

CREATE TABLE CUATRO_QUESOS.Medicamentos (
        Id_Medicamento numeric(18) NOT NULL Identity(1,1),
        Descripcion varchar(255) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta (
        Id_Consulta numeric(18) NOT NULL,
        Id_Medicamento numeric(18) NOT NULL,
        Nro_Bono_Farmacia numeric(18) NOT NULL,
        Cantidad varchar(255) NOT NULL CHECK(Cantidad = '1 (UNO)' OR Cantidad = '2 (DOS)' OR Cantidad = '3 (TRES)'), --Segun el enunciado debe ser la cantidad en numero seguido la cantidad en letras, puede ir de 1 a 3
        Tipo_Bono varchar(255),
)
;

CREATE TABLE CUATRO_QUESOS.Medicos (
        Id_Medico numeric(18) NOT NULL Identity(1,1),
        Nombre varchar(255) NOT NULL,
        Apellido varchar(255) NOT NULL,
        Sexo varchar(255) NOT NULL CHECK(Sexo = 'M' OR Sexo = 'F' OR Sexo = '-'), --puede ser M (masculino), F (femenino), o '-' (indefinido o migrado)
        Tipo_Doc varchar(3) NOT NULL CHECK(Tipo_Doc = 'DNI' OR Tipo_Doc = 'LE' OR Tipo_Doc = 'LC'), -- DNI (Documento Nacional de Identidad), LE (Libreta de Enrolamiento), LC (Libreta Civica)
        Nro_Doc numeric(18) NOT NULL,
        Direccion varchar(255) NOT NULL,
        Telefono numeric(18) NOT NULL,
        Mail varchar(255),
        Fecha_Nac datetime NOT NULL,
        Nro_Matricula numeric(18) NOT NULL,
        Fecha_Atencion_Desde datetime,
        Fecha_Atencion_Hasta datetime,
        Habilitado bit NOT NULL DEFAULT 1
)
;

CREATE TABLE CUATRO_QUESOS.Planes_Medicos (
        Codigo numeric(18) NOT NULL,
        Descripcion varchar(255) NOT NULL,
        Precio_Bono_Consulta numeric(18) NOT NULL,
        Precio_Bono_Farmacia numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Roles (
        Id_Rol numeric(18) NOT NULL Identity(1,1),
        Habilitado bit NOT NULL,
        Nombre varchar(50) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades (
        Id_Rol numeric(18) NOT NULL,
        Id_Funcionalidad numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Tipos_Especialidades (
        Codigo numeric(18) NOT NULL,
        Descripcion varchar(255) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Turnos (
        Numero numeric(18) NOT NULL,
        Fecha datetime NOT NULL,
        Nro_Afiliado numeric(18) NOT NULL,
        Id_Medico numeric(18) NOT NULL,
        Cod_Especialidad numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Usuarios (
        Username nvarchar(20) NOT NULL,
        Pass binary(32) NOT NULL,
        Intentos_Fallidos tinyint,
        Habilitado bit
)
;

CREATE TABLE CUATRO_QUESOS.Usuarios_Afiliados (
        Nro_Afiliado numeric(18) NOT NULL,
        Username nvarchar(20) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Usuarios_Medicos (
        Username nvarchar(20) NOT NULL,
        Id_Medico numeric(18) NOT NULL
)
;

CREATE TABLE CUATRO_QUESOS.Usuarios_Por_Rol (
        Username nvarchar(20) NOT NULL,
        Id_Rol numeric(18) NOT NULL
)
;

--CHECK Constraints

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT CHK_Estado_Civil --Solo se permite estos inputs taxativos
        CHECK(Estado_Civil = 'Soltero/a' OR
         Estado_Civil = 'Divorciado/a' OR
         Estado_Civil = 'Viudo/a' OR
         Estado_Civil = 'Concubinato' OR
         Estado_Civil = 'Casado/a')
;

-- UNIQUE Constraints 

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados
        ADD CONSTRAINT UQ_Usuarios_Afiliados_Nro_Afiliado UNIQUE (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados
        ADD CONSTRAINT UQ_Usuarios_Afiliados_Username UNIQUE (Username)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos
        ADD CONSTRAINT UQ_Usuarios_Medicos_Id_Medico UNIQUE (Id_Medico)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos
        ADD CONSTRAINT UQ_Usuarios_Medicos_Username UNIQUE (Username)
;

-- Create Primary Key Constraints

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT PK_Afiliados
        PRIMARY KEY CLUSTERED (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Agendas_Medicos ADD CONSTRAINT PK_Agendas_Medicos
        PRIMARY KEY CLUSTERED (Id_Medico, Fecha_Hora)
;

ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT PK_Bonos
        PRIMARY KEY CLUSTERED (Numero, Tipo_Bono)
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan ADD CONSTRAINT PK_Cambios_Plan
        PRIMARY KEY CLUSTERED (Id_Cambio)
;

ALTER TABLE CUATRO_QUESOS.Cancelaciones ADD CONSTRAINT PK_Cancelaciones
        PRIMARY KEY CLUSTERED (Nro_Turno)
;

ALTER TABLE CUATRO_QUESOS.Compra ADD CONSTRAINT PK_Compra
        PRIMARY KEY CLUSTERED (Id_Compra)
;

ALTER TABLE CUATRO_QUESOS.Consultas ADD CONSTRAINT PK_Consultas
        PRIMARY KEY CLUSTERED (Id_Consulta)
;

ALTER TABLE CUATRO_QUESOS.Dias_Atencion ADD CONSTRAINT PK_Dias_Atencion
        PRIMARY KEY CLUSTERED (Id_Medico, Dia_Semana)
;

ALTER TABLE CUATRO_QUESOS.Especialidades ADD CONSTRAINT PK_Especialidades
        PRIMARY KEY CLUSTERED (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Especialidades_Medicos ADD CONSTRAINT PK_Especialidades_Medicos
        PRIMARY KEY CLUSTERED (Id_Medico, Cod_Especialidad)
;

ALTER TABLE CUATRO_QUESOS.Funcionalidades ADD CONSTRAINT PK_Funcionalidades
        PRIMARY KEY CLUSTERED (Id_Funcionalidad)
;

ALTER TABLE CUATRO_QUESOS.Medicamentos ADD CONSTRAINT PK_Medicamentos
        PRIMARY KEY CLUSTERED (Id_Medicamento)
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta ADD CONSTRAINT PK_Medicamentos_Por_Consulta
        PRIMARY KEY CLUSTERED (Id_Consulta, Id_Medicamento, Nro_Bono_Farmacia)
;

ALTER TABLE CUATRO_QUESOS.Medicos ADD CONSTRAINT PK_Medicos
        PRIMARY KEY CLUSTERED (Id_Medico)
;

ALTER TABLE CUATRO_QUESOS.Planes_Medicos ADD CONSTRAINT PK_Planes_Medicos
        PRIMARY KEY CLUSTERED (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Roles ADD CONSTRAINT PK_Roles
        PRIMARY KEY CLUSTERED (Id_Rol)
;

ALTER TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades ADD CONSTRAINT PK_Roles_Por_Funcionalidades
        PRIMARY KEY CLUSTERED (Id_Rol, Id_Funcionalidad)
;

ALTER TABLE CUATRO_QUESOS.Tipos_Especialidades ADD CONSTRAINT PK_Tipos_Especialidades
        PRIMARY KEY CLUSTERED (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Turnos ADD CONSTRAINT PK_Turnos
        PRIMARY KEY CLUSTERED (Numero)
;

ALTER TABLE CUATRO_QUESOS.Usuarios ADD CONSTRAINT PK_Usuarios
        PRIMARY KEY CLUSTERED (Username)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT PK_Usuarios_Afiliados
        PRIMARY KEY CLUSTERED (Nro_Afiliado, Username)
;


ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT PK_Usuarios_Medicos
        PRIMARY KEY CLUSTERED (Username, Id_Medico)
;


ALTER TABLE CUATRO_QUESOS.Usuarios_Por_Rol ADD CONSTRAINT PK_Usuarios_Por_Rol
        PRIMARY KEY CLUSTERED (Username, Id_Rol)
;



-- Create Foreign Key Constraints
ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT FK_Afiliados_Planes
        FOREIGN KEY (Cod_Plan) REFERENCES CUATRO_QUESOS.Planes_Medicos (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT FK_Nro_Conyuge
        FOREIGN KEY (Nro_Conyuge) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT FK_Nro_Titular
        FOREIGN KEY (Nro_Titular) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Agendas_Medicos ADD CONSTRAINT FK_Agenda_Medico
		FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
;

ALTER TABLE CUATRO_QUESOS.Agendas_Medicos ADD CONSTRAINT FK_Agenda_Turno
		FOREIGN KEY (Nro_Turno) REFERENCES CUATRO_QUESOS.Turnos (Numero)
;


ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT FK_Bonos_Afiliados
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT FK_Bonos_Usuarios
        FOREIGN KEY (Nro_Usuario) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT FK_Bonos_Compra
        FOREIGN KEY (Id_Compra) REFERENCES CUATRO_QUESOS.Compra (Id_Compra)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT FK_Bonos_Planes_Medicos
        FOREIGN KEY (Cod_Plan) REFERENCES CUATRO_QUESOS.Planes_Medicos (Codigo)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan ADD CONSTRAINT FK_Afiliado
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan ADD CONSTRAINT FK_Plan_Destino
        FOREIGN KEY (Plan_Destino) REFERENCES CUATRO_QUESOS.Planes_Medicos (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan ADD CONSTRAINT FK_Plan_Origen
        FOREIGN KEY (Plan_Origen) REFERENCES CUATRO_QUESOS.Planes_Medicos (Codigo)
;

ALTER TABLE CUATRO_QUESOS.Cancelaciones ADD CONSTRAINT FK_Cancelaciones_Turnos
        FOREIGN KEY (Nro_Turno) REFERENCES CUATRO_QUESOS.Turnos (Numero)
;

ALTER TABLE CUATRO_QUESOS.Compra ADD CONSTRAINT FK_Compra_Afiliados
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Consultas ADD CONSTRAINT FK_Consultas_Bonos
        FOREIGN KEY (Nro_Bono_Consulta, Tipo_Bono) REFERENCES CUATRO_QUESOS.Bonos (Numero, Tipo_Bono)
;

ALTER TABLE CUATRO_QUESOS.Consultas ADD CONSTRAINT FK_Consultas_Turnos
        FOREIGN KEY (Nro_Turno) REFERENCES CUATRO_QUESOS.Turnos (Numero)
;

ALTER TABLE CUATRO_QUESOS.Dias_Atencion ADD CONSTRAINT FK_Dias_Atencion_Medicos
        FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Especialidades ADD CONSTRAINT FK_Especialidades_Tipos_Especialidades
        FOREIGN KEY (Tipo_Codigo) REFERENCES CUATRO_QUESOS.Tipos_Especialidades (Codigo)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Especialidades_Medicos ADD CONSTRAINT FK_Especialidades_Medicos_Especialidades
        FOREIGN KEY (Cod_Especialidad) REFERENCES CUATRO_QUESOS.Especialidades (Codigo)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Especialidades_Medicos ADD CONSTRAINT FK_Especialidades_Medicos_Medicos
        FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta ADD CONSTRAINT FK_Medicamentos_Por_Consulta_Bonos
        FOREIGN KEY (Nro_Bono_Farmacia, Tipo_Bono) REFERENCES CUATRO_QUESOS.Bonos (Numero, Tipo_Bono)
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta ADD CONSTRAINT FK_Medicamentos_Por_Consulta_Consultas
        FOREIGN KEY (Id_Consulta) REFERENCES CUATRO_QUESOS.Consultas (Id_Consulta)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta ADD CONSTRAINT FK_Medicamentos_Por_Consulta_Medicamentos
        FOREIGN KEY (Id_Medicamento) REFERENCES CUATRO_QUESOS.Medicamentos (Id_Medicamento)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades ADD CONSTRAINT FK_Roles_Por_Funcionalidades_Funcionalidades
        FOREIGN KEY (Id_Funcionalidad) REFERENCES CUATRO_QUESOS.Funcionalidades (Id_Funcionalidad)
        ON DELETE CASCADE ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades ADD CONSTRAINT FK_Roles_Por_Funcionalidades_Roles
        FOREIGN KEY (Id_Rol) REFERENCES CUATRO_QUESOS.Roles (Id_Rol)
        ON DELETE CASCADE ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Turnos ADD CONSTRAINT FK_Turnos_Afiliados
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Turnos ADD CONSTRAINT FK_Turnos_Especialidades
        FOREIGN KEY (Cod_Especialidad) REFERENCES CUATRO_QUESOS.Especialidades (Codigo)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Turnos ADD CONSTRAINT FK_Turnos_Medicos
        FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Por_Rol ADD CONSTRAINT FK_Usuarios_Por_Rol_Roles
        FOREIGN KEY (Id_Rol) REFERENCES CUATRO_QUESOS.Roles (Id_Rol)
        ON DELETE CASCADE ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Por_Rol ADD CONSTRAINT FK_Usuarios_Por_Rol_Usuarios
        FOREIGN KEY (Username) REFERENCES CUATRO_QUESOS.Usuarios (Username)
        ON DELETE CASCADE ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT FK_Usuarios_Afiliados_Afiliados
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT FK_Usuarios_Afiliados_Usuarios
        FOREIGN KEY (Username) REFERENCES CUATRO_QUESOS.Usuarios (Username)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT FK_Usuarios_Medicos_Medicos
        FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT FK_Usuarios_Medicos_Usuarios
        FOREIGN KEY (Username) REFERENCES CUATRO_QUESOS.Usuarios (Username)
        ON UPDATE CASCADE
;

--Create other constraints


/* ****** Migrar datos existentes ******* */

--Planes medicos

INSERT INTO CUATRO_QUESOS.Planes_Medicos
        (
        Codigo,
        Descripcion,
        Precio_Bono_Consulta,
        Precio_Bono_Farmacia
        )
        
        select distinct Plan_Med_Codigo as Codigo,
                Plan_Med_Descripcion as Descripcion,
                Plan_Med_Precio_Bono_Consulta as Precio_Bono_Consulta,
                Plan_Med_Precio_Bono_Farmacia as Precio_Bono_Farmacia
                
        from gd_esquema.Maestra

--Afiliados

INSERT INTO CUATRO_QUESOS.Afiliados
        (
        Nro_Afiliado,
        Nombre,
        Apellido,
        Sexo,
        Tipo_Doc,
        Nro_Doc,
        Direccion,
        Telefono,
        Mail,
        Fecha_Nac,
        Cod_Plan,
        Estado_Civil,
        Nro_Titular,
        Nro_Conyuge,
        Fecha_Baja,
        Nro_Consulta
        )
        
        select (row_number() over(order by paciente_dni))*100 + 1 as Nro_Afiliado,
        Paciente_Nombre as Nombre,
        Paciente_Apellido as Apellido,
        '-' as Sexo, --indefinido o migrado
        'DNI' as Tipo_Doc, --como la columna de la maestra dice DNI, asumo que todos los documentos existentes son DNI
        Paciente_Dni as Nro_Doc,
        Paciente_Direccion as Direccion,
        Paciente_Telefono as Telefono,
        Paciente_Mail as Mail,
        Paciente_Fecha_Nac as Fecha_Nac,
        Plan_Med_Codigo as Cod_Plan,
        'Soltero/a' as Estado_Civil, --presumido
        NULL as Nro_Titular, --nadie es familiar a cargo de algun titular
        NULL as Nro_Conyuge, --nadie tiene conyuge
        NULL as Fecha_Baja, --asumo que los socios dados están activos
        (select COUNT(*) from gd_esquema.Maestra as sub1
                where subtabla.Paciente_DNI = sub1.Paciente_DNI
                        and sub1.Turno_Numero is not null
                        and sub1.Bono_Consulta_Numero is not null
                        and sub1.Turno_Fecha < CUATRO_QUESOS.FechaMigracion())
        as Nro_Consulta --cuento la cantidad de consultas concretadas (turno pasado asociado a bono consulta = consulta concretada)

        from
                (select distinct Paciente_Nombre, Paciente_Apellido, Paciente_Direccion, Paciente_Dni, Paciente_Telefono, Paciente_Fecha_Nac, Paciente_Mail, Plan_Med_Codigo
                from gd_esquema.Maestra) as subtabla


--Medicamentos

INSERT INTO CUATRO_QUESOS.Medicamentos
        (
        Descripcion
        )

        select
                Bono_Farmacia_Medicamento as Descripcion

        from (select distinct Bono_Farmacia_Medicamento
                from gd_esquema.Maestra
                where Bono_Farmacia_Medicamento is not null) as subtabla

--Tipos de especialidades médicas

INSERT INTO CUATRO_QUESOS.Tipos_Especialidades
        (
        Codigo,
        Descripcion
        )
        
        select distinct Tipo_Especialidad_Codigo as Codigo,
                Tipo_Especialidad_Descripcion as Descripcion
                
        from gd_esquema.Maestra
        where Tipo_Especialidad_Codigo is not null



--Especialidades médicas

INSERT INTO CUATRO_QUESOS.Especialidades
        (
        Codigo,
        Descripcion,
        Tipo_Codigo
        )
        
        select distinct Especialidad_Codigo as Codigo,
                Especialidad_Descripcion as Descripcion,
                Tipo_Especialidad_Codigo as Tipo_Codigo
        
        from gd_esquema.Maestra
        where Especialidad_Codigo is not null






--Medicos

INSERT INTO CUATRO_QUESOS.Medicos
        (
        Nombre,
        Apellido,
        Sexo,
        Tipo_Doc,
        Nro_Doc,
        Direccion,
        Telefono,
        Mail,
        Fecha_Nac,
        Nro_Matricula,
        Fecha_Atencion_Desde,
        Fecha_Atencion_Hasta,
        Habilitado
        )
        
        select
                Medico_Nombre as Nombre,
                Medico_Apellido as Apellido,
                '-' as Sexo, --indefinido
                'DNI' as Tipo_Doc, --como la columna de la maestra dice DNI, asumo que todos los documentos existentes son DNI
                Medico_Dni as Nro_Doc,
                Medico_Direccion as Direccion,
                Medico_Telefono as Telefono,
                Medico_Mail as Mail,
                Medico_Fecha_Nac as Fecha_Nac,
                0 as Nro_Matricula, --indefinido
                NULL as Fecha_Atencion_Desde, --quedan en NULL por no tener agenda registrada
                NULL as Fecha_Atencion_Hasta,
                1 as Habilitado --asumo que los medicos existentes están todos activos
                
                
        from gd_esquema.Maestra
        where Medico_Dni is not null
        group by Medico_Dni,
                Medico_Nombre,
                Medico_Apellido,
                Medico_Direccion,
                Medico_Telefono,
                Medico_Mail,
                Medico_Fecha_Nac


/*NOTA: ACA EMPIEZA LA PARTE DE LOS BONOS. */

--Bonos consulta
INSERT INTO CUATRO_QUESOS.Bonos
        (
        Numero,
        Fecha_Impresion,
        Nro_Afiliado,
        Cod_Plan,
        ID_Compra,
        Tipo_Bono,
        Fecha_Vencimiento,
        Nro_Consulta,
        Nro_Usuario
        )
        
        select distinct Bono_Consulta_Numero as Numero,
                Bono_Consulta_Fecha_Impresion as Fecha_Impresion,
                (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI) as Nro_Afiliado,
                Plan_Med_Codigo as Cod_Plan,
                NULL as ID_Compra, --no se tienen datos de las compras anteriores a la migración
                'Consulta' as Tipo_Bono,
                NULL as Fecha_Vencimiento, --no aplica para bonos consulta
                
                --lo que sigue es para calcular el campo nro_consulta (se anota en el bono cuantas veces se atendio ESE afiliado)
                case (select COUNT(*) from gd_esquema.Maestra as sub1 where Turno_Numero is not null and sub1.Bono_Consulta_Numero = principal.Bono_Consulta_Numero) --esta columna cambia según si para este bono hubo turno asociado (consulta concretada) o no
                when 0 then NULL --si no hubo consulta el nro_consulta es null
                else --si hubo consulta hay que calcular nro_consulta
                (select COUNT(*) --para obtener el nro_consulta de ese paciente tengo que contar....
                        from gd_esquema.Maestra submaestra --usando una tabla auxiliar
                        where principal.Paciente_Dni = submaestra.Paciente_Dni --para ese afiliado
                                and submaestra.Bono_Consulta_Numero <= principal.Bono_Consulta_Numero --cuantos bonos menores o iguales a este bono existen
                                and submaestra.Turno_Numero is not null
                                and submaestra.Turno_Fecha < CUATRO_QUESOS.FechaMigracion()) --y que hayan sido usados en una consulta PASADA (sabemos que se usaron cuando se asocian a un turno)
                 end as Nro_Consulta,
                
                 --lo que sigue es para determinar el usuario. Si se concretó el turno, asumo que el usuario es el mismo que lo compró, si no se concretó el usuario es NULL
                case (select COUNT(*) from gd_esquema.Maestra as sub1 where Turno_Numero is not null and sub1.Bono_Consulta_Numero = principal.Bono_Consulta_Numero and sub1.Turno_Fecha < CUATRO_QUESOS.FechaMigracion())
                when 0 then NULL --si no hubo consulta el nro_consulta es null
                else
                        (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI)
                end as Nro_Usuario


        from gd_esquema.Maestra as principal
        where Bono_Consulta_Numero is not null
                and Compra_Bono_Fecha is not null
                
                

                
--Bonos farmacia
INSERT INTO CUATRO_QUESOS.Bonos
        (
        Numero,
        Fecha_Impresion,
        Nro_Afiliado,
        Cod_Plan,
        ID_Compra,
        Tipo_Bono,
        Fecha_Vencimiento,
        Nro_Consulta,
        Nro_Usuario
        )
        --este es bastante straightforward comparado con el de bonos consulta
        select distinct Bono_Farmacia_Numero as Numero,
                Bono_Farmacia_Fecha_Impresion as Fecha_Impresion,
                (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI) as Nro_Afiliado,
                Plan_Med_Codigo as Cod_Plan,
                NULL as ID_Compra,
                'Farmacia' as Tipo_Bono,
                Bono_Farmacia_Fecha_Vencimiento as Fecha_Vencimiento,
                NULL as Nro_Consulta, --no aplica para bonos farmacia
                --lo que sigue es para determinar el usuario. Si se usó, asumo que el usuario es el mismo que lo compró, si no se usó el usuario es NULL
                case (select COUNT(*) from gd_esquema.Maestra as sub1 where Bono_Farmacia_Medicamento is not null and sub1.Bono_Farmacia_Numero = principal.Bono_Farmacia_Numero and sub1.Turno_Fecha < CUATRO_QUESOS.FechaMigracion()) --claramente un bono farmacia usado es el que tiene un medicamento escrito.... en el pasado
                when 0 then NULL --si no hubo se usó el nro_consulta es null
                else
                        (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI)
                end as Nro_Usuario
                
                

from gd_esquema.Maestra as principal
where Bono_Farmacia_Numero is not null

/* *************FIN INSERCION DE BONOS*************** */

--Compras de bonos

set IDENTITY_INSERT CUATRO_QUESOS.Compra ON

insert into CUATRO_QUESOS.Compra(ID_Compra, Nro_Afiliado, Fecha, Cantidad_Comprada_Consulta, Cantidad_Comprada_Farmacia, Monto)
select ROW_NUMBER() over (order by compra_bono_fecha asc, paciente_dni asc) as ID_Compra,
	(select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI) as Nro_Afiliado,
	Compra_Bono_Fecha as Fecha,
	(select COUNT(*) 
	from gd_esquema.Maestra as SUB 
	where SUB.Compra_Bono_Fecha = Main.Compra_Bono_Fecha and MAIN.Paciente_Dni = SUB.Paciente_Dni and Bono_Consulta_Numero is not null)
		as Cantidad_Comprada_Consulta,
	(select COUNT(*) 
	from gd_esquema.Maestra as SUB 
	where SUB.Compra_Bono_Fecha = Main.Compra_Bono_Fecha and MAIN.Paciente_Dni = SUB.Paciente_Dni and Bono_Farmacia_Numero is not null)
		as Cantidad_Comprada_Farmacia,
	0 as Monto --esto como temporal para migrar porque no admite valores null (y tiene sentido que no los admita)
				--el tema es que no voy a calcular el monto ahora porque necesito las cantidades que acabo de calcular
				--y si quisiera hacerlo ahora tengo que volver a hacer esos select
				--en la proxima instrucción voy a estar completando este campo
	 
from gd_esquema.Maestra as MAIN where Compra_Bono_Fecha is not null group by Paciente_Dni, Compra_Bono_Fecha

set IDENTITY_INSERT CUATRO_QUESOS.Compra OFF


--ahora completo el monto
update CUATRO_QUESOS.Compra
set Monto = 

(select Precio_Bono_Consulta 
from CUATRO_QUESOS.Planes_Medicos, CUATRO_QUESOS.Afiliados 
where Afiliados.Cod_Plan = Planes_Medicos.Codigo
	and Afiliados.Nro_Afiliado = Compra.Nro_Afiliado) * Cantidad_Comprada_Consulta
--busco el precio del bono consulta, y lo multiplico por la cantidad comprada
+ --y lo sumo a...

(select Precio_Bono_Farmacia 
from CUATRO_QUESOS.Planes_Medicos, CUATRO_QUESOS.Afiliados 
where Afiliados.Cod_Plan = Planes_Medicos.Codigo
	and Afiliados.Nro_Afiliado = Compra.Nro_Afiliado) * Cantidad_Comprada_Farmacia
--busco el precio del bono farmacia, y lo multiplico por la cantidad comprada


--asigno a cada bono su ID compra (que acabo de generar)
update CUATRO_QUESOS.Bonos
set ID_Compra = (select Id_Compra --ahora que generé las compras, asigno los ID de compra a cada bono
				from CUATRO_QUESOS.Compra
				where Compra.Fecha = Bonos.Fecha_Impresion --pudimos verificar que para todos los registros existentes, estas dos fechas coinciden
															--entonces suponemos que un bono se genera y se imprime al momento de comprarse
					and Compra.Nro_Afiliado = Bonos.Nro_Afiliado) --estos dos campos del where son los que usamos para agrupar las compras
																  --por lo tanto, aunque no son PK, al momento de la migración sirven para identificar unívocamente a una fila
																  --justamente en base a ellos se generó la PK autonumérica

--Días de atención

INSERT INTO CUATRO_QUESOS.Dias_Atencion
--Esta tabla la dejo pre-completada porque 1. ya tengo el código y 2. queda prolijo para el caso de uso
        (
        ID_Medico,
        Dia_Semana,
        Hora_Desde,
        Hora_Hasta
        )


        select (select ID_Medico from CUATRO_QUESOS.Medicos where Nro_Doc = Medico_Dni) as ID_Medico,
                DATEPART(dw, Turno_Fecha) as Dia_Semana,
                MIN(Cast(Turno_Fecha as time)) as Hora_Desde,
                MAX(Cast(DATEADD(minute, 30, Turno_Fecha) as time)) as Hora_Hasta

        from gd_esquema.Maestra
        where Turno_Fecha is not null
                and DATEPART(dw, Turno_Fecha) != 7 --esto falla espectacularmente si la base de datos no está en español
                and ( (DATEPART(dw, Turno_Fecha) != 6 --clausula para los días hábiles
                                and datepart(hour, Turno_Fecha) >= 7
                                and datepart(hour, Turno_Fecha) < 20) --menor a 20 porque si la clínica cierra a las 20, el último turno es a las 19:30
                        or
                                (DATEPART(dw, Turno_Fecha) = 6 --clausula para los sábados
                                and datepart(hour, Turno_Fecha) >= 10
                                and datepart(hour, Turno_Fecha) < 15)
                        )
        group by Medico_Dni, DATEPART(dw, Turno_Fecha)

        
--Especialidades por médico

INSERT INTO CUATRO_QUESOS.Especialidades_Medicos
        (
        ID_Medico,
        Cod_Especialidad
        )
        
        select distinct (select ID_Medico from CUATRO_QUESOS.Medicos where Nro_Doc = Medico_Dni) as ID_Medico,
                Especialidad_Codigo as Cod_Especialidad
        from gd_esquema.Maestra
        where Medico_Dni is not null

        
--Turnos

INSERT INTO CUATRO_QUESOS.Turnos
        (
        Numero,
        Fecha,
        Nro_Afiliado,
        ID_Medico,
        Cod_Especialidad
        )

        select distinct Turno_Numero as Numero,
                Turno_Fecha as Fecha,
                (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI) as Nro_Afiliado,
                (select ID_Medico from CUATRO_QUESOS.Medicos where Nro_Doc = Medico_Dni) as ID_Medico,
                Especialidad_Codigo

        from gd_esquema.Maestra
        where Turno_Numero is not null


        
--Cancelaciones

INSERT INTO CUATRO_QUESOS.Cancelaciones
        (
        Nro_Turno,
        Tipo,
        Motivo
        )
        
        select Turno_Numero as Nro_Turno,
        'No asistencia' as Tipo,
        'Se encontró un turno pasado para el cual no se registra la consulta correspondiente' as Motivo
        
        from gd_esquema.Maestra as principal
        where Turno_Numero is not null
                --and Bono_Consulta_Numero is null
                and (select COUNT(*)
                        from gd_esquema.Maestra as sub1
                        where principal.Turno_Numero = sub1.Turno_Numero
                                and sub1.Bono_Consulta_Numero is not null) = 0
                --esta condición significa que no existe un registro con este número de turno y un bono de consulta asociado
                --esto quiere decir que el turno no se concretó ya que no se usó bono consulta
                and Turno_Fecha < CUATRO_QUESOS.FechaMigracion()-- y esto otro significa que el turno debería haberse concretado antes de la migración


INSERT INTO CUATRO_QUESOS.Cancelaciones
        (
        Nro_Turno,
        Tipo,
        Motivo
        )
        
        select distinct Turno_Numero as Nro_Turno,
        'Horario no permitido' as Tipo,
        'Se encontró un turno futuro en un horario en el cual la clínica no estará abierta' as Motivo
        
        from gd_esquema.Maestra as principal
        where Turno_Numero is not null
                and Turno_Fecha > CUATRO_QUESOS.FechaMigracion()
                and (DATEPART(dw, Turno_Fecha) = 7
                        
                        or ((DATEPART(dw, Turno_Fecha) = 6
                                        and (datepart(hour, Turno_Fecha) < 10
                                                or datepart(hour, Turno_Fecha) >= 15))
                        or datepart(hour, Turno_Fecha) < 7
                        
                        or datepart(hour, Turno_Fecha) >= 20)
                        )

                
                
                
--Consultas

INSERT INTO CUATRO_QUESOS.Consultas
        (
        Nro_Turno,
        Fecha_Llegada,
        Fecha_Atencion,
        Sintomas,
        Enfermedades,
        Nro_Bono_Consulta,
        Tipo_Bono
        )
        
        select
        Turno_Numero as Nro_Turno,
        Turno_Fecha as Fecha_Llegada,
        Turno_Fecha as Fecha_Atencion,
        Consulta_Sintomas as Sintomas,
        Consulta_Enfermedades as Enfermedades,
        Bono_Consulta_Numero as Nro_Bono_Consulta,
        'Consulta' as Tipo_Bono

        from gd_esquema.Maestra

        where Bono_Consulta_Numero is not null and Turno_Numero is not null and turno_Fecha < CUATRO_QUESOS.FechaMigracion()
        
INSERT INTO CUATRO_QUESOS.Medicamentos_Por_Consulta
        (
        ID_Consulta,
        ID_Medicamento,
        Nro_Bono_Farmacia,
        Cantidad,
        Tipo_Bono
        )
        
        select (select sub1.ID_Consulta from CUATRO_QUESOS.Consultas as sub1 where principal.Turno_Numero = sub1.Nro_Turno) as ID_Consulta,
                (select sub2.ID_Medicamento from CUATRO_QUESOS.Medicamentos as sub2 where Bono_Farmacia_Medicamento =sub2.Descripcion) as Medicamento,
                Bono_Farmacia_Numero as Nro_Bono_Farmacia,
                '1 (UNO)' as Cantidad, --asumo que sólo se receto una instancia del medicamento que aparece en la maestra
                'Farmacia' as Tipo_Bono
                
        from gd_esquema.Maestra as principal
        where Turno_Numero is not null
                and Bono_Farmacia_Numero is not null
                and Bono_Farmacia_Medicamento is not null
                and Turno_Fecha < CUATRO_QUESOS.FechaMigracion()

                
/* *****USUARIOS Y DEMAS YERBAS***** */


--crear usuarios para los afiliados
insert into CUATRO_QUESOS.Usuarios(Username, Pass, Intentos_Fallidos, Habilitado)
        select CAST(nro_afiliado as varchar(8))+'A', 0xe00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29, 0, 1 from CUATRO_QUESOS.Afiliados
--la password es UTNFRBA

--relacionarlos con los afiliados
insert into CUATRO_QUESOS.Usuarios_Afiliados(Username, Nro_Afiliado)
        select CAST(nro_afiliado as varchar(8))+'A', nro_afiliado from CUATRO_QUESOS.Afiliados
        
        
--crear usuarios para los medicos
insert into CUATRO_QUESOS.Usuarios(Username, Pass, Intentos_Fallidos, Habilitado)
        select LEFT(nombre, 2)+LEFT(apellido, 1)+CAST(Id_Medico as varchar(4))+'M', 0xe00c42a301d2d5a17c9f2081ff897f031129c57cae3a55fa7ad6a649f939ea29, 0, 1 from CUATRO_QUESOS.Medicos
--la password es UTNFRBA

--relacionarlos con los medicos
insert into CUATRO_QUESOS.Usuarios_Medicos(Username, Id_Medico)
        select LEFT(nombre, 2)+LEFT(apellido, 1)+CAST(Id_Medico as varchar(4))+'M', Id_Medico from CUATRO_QUESOS.Medicos
        
--crear usuario admin
--set IDENTITY_INSERT CUATRO_QUESOS.Usuarios ON

insert into CUATRO_QUESOS.Usuarios(Username, Pass, Intentos_Fallidos, Habilitado)
        values('admin', 0xe6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7, 0, 1)
                
--set IDENTITY_INSERT CUATRO_QUESOS.Usuarios OFF
                
--crear roles

set IDENTITY_INSERT CUATRO_QUESOS.Roles ON

insert into CUATRO_QUESOS.Roles(Id_Rol, Habilitado, Nombre)
values(1, 1, 'Administrativo');

insert into CUATRO_QUESOS.Roles(Id_Rol, Habilitado, Nombre)
values(2, 1, 'Profesional');

insert into CUATRO_QUESOS.Roles(Id_Rol, Habilitado, Nombre)
values(3, 1, 'Afiliado');

set IDENTITY_INSERT CUATRO_QUESOS.Roles OFF
                

--relacionar usuarios por rol (relacion muchos a muchos)

insert into CUATRO_QUESOS.Usuarios_Por_Rol(Username, ID_Rol)
select username, 2 as ID_Rol from CUATRO_QUESOS.Usuarios_Medicos
--todos los usuarios que son médicos, tienen el rol médico

insert into CUATRO_QUESOS.Usuarios_Por_Rol(Username, ID_Rol)
select username, 3 as ID_Rol from CUATRO_QUESOS.Usuarios_Afiliados
--todos los usuarios que son afiliados, tienen el rol afiliado

insert into CUATRO_QUESOS.Usuarios_Por_Rol(Username, ID_Rol)
        values('admin', 1)
--el usuario admin lo ingresamos con rol administrativo


--crear funcionalidades

set IDENTITY_INSERT CUATRO_QUESOS.Funcionalidades ON

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (1, 'ABM de rol')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (2, 'Registro de usuario')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (3, 'ABM Afiliado')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (4, 'ABM profesional')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (5, 'ABM especialidades medicas')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (6, 'ABM de planes')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (7, 'Registrar agenda profesional')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (8, 'Compra de bonos')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (9, 'Pedir turno')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (10, 'Registro de llegada')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (11, 'Registro de resultado')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (12, 'Cancelar turno/s')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (13, 'Generar receta')
;

insert into CUATRO_QUESOS.Funcionalidades(ID_Funcionalidad, Descripcion)
values (14, 'Listado estadistico')
;

set IDENTITY_INSERT CUATRO_QUESOS.Funcionalidades OFF



--asignar funcionalidades a los roles

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades
select 1, Id_Funcionalidad from CUATRO_QUESOS.Funcionalidades
--este insert le da todo el power al administrativo

--luego asigno las funcionalidades individualmente
insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(2, 7); --medico, registrar agenda profesional

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(3, 8); --afiliado, compra de bonos

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(3, 9); --afiliado, pedir turno

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(2, 11); --medico, registro de resultados

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(2, 12); --medico, cancelar

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(3, 12); --afiliado, cancelar

insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
values(2, 13); --medico, generar receta
                

                
GO


--CREATE FUNCTIONS

CREATE FUNCTION CUATRO_QUESOS.siguienteNroFamiliar(@nroAfiliadoRaiz int)
RETURNS numeric(18) --me permite calcular el nuevo nro de afiliado para el familiar del titular
BEGIN
        DECLARE @nroFamiliar numeric(18)
        
        SELECT TOP 1 @nroFamiliar = Nro_Afiliado + 1
        FROM CUATRO_QUESOS.Afiliados
        WHERE Nro_Afiliado BETWEEN @nroAfiliadoRaiz AND @nroAfiliadoRaiz + 100
        ORDER BY Nro_Afiliado DESC
        
        IF(@nroFamiliar % 100 = 2) SET @nroFamiliar = @nroFamiliar + 1
        
        RETURN @nroFamiliar
END
GO

CREATE FUNCTION CUATRO_QUESOS.tipoAfiliado(@nroAfiliado numeric(18)) --1 es titular, 2 es conyuge, 3 es familiar no titular ni conyuge
RETURNS int
BEGIN
        DECLARE @tipo int
        SET @tipo = @nroAfiliado % 100
        RETURN CASE WHEN @tipo = 1 THEN 1 WHEN @tipo = 2 THEN 2 ELSE 3 END
END
GO

CREATE FUNCTION CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado numeric(18)) --devuelve la raiz del numero de afiliado
RETURNS int
BEGIN
RETURN (CAST(@nroAfiliado AS INT)/ 100)*100
END
GO

CREATE FUNCTION [CUATRO_QUESOS].[getNroAfiliado] (@Nombre VARCHAR(255), @Apellido VARCHAR(255), @Documento NUMERIC, @TipoDocumento VARCHAR(3)) --devuelve el nro de un afiliado
RETURNS NUMERIC(18,0)
BEGIN
        DECLARE @nro numeric(18)
        SELECT @nro = Nro_Afiliado
        FROM CUATRO_QUESOS.Afiliados
        WHERE Nombre = @Nombre AND Apellido = @Apellido AND Nro_Doc = @Documento AND Tipo_Doc = @TipoDocumento
        RETURN @nro
END
GO

CREATE FUNCTION CUATRO_QUESOS.estaHabilitadoUsuario(@username AS VARCHAR(20)) RETURNS BIT --retorna 1 si se encuentra habilitado o 0 si esta inhabilitado
AS
BEGIN
	RETURN (SELECT Habilitado FROM CUATRO_QUESOS.Usuarios WHERE Username = @username)
END
GO

CREATE FUNCTION CUATRO_QUESOS.getPass(@username AS VARCHAR(20)) RETURNS BINARY(32) --obtiene la password de un usuario
AS
BEGIN
	RETURN (SELECT pass FROM CUATRO_QUESOS.Usuarios WHERE Username = @username)
END
GO

CREATE FUNCTION CUATRO_QUESOS.getFinalDeMes(@PrincipioMes DATETIME) RETURNS DATETIME --retorna el fin del mes en base al principio del mes
AS
BEGIN
	RETURN DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@PrincipioMes)+1,0))
END
GO

--CREATE PROCEDURES

--procedures medicos

CREATE PROCEDURE CUATRO_QUESOS.altaMedico( --funcionalidad de alta de medico
@nombre varchar(255),
@apellido varchar(255),
@sexo varchar(255),
@tipoDoc varchar(3),
@nroDoc numeric(18),
@direccion varchar(255),
@telefono numeric(18),
@mail varchar(255),
@fechaNac datetime,
@nroMatricula numeric(18)
)
AS

INSERT INTO CUATRO_QUESOS.Medicos (Nombre, Apellido, Sexo, Tipo_Doc, Nro_Doc, Direccion, Telefono, Mail, Fecha_Nac, Nro_Matricula, Fecha_Atencion_Desde, Fecha_Atencion_Hasta)

VALUES (
@nombre,
@apellido,
@sexo,
@tipoDoc,
@nroDoc,
@direccion,
@telefono,
@mail,
@fechaNac,
@nroMatricula,
NULL,
NULL
)

GO


CREATE PROCEDURE CUATRO_QUESOS.updateMedico --funcionalidad que actualiza los campos factibles de ser modificados de un medico
(@id numeric(18),
@direccion varchar(255),
@telefono numeric(18),
@mail varchar(255)
)
AS

UPDATE CUATRO_QUESOS.Medicos
SET Direccion = @direccion,
Telefono = @telefono,
Mail = @mail
WHERE Id_Medico = @id
                
GO


CREATE PROCEDURE CUATRO_QUESOS.bajaMedico(@id numeric(18)) --funcionalidad que da de baja de forma logica a un medico, inhabilitandolo
AS
BEGIN
        UPDATE CUATRO_QUESOS.Medicos
        SET Habilitado = 0
        WHERE Id_Medico = @id
END

GO

--trae el datatable con los datos de los medicos, filtrando por nombre, apellido, numero de matricula o especialidad
CREATE PROCEDURE CUATRO_QUESOS.getMedicos @nombre varchar(255), @apellido varchar(255), @matricula numeric(18), @codEspecialidad numeric(18)
AS
SELECT Id_Medico 'ID Medico',
Nombre 'Nombre', Apellido 'Apellido',
Sexo 'Sexo', Tipo_Doc 'Tipo Documento',
Nro_Doc 'Numero Documento', Direccion 'Direccion',
Telefono 'Telefono', Mail 'Mail', Fecha_Nac 'Fecha Nacimiento',
Nro_Matricula 'Numero Matricula', Fecha_Atencion_Desde 'Fecha Atencion Desde',
Fecha_Atencion_Hasta 'Fecha Atencion Hasta', Habilitado 'Habilitado'
FROM CUATRO_QUESOS.Medicos
WHERE Nombre LIKE '%' + @nombre + '%' 
AND Apellido LIKE '%' + @Apellido + '%' 
AND ((Nro_Matricula = @matricula AND @matricula != 0) OR (@matricula = 0))
AND Id_Medico IN (SELECT Especialidades_Medicos.Id_Medico FROM CUATRO_QUESOS.Especialidades_Medicos WHERE (Cod_Especialidad = @codEspecialidad AND @codEspecialidad != 0) OR (@codEspecialidad = 0))
GO

--devuelve el ID de un medico
CREATE PROCEDURE CUATRO_QUESOS.getIdMedico(@nombre varchar(255), @apellido varchar(255),@tipoDoc varchar(3), @nroDoc numeric(18))
AS
BEGIN
        DECLARE @Id numeric(18)
        SELECT @Id = Id_Medico
        FROM CUATRO_QUESOS.Medicos
        WHERE Nombre = @nombre AND Apellido = @apellido AND Nro_Doc = @nroDoc AND Tipo_Doc = @tipoDoc
        RETURN @Id
END
GO

--chequea si ya existe un medico, retornandolo, con una matricula dada por parametro
CREATE PROCEDURE CUATRO_QUESOS.existeMatricula @matricula numeric(18)
AS
SELECT * FROM CUATRO_QUESOS.Medicos WHERE Nro_Matricula = @matricula
GO
/******** PROCEDURES ESPECIALIDES MEDICAS **********/

--devuelve todas las especialidades existentes
CREATE PROCEDURE CUATRO_QUESOS.getEspecialidades
AS
SELECT Especialidades.Codigo 'Codigo', Especialidades.Descripcion 'Descripcion', Especialidades.Tipo_Codigo 'Tipo Codigo'
FROM CUATRO_QUESOS.Especialidades
GO

/******* PROCEDURES ESPECIALIDADES_MEDICO ********/

--asocia una especialidad a un medico
CREATE PROCEDURE CUATRO_QUESOS.altaMedico_Especialidad ( @codEspecialidad numeric(18), @Id numeric(18) )
AS
INSERT INTO CUATRO_QUESOS.Especialidades_Medicos(Cod_Especialidad, Id_Medico)
VALUES (@codEspecialidad, @Id)

GO

--devuelve las especialidades que tiene asociadas un medico
CREATE PROCEDURE CUATRO_QUESOS.getEspecialidadesMedico @id numeric(18)
AS
SELECT Cod_Especialidad FROM CUATRO_QUESOS.Especialidades_Medicos WHERE Id_Medico = @id
GO

--elimina la asociacion de especialidades de un medico pasado por parametro
CREATE PROCEDURE CUATRO_QUESOS.deleteEspecialidades @id numeric(18)
AS
DELETE FROM CUATRO_QUESOS.Especialidades_Medicos WHERE Id_Medico = @id
GO
/********* PROCEDURES AFILIADOS ***************/

--devuelve la cantidad de familiares registrados que tiene un titular
CREATE PROCEDURE CUATRO_QUESOS.cantFamiliaresRegistrados(@nroAfiliadoTitular numeric(18))
AS
DECLARE @cantidadFamiliares int
SELECT @cantidadFamiliares = COUNT(*)
FROM CUATRO_QUESOS.Afiliados
WHERE Nro_Titular = @nroAfiliadoTitular
RETURN @cantidadFamiliares
GO

--devuelve el conyuge de un titular
CREATE PROCEDURE CUATRO_QUESOS.getConyuge(@nroAfiliadoTitular numeric(18))
AS
SELECT Nro_Afiliado 'Nª Afiliado',Nombre 'Nombre', Apellido 'Apellido',Sexo 'Sexo',
Tipo_Doc 'Tipo Documento',Nro_Doc 'Nª Documento', Direccion 'Dirección',Telefono 'Teléfono', Mail 'Mail',
Fecha_Nac 'Fecha de Nacimiento', Planes_Medicos.Descripcion 'Plan Medico', Estado_Civil 'Estado Civil',Nro_Titular 'Nª Afiliado de Titular',
Nro_Conyuge 'Nª Afiliado de Conyuge', Fecha_Baja 'Fecha de Baja', Nro_Consulta 'Nª de Consultas Realizadas',CantFamiliaresACargo 'Cantidad de Familiares a Cargo'
FROM CUATRO_QUESOS.Afiliados LEFT JOIN CUATRO_QUESOS.Planes_Medicos ON Afiliados.Cod_Plan = Planes_Medicos.Codigo
WHERE Nro_Conyuge = @nroAfiliadoTitular
GO

CREATE PROCEDURE CUATRO_QUESOS.darAltaAfiliado --Procedure para dar de alta un afiliado, dependiendo del tipo de afiliado insertara valores distintos y en distintas columnas
(@Nombre varchar(255),
 @Apellido varchar(255),
 @Sexo char(1) ,
 @Tipo_Doc varchar(3) ,
 @Nro_Doc numeric(18) ,
 @Direccion varchar(255),
 @Mail varchar(255),
 @Telefono numeric(18),
 @Fecha_Nac datetime ,
 @Cod_Plan numeric(18),
 @Estado_Civil varchar(255) ,
 @CantFamiliaresACargo tinyint,
 @tipoAfiliado char(1), -- T es titular, C es la pareja del titular y F es un familiar
 @nroAfiliadoTitular numeric(18)-- Solo se usa en el caso de conyuge o familiar
)
AS
BEGIN
        DECLARE @Nro_AfiliadoRaiz numeric(18)
        SET @Nro_AfiliadoRaiz = CUATRO_QUESOS.raizNroAfiliado(@nroAfiliadoTitular)
        
        IF(@tipoAfiliado = 'T')
                BEGIN
                        SELECT TOP 1 @Nro_AfiliadoRaiz = CUATRO_QUESOS.raizNroAfiliado(Nro_Afiliado) FROM CUATRO_QUESOS.Afiliados ORDER BY Nro_Afiliado DESC
                        SET @Nro_AfiliadoRaiz = @Nro_AfiliadoRaiz + 101;
                        INSERT INTO CUATRO_QUESOS.Afiliados
                        (Nro_Afiliado,Nombre,Apellido,Sexo,Tipo_Doc,Nro_Doc,Direccion,Mail,Telefono,Fecha_Nac,Cod_Plan,Estado_Civil,CantFamiliaresACargo)
                        VALUES (
                        @Nro_AfiliadoRaiz,
                        @Nombre,
                        @Apellido,
                        @Sexo,
                        @Tipo_Doc,
                        @Nro_Doc,
                        @Direccion,
                        @Mail,
                        @Telefono,
                        @Fecha_Nac,
                        @Cod_Plan,
                        @Estado_Civil,
                        @CantFamiliaresACargo
                        )
                END
        ELSE
                IF(@tipoAfiliado = 'C')
                BEGIN
                        SET @Nro_AfiliadoRaiz = @Nro_AfiliadoRaiz + 2;
                        INSERT INTO CUATRO_QUESOS.Afiliados
                        (Nro_Afiliado,Nombre,Apellido,Sexo,Tipo_Doc,Nro_Doc,Direccion,Mail,Telefono,Fecha_Nac,Cod_Plan,Estado_Civil,CantFamiliaresACargo, Nro_Conyuge)
                        VALUES (
                        @Nro_AfiliadoRaiz,
                        @Nombre,
                        @Apellido,
                        @Sexo,
                        @Tipo_Doc,
                        @Nro_Doc,
                        @Direccion,
                        @Mail,
                        @Telefono,
                        @Fecha_Nac,
                        @Cod_Plan,
                        @Estado_Civil,
                        0,
                        @nroAfiliadoTitular
                        )
                END
                ELSE
                        IF(@tipoAfiliado = 'F')
                        BEGIN
                                SET @Nro_AfiliadoRaiz = CUATRO_QUESOS.siguienteNroFamiliar(@Nro_AfiliadoRaiz)
                                INSERT INTO CUATRO_QUESOS.Afiliados
                                (Nro_Afiliado,Nombre,Apellido,Sexo,Tipo_Doc,Nro_Doc,Direccion,Mail,Telefono,Fecha_Nac,Cod_Plan,Estado_Civil,CantFamiliaresACargo, Nro_Titular)
                                VALUES (
                                @Nro_AfiliadoRaiz,
                                @Nombre,
                                @Apellido,
                                @Sexo,
                                @Tipo_Doc,
                                @Nro_Doc,
                                @Direccion,
                                @Mail,
                                @Telefono,
                                @Fecha_Nac,
                                @Cod_Plan,
                                'Soltero/a' , -- Como no interesa el estado civil de un hijo / familiar a cargo, se pone Soltero/a por defecto
                                0,
                                @nroAfiliadoTitular
                                )
                        END
END
GO

--devuelve el datatable con los afiliados, filtrados por nombre, apellido, tipo de documento, numero de documento o numero de afiliado raiz
CREATE PROCEDURE CUATRO_QUESOS.getAfiliados @nombre varchar(255), @apellido varchar(255), @tipoDoc varchar(3), @nroDoc numeric(18), @nroAfiliadoRaiz numeric(18)
AS
SELECT TOP 100 Nro_Afiliado 'Nª Afiliado',Nombre 'Nombre', Apellido 'Apellido',Sexo 'Sexo',
Tipo_Doc 'Tipo Documento',Nro_Doc 'Nª Documento', Direccion 'Dirección',Telefono 'Teléfono', Mail 'Mail',
Fecha_Nac 'Fecha de Nacimiento', Planes_Medicos.Descripcion 'Plan Medico', Estado_Civil 'Estado Civil',Nro_Titular 'Nª Afiliado de Titular',
Nro_Conyuge 'Nª Afiliado de Conyuge', Fecha_Baja 'Fecha de Baja', Nro_Consulta 'Nª de Consultas Realizadas',CantFamiliaresACargo 'Cantidad de Familiares a Cargo'
FROM CUATRO_QUESOS.Afiliados LEFT JOIN CUATRO_QUESOS.Planes_Medicos ON Afiliados.Cod_Plan = Planes_Medicos.Codigo
WHERE Nombre LIKE '%' + @nombre + '%'
AND Apellido LIKE '%' + @apellido + '%'
AND Tipo_Doc LIKE '%' + @tipoDoc + '%'
AND ((@nroDoc > 0 AND Nro_Doc = @nroDoc) OR (@nroDoc = 0))
AND ((@nroAfiliadoRaiz > 99 AND Nro_Afiliado BETWEEN @nroAfiliadoRaiz AND @nroAfiliadoRaiz + 100) OR
(@nroAfiliadoRaiz <= 99))
ORDER BY Nro_Afiliado DESC
GO

CREATE PROCEDURE CUATRO_QUESOS.darBajaAfiliado(@nroAfiliado numeric(18), @fechaSistema datetime) --la baja de un afiliado es logica, no fisica
AS
IF(CUATRO_QUESOS.tipoAfiliado(@nroAfiliado) = 1) --si el afiliado a dar de baja es titular, da de baja tambien a su conyuge y a los familiares que tiene a cargo
BEGIN
        UPDATE CUATRO_QUESOS.Afiliados
        SET Fecha_Baja = @fechaSistema
        WHERE Nro_Afiliado = @nroAfiliado OR Nro_Conyuge = @nroAfiliado OR Nro_Titular = @nroAfiliado
END
ELSE
BEGIN        -- si es otro tipo de afiliado, le da de baja solamente a el
        UPDATE CUATRO_QUESOS.Afiliados
        SET Fecha_Baja = @fechaSistema
        WHERE Nro_Afiliado = @nroAfiliado
END

GO

--busca si ya existe un afiliado, especificando su nombre, apellido, tipo de documento y numero, devuelve su numero de afiliado
CREATE PROCEDURE CUATRO_QUESOS.buscarNroAfiliado @nombre varchar(255), @apellido varchar(255), @tipoDoc varchar(3), @nroDoc numeric(18)
AS
DECLARE @nroAfiliado numeric(18)

SELECT @nroAfiliado = Nro_Afiliado
FROM CUATRO_QUESOS.Afiliados
WHERE Nombre = @nombre AND Apellido = @apellido AND Tipo_Doc = @tipoDoc AND Nro_Doc = @nroDoc

RETURN @nroAfiliado
GO

--actualiza el numero de conyuge de un afiliado
CREATE PROCEDURE CUATRO_QUESOS.updateNroConyuge (@nroAfiliado numeric(18))
AS
UPDATE CUATRO_QUESOS.Afiliados
SET Nro_Conyuge = @nroAfiliado
WHERE Nro_Afiliado = (@nroAfiliado - 1)
GO

--funcionalidad que actualiza los datos de un afiliado en sus campos factibles de ser modificados
CREATE PROCEDURE CUATRO_QUESOS.updateAfiliado (
@nroAfiliado numeric(18),
@direccion varchar(255),
@telefono numeric(18),
@mail varchar(255),
@cod_plan numeric(18),
@estadoCivil varchar(255),
@cantFamiliares tinyint)
AS
BEGIN

IF(CUATRO_QUESOS.tipoAfiliado(@nroAfiliado) = 1)
        BEGIN
                UPDATE CUATRO_QUESOS.Afiliados
                SET Direccion = @direccion,
                Telefono = @telefono,
                Mail = @mail,
                Cod_Plan = @cod_plan,
                Estado_Civil = @estadoCivil,
                CantFamiliaresACargo = @cantFamiliares
                WHERE Nro_Afiliado = @nroAfiliado
        END
ELSE
        BEGIN

                UPDATE CUATRO_QUESOS.Afiliados
                SET Direccion = @direccion,
                Telefono = @telefono,
                Mail = @mail,
                Cod_Plan = @cod_plan
                WHERE Nro_Afiliado = @nroAfiliado
        
        END

END

GO

/********* FIN PROCEDURES AFILIADOS ***************/


/********** PROCEDURES PLANES MEDICOS ************/

--devuelve los planes medicos existentes
CREATE PROCEDURE CUATRO_QUESOS.getPlanesMedicos @codigo numeric(18), @descripcion varchar(255),@precioBonoConsulta int, @precioBonoFarmacia int
AS
SELECT Codigo, Descripcion, Precio_Bono_Consulta 'Precio Bono Consulta', Precio_Bono_Farmacia 'Precio Bono Farmacia'
FROM Planes_Medicos
WHERE ((Codigo = @codigo AND @codigo > 0) OR (@codigo = 0))
AND Descripcion LIKE '%' + @descripcion + '%'
AND Precio_Bono_Consulta >= @precioBonoConsulta
AND Precio_Bono_Farmacia >= @precioBonoFarmacia
GO

--registra el momento y el motivo del cambio de un plan medico por parte de un afiliado
CREATE PROCEDURE CUATRO_QUESOS.registrarCambioPlanMedico
@nroAfiliado numeric(18),
@fecha datetime,
@planMedicoAnterior numeric(18),
@planMedicoNuevo numeric(18),
@motivo varchar(255)

AS
BEGIN
        INSERT INTO CUATRO_QUESOS.Cambios_Plan(Nro_Afiliado, Fecha, Plan_Origen, Plan_Destino, Motivo)
        VALUES (@nroAfiliado, @fecha, @planMedicoAnterior, @planMedicoNuevo, @motivo)
END
GO
/********** FIN PROCEDURES PLANES MEDICOS ************/

/********* PROCEDURES ABM ROL ************/

create procedure CUATRO_QUESOS.getRoles(@nombre varchar(50)) --devuelve los roles existentes
as
select Id_Rol 'ID Rol',
	   Nombre 'Nombre',
	   Habilitado 'Habilitado'
from CUATRO_QUESOS.Roles
where Nombre like '%' + @nombre + '%'

go

CREATE PROCEDURE CUATRO_QUESOS.inhabilitarRol(@rol numeric(18)) --da de baja un rol de forma logica, inhabilitandolo
AS
        BEGIN TRAN
				UPDATE CUATRO_QUESOS.Roles 
                SET Habilitado = 0
                where Id_Rol = @rol
        COMMIT
        
go

CREATE PROCEDURE CUATRO_QUESOS.habilitarRol(@rol numeric(18)) --habilita el rol dado de baja anteriormente
AS
        BEGIN TRAN
				UPDATE CUATRO_QUESOS.Roles 
                SET Habilitado = 1
                where Id_Rol = @rol
        COMMIT

go

CREATE PROCEDURE CUATRO_QUESOS.getIdRol(@nombre varchar(50)) --devuelve el ID de un rol segun su nombre
AS
BEGIN
        DECLARE @Id numeric(18,0)
        SELECT @Id = Id_Rol
        FROM CUATRO_QUESOS.Roles
        WHERE Nombre = @nombre
        RETURN @Id
END

go

--asocia una funcionalidad a un rol
CREATE PROCEDURE CUATRO_QUESOS.altaRol_Funcionalidad ( @codFuncionalidad numeric(18), @Id numeric(18) )
AS
INSERT INTO CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Funcionalidad, Id_Rol)
VALUES (@codFuncionalidad, @Id)

go

create procedure CUATRO_QUESOS.addFuncionalidadARol(@rol numeric(18), @funcionalidad numeric(18)) --me refiero a los id
as
        begin
                insert into CUATRO_QUESOS.Roles_Por_Funcionalidades(Id_Rol, Id_Funcionalidad)
                values (@rol, @funcionalidad)
        end
        
go

create procedure CUATRO_QUESOS.sacarTodaFuncionalidadARol(@rol numeric(18))
as
        begin
                delete from CUATRO_QUESOS.Roles_Por_Funcionalidades
                where Id_Rol = @rol --va a borrar a todas las filas que cumplan esta condicion
        end
        
go

create procedure CUATRO_QUESOS.altaRol(@nombre varchar(50))
--aca el id lo va a autogenerar
as
        begin
                insert into CUATRO_QUESOS.Roles(Nombre, Habilitado)
                values(@nombre, 1)
        end
        
go
        
create procedure CUATRO_QUESOS.getFuncionalidades --devuelve las funcionalidades existentes
as
        begin
                SELECT Id_Funcionalidad 'Id_Funcionalidad', Descripcion 'Descripcion'
                FROM CUATRO_QUESOS.Funcionalidades
        end

go
        
CREATE PROCEDURE CUATRO_QUESOS.modificarRol(@idRol numeric(18),@nombre varchar(50)) --modifica el nombre de un rol
AS
UPDATE CUATRO_QUESOS.Roles
SET Nombre = @nombre
WHERE Id_Rol = @idRol

go

create procedure CUATRO_QUESOS.getNombreRol(@idRol numeric(18)) --devuelve el nombre de un rol pasando su id por parametro
as
        begin
                SELECT Nombre 'NombreRol'
                FROM CUATRO_QUESOS.Roles
                WHERE Id_Rol = @idRol
        end
        
GO

create procedure CUATRO_QUESOS.getFuncionalidadesRol(@idRol numeric(18)) --devuelve las funcionalidades asociadas a un rol
as
        begin
                SELECT rf.Id_Funcionalidad 'Id_Funcionalidad'
                FROM CUATRO_QUESOS.Roles r, CUATRO_QUESOS.Funcionalidades f, CUATRO_QUESOS.Roles_Por_Funcionalidades rf
                WHERE r.Id_Rol = @idRol and r.Id_Rol = rf.Id_Rol and f.Id_Funcionalidad = rf.Id_Funcionalidad
        end
GO

/********* FIN PROCEDURES ABM ROL ************/

/********* PROCEDURES ABM CANCELACION ************/

CREATE TYPE [CUATRO_QUESOS].[TURNOS_MEDICO] AS TABLE( --se crea un tipo turno medico
[numero] [numeric](18, 0) NOT NULL,
[nombre_paciente] [varchar](255) NOT NULL,
[paciente_apellido] [varchar](255) NOT NULL,
[fecha] [date] NOT NULL
)
GO

--devuelve los turnos asociados a un medico
CREATE PROCEDURE [CUATRO_QUESOS].[getTurnosDeMedico]
(@Nombre VARCHAR(255), 
@Apellido VARCHAR(255),
@Documento NUMERIC(18,0),
@TipoDoc VARCHAR(3),
@DesdeFecha DATE,
@HastaFecha DATE)
AS
declare @ID_Medico numeric(18)
EXEC @ID_Medico = CUATRO_QUESOS.getIdMedico @Nombre, @Apellido, @TipoDoc, @Documento
SELECT t.numero, a.nombre AS 'Nombre Paciente', a.apellido AS 'Apellido Paciente', t.fecha
FROM CUATRO_QUESOS.Turnos t
JOIN CUATRO_QUESOS.Afiliados a
ON t.nro_afiliado = a.nro_afiliado
AND t.id_medico = @ID_Medico
WHERE t.Numero NOT IN(
                SELECT c.Nro_Turno
                FROM CUATRO_QUESOS.Cancelaciones c)
        AND((CAST(fecha AS DATE) BETWEEN CAST(@DesdeFecha AS DATE) AND CAST(@HastaFecha AS DATE))
        OR (@DesdeFecha IS NULL AND @HastaFecha IS NULL)
        OR (@DesdeFecha = '' AND @HastaFecha = ''))
        AND t.Numero NOT IN (SELECT Consultas.Nro_Turno FROM CUATRO_QUESOS.Consultas)
GO

--devuelve los turnos asociados a un afiliado
CREATE PROCEDURE [CUATRO_QUESOS].[getTurnosDeAfiliado](@Nombre VARCHAR(255), @Apellido VARCHAR(255), @Documento NUMERIC, @TipoDoc VARCHAR(3))
AS
DECLARE @nro NUMERIC(18,0)
SET @nro = (SELECT CUATRO_QUESOS.getNroAfiliado(@Nombre, @Apellido, @Documento, @TipoDoc))
SELECT t.numero, m.nombre AS 'Nombre Médico', m.apellido AS 'Apellido Médico', t.fecha, e.descripcion AS Especialidad
FROM CUATRO_QUESOS.Medicos m
JOIN CUATRO_QUESOS.Turnos t
        ON t.id_medico = m.id_medico
        AND nro_afiliado = @nro
JOIN CUATRO_QUESOS.Especialidades e
        ON t.cod_especialidad = e.Codigo
WHERE t.Numero NOT IN(
                SELECT c.Nro_Turno
                FROM CUATRO_QUESOS.Cancelaciones c)
                AND t.Numero NOT IN (SELECT Consultas.Nro_Turno FROM CUATRO_QUESOS.Consultas)
GO

--cancela un turno especificado, ingresando su motivo
CREATE PROCEDURE [CUATRO_QUESOS].[cancelarTurno]( @Nro_Turno NUMERIC(18,0),@TipoMotivo VARCHAR(255), @Motivo VARCHAR(255) )
AS
INSERT INTO CUATRO_QUESOS.Cancelaciones (Nro_Turno, Tipo, Motivo)
VALUES (@Nro_Turno, @TipoMotivo, @Motivo)
GO

--cancela un periodo, setiando el tipo de motivo por no asistencia
CREATE PROCEDURE [CUATRO_QUESOS].[cancelarPeriodo](@Tabla CUATRO_QUESOS.TURNOS_MEDICO READONLY,@Motivo VARCHAR(255))
AS
        INSERT INTO CUATRO_QUESOS.Cancelaciones
        SELECT t.numero, 'No asistencia', @Motivo
        FROM @Tabla t
GO


/********* FIN PROCEDURES ABM CANCELACION ************/

/********* PROCEDURES COMPRA DE BONOS ************/

--funcionalidad que compra una cantidad de bonos de consulta y de farmacia, pasando cantidades respectivas por parametro
create procedure CUATRO_QUESOS.comprarBonos(@afiliado numeric(18), @cant_farmacia int, @cant_consulta int, @fechaSistema datetime)
as
begin
        declare @plan numeric(18);
        declare @precio_consulta numeric(18);
        declare @precio_farmacia numeric(18);
        declare @id_compra numeric(18);
        
        select @plan = Cod_Plan, @precio_consulta = Planes_Medicos.Precio_Bono_Consulta, @precio_farmacia = Planes_Medicos.Precio_Bono_Farmacia
        from CUATRO_QUESOS.Afiliados inner join CUATRO_QUESOS.Planes_Medicos on Afiliados.Cod_Plan = Planes_Medicos.Codigo
        where Afiliados.Nro_Afiliado = @afiliado
        
        set @id_compra = (select COUNT(*) from CUATRO_QUESOS.Compra) + 1

        set IDENTITY_INSERT CUATRO_QUESOS.Compra ON
        insert into CUATRO_QUESOS.Compra(Id_Compra, Nro_Afiliado, Fecha, Cantidad_Comprada_Consulta, Cantidad_Comprada_Farmacia, Monto)
        values (
                        @id_compra,
                        @afiliado,
                        @fechaSistema,
                        @cant_consulta,
                        @cant_farmacia,
                        (@precio_consulta * @cant_consulta + @precio_farmacia * @cant_farmacia)
                        )
        set IDENTITY_INSERT CUATRO_QUESOS.Compra OFF        
        
        declare @c int;
        declare @f int;
        declare @c_base int;
        declare @f_base int;
        set @c=0;
        set @f=0;
        set @c_base = (select MAX(Numero) from CUATRO_QUESOS.Bonos where Tipo_Bono = 'Consulta') + 1;
        set @f_base = (select MAX(Numero) from CUATRO_QUESOS.Bonos where Tipo_Bono = 'Farmacia') + 1;
        
        while (@c < @cant_consulta)
        begin
                insert into CUATRO_QUESOS.Bonos(Numero, Fecha_Impresion, Nro_Afiliado, Cod_Plan, Id_Compra, Tipo_Bono, Fecha_Vencimiento, Nro_Consulta, Nro_Usuario)
                values
                        (
                        (@c_base+@c),
                        @fechaSistema,
                        @afiliado,
                        @plan,
                        @id_compra,
                        'Consulta',
                        NULL,
                        NULL,
                        NULL
                        )
                        
                set @c = @c+1
        end
        
                        while (@f < @cant_farmacia)
        begin
                insert into CUATRO_QUESOS.Bonos(Numero, Fecha_Impresion, Nro_Afiliado, Cod_Plan, Id_Compra, Tipo_Bono, Fecha_Vencimiento, Nro_Consulta, Nro_Usuario)
                values
                        (
                        (@f_base+@f),
                        @fechaSistema,
                        @afiliado,
                        @plan,
                        @id_compra,
                        'Farmacia',
                        dateadd(day, 60, @fechaSistema),
                        NULL,
                        NULL
                        )
                        
                set @f = @f+1
        end        

        return (@precio_consulta * @cant_consulta + @precio_farmacia * @cant_farmacia)

end

GO

--devuelve los datos de la compra de un afiliado
create procedure CUATRO_QUESOS.getDatosParaCompra (@afiliado numeric(18))
as
begin
        select Descripcion, Precio_Bono_Consulta, Precio_Bono_Farmacia
        from CUATRO_QUESOS.Afiliados inner join CUATRO_QUESOS.Planes_Medicos on Cod_Plan = Codigo
        where Afiliados.Nro_Afiliado = @afiliado and afiliados.Fecha_Baja is null
end

GO

/********* FIN PROCEDURES COMPRA DE BONOS ************/

/********* PROCEDURES LOGIN ************/


--intenta loguear con el usuario y password especificados, en caso de no poder incrementa un intento
CREATE PROCEDURE CUATRO_QUESOS.intentarLogear( @username VARCHAR(20) , @pass BINARY(32) )
AS
BEGIN
	DECLARE @resultado TINYINT
	
	IF EXISTS(SELECT * FROM CUATRO_QUESOS.Usuarios WHERE username = @username)
		BEGIN
			IF (CUATRO_QUESOS.estaHabilitadoUsuario(@username)) = 1
				BEGIN
					IF @pass = CUATRO_QUESOS.getPass(@username)
						BEGIN
							UPDATE CUATRO_QUESOS.Usuarios
							SET Intentos_Fallidos = 0, @resultado = 0
							WHERE Username = @username
						END
					ELSE
						BEGIN
							UPDATE CUATRO_QUESOS.Usuarios
							SET Intentos_Fallidos = Intentos_Fallidos + 1, @resultado = Intentos_Fallidos + 1
							WHERE Username = @username
						END
				END
			ELSE
				SET @resultado = 4
	END
	ELSE SET @resultado = 5

	RETURN @resultado
END
GO

--devuelve los roles de un usuario pasado por parametro
CREATE PROCEDURE CUATRO_QUESOS.traerRolesDeUsuario(@username VARCHAR(20))
AS
BEGIN
	SELECT r.id_rol, r.Nombre, r.Habilitado
	FROM CUATRO_QUESOS.Roles r, CUATRO_QUESOS.Usuarios_Por_Rol ur
	WHERE ur.Username = @username AND ur.id_rol = r.id_rol
END
GO

--devuelve las funcionalidades que tiene un rol especificado
CREATE PROCEDURE CUATRO_QUESOS.traerFuncionalidadesDeRol(@rol NUMERIC(18,0))
AS
BEGIN
	SELECT f.id_funcionalidad, f.descripcion
	FROM CUATRO_QUESOS.Funcionalidades f, CUATRO_QUESOS.Roles_Por_Funcionalidades rf
	WHERE rf.id_rol = @rol AND rf.id_funcionalidad = f.id_funcionalidad
END
GO

--trae los datos del usuario con el rol seleccionado
CREATE PROCEDURE CUATRO_QUESOS.traerDatosUsuario(@username VARCHAR(20), @rol VARCHAR(50))
AS
BEGIN
	IF( @rol = 'Profesional' )
				SELECT	m.* 
				FROM CUATRO_QUESOS.Medicos m, CUATRO_QUESOS.Usuarios_Medicos um 
				WHERE um.username = @username AND um.id_medico = m.id_medico
	ELSE IF( @rol = 'Afiliado' )	 
				SELECT a.*
				FROM CUATRO_QUESOS.Afiliados a, CUATRO_QUESOS.Usuarios_Afiliados ua
				WHERE ua.username = @username AND ua.nro_afiliado = a.nro_afiliado
END
GO

/********* FIN PROCEDURES LOGIN ************/

/********* PROCEDURES REGISTRO DE LLEGADA *********/


--devuelve los turnos que tiene un afiliado para cierto profesional, estando estos no cancelados ni registrados
CREATE PROCEDURE CUATRO_QUESOS.getTurnosAfiliadoMedicoRegistroLlegada @nroAfiliado numeric(18), @id_profesional numeric(18), @fechaSistema datetime
AS
SELECT Afiliados.Nombre+' '+ Afiliados.Apellido 'Afiliado', Medicos.Nombre+' '+Medicos.Apellido 'Médico', 
Especialidades.Descripcion 'Especialidad', Turnos.Numero 'Nro. de Turno', Turnos.Fecha 'Fecha de Turno'
FROM CUATRO_QUESOS.Turnos JOIN CUATRO_QUESOS.Afiliados ON Turnos.Nro_Afiliado = Afiliados.Nro_Afiliado
JOIN CUATRO_QUESOS.Medicos ON Medicos.Id_Medico = Turnos.Id_Medico
JOIN CUATRO_QUESOS.Especialidades ON Especialidades.Codigo = Turnos.Cod_Especialidad
WHERE Turnos.Id_Medico = @id_profesional
AND ((Turnos.Nro_Afiliado = @nroAfiliado AND @nroAfiliado != 0) OR (@nroAfiliado = 0) )
AND Turnos.Fecha >= @fechaSistema
AND DAY(Turnos.Fecha) = DAY(@fechaSistema)
AND MONTH(Turnos.Fecha) = MONTH(@fechaSistema)
AND YEAR(Turnos.Fecha) = YEAR(@fechaSistema)
AND Turnos.Numero NOT IN (SELECT Consultas.Nro_Turno FROM CUATRO_QUESOS.Consultas)
AND Turnos.Numero NOT IN (SELECT Cancelaciones.Nro_Turno FROM CUATRO_QUESOS.Cancelaciones)
GO

--devuelve los bonos de consulta que tiene el grupo familiar de un afiliado, siendo congruentes con su plan medico
CREATE PROCEDURE CUATRO_QUESOS.getBonoConsultaRegistroLlegada @nroAfiliado numeric(18)
AS
SELECT Bonos.Numero 'Nro. de Bono', Bonos.Cod_Plan 'Codigo de Plan', 
Bonos.Fecha_Impresion 'Fecha de Impresión', Bonos.Nro_Afiliado 'Nro. Afiliado Comprador'
FROM CUATRO_QUESOS.Bonos 
WHERE Bonos.Tipo_Bono = 'Consulta' 
AND EXISTS (
SELECT * FROM CUATRO_QUESOS.Afiliados 
WHERE Afiliados.Nro_Afiliado = @nroAfiliado 
AND Bonos.Nro_Afiliado BETWEEN CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado) AND CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado)+99
)
AND Bonos.Cod_Plan IN (
SELECT Afiliados.Cod_Plan 
FROM CUATRO_QUESOS.Afiliados 
WHERE Afiliados.Nro_Afiliado = @nroAfiliado
) 
AND Bonos.Nro_Usuario IS NULL
AND Bonos.Nro_Consulta IS NULL
GO

--registra la llegada de un afiliado, efectivizando la creacion de una consulta
CREATE PROCEDURE CUATRO_QUESOS.registrarLlegada 
@numeroAfiliado numeric(18), @numeroBono numeric(18), @numeroTurno numeric(18), @fechaAtencion datetime, @fechaLlegada datetime
AS
BEGIN TRAN

--Inserto en consultas una vez registrada la llegada
INSERT INTO CUATRO_QUESOS.Consultas(Enfermedades, Fecha_Atencion, Fecha_Llegada, Nro_Bono_Consulta, Nro_Turno, Sintomas, Tipo_Bono)
VALUES('no registrado aún', @fechaAtencion, @fechaLlegada, @numeroBono, @numeroTurno, 'no registrado aún', 'Consulta') --dejo sintomas y enfermedades como no registrado aún, luego esto se completara en el registro de resultados

UPDATE CUATRO_QUESOS.Bonos --Actualizo el bono que utilize para la consulta
SET Bonos.Nro_Usuario = @numeroAfiliado, Bonos.Nro_Consulta = 
( --busco el numero de la consulta para este afiliado
SELECT Afiliados.Nro_Consulta + 1 FROM CUATRO_QUESOS.Afiliados
WHERE Nro_Afiliado = @numeroAfiliado
)
WHERE Bonos.Tipo_Bono = 'Consulta' 
AND Bonos.Numero = @numeroBono 

COMMIT
GO

/******* FIN PROCEDURES REGISTRO DE LLEGADA ********/

/* ****** PROCEDURES REGISTRAR AGENDA ****** */

create procedure CUATRO_QUESOS.verifyMedico(@ID numeric(18)) --verifica la existencia de un médico
as
begin
	if (select COUNT(*) from CUATRO_QUESOS.Medicos where ID_Medico = @ID and Habilitado = 1) > 0
	begin
		return @ID
	end
	return 0
end

GO

create procedure CUATRO_QUESOS.getNYAMedico (@ID numeric(18)) --trae nombre y apellido, y averigua si registró agenda
as
	select Nombre 'Nombre', 
		Apellido 'Apellido', 
		case when (Fecha_Atencion_Desde is null or Fecha_Atencion_Hasta is null) then 'N'
			else 'S'
		end 'Tiene_Agenda'
	from CUATRO_QUESOS.Medicos where ID_Medico = @ID
GO

create procedure CUATRO_QUESOS.getDiasAtencion(@Id_Medico numeric(18)) --devuelve los dias de atencion de un medico
as
begin
	select Dia_Semana, Hora_Desde, Hora_Hasta from CUATRO_QUESOS.Dias_Atencion where Id_Medico = @Id_Medico
end

GO

create procedure CUATRO_QUESOS.quitarDiaAtencion(@id_medico numeric(18), @Dia_Semana tinyint) --elimina un dia de atencion especificado para un medico
as
begin
	delete from CUATRO_QUESOS.Dias_Atencion
	where Id_Medico = @id_medico and Dia_Semana = @Dia_Semana
end

GO

--modifica el horario de atencion para un dia
create procedure CUATRO_QUESOS.modificarDiaAtencion(@Id_Medico numeric(18), @Dia_Semana tinyint, @str_desde char(5), @str_hasta char(5))
as
begin
	declare @desde time;
	declare @hasta time;
	
	set @desde = CONVERT(time, @str_desde);
	set @hasta = CONVERT(time, @str_hasta);
	
	update CUATRO_QUESOS.Dias_Atencion set Hora_Desde = @desde, Hora_Hasta = @hasta
	where Dia_Semana = @Dia_Semana and Id_Medico = @Id_Medico
	
end

GO
--crea un nuevo dia de atencion con horarios para un medico
create procedure CUATRO_QUESOS.agregarDiaAtencion(@Id_Medico numeric(18), @Dia_Semana tinyint, @str_desde char(5), @str_hasta char(5))
as
begin
	declare @desde time;
	declare @hasta time;
	
	set @desde = CONVERT(time, @str_desde);
	set @hasta = CONVERT(time, @str_hasta);
	
	--la validez de los datos que llegan aca (que no sea un intervalo negativo, que los strings estén bien formateados, etc) se verifica en la app
	
	insert into CUATRO_QUESOS.Dias_Atencion(Id_Medico, Dia_Semana, Hora_Desde, Hora_Hasta)
	values(@Id_Medico, @Dia_Semana, @desde, @hasta)

end

GO

--actualiza las fechas de atencion desde y hasta de un medico una vez registrada la agenda
create procedure CUATRO_QUESOS.updateFechasMedico(@id_medico numeric(18), @desde datetime, @hasta datetime)
as
begin
	update CUATRO_QUESOS.Medicos set Fecha_Atencion_Desde = @desde, Fecha_Atencion_Hasta = @hasta
	where Id_Medico = @id_medico
end

GO

--genera la agenda para un medico, creando timeslots segun la fecha desde la que atiende hasta la que finaliza la agenda
create procedure CUATRO_QUESOS.generarAgenda(@ID numeric(18), @fecha_desde datetime, @fecha_hasta datetime)
--al ejecutarse este SP la app ya verificó que los campos que voy a usar son no-nulos
as
begin

set language 'spanish'
set datefirst 1 --porque para nosotros 1 significa lunes, y si esto llega a correr en una máquina con inglés americano por default, va a romper

/* -- creo horas del día -- */
create table #horas_del_dia
(
        hora time
)

declare @offset tinyint
set @offset = 0

while @offset < 24
begin
        insert into #Horas_del_dia(hora)
        values(DATEADD(hour, @offset, '00:00:00'))
        insert into #Horas_del_dia(hora)
        values(DATEADD(hour, @offset, '00:30:00'))
        set @offset = @offset+1
end
/* -- fin horas del día -- */
--esta tabla contiene todos los intervalos de media hora que hay en un día dado

/* -- creo días -- */
create table #Dias
(
        dia date
)


declare @acum_fecha datetime
set @acum_fecha = @fecha_desde
while @acum_fecha <= @fecha_hasta
begin
        insert into #Dias(dia)
        values(@acum_fecha)
        set @acum_fecha = (DATEADD(day, 1, @acum_fecha))
end
/* -- fin días -- */
--esta tabla contiene todos los días incluidos en el intervalo del médico. o sea, tiene máximo 120 filas

/* -- traigo turnos relevantes -- */
create table #turnos_relevantes
 (
        Numero numeric(18) NOT NULL,
        Fecha datetime NOT NULL,
        Nro_Afiliado numeric(18) NOT NULL,
        Id_Medico numeric(18) NOT NULL,
        Cod_Especialidad numeric(18) NOT NULL
)
;

insert into #turnos_relevantes
select Numero, Fecha, Nro_Afiliado, Id_Medico, Cod_Especialidad from CUATRO_QUESOS.Turnos
	where ID_Medico = @ID and  Fecha <= @fecha_hasta and (Fecha  > @fecha_desde or (cast(Fecha as date) = cast (@fecha_desde as date))) --me traigo TODO el día actual, aunque me esté metiendo (por horas) en el pasado - esto es porque, por cómo genero los timeslots, necesito trabajar con días enteros
--básicamente me traigo los turnos que "sirven" de la tabla gigante de turnos, para que los selects que vienen después sean más fáciles y espero que más rápidos


/* -- fin turnos relevantes -- */

insert into CUATRO_QUESOS.Agendas_Medicos(Id_Medico, Fecha_Hora, Nro_Turno)

select  Medicos.Id_Medico as Id_Medico,
		(CAST(dia as datetime) + cast(hora as datetime)) as Fecha_Hora,
		(case when ((select COUNT(*)
					from #turnos_relevantes 
					where Fecha = (CAST(dia as datetime) + cast(hora as datetime))) > 0)
			  then  (select top 1 Numero --este top 1 no debería ser necesario ya que no se están permitiendo sobreturnos
					from #turnos_relevantes 
					where Fecha = (CAST(dia as datetime) + cast(hora as datetime)))
			 else NULL
			 end) as Nro_Turno --si hay un turno a esa hora lo asocio, si no hay lo dejo en NULL (el médico está libre en ese timeslot)
		
from CUATRO_QUESOS.Medicos, #dias as dia, #horas_del_dia as hora

where Medicos.Id_Medico = @ID 
		and (DATEPART(DW, dia) in (select Dia_Semana from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = medicos.id_medico))
        and (hora >= (select hora_desde from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = Medicos.Id_Medico and Dias_Atencion.Dia_Semana = DATEPART(dw, dia)))
        and (hora < (select Hora_Hasta from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = Medicos.Id_Medico and Dias_Atencion.Dia_Semana = DATEPART(dw, dia)))

end


GO
/****** FIN PROCEDURES REGISTRAR AGENDA ******/

/****** PROCEDURES LISTADOS ESTADISTICOS ******/

-- genera el listado correspondiente al top 5 de bonos vencidos por afiliados
CREATE PROCEDURE CUATRO_QUESOS.bonosVencidosPorAfiliado (@ANIO INT, @MES INT, @FINMES INT = NULL, @FECHASISTEMA DATETIME)
AS
BEGIN
	SET LANGUAGE 'SPANISH'
	DECLARE @PrincipioMES DATETIME = DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@MES-1,0)
	DECLARE @FinalMES DATETIME = CASE WHEN @FINMES IS NULL THEN CUATRO_QUESOS.getFinalDeMes(@PrincipioMES)
											ELSE CUATRO_QUESOS.getFinalDeMes(DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@FINMES-1,0))
											END
											
	SELECT A.Nro_afiliado,  A.nombre + ' ' + A.apellido , COUNT(*) CANTIDAD
	FROM CUATRO_QUESOS.Afiliados A, CUATRO_QUESOS.Bonos B
	WHERE B.Nro_Afiliado = A.Nro_Afiliado AND B.Tipo_Bono = 'Farmacia'
		  AND B.Fecha_Vencimiento BETWEEN @PrincipioMES AND @FinalMES --los bonos vencidos en un intervalo mensual
		  AND B.Fecha_Vencimiento < @FECHASISTEMA --cuya fecha de ya haya pasado respecto a la del sistema
		  AND B.Nro_Usuario	IS NULL --que no hayan sido usados
	GROUP BY A.Nro_afiliado, A.nombre, A.apellido
	ORDER BY COUNT(B.Numero) DESC
END
GO

-- genera el listado de top 5 de especialidades con mas recetas
CREATE PROCEDURE CUATRO_QUESOS.especialidadesConMasRecetas (@ANIO INT, @MES INT, @FINMES INT = NULL)
AS
BEGIN
	SET LANGUAGE 'SPANISH'
	DECLARE @PrincipioMES DATETIME = DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@MES-1,0)
	DECLARE @FinalMES DATETIME = CASE WHEN @FINMES IS NULL THEN CUATRO_QUESOS.getFinalDeMes(@PrincipioMES)
											ELSE CUATRO_QUESOS.getFinalDeMes(DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@FINMES-1,0))
											END
	
	SELECT E.Codigo , E.Descripcion , COUNT(DISTINCT(B.Numero)) CANTIDAD  
	FROM CUATRO_QUESOS.Medicamentos_por_consulta MC, CUATRO_QUESOS.Turnos T, CUATRO_QUESOS.Consultas C, CUATRO_QUESOS.Bonos B, CUATRO_QUESOS.Especialidades E
	WHERE C.Nro_Turno = T.Numero AND T.Cod_Especialidad = E.Codigo AND MC.ID_Consulta = C.ID_Consulta AND MC.Nro_Bono_Farmacia = B.Numero
		AND T.Fecha BETWEEN @PrincipioMES AND @FinalMES
	GROUP BY E.Codigo, E.Descripcion
	ORDER BY COUNT(DISTINCT( B.Numero )) DESC
END
GO

-- genera el listado de top 5 de especialidades con mas cancelaciones
CREATE PROCEDURE CUATRO_QUESOS.especialidadesConMasCancelaciones (@ANIO INT, @MES INT, @FINMES INT = NULL)
AS
BEGIN
 	SET LANGUAGE 'SPANISH'
	DECLARE @PrincipioMES DATETIME = DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@MES-1,0)
	DECLARE @FinalMES DATETIME = CASE WHEN @FINMES IS NULL THEN CUATRO_QUESOS.getFinalDeMes(@PrincipioMES)
											ELSE CUATRO_QUESOS.getFinalDeMes(DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@FINMES-1,0))
											END
											
	SELECT E.Codigo, E.Descripcion,COUNT(E.Descripcion) AS CANTIDAD
	FROM CUATRO_QUESOS.Especialidades E, CUATRO_QUESOS.Turnos T, CUATRO_QUESOS.Cancelaciones C
	WHERE C.Nro_Turno = T.Numero AND T.COD_Especialidad = E.Codigo
		AND T.fecha	BETWEEN @PrincipioMES AND @FinalMES	
	GROUP BY E.Codigo, E.Descripcion
	ORDER BY COUNT(E.Descripcion) DESC
END
GO

-- genera el top 10 de los afiliados que usaron bonos que ellos mismos no compraron
CREATE PROCEDURE [CUATRO_QUESOS].[bonosPorTerceros] (@ANIO INT, @MES INT, @FINMES INT = NULL)
AS
BEGIN
	SET LANGUAGE 'SPANISH'
	DECLARE @PrincipioMES DATETIME = DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@MES-1,0)
	DECLARE @FinalMES DATETIME = CASE WHEN @FINMES IS NULL THEN CUATRO_QUESOS.getFinalDeMes(@PrincipioMES)
											ELSE CUATRO_QUESOS.getFinalDeMes(DATEADD(yy,(@ANIO-1900),0) + DATEADD(mm,@FINMES-1,0))
											END
	
	SELECT A.Nro_Afiliado, A.nombre + ' ' + A.apellido, COUNT(B.numero) AS CANTIDAD
	FROM CUATRO_QUESOS.Bonos B, CUATRO_QUESOS.Afiliados A
	WHERE B.Nro_Usuario = A.Nro_Afiliado AND B.Nro_Afiliado != B.Nro_Usuario -- el numero de usuario y el del afiliado que los compro seran distintos 
		AND B.Fecha_Impresion BETWEEN @PrincipioMES AND @FinalMES
	GROUP BY A.Nro_Afiliado, A.nombre, A.apellido
	ORDER BY COUNT(B.numero) DESC
END
GO

--permite decidir que listado traer segun un identificador
--el proposito es poder separar que listado traer de como se arman
--ya que se arman todos igual, pero se traen segun lo indique el usuario desde la app 
CREATE PROCEDURE CUATRO_QUESOS.elegirListado(@ID_Listado INT , @ANIO INT, @MES INT, @MESFIN INT = NULL, @FECHASISTEMA DATETIME)
AS
BEGIN
	IF @ID_Listado = 0
		EXEC CUATRO_QUESOS.especialidadesConMasCancelaciones @ANIO, @MES, @MESFIN
	ELSE IF @ID_Listado = 1
		EXEC CUATRO_QUESOS.bonosVencidosPorAfiliado @ANIO, @MES, @MESFIN, @FECHASISTEMA
	ELSE IF @ID_Listado = 2
		EXEC CUATRO_QUESOS.especialidadesConMasRecetas @ANIO, @MES, @MESFIN
	ELSE IF @ID_Listado = 3
		EXEC CUATRO_QUESOS.bonosPorTerceros @ANIO, @MES, @MESFIN	
END
GO

--este procedure arma un listado pedido en los meses de un semestre y los totales
--la idea era separar la logica de busqueda de cada listado de como se muestran, ya que todos se muestran de la mismo forma pero se arman individualmente distinto
--por eso justamente este codigo ensambla cualquier listado segun se pida, delegando la busqueda de cada listado en si...ojala se entienda
CREATE PROCEDURE CUATRO_QUESOS.getListadoEstadistico(@Semestre VARCHAR(20), @ID_Listado INT, @ANIO INT, @FECHA DATETIME)
AS
BEGIN
	DECLARE @T  TABLE (ID INT, RANKING VARCHAR(50), CANT INT) -- tabla con los totales
	DECLARE @T1 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @T2 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @T3 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @T4 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @T5 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @T6 TABLE (ID INT, RANKING VARCHAR(50), CANT INT)
	DECLARE @TOP INT = CASE @ID_Listado WHEN 3 THEN 10 ELSE 5 END -- para el listado de ID 3 hay que hace TOP 10, los TOP del select se hacen sobre esta variable
	
	IF (@Semestre = '1er semestre')
		BEGIN			
			--trae en 7 variables de tablas los listados pedidos en los meses pedidos y en @T los totales
			INSERT INTO @T  EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 1, 6, @FECHASISTEMA = @FECHA
			INSERT INTO @T1 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 1, @FECHASISTEMA = @FECHA
			INSERT INTO @T2 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 2, @FECHASISTEMA = @FECHA
			INSERT INTO @T3 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 3, @FECHASISTEMA = @FECHA
			INSERT INTO @T4 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 4, @FECHASISTEMA = @FECHA
			INSERT INTO @T5 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 5, @FECHASISTEMA = @FECHA
			INSERT INTO @T6 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 6, @FECHASISTEMA = @FECHA
			
			--joinea los listados por ranking, armando un listado semestral desagregado en meses
			SELECT T.RANKING, T.CANT TOTAL, A.CANT ENERO, B.CANT FEBRERO, C.CANT MARZO, D.CANT ABRIL, E.CANT MAYO, F.CANT JUNIO
			FROM (SELECT TOP (@TOP) * FROM @T) T
			LEFT JOIN @T1 A ON T.ID = A.ID
			LEFT JOIN @T2 B ON T.ID = B.ID
			LEFT JOIN @T3 C ON T.ID = C.ID
			LEFT JOIN @T4 D ON T.ID = D.ID
			LEFT JOIN @T5 E ON T.ID = E.ID
			LEFT JOIN @T6 F	ON T.ID = F.ID
		END

	IF (@Semestre = '2do semestre')
		BEGIN
			--trae en 7 variables de tablas los listados pedidos en los meses pedidos y en @T los totales
			INSERT INTO @T  EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 7, 12, @FECHASISTEMA = @FECHA
			INSERT INTO @T1 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 7,  @FECHASISTEMA = @FECHA
			INSERT INTO @T2 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 8,  @FECHASISTEMA = @FECHA
			INSERT INTO @T3 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 9,  @FECHASISTEMA = @FECHA
			INSERT INTO @T4 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 10, @FECHASISTEMA = @FECHA
			INSERT INTO @T5 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 11, @FECHASISTEMA = @FECHA
			INSERT INTO @T6 EXEC CUATRO_QUESOS.elegirListado @ID_Listado, @ANIO, 12, @FECHASISTEMA = @FECHA
			
			--joinea los listados por ranking, armando un listado semestral desagregado en meses
			SELECT T.RANKING, T.CANT TOTAL, A.CANT JULIO, B.CANT AGOSTO, C.CANT SEPTIEMBRE, D.CANT OCTUBRE, E.CANT NOVIEMBRE, F.CANT DICIEMBRE
			FROM (SELECT TOP (@TOP) * FROM @T) T
			LEFT JOIN @T1 A ON T.ID = A.ID
			LEFT JOIN @T2 B ON T.ID = B.ID
			LEFT JOIN @T3 C ON T.ID = C.ID
			LEFT JOIN @T4 D ON T.ID = D.ID
			LEFT JOIN @T5 E ON T.ID = E.ID
			LEFT JOIN @T6 F	ON T.ID = F.ID
		END
END
GO

/****** FIN PROCEDURES LISTADOS ESTADISTICOS ******/

/****************** PROCEDURES RESULTADOS ATENCION MEDICA*****************/

--devuelve las consultas medicas que no tengan un registro de sintomas y enfermedades
CREATE PROCEDURE CUATRO_QUESOS.getConsultasMedicas @nroAfiliado numeric(18), @idMedico numeric(18), @fechaAtencion DateTime, @sinResultado bit, @soloConResultado bit
AS
SELECT Afiliados.Nombre+' '+Afiliados.Apellido 'Afiliado',
Medicos.Nombre+' '+Medicos.Apellido 'Médico',
Turnos.Numero 'Nro. de Turno',
Consultas.Id_Consulta 'Nro. de Consulta',
Consultas.Sintomas 'Síntomas',
Consultas.Enfermedades 'Enfermedades',
Consultas.Fecha_Atencion 'Fecha de Atención',
Consultas.Fecha_Llegada 'Fecha de Llegada'
FROM CUATRO_QUESOS.Consultas JOIN CUATRO_QUESOS.Turnos ON Consultas.Nro_Turno = Turnos.Numero
JOIN CUATRO_QUESOS.Afiliados ON Turnos.Nro_Afiliado = Afiliados.Nro_Afiliado
JOIN CUATRO_QUESOS.Medicos ON Turnos.Id_Medico = Medicos.Id_Medico
WHERE ((Turnos.Nro_Afiliado = @nroAfiliado AND @nroAfiliado != 0) OR (@nroAfiliado = 0))
AND Turnos.Id_Medico = @idMedico
AND DAY(Consultas.Fecha_Atencion) = DAY(@fechaAtencion)
AND MONTH(Consultas.Fecha_Atencion) = MONTH(@fechaAtencion)
AND YEAR(Consultas.Fecha_Atencion) = YEAR(@fechaAtencion)
AND ((@sinResultado = 1 AND (Consultas.Sintomas = 'no registrado aún' OR Consultas.Enfermedades = 'no registrado aún')) OR (@sinResultado = 0))
AND ((@soloConResultado = 1 AND Consultas.Enfermedades != 'no registrado aún')OR(@soloConResultado = 0))
GO

--actualiza una consulta medica con los sintomas y enfermedades que tuvo un paciente
CREATE PROCEDURE CUATRO_QUESOS.updateConsultaMedica @idConsulta numeric(18), @sintomas varchar(255), @enfermedades varchar(255)
AS
UPDATE CUATRO_QUESOS.Consultas
SET Enfermedades =@enfermedades, Sintomas = @sintomas
WHERE Id_Consulta = @idConsulta
GO

/****************** FIN PROCEDURES RESULTADOS ATENCION MEDICA *****************/

/*************** PROCEDURES GENERAR RECETA *****************************/

--devuelve todos los bonos de farmacias comprados por el grupo familiar del afiliado y que coincidan con su plan medico
CREATE PROCEDURE CUATRO_QUESOS.getBonosFarmacia @nroAfiliado numeric(18), @fecha datetime
AS
SELECT Bonos.Numero 'Nro. de Bono', Bonos.Cod_Plan 'Codigo de Plan', 
Bonos.Fecha_Impresion 'Fecha de Impresión', Bonos.Fecha_Vencimiento 'Fecha de Vencimiento',
Bonos.Nro_Afiliado 'Nro. Afiliado Comprador'
FROM CUATRO_QUESOS.Bonos 
WHERE Bonos.Tipo_Bono = 'Farmacia' 
AND EXISTS (
SELECT * FROM CUATRO_QUESOS.Afiliados 
WHERE Afiliados.Nro_Afiliado = @nroAfiliado 
AND Bonos.Nro_Afiliado BETWEEN CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado) AND CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado)+99
)
AND Bonos.Cod_Plan IN (
SELECT Afiliados.Cod_Plan 
FROM CUATRO_QUESOS.Afiliados 
WHERE Afiliados.Nro_Afiliado = @nroAfiliado
) 
AND Bonos.Nro_Usuario IS NULL
AND Bonos.Fecha_Vencimiento >= @fecha
GO

--trae todos los medicamentos existentes
CREATE PROCEDURE CUATRO_QUESOS.traerMedicamentos @nroMedicamento numeric(18), @descripcion varchar(255)
AS
SELECT Medicamentos.Id_Medicamento 'Nro. Medicamento', Medicamentos.Descripcion 'Descripcion Medicamento'
FROM CUATRO_QUESOS.Medicamentos
WHERE ((Medicamentos.Id_medicamento = @nroMedicamento AND @nroMedicamento >= 0)OR(@nroMedicamento < 0))
AND Medicamentos.Descripcion LIKE '%'+ @descripcion + '%'
GO

--registra una receta medica en Medicamentos_Por_Consulta, especificando cantidad de cada uno, numero de consulta y  el bono de farmacia
CREATE PROCEDURE CUATRO_QUESOS.registrarReceta 
@nroAfiliado numeric(18),
@idConsulta numeric(18), 
@nroBonoFarmacia numeric(18),
@idMedicamento numeric(18), 
@cantidad int,
@fecha datetime
AS
BEGIN TRAN
INSERT INTO CUATRO_QUESOS.Medicamentos_Por_Consulta(Id_Consulta, Id_Medicamento, Nro_Bono_Farmacia, Cantidad, Tipo_Bono)
VALUES (
@idConsulta, 
@idMedicamento, 
@nroBonoFarmacia, 
(CASE WHEN @cantidad = 1 THEN '1 (UNO)' WHEN @cantidad = 2 THEN '2 (DOS)' ELSE '3 (TRES)' END),
'Farmacia'
)

UPDATE CUATRO_QUESOS.Bonos
SET Bonos.Nro_Usuario = @nroAfiliado, Fecha_Prescripcion_Medica = @fecha
WHERE Bonos.Nro_Usuario IS NULL 
AND Bonos.Tipo_Bono = 'Farmacia' 
AND Bonos.Numero = @nroBonoFarmacia

COMMIT
GO

/*************** FIN PROCEDURE GENERAR RECETA****************************/
/*************** PROCEDURES PEDIR TURNO *********************/

--trae todas las fechas disponibles de atencion que tiene un medico en su agenda
CREATE PROCEDURE CUATRO_QUESOS.getFechasDisponiblesAgenda @idMedico numeric(18), @fechaSistema datetime
AS
SELECT CAST(Agendas_Medicos.Fecha_Hora as DATE) 'Fechas Disponibles'
FROM CUATRO_QUESOS.Agendas_Medicos
WHERE Id_Medico = @idMedico 
AND Nro_Turno IS NULL
AND Agendas_Medicos.Fecha_Hora >= @fechaSistema
GROUP BY CAST(Agendas_Medicos.Fecha_Hora as DATE) 
ORDER BY 1 ASC
GO

--trae todos los timeslots disponibles para una fecha en la agenda del medico
CREATE PROCEDURE CUATRO_QUESOS.getTimeslotsFecha @idMedico numeric(18), @fechaAgenda datetime, @fechaSistema datetime
AS
SELECT CAST(Agendas_Medicos.Fecha_Hora as TIME) 'Horarios Disponibles'
FROM CUATRO_QUESOS.Agendas_Medicos
WHERE Id_Medico = @idMedico 
AND Nro_Turno IS NULL
AND DAY(Fecha_Hora) = DAY(@fechaAgenda)
AND MONTH(Fecha_Hora) = MONTH(@fechaAgenda)
AND YEAR(Fecha_Hora) = YEAR(@fechaAgenda)
AND Agendas_Medicos.Fecha_Hora >= @fechaSistema
ORDER BY Fecha_Hora ASC
GO

--genera un turno para un afiliado, asociando medico, especialidad del turno y la fecha del mismo
CREATE PROCEDURE CUATRO_QUESOS.generarTurno @nroAfiliado numeric(18), @idMedico numeric(18), @codEspecialidad numeric(18) , @fecha datetime
AS
INSERT INTO CUATRO_QUESOS.Turnos(Numero, Nro_Afiliado, Id_Medico, Cod_Especialidad, Fecha)
VALUES ((SELECT MAX(Numero)+1 FROM CUATRO_QUESOS.Turnos),@nroAfiliado, @idMedico, @codEspecialidad, @fecha)
GO

--devuelve el numero de turno del afiliado pasado por parametro que coincida con la fecha
CREATE PROCEDURE CUATRO_QUESOS.getTurnoAfiliado @nroAfiliado numeric(18), @fecha datetime
AS
SELECT Turnos.Numero
FROM CUATRO_QUESOS.Turnos 
WHERE Turnos.Nro_Afiliado = @nroAfiliado AND Turnos.Fecha = @fecha 
AND Turnos.Numero NOT IN (SELECT Cancelaciones.Nro_Turno FROM CUATRO_QUESOS.Cancelaciones)
GO

/**************** FIN PROCEDURES PEDIR TURNO ********************/

/********** TRIGGERS *****************/

create trigger CUATRO_QUESOS.quitarRolInhabilitado on CUATRO_QUESOS.Roles for update --trigger para quitar un rol que haya quedado inhabilitado
as
if UPDATE(Habilitado)
begin
        --los roles son muy pocos, me voy a tomar la libertad de usar un cursor
        declare @ID numeric(18)
        declare @Habilitado bit
        declare curLocal cursor for select ID_Rol, Habilitado from inserted
        
        open curLocal
        fetch CurLocal into @ID, @Habilitado
        while @@FETCH_STATUS = 0
        begin
                if @Habilitado = 0 --uno de los roles se inhabilito
                        delete from CUATRO_QUESOS.Usuarios_Por_Rol where CUATRO_QUESOS.Usuarios_Por_Rol.ID_Rol = @ID        
                        --se lo quito a todos los usuarios que lo tienen        
        fetch CurLocal into @ID, @Habilitado
        end
        
        close CurLocal
        deallocate CurLocal

end


GO

create trigger CUATRO_QUESOS.revocarUsuario on CUATRO_QUESOS.Usuarios for update --automaticamente despues de los intentos fallidos permitidos, inhabilita al usuario
as
if UPDATE(Intentos_Fallidos)
begin
        --esto SÍ O SÍ se actualiza un registro a la vez. SÉ que inserted tiene una fila
        if (select Intentos_Fallidos from inserted) > 2
                update CUATRO_QUESOS.Usuarios set Habilitado = 0 where CUATRO_QUESOS.Usuarios.Username = (select username from inserted)        

end

GO


create trigger CUATRO_QUESOS.cancelarTurnosMedicosDesvinculados on CUATRO_QUESOS.Medicos for update --cuando se da de baja un medico, cancela todos los turnos que tenia asignados
as
if UPDATE(Habilitado)

begin
        --no se si los médicos se darán de baja de a uno o masivamente... meto cursor nomás
        declare @ID numeric(18)
        declare @Habilitado bit
        declare curLocal cursor for select ID_Medico, Habilitado from inserted
        
        open curLocal
        fetch CurLocal into @ID, @Habilitado
        while @@FETCH_STATUS = 0
        begin
                if @Habilitado = 0 --uno de los médicos se dio de baja
                        --tengo que cancelar sus turnos futuros
                        
                        INSERT INTO CUATRO_QUESOS.Cancelaciones
                        (
                        Nro_Turno,
                        Tipo,
                        Motivo
                        )
                        
                        select Numero as Nro_Turno,
                                        'Desvinculación del médico' as Tipo,
                                        'El médico a cargo de este turno ya no trabaja en la clínica' as Motivo
                        from CUATRO_QUESOS.Turnos as sub
                        where sub.ID_Medico = @ID
                                and sub.Fecha > CUATRO_QUESOS.FechaMigracion()
                                and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Cancelaciones) --y ojo que no este ya cancelado!
                                and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Consultas) --y que no haya sido efectivizado el turno
                        
        fetch CurLocal into @ID, @Habilitado
        end
        
        close CurLocal
        deallocate CurLocal
end

GO

create trigger CUATRO_QUESOS.cancelarTurnosPacientesDesvinculados on CUATRO_QUESOS.Afiliados for update --mismo caso que los medicos, cancela todos los turnos para el afiliado dado de baja
as
if UPDATE(Fecha_Baja)

begin
        --no se si los pacientes se darán de baja de a uno o masivamente... meto cursor nomás
        declare @Nro numeric(18)
        declare @Fecha_Baja datetime
        declare curLocal cursor for select Nro_Afiliado, Fecha_Baja from inserted
        
        open curLocal
        fetch CurLocal into @Nro, @Fecha_Baja
        while @@FETCH_STATUS = 0
        begin
                if @Fecha_Baja is not null --uno de los pacientes está dado de baja
                        --tengo que cancelar sus turnos futuros
                        
                        INSERT INTO CUATRO_QUESOS.Cancelaciones
                        (
                        Nro_Turno,
                        Tipo,
                        Motivo
                        )
                        
                        select Numero as Nro_Turno,
                                        'Desvinculación del paciente' as Tipo,
                                        'El paciente de este turno ya no se atiende en la clínica' as Motivo
                        from CUATRO_QUESOS.Turnos as sub
                        where sub.Nro_Afiliado = @Nro
                                and sub.Fecha > CUATRO_QUESOS.FechaMigracion()
                                and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Cancelaciones) --y ojo que no este ya cancelado!
                                and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Consultas) --y que no haya sido efectivizado el turno
                        
        fetch CurLocal into @Nro, @Fecha_Baja
        end
        
        close CurLocal
        deallocate CurLocal
end

GO

--trigger para verificar que no se receten más de 5 medicamentos en un mismo bono farmacia        
create trigger CUATRO_QUESOS.limitarMedicamentosPorBono on CUATRO_QUESOS.Medicamentos_Por_Consulta for update, insert
as
begin
        if (select top 1 COUNT(*)
        from CUATRO_QUESOS.Medicamentos_Por_Consulta
        group by Nro_Bono_Farmacia
        order by 1 desc) > 5 
        begin
                rollback
                raiserror('Error: no se pueden recetar más de 5 medicamentos usando un mismo bono.', 16, 0)
        end
end

GO

--trigger para verificar que la jornada semanal sea menor a 48 horas
create trigger CUATRO_QUESOS.limitarJornadaLaboral on CUATRO_QUESOS.Dias_Atencion for update, insert
as
begin
		declare @ID numeric(18)
		set @ID = (select top 1 ID_Medico from inserted)
		--hago este set así porque sé que la app nunca va a modificar a dos médicos en la misma transacción, entonces el ID es el mismo en todas las filas de inserted
		
        if (select SUM(DATEDIFF(HOUR, hora_desde, hora_hasta))
        from CUATRO_QUESOS.Dias_Atencion
        where ID_Medico = @ID) > 48 --sumo las horas laborales del médico que estoy actualizando y me fijo que no se pasen de 48
        begin
                rollback
                raiserror('Error: un médico no puede trabajar más de 48 horas a la semana.', 16, 0)
        end
end

GO


--trigger para verificar que los horarios de los médicos queden dentro de los horarios de la clínica
--en realidad estaría "por las dudas", porque la app ya valida esto en registrar agenda

create trigger CUATRO_QUESOS.obedecerHorariosClinica on CUATRO_QUESOS.Dias_Atencion for insert, update
as
begin
        if ((select COUNT(*) from inserted where Hora_Desde < '07:00' or Hora_Hasta > '20:00') > 0)
                or
                ((select COUNT(*) from inserted where Dia_Semana = 6 and (Hora_Desde < '10:00' or Hora_Hasta > '15:00')) > 0)
        begin
                rollback
                raiserror('Error: el horario de atención especificado está fuera de los horarios de funcionamiento de la clínica', 16, 0)
        end
end

GO


CREATE TRIGGER CUATRO_QUESOS.tr_updateNroConyuge --actualiza el numero de conyuge, utilizando un procedure
ON CUATRO_QUESOS.Afiliados FOR UPDATE, INSERT
AS
BEGIN
        DECLARE @nroAfiliado numeric(18)
        SELECT @nroAfiliado = Nro_Afiliado FROM INSERTED
        
        IF(UPDATE(Nro_Conyuge)AND CUATRO_QUESOS.tipoAfiliado(@nroAfiliado)= 2)
        EXEC CUATRO_QUESOS.updateNroConyuge @nroAfiliado
END
GO

CREATE TRIGGER CUATRO_QUESOS.tr_cancelarTurnoAgenda --cuando se cancela un turno, se libera el timeslot que ocupaba dejandolo disponible
ON CUATRO_QUESOS.Cancelaciones AFTER INSERT
AS
BEGIN
DECLARE @nroTurno numeric(18)
DECLARE cursorTurno CURSOR FOR
SELECT Nro_Turno FROM INSERTED

OPEN cursorTurno
FETCH cursorTurno INTO @nroTurno

WHILE @@FETCH_STATUS = 0
	BEGIN
	UPDATE CUATRO_QUESOS.Agendas_Medicos
	SET Nro_Turno = NULL
	WHERE Nro_Turno = @nroTurno

	FETCH cursorTurno INTO @nroTurno
END

CLOSE cursorTurno
DEALLOCATE cursorTurno
END

GO

CREATE TRIGGER CUATRO_QUESOS.tr_up_after_consulta --disparador para actualizar los datos del afiliado
ON CUATRO_QUESOS.Bonos AFTER UPDATE
AS
BEGIN
IF(UPDATE(Nro_Consulta))
	BEGIN
	DECLARE @numeroAfiliado numeric(18)

	DECLARE cursorBonos CURSOR FOR
	SELECT Nro_Usuario FROM INSERTED

	OPEN cursorBonos
	FETCH cursorBonos INTO @numeroAfiliado

	WHILE @@FETCH_STATUS = 0
	BEGIN
	UPDATE CUATRO_QUESOS.Afiliados
	SET Afiliados.Nro_Consulta = Afiliados.Nro_Consulta + 1 --actualizo el nro de consultas hechas por el afiliado
	WHERE Afiliados.Nro_Afiliado = @numeroAfiliado
	FETCH cursorBonos INTO @numeroAfiliado
	END
	CLOSE cursorBonos
	DEALLOCATE cursorBonos
END
END
GO

CREATE TRIGGER CUATRO_QUESOS.tr_updateAgenda --actualiza el turno asociado a un timeslot en la agenda de un profesional
ON CUATRO_QUESOS.Turnos AFTER INSERT
AS
BEGIN
DECLARE @nroTurno numeric(18), @idMedico numeric(18), @fecha datetime
DECLARE cursorTurno CURSOR FOR
SELECT Numero, Id_Medico, Fecha FROM INSERTED

OPEN cursorTurno
FETCH cursorTurno INTO @nroTurno, @idMedico, @fecha

WHILE @@FETCH_STATUS = 0
	BEGIN
	UPDATE CUATRO_QUESOS.Agendas_Medicos
	SET Nro_Turno = @nroTurno
	WHERE Id_Medico = @idMedico AND Fecha_Hora = @fecha

	FETCH cursorTurno INTO @nroTurno, @idMedico, @fecha
END

CLOSE cursorTurno
DEALLOCATE cursorTurno
END

GO

/********* FIN TRIGGERS ****************/

IF @@ERROR != 0 ROLLBACK --si hubo un error, cancela toda la operacion

COMMIT
GO
