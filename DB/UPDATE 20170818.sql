/*Modificaciones*/
use BusDep
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Jugador') and o.name = 'FK_PuestoAlt_Jugador')
alter table Jugador
   drop constraint FK_PuestoAlt_Jugador
go

ALTER TABLE Jugador ADD PuestoAltId  numeric(10);
go

alter table Jugador
   add constraint FK_PuestoAlt_Jugador foreign key (PuestoAltId)
      references Puesto (PuestoId)
go
