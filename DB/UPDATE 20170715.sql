/*Modificaciones*/
use BusDep
go

ALTER TABLE Usuario ADD UltimoLogin date;
go

ALTER TABLE TipoEvaluacion ADD FechaAlta date default getdate();
go
ALTER TABLE TipoEvaluacion ADD Estado date default 'A';
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Evaluacion') and o.name = 'FK_Jugador_Evaluacion')
alter table Evaluacion
   drop constraint FK_Jugador_Evaluacion
go

ALTER TABLE Evaluacion ADD UsuarioId numeric(10,0);
go

UPDATE Evaluacion
SET Evaluacion.UsuarioId = Table_B.UsuarioId
FROM Evaluacion AS Table_A
    INNER JOIN Jugador AS Table_B
        ON Table_A.JugadorId = Table_B.JugadorId
go
ALTER TABLE Evaluacion DROP COLUMN JugadorId
go

ALTER TABLE TipoEvaluacion ADD FechaAlta date default getdate();
go
ALTER TABLE TipoEvaluacion ADD Estado nvarchar(2) default 'A';
go

update TipoEvaluacion
set FechaAlta = getdate(),
Estado = 'A'
go

alter table Evaluacion
   add constraint FK_Usuario_Evaluacion foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

create table LogError (
   LogErrorId           numeric(10)          identity,
   Modulo               nvarchar(400)        null,
   Descripcion          nvarchar(4000)       null,
   Fecha                datetime             null,
   constraint PK_LOGERROR primary key (LogErrorId)
)
go
create table LogActividad (
   LogActividadId       numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   Metodo               nvarchar(400)        null,
   Informacion          nvarchar(4000)       null,
   Fecha                datetime             null,
   constraint PK_LOGACTIVIDAD primary key (LogActividadId)
)
go
