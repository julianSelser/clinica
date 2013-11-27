USE [GD2C2013]
GO

BEGIN TRAN
GO

DROP FUNCTION CUATRO_QUESOS.FechaMigracion
DROP TRIGGER CUATRO_QUESOS.tr_cancelarTurnoAgenda
DROP PROCEDURE CUATRO_QUESOS.generarTurno
DROP TRIGGER CUATRO_QUESOS.tr_updateAgenda
DROP PROCEDURE CUATRO_QUESOS.getTimeslotsFecha
DROP PROCEDURE CUATRO_QUESOS.getFechasDisponiblesAgenda
drop procedure CUATRO_QUESOS.generarAgenda;
drop procedure CUATRO_QUESOS.getNYAMedico;
DROP PROCEDURE CUATRO_QUESOS.registrarReceta 
DROP PROCEDURE CUATRO_QUESOS.traerMedicamentos
DROP PROCEDURE CUATRO_QUESOS.getBonosFarmacia
DROP PROCEDURE CUATRO_QUESOS.updateConsultaMedica
DROP PROCEDURE CUATRO_QUESOS.getConsultasMedicas
DROP FUNCTION CUATRO_QUESOS.getFinalDeMes
DROP FUNCTION CUATRO_QUESOS.getPrinicipioDeMes
DROP PROCEDURE CUATRO_QUESOS.especialidadesConMasCancelaciones
DROP PROCEDURE CUATRO_QUESOS.bonosVencidosPorAfiliado 
DROP PROCEDURE CUATRO_QUESOS.especialidadesConMasRecetas
DROP PROCEDURE CUATRO_QUESOS.elegirListado
DROP PROCEDURE CUATRO_QUESOS.getListadoEstadistico
DROP PROCEDURE CUATRO_QUESOS.bonosPorTerceros
drop procedure CUATRO_QUESOS.updateFechasMedico
drop procedure CUATRO_QUESOS.modificarDiaAtencion
drop procedure CUATRO_QUESOS.agregarDiaAtencion
drop procedure CUATRO_QUESOS.verifyMedico
drop procedure CUATRO_QUESOS.getDiasAtencion
drop procedure CUATRO_QUESOS.quitarDiaAtencion
DROP PROCEDURE CUATRO_QUESOS.registrarLlegada 
DROP PROCEDURE CUATRO_QUESOS.getBonoConsultaRegistroLlegada
DROP PROCEDURE CUATRO_QUESOS.getTurnosAfiliadoMedicoRegistroLlegada
DROP PROCEDURE CUATRO_QUESOS.deleteEspecialidades
DROP PROCEDURE CUATRO_QUESOS.getEspecialidadesMedico
DROP PROCEDURE CUATRO_QUESOS.traerFuncionalidadesDeRol
DROP PROCEDURE CUATRO_QUESOS.traerRolesDeUsuario
DROP FUNCTION CUATRO_QUESOS.estaHabilitadoUsuario
DROP FUNCTION CUATRO_QUESOS.getPass
DROP PROCEDURE CUATRO_QUESOS.intentarLogear
DROP PROCEDURE CUATRO_QUESOS.traerDatosUsuario
DROP PROCEDURE CUATRO_QUESOS.altaMedico_Especialidad
DROP PROCEDURE CUATRO_QUESOS.getEspecialidades
DROP PROCEDURE CUATRO_QUESOS.registrarCambioPlanMedico
DROP PROCEDURE CUATRO_QUESOS.getConyuge
DROP PROCEDURE CUATRO_QUESOS.cantFamiliaresRegistrados
DROP PROCEDURE CUATRO_QUESOS.getPlanesMedicos
DROP PROCEDURE CUATRO_QUESOS.buscarNroAfiliado
DROP PROCEDURE CUATRO_QUESOS.updateNroConyuge
DROP PROCEDURE CUATRO_QUESOS.updateAfiliado
DROP PROCEDURE CUATRO_QUESOS.getAfiliados
DROP PROCEDURE CUATRO_QUESOS.getIdMedico
DROP FUNCTION CUATRO_QUESOS.tipoAfiliado
DROP FUNCTION CUATRO_QUESOS.getNroAfiliado
DROP FUNCTION CUATRO_QUESOS.raizNroAfiliado
DROP FUNCTION CUATRO_QUESOS.siguienteNroFamiliar
DROP PROCEDURE CUATRO_QUESOS.cancelarPeriodo
DROP PROCEDURE CUATRO_QUESOS.cancelarTurno
DROP PROCEDURE CUATRO_QUESOS.getTurnosDeAfiliado
DROP PROCEDURE CUATRO_QUESOS.getTurnosDeMedico
DROP PROCEDURE CUATRO_QUESOS.darAltaAfiliado
DROP PROCEDURE CUATRO_QUESOS.darBajaAfiliado
DROP PROCEDURE CUATRO_QUESOS.getMedicos
DROP PROCEDURE CUATRO_QUESOS.altaMedico
DROP PROCEDURE CUATRO_QUESOS.bajaMedico
DROP PROCEDURE CUATRO_QUESOS.updateMedico
DROP PROCEDURE CUATRO_QUESOS.getRoles
DROP PROCEDURE CUATRO_QUESOS.inhabilitarRol
DROP PROCEDURE CUATRO_QUESOS.habilitarRol
DROP PROCEDURE CUATRO_QUESOS.getIdRol
DROP PROCEDURE CUATRO_QUESOS.altaRol_Funcionalidad
DROP PROCEDURE CUATRO_QUESOS.addFuncionalidadARol
DROP PROCEDURE CUATRO_QUESOS.sacarTodaFuncionalidadARol
DROP PROCEDURE CUATRO_QUESOS.altaRol
DROP PROCEDURE CUATRO_QUESOS.getFuncionalidades
DROP PROCEDURE CUATRO_QUESOS.getFuncionalidadesRol
DROP PROCEDURE CUATRO_QUESOS.getNombreRol
DROP PROCEDURE CUATRO_QUESOS.modificarRol
drop procedure CUATRO_QUESOS.getDatosParaCompra
drop procedure CUATRO_QUESOS.comprarBonos
DROP TYPE CUATRO_QUESOS.TURNOS_MEDICO

DROP TRIGGER CUATRO_QUESOS.tr_up_after_consulta
DROP TRIGGER CUATRO_QUESOS.tr_updateNroConyuge
drop trigger CUATRO_QUESOS.quitarRolInhabilitado
drop trigger CUATRO_QUESOS.revocarUsuario
drop trigger CUATRO_QUESOS.cancelarTurnosMedicosDesvinculados
drop trigger CUATRO_QUESOS.cancelarTurnosPacientesDesvinculados
drop trigger CUATRO_QUESOS.limitarJornadaLaboral
drop trigger CUATRO_QUESOS.obedecerHorariosClinica
drop trigger CUATRO_QUESOS.limitarMedicamentosPorBono
--drop trigger CUATRO_QUESOS.quitarTurnosDeDiaEliminado
--drop trigger CUATRO_QUESOS.cancelarTurnosFueraDeHora
--drop trigger CUATRO_QUESOS.cancelarTurnosFueraDeAgenda


-- Drop Foreign Key Constraints
ALTER TABLE CUATRO_QUESOS.Agendas_Medicos DROP CONSTRAINT FK_Agenda_Medico
;

ALTER TABLE CUATRO_QUESOS.Agendas_Medicos DROP CONSTRAINT FK_Agenda_Turno
;



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

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados DROP CONSTRAINT UQ_Usuarios_Afiliados_Nro_Afiliado
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados DROP CONSTRAINT UQ_Usuarios_Afiliados_Username
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados DROP CONSTRAINT PK_Usuarios_Afiliados
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados DROP CONSTRAINT FK_Usuarios_Afiliados_Afiliados
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Afiliados DROP CONSTRAINT FK_Usuarios_Afiliados_Usuarios
;


ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos DROP CONSTRAINT UQ_Usuarios_Medicos_Id_Medico
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos DROP CONSTRAINT UQ_Usuarios_Medicos_Username
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos DROP CONSTRAINT PK_Usuarios_Medicos
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos DROP CONSTRAINT FK_Usuarios_Medicos_Medicos
;

ALTER TABLE CUATRO_QUESOS.Usuarios_Medicos DROP CONSTRAINT FK_Usuarios_Medicos_Usuarios
;

-- Drop other constraints



ALTER TABLE CUATRO_QUESOS.Afiliados DROP CONSTRAINT CHK_Estado_Civil
;


-- Drop Tables, Stored Procedures and Views

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Afiliados') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Afiliados
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Agendas_Medicos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Agendas_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Bonos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Bonos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Cambios_Plan') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Cambios_Plan
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Cancelaciones') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Cancelaciones
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Compra') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Compra
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Consultas') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Consultas
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Consultas_Exceptions') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Consultas_Exceptions
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Dias_Atencion') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Dias_Atencion
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Especialidades') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Especialidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Especialidades_Medicos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Especialidades_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Funcionalidades') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Funcionalidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicamentos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicamentos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicamentos_Por_Consulta') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicamentos_Por_Consulta
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Medicos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Planes_Medicos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Planes_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Roles') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Roles
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Roles_Por_Funcionalidades') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Roles_Por_Funcionalidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Tipos_Especialidades') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Tipos_Especialidades
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Turnos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Turnos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios_Afiliados') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios_Afiliados
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios_Medicos') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios_Medicos
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Usuarios_Por_Rol') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Usuarios_Por_Rol
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Horas_del_dia') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Horas_del_dia
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('CUATRO_QUESOS.Dias') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE CUATRO_QUESOS.Dias
;

--DROP VIEW CUATRO_QUESOS.Agendas_Medicos;
--esta vista ya no existe

DROP SCHEMA [CUATRO_QUESOS]
GO

COMMIT
