use Busdep
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Intermediario') and o.name = 'FK_Usuario_Intermediario')
alter table Intermediario
   drop constraint FK_Usuario_Intermediario
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Club') and o.name = 'FK_Usuario_Club')
alter table Club
   drop constraint FK_Usuario_Club
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Entrenador') and o.name = 'FK_Usuario_Entrenador')
alter table Entrenador
   drop constraint FK_Usuario_Entrenador
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Jugador') and o.name = 'FK_Usuario_Jugador')
alter table Jugador
   drop constraint FK_Usuario_Jugador
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DatosPersona') and o.name = 'FK_DatosPersona_Usuario')
alter table DatosPersona
   drop constraint FK_DatosPersona_Usuario
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DatosPersona') and o.name = 'FK_DATOSPER_REFERENCE_USUARIO')
alter table DatosPersona
   drop constraint FK_DATOSPER_REFERENCE_USUARIO
go


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Intermediario') and o.name = 'FK_INTERMED_REFERENCE_USUARIO')
alter table Intermediario
   drop constraint FK_INTERMED_REFERENCE_USUARIO
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Club') and o.name = 'FK_CLUB_REFERENCE_USUARIO')
alter table Club
   drop constraint FK_CLUB_REFERENCE_USUARIO
go
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Entrenador') and o.name = 'FK_ENTRENAD_REFERENCE_USUARIO')
alter table Entrenador
   drop constraint FK_ENTRENAD_REFERENCE_USUARIO
go

ALTER TABLE Intermediario DROP COLUMN USUARIOID;
go
ALTER TABLE Club DROP COLUMN USUARIOID;
go
ALTER TABLE Jugador DROP COLUMN USUARIOID;
go
ALTER TABLE Entrenador DROP COLUMN USUARIOID;
go
ALTER TABLE DatosPersona DROP COLUMN USUARIOID;
go
