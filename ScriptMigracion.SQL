USE [GD2C2013]
GO

BEGIN TRAN
GO
CREATE SCHEMA [CUATRO_QUESOS] AUTHORIZATION [gd]
GO

-- Create Tables
CREATE TABLE CUATRO_QUESOS.Afiliados (
        Nro_Afiliado numeric(18) NOT NULL,
        Nombre varchar(255) NOT NULL,
        Apellido varchar(255) NOT NULL,
        Sexo char(1) NOT NULL CHECK(Sexo = 'M' OR Sexo = 'F' OR Sexo = '-'),
        Tipo_Doc varchar(3) NOT NULL CHECK(Tipo_Doc = 'DNI' OR Tipo_Doc = 'LE' OR Tipo_Doc = 'LC'),
        Nro_Doc numeric(18) NOT NULL,
        Direccion varchar(255) NOT NULL,
        Mail varchar(255),
        Telefono numeric(18) NOT NULL,
        Fecha_Nac datetime NOT NULL,
        Cod_Plan numeric(18) NOT NULL,
        Estado_Civil varchar(255) NOT NULL,
        Nro_Titular numeric(18) DEFAULT NULL,
        Nro_Conyuge numeric(18)DEFAULT NULL,
        Fecha_Baja datetime DEFAULT NULL,
        Nro_Consulta int DEFAULT 0,
        CantFamiliaresACargo tinyint NOT NULL DEFAULT 0
)
;

CREATE TABLE CUATRO_QUESOS.Bonos (
        Numero numeric(18) NOT NULL,
        Fecha_Impresion datetime NOT NULL,
        Nro_Afiliado numeric(18) NOT NULL,
        Cod_Plan numeric(18) NOT NULL,
        Id_Compra numeric(18),
        Tipo_Bono varchar(255) NOT NULL,
        Fecha_Vencimiento datetime,
        Nro_Consulta int,
        Nro_Usuario numeric(18)
)
;

CREATE TABLE CUATRO_QUESOS.Cambios_Plan (
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
        Id_Compra numeric(18) NOT NULL Identity(1,1),
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

CREATE TABLE CUATRO_QUESOS.Consultas_Exceptions (
        Id_Consulta numeric(18),
        Nro_Turno numeric(18) NOT NULL,
        Fecha_Llegada datetime,
        Fecha_Atencion datetime,
        Sintomas varchar(255) NOT NULL,
        Enfermedades varchar(255) NOT NULL,
        Nro_Bono_Consulta numeric(18) NOT NULL,
        Nro_Bono_Farmacia numeric(18) NOT NULL,
        Medicamento varchar(255) NOT NULL,
)
;

CREATE TABLE CUATRO_QUESOS.Dias_Atencion (
        Id_Medico numeric(18) NOT NULL,
        Nombre_Dia varchar(9) NOT NULL,
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
        Cantidad smallint NOT NULL,
        Tipo_Bono varchar(255)
)
;

CREATE TABLE CUATRO_QUESOS.Medicos (
        Id_Medico numeric(18) NOT NULL Identity(1,1),
        Nombre varchar(255) NOT NULL,
        Apellido varchar(255) NOT NULL,
        Sexo varchar(255) NOT NULL CHECK(Sexo = 'M' OR Sexo = 'F' OR Sexo = '-'),
        Tipo_Doc varchar(3) NOT NULL CHECK(Tipo_Doc = 'DNI' OR Tipo_Doc = 'LE' OR Tipo_Doc = 'LC'),
        Nro_Doc numeric(18) NOT NULL,
        Direccion varchar(255) NOT NULL,
        Telefono numeric(18) NOT NULL,
        Mail varchar(255) NOT NULL,
        Fecha_Nac datetime NOT NULL,
        Nro_Matricula numeric(18),
        Fecha_Atencion_Desde datetime NOT NULL,
        Fecha_Atencion_Hasta datetime NOT NULL,
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


-- Create Primary Key Constraints

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT CHK_Estado_Civil
	CHECK(Estado_Civil = 'Soltero/a' OR
	 Estado_Civil = 'Divorciado/a' OR
	 Estado_Civil = 'Viudo/a' OR
	 Estado_Civil = 'Concubinato' OR
	 Estado_Civil = 'Casado/a' OR 
	 Estado_Civil = '-')
;

ALTER TABLE CUATRO_QUESOS.Afiliados ADD CONSTRAINT PK_Afiliados
        PRIMARY KEY CLUSTERED (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Bonos ADD CONSTRAINT PK_Bonos
        PRIMARY KEY CLUSTERED (Numero, Tipo_Bono)
;

ALTER TABLE CUATRO_QUESOS.Cambios_Plan ADD CONSTRAINT PK_Cambios_Plan
        PRIMARY KEY CLUSTERED (Nro_Afiliado, Fecha)
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
        PRIMARY KEY CLUSTERED (Id_Medico, Nombre_Dia)
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

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados
        ADD CONSTRAINT UQ_Usuarios_Afiliados_Nro_Afiliado UNIQUE (Nro_Afiliado)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados
        ADD CONSTRAINT UQ_Usuarios_Afiliados_Username UNIQUE (Username)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT PK_Usuarios_Afiliados
        PRIMARY KEY CLUSTERED (Nro_Afiliado, Username)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT FK_Usuarios_Afiliados_Afiliados
        FOREIGN KEY (Nro_Afiliado) REFERENCES CUATRO_QUESOS.Afiliados (Nro_Afiliado)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados ADD CONSTRAINT FK_Usuarios_Afiliados_Usuarios
        FOREIGN KEY (Username) REFERENCES CUATRO_QUESOS.Usuarios (Username)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos
        ADD CONSTRAINT UQ_Usuarios_Medicos_Id_Medico UNIQUE (Id_Medico)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos
        ADD CONSTRAINT UQ_Usuarios_Medicos_Username UNIQUE (Username)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT PK_Usuarios_Medicos
        PRIMARY KEY CLUSTERED (Username, Id_Medico)
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT FK_Usuarios_Medicos_Medicos
        FOREIGN KEY (Id_Medico) REFERENCES CUATRO_QUESOS.Medicos (Id_Medico)
        ON UPDATE CASCADE
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos ADD CONSTRAINT FK_Usuarios_Medicos_Usuarios
        FOREIGN KEY (Username) REFERENCES CUATRO_QUESOS.Usuarios (Username)
        ON UPDATE CASCADE
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

--Create other constraints

--constraint para verificar que la agenda profesional sea de 120 días como máximo
alter table CUATRO_QUESOS.Medicos add constraint limitarAgendaProfesional 
		check (datediff(day, fecha_atencion_desde, fecha_atencion_hasta) <= 120)

--constraint para verificar que no se recete más de 3 instancias del mismo medicamento
alter table CUATRO_QUESOS.Medicamentos_Por_Consulta add constraint verificarCantidadMedicamentoIndividual
	check (Cantidad <=3)


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
                        and sub1.Turno_Fecha < GETDATE())
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
                getdate() as Fecha_Atencion_Desde,
                case when MAX(Turno_Fecha) > dateadd(month, 1, GETDATE()) then MAX(Turno_fecha) else dateadd(month, 1, GETDATE()) end as Fecha_Atencion_Hasta, --esto significa que el medico esta disponible al menos durante un mes desde la migración, pero si tiene turnos posteriores se estira hasta ese momento
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
                                and submaestra.Turno_Fecha < GETDATE()) --y que hayan sido usados en una consulta PASADA (sabemos que se usaron cuando se asocian a un turno)
                 end as Nro_Consulta,
                
                 --lo que sigue es para determinar el usuario. Si se concretó el turno, asumo que el usuario es el mismo que lo compró, si no se concretó el usuario es NULL
                case (select COUNT(*) from gd_esquema.Maestra as sub1 where Turno_Numero is not null and sub1.Bono_Consulta_Numero = principal.Bono_Consulta_Numero and sub1.Turno_Fecha < GETDATE())
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
                case (select COUNT(*) from gd_esquema.Maestra as sub1 where Bono_Farmacia_Medicamento is not null and sub1.Bono_Farmacia_Numero = principal.Bono_Farmacia_Numero and sub1.Turno_Fecha < GETDATE()) --claramente un bono farmacia usado es el que tiene un medicamento escrito.... en el pasado
                when 0 then NULL --si no hubo se usó el nro_consulta es null
                else
                        (select Nro_Afiliado from CUATRO_QUESOS.Afiliados where Nro_Doc = Paciente_DNI)
                end as Nro_Usuario
                
                

from gd_esquema.Maestra as principal
where Bono_Farmacia_Numero is not null

/* *************FIN INSERCION DE BONOS*************** */


--Días de atención

INSERT INTO CUATRO_QUESOS.Dias_Atencion
        (
        ID_Medico,
        Nombre_Dia,
        Hora_Desde,
        Hora_Hasta
        )


        select (select ID_Medico from CUATRO_QUESOS.Medicos where Nro_Doc = Medico_Dni) as ID_Medico,
                DATENAME(dw, Turno_Fecha) as Nombre_Dia,
                MIN(Cast(Turno_Fecha as time)) as Hora_Desde,
                MAX(Cast(DATEADD(minute, 30, Turno_Fecha) as time)) as Hora_Hasta

        from gd_esquema.Maestra
        where Turno_Fecha is not null
                and DATENAME(dw, Turno_Fecha) != 'Domingo' --esto falla espectacularmente si la base de datos no está en español
                and (        (DATENAME(dw, Turno_Fecha) != 'Sábado' --clausula para los días hábiles
                                and datepart(hour, Turno_Fecha) >= 7
                                and datepart(hour, Turno_Fecha) < 20) --menor a 20 porque si la clínica cierra a las 20, el último turno es a las 19:30
                        or
                                (DATENAME(dw, Turno_Fecha) = 'Sábado' --clausula para los sábados
                                and datepart(hour, Turno_Fecha) >= 10
                                and datepart(hour, Turno_Fecha) < 15)
                        )
        group by Medico_Dni, DATENAME(dw, Turno_Fecha)

        
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
                and Turno_Fecha < GETDATE()-- y esto otro significa que el turno debería haberse concretado antes de la migración


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
                and Turno_Fecha > GETDATE()
                and (DATENAME(dw, Turno_Fecha) = 'Domingo'
                        
                        or ((DATENAME(dw, Turno_Fecha) = 'Sábado'
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

        where Bono_Consulta_Numero is not null and Turno_Numero is not null and turno_Fecha < GETDATE()

INSERT INTO CUATRO_QUESOS.Consultas_Exceptions
--en esta tabla van las consultas futuras
        (
        Nro_Turno,
        Fecha_Llegada,
        Fecha_Atencion,
        Sintomas,
        Enfermedades,
        Nro_Bono_Consulta,
        Nro_Bono_Farmacia,
        Medicamento
        )
        
        select
        Turno_Numero as Nro_Turno,
        Turno_Fecha as Fecha_Llegada,
        Turno_Fecha as Fecha_Atencion,
        Consulta_Sintomas as Sintomas,
        Consulta_Enfermedades as Enfermedades,
        Bono_Consulta_Numero as Nro_Bono_Consulta,
        Bono_Farmacia_Numero as Nro_Bono_Farmacia,
        Bono_Farmacia_Medicamento as Medicamento

        from gd_esquema.Maestra

        where Bono_Consulta_Numero is not null and Turno_Numero is not null and turno_Fecha >= GETDATE()
        
        
        
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
                1 as Cantidad, --asumo que sólo se receto una instancia del medicamento que aparece en la maestra
                'Farmacia' as Tipo_Bono
                
        from gd_esquema.Maestra as principal
        where Turno_Numero is not null
                and Bono_Farmacia_Numero is not null
                and Bono_Farmacia_Medicamento is not null
                and Turno_Fecha < GETDATE()

                
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
                

                
                
--esta es una tabla auxiliar, no se si hara falta agregarla en el DER:

create table CUATRO_QUESOS.horas_del_dia
(
        hora time primary key
)

declare @offset tinyint
set @offset = 0

while @offset < 24
begin
        insert into CUATRO_QUESOS.Horas_del_dia(hora)
        values(DATEADD(hour, @offset, '00:00:00'))
        insert into CUATRO_QUESOS.Horas_del_dia(hora)
        values(DATEADD(hour, @offset, '00:30:00'))
        set @offset = @offset+1
end
--contiene todos los intervalos de media hora que hay en el día


--otra tabla auxiliar:


create table CUATRO_QUESOS.Dias --calendar table
(
        dia date primary key
)

declare @offdias integer
set @offdias = 0
while @offdias < 2000
begin
        insert into CUATRO_QUESOS.Dias(dia)
        values(DATEADD(day, @offdias, '20120101'))
        set @offdias = @offdias + 1
end

--contiene todos los días que hay de 2012 a más o menos 2017

go

--CREATE VIEWS

--finalmente creo la vista que contiene las agendas de los medicos!
create view CUATRO_QUESOS.Agendas_Medicos as
select (CAST(dia as datetime) + cast(hora as datetime)) as Horario,
                Medicos.Id_Medico as Id_Medico,
                case when (select COUNT(*)
                                        from CUATRO_QUESOS.Turnos
                                        where Turnos.Fecha = (CAST(dia as datetime) + cast(hora as datetime))
                                                and Turnos.Id_Medico = Medicos.Id_Medico
                                                and Turnos.Numero not in (select Nro_Turno from CUATRO_QUESOS.Cancelaciones)) >0 then 'Ocupado'
                        else 'Libre'
                end as Estado                        


from CUATRO_QUESOS.Medicos,
 CUATRO_QUESOS.Dias as dia, CUATRO_QUESOS.Horas_del_dia as hora
where dia >= Medicos.fecha_atencion_desde and dia <= Medicos.Fecha_Atencion_Hasta
        and (DATENAME(DW, dia) in (select nombre_dia from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = medicos.id_medico))
        and (hora >= (select hora_desde from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = Medicos.Id_Medico and Dias_Atencion.Nombre_Dia = DATENAME(dw, dia)))
        and (hora < (select Hora_Hasta from CUATRO_QUESOS.Dias_Atencion where Dias_Atencion.Id_Medico = Medicos.Id_Medico and Dias_Atencion.Nombre_Dia = DATENAME(dw, dia)))

GO

--CREATE TRIGGERS

create trigger CUATRO_QUESOS.quitarRolInhabilitado on CUATRO_QUESOS.Roles for update
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

create trigger CUATRO_QUESOS.revocarUsuario on CUATRO_QUESOS.Usuarios for update
as
if UPDATE(Intentos_Fallidos)
begin
	--esto SÍ O SÍ se actualiza un registro a la vez. SÉ que inserted tiene una fila
	if (select Intentos_Fallidos from inserted) > 2
		update CUATRO_QUESOS.Usuarios set Habilitado = 0 where CUATRO_QUESOS.Usuarios.Username = (select username from inserted)	

end

GO


create trigger CUATRO_QUESOS.cancelarTurnosMedicosDesvinculados on CUATRO_QUESOS.Medicos for update
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
				and sub.Fecha > GETDATE()
				and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Cancelaciones) --y ojo que no este ya cancelado!
			
	fetch CurLocal into @ID, @Habilitado
	end
	
	close CurLocal
	deallocate CurLocal
end

GO

create trigger CUATRO_QUESOS.cancelarTurnosPacientesDesvinculados on CUATRO_QUESOS.Afiliados for update
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
				and sub.Fecha > GETDATE()
				and sub.Numero not in (select Nro_Turno from CUATRO_QUESOS.Cancelaciones) --y ojo que no este ya cancelado!
			
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
	order by 1 desc) > 5 --esta consulta devuelve el total de horas de atención a la semana de cada médico. pregunto si la más grande se pasa de 48
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
	if (select top 1 SUM(DATEDIFF(HOUR, hora_desde, hora_hasta)) 
	from CUATRO_QUESOS.Dias_Atencion 
	group by ID_Medico 
	order by 1 desc) > 48 --esta consulta devuelve el total de horas de atención a la semana de cada médico. pregunto si la más grande se pasa de 48
	begin
		rollback
		raiserror('Error: un médico no puede trabajar más de 48 horas a la semana.', 16, 0)
	end
end

GO


--trigger para verificar que los horarios de los médicos queden dentro de los horarios de la clínica

create trigger CUATRO_QUESOS.obedecerHorariosClinica on CUATRO_QUESOS.Dias_Atencion for insert, update
as
begin
	if ((select COUNT(*) from inserted where Hora_Desde < '07:00' or Hora_Hasta > '20:00') > 0)
		or
		((select COUNT(*) from inserted where Nombre_Dia = 'Sábado' and (Hora_Desde < '10:00' or Hora_Hasta > '15:00')) > 0)
	begin
		rollback
		raiserror('Error: el horario de atención especificado está fuera de los horarios de funcionamiento de la clínica', 16, 0)
	end
end

GO


--CREATE PROCEDURES

--procedures medicos

CREATE PROCEDURE CUATRO_QUESOS.altaMedico(@nombre varchar(255),
                                                                                 @apellido varchar(255),
                                                                                 @sexo varchar(255),
                                                                                 @tipoDoc varchar(3),
                                                                                 @nroDoc numeric(18),
                                                                                 @direccion varchar(255),
                                                                                 @telefono numeric(18),
                                                                                 @mail varchar(255),
                                                                                 @fechaNac datetime,
                                                                                 @nroMatricula numeric(18),
                                                                                 @fechaAtencionDesde datetime,
                                                                                 @fechaAtencionHasta datetime)
AS
        BEGIN TRAN


                INSERT INTO CUATRO_QUESOS.Medicos (Nombre, Apellido, Sexo, Tipo_Doc, Nro_Doc, Direccion, Telefono, Mail, Fecha_Nac, Nro_Matricula, Fecha_Atencion_Desde, Fecha_Atencion_Hasta, Habilitado)

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
                                @fechaAtencionDesde,
                                @fechaAtencionHasta,
                                1)
        COMMIT

--falta hacer el insert de las especialidades, y horarios de consulta

GO


CREATE PROCEDURE CUATRO_QUESOS.updateMedico(@id numeric(18),
                                                                                        @nombre varchar(255),
                                                                                        @apellido varchar(255),
                                                                                 @sexo varchar(255),
                                                                                        @tipoDoc varchar(3),
                                                                                        @nroDoc numeric(18),
                                                                                        @direccion varchar(255),
                                                                                        @telefono numeric(18),
                                                                                        @mail varchar(255),
                                                                                        @fechaNac datetime,
                                                                                        @nroMatricula numeric(18),
                                                                                        @fechaAtencionDesde datetime,
                                                                                        @fechaAtencionHasta datetime)
AS
BEGIN TRAN
        UPDATE CUATRO_QUESOS.Medicos
                
                SET Nombre = @nombre,
                        Apellido = @apellido,
                        Sexo = @sexo,
                        Tipo_Doc = @tipoDoc,
                        Nro_Doc = @nroDoc,
                        Direccion = @direccion,
                        Telefono = @telefono,
                        Mail = @mail,
                        Fecha_Nac = @fechaNac,
                        Nro_Matricula = @nroMatricula,
                        Fecha_Atencion_Desde = @fechaAtencionDesde,
                        Fecha_Atencion_Hasta = @fechaAtencionHasta
                        
                WHERE Id_Medico = @id
COMMIT
                
GO


CREATE PROCEDURE CUATRO_QUESOS.bajaMedico(@dni numeric(18), @nombre varchar(255), @apellido varchar(255)) --lo busco por el dni, nombre y apellido
AS
BEGIN TRAN
        DELETE FROM CUATRO_QUESOS.Medicos
        WHERE Nro_Doc = @dni AND
                 Nombre = @nombre AND
                 Apellido = @apellido
COMMIT

GO

CREATE PROCEDURE CUATRO_QUESOS.getMedicos
AS
SELECT Id_Medico 'ID Medico',
Nombre 'Nombre', Apellido 'Apellido',
Sexo 'Sexo', Tipo_Doc 'Tipo Documento',
Nro_Doc 'Numero Documento', Direccion 'Direccion',
Telefono 'Telefono', Mail 'Mail', Fecha_Nac 'Fecha Nacimiento',
Nro_Matricula 'Numero Matricula', Fecha_Atencion_Desde 'Fecha Atencion Desde',
Fecha_Atencion_Hasta 'Fecha Atencion Hasta', Habilitado 'Habilitado'
FROM CUATRO_QUESOS.Medicos
GO

CREATE FUNCTION CUATRO_QUESOS.getIdMedico(@nombre varchar(255), @apellido varchar(255), @nroDoc numeric(18))
RETURNS numeric(18)
BEGIN
        DECLARE @Id numeric(18)
        SELECT @Id = Id_Medico
        FROM CUATRO_QUESOS.Medicos
        WHERE Nombre = @nombre AND Apellido = @apellido AND Nro_Doc = @nroDoc
        RETURN @Id
END
GO

--procedures afiliados

CREATE PROCEDURE CUATRO_QUESOS.darAltaAfiliado  --Procedure para dar de alta un afiliado, dependiendo del tipo de afiliado insertara valores distintos y en distintas columnas
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
                                '-' , -- Como no interesa el estado civil de un hijo / familiar a cargo, se pone guion por defecto
                                0,
                                @nroAfiliadoTitular
                                )
                        END        
END
GO

CREATE PROCEDURE CUATRO_QUESOS.getAfiliados @nombre varchar(255), @apellido varchar(255), @nroAfiliadoRaiz numeric(18)
AS
SELECT TOP 100 Nro_Afiliado 'Nª Afiliado',Nombre 'Nombre', Apellido 'Apellido',Sexo 'Sexo', 
Tipo_Doc 'Tipo Documento',Nro_Doc 'Nª Documento', Direccion 'Dirección',Telefono 'Teléfono', Mail 'Mail', 
Fecha_Nac 'Fecha de Nacimiento',Cod_Plan 'Plan Medico', Estado_Civil 'Estado Civil',Nro_Titular 'Nª Afiliado de Titular',
Nro_Conyuge 'Nª Afiliado de Conyuge', Fecha_Baja 'Fecha de Baja', Nro_Consulta 'Nª de Consultas Realizadas',CantFamiliaresACargo 'Cantidad de Familiares a Cargo' 
FROM CUATRO_QUESOS.Afiliados
WHERE Nombre LIKE '%' + @nombre + '%'
AND Apellido LIKE '%' + @apellido + '%'
AND 
((@nroAfiliadoRaiz > 99 AND Nro_Afiliado BETWEEN @nroAfiliadoRaiz AND @nroAfiliadoRaiz + 100) OR
(@nroAfiliadoRaiz <= 99))
GO

CREATE PROCEDURE CUATRO_QUESOS.darBajaAfiliado(@nroAfiliado numeric(18), @fechaSistema datetime)
AS
UPDATE CUATRO_QUESOS.Afiliados
SET Fecha_Baja = @fechaSistema
WHERE Nro_Afiliado = @nroAfiliado

GO

CREATE PROCEDURE CUATRO_QUESOS.buscarNroAfiliado @nombre varchar(255), @apellido varchar(255), @tipoDoc varchar(3), @nroDoc numeric(18)
AS
DECLARE @nroAfiliado numeric(18)
SELECT @nroAfiliado = Nro_Afiliado
FROM CUATRO_QUESOS.Afiliados
WHERE Nombre = @nombre AND Apellido = @apellido AND Tipo_Doc = @tipoDoc AND Nro_Doc = @nroDoc

RETURN @nroAfiliado
GO

CREATE TRIGGER CUATRO_QUESOS.tr_updateNroConyuge
ON CUATRO_QUESOS.Afiliados FOR UPDATE, INSERT
AS
BEGIN
	DECLARE @nroAfiliado numeric(18)
	SELECT @nroAfiliado = Nro_Afiliado FROM INSERTED
	
	IF(UPDATE(Nro_Conyuge)AND CUATRO_QUESOS.tipoAfiliado(@nroAfiliado)= 2)
	EXEC CUATRO_QUESOS.updateNroConyuge @nroAfiliado
END
GO

CREATE PROCEDURE CUATRO_QUESOS.updateNroConyuge (@nroAfiliado numeric(18))
AS
UPDATE CUATRO_QUESOS.Afiliados
SET Nro_Conyuge = @nroAfiliado
WHERE Nro_Afiliado = (@nroAfiliado - 1)
GO

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
		-- TODO: crear un trigger que valide la cantidad de familiares 
		--que estan dados de alta contra el nuevo valor de la columna CantFamiliaresACargo, 
		--en caso de que el valor de este sea menor, solicitar la baja obligatoria de algun familiar (se da el nro de afiliado), 
		--de lo contrario dejar la cantidad real de familiares a cargo que existen en la BD para mantener la consistencia
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

CREATE FUNCTION CUATRO_QUESOS.tipoAfiliado(@nroAfiliado numeric(18)) --1 es titular, 2 es conyuge, 3 es familiar no titular ni conyuge
RETURNS int
BEGIN
        DECLARE @tipo int
        SET @tipo = @nroAfiliado % 100
        RETURN CASE WHEN @tipo = 1 THEN 1 WHEN @tipo = 2 THEN 2 ELSE 3 END
END
GO

CREATE FUNCTION CUATRO_QUESOS.raizNroAfiliado(@nroAfiliado numeric(18))
RETURNS int
BEGIN
RETURN (CAST(@nroAfiliado AS INT)/ 100)*100
END
GO

CREATE FUNCTION CUATRO_QUESOS.siguienteNroFamiliar(@nroAfiliadoRaiz int)
RETURNS int
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

--procedures abm rol

CREATE PROCEDURE CUATRO_QUESOS.inhabilitarRol(@rol numeric(18))
AS
        BEGIN TRAN
                INSERT INTO CUATRO_QUESOS.Roles (Habilitado)
                VALUES (0) -- para baja logica
        COMMIT
        
go

CREATE PROCEDURE CUATRO_QUESOS.habilitarRol(@rol numeric(18))
AS
        BEGIN TRAN
                INSERT INTO CUATRO_QUESOS.Roles (Habilitado)
                VALUES (1) -- para baja logica
        COMMIT        

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
        
create procedure CUATRO_QUESOS.getFuncionalidades --no recibe parametros
as
        begin
                SELECT Descripcion 'Funcionalidad'
                FROM CUATRO_QUESOS.Funcionalidades
        end

go        
        
CREATE PROCEDURE CUATRO_QUESOS.modificarRol(@idRol numeric(18),@nombre varchar(50))
AS
UPDATE CUATRO_QUESOS.Roles
SET Nombre = @nombre
WHERE Id_Rol = @idRol

go

create procedure CUATRO_QUESOS.getNombreRol(@idRol numeric(18)) --no recibe parametros
as
        begin
                SELECT Nombre 'NombreRol'
                FROM CUATRO_QUESOS.Roles
                WHERE Id_Rol = @idRol
        end
        
GO

create procedure CUATRO_QUESOS.getFuncionalidadesRol(@idRol numeric(18)) --no recibe parametros
as
        begin
                SELECT f.Descripcion 'Funcionalidad'
                FROM CUATRO_QUESOS.Roles r, CUATRO_QUESOS.Funcionalidades f, CUATRO_QUESOS.Roles_Por_Funcionalidades rf
                WHERE r.Id_Rol = @idRol and r.Id_Rol = rf.Id_Rol and f.Id_Funcionalidad = rf.Id_Funcionalidad
        end
GO

-- CÓDIGO DE ABM DE CANCELACIÓN

CREATE TYPE [CUATRO_QUESOS].[TURNOS_MEDICO] AS TABLE(
	[numero] [numeric](18, 0) NOT NULL,
	[nombre_paciente] [varchar](255) NOT NULL,
	[paciente_apellido] [varchar](255) NOT NULL,
	[fecha] [date] NOT NULL
)
GO

CREATE FUNCTION [CUATRO_QUESOS].[getNroAfiliado] (@Nombre VARCHAR(255), @Apellido VARCHAR(255), @Documento NUMERIC, @TipoDocumento VARCHAR(3))
RETURNS NUMERIC(18,0)
BEGIN
	DECLARE @nro numeric(18)
	SELECT @nro = Nro_Afiliado
	FROM CUATRO_QUESOS.Afiliados
	WHERE Nombre = @Nombre AND Apellido = @Apellido AND Nro_Doc = @Documento AND Tipo_Doc = @TipoDocumento
	RETURN @nro
END
GO

CREATE PROCEDURE [CUATRO_QUESOS].[getTurnosDeMedico](@Nombre VARCHAR(255), 
													@Apellido VARCHAR(255), 
													@Documento NUMERIC(18,0), 
													@TipoDoc VARCHAR(3),
													@DesdeFecha DATE,
													@HastaFecha DATE)
AS
declare @ID_Medico numeric(18)
set @ID_Medico = CUATRO_QUESOS.getIdMedico(@Nombre, @Apellido, @Documento)
SELECT t.numero, a.nombre AS 'Nombre Paciente', a.apellido AS 'Apellido Paciente', t.fecha
FROM CUATRO_QUESOS.Turnos t 
JOIN CUATRO_QUESOS.Afiliados a
ON t.nro_afiliado = a.nro_afiliado
AND t.id_medico = @ID_Medico
WHERE  t.Numero NOT IN(
		SELECT c.Nro_Turno
		FROM CUATRO_QUESOS.Cancelaciones c)
	AND((fecha >= @DesdeFecha AND fecha <= @HastaFecha)
	OR (@DesdeFecha IS NULL AND @HastaFecha IS NULL)
	OR (@DesdeFecha = '' AND @HastaFecha = ''))
GO

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
WHERE  t.Numero NOT IN(
		SELECT c.Nro_Turno
		FROM CUATRO_QUESOS.Cancelaciones c)
GO

CREATE PROCEDURE [CUATRO_QUESOS].[cancelarTurno]( @Nro_Turno NUMERIC(18,0), 
												  @TipoMotivo VARCHAR(255),
												  @Motivo VARCHAR(255) )
AS
INSERT INTO CUATRO_QUESOS.Cancelaciones (Nro_Turno, Tipo, Motivo)
VALUES (@Nro_Turno, @TipoMotivo, @Motivo)
GO

CREATE PROCEDURE [CUATRO_QUESOS].[cancelarPeriodo](	@Tabla CUATRO_QUESOS.TURNOS_MEDICO READONLY, 
												@Motivo VARCHAR(255)		)
AS
	INSERT INTO CUATRO_QUESOS.Cancelaciones
	SELECT t.numero, 'No asistencia', @Motivo
	FROM @Tabla t
GO


-- FIN ABM DE CANCELACIÓN

IF @@ERROR != 0 ROLLBACK

COMMIT
GO