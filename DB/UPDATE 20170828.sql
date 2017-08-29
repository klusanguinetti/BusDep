use BusDep
go

ALTER TABLE Usuario ADD JugadorId  numeric(10);
ALTER TABLE Usuario ADD IntermediarioId  numeric(10);
ALTER TABLE Usuario ADD EntrenadorId  numeric(10);
ALTER TABLE Usuario ADD ClubId  numeric(10);
ALTER TABLE Usuario ADD DatosPersonaId  numeric(10);
go

update Usuario
set Usuario.JugadorId = s.JugadorId
from Usuario u
    inner join Jugador s on
        u.UsuarioId = s.UsuarioId
go

update Usuario
set Usuario.IntermediarioId = s.IntermediarioId
from Usuario u
    inner join Intermediario s on
        u.UsuarioId = s.UsuarioId
go

update Usuario
set Usuario.EntrenadorId = s.EntrenadorId
from Usuario u
    inner join Entrenador s on
        u.UsuarioId = s.UsuarioId
go

update Usuario
set Usuario.ClubId = s.ClubId
from Usuario u
    inner join Club s on
        u.UsuarioId = s.UsuarioId
go

update Usuario
set Usuario.DatosPersonaId = s.DatosPersonaId
from Usuario u
    inner join DatosPersona s on
        u.UsuarioId = s.UsuarioId
go

alter table Usuario
   add constraint FK_Jugardor_Usuario foreign key (JugadorId)
      references Jugador (JugadorId)
go
alter table Usuario
   add constraint FK_Club_Usuario foreign key (ClubId)
      references Club (ClubId)
go
alter table Usuario
   add constraint FK_Intermediario_Usuario foreign key (IntermediarioId)
      references Intermediario (IntermediarioId)
go
alter table Usuario
   add constraint FK_Entrenado_Usuario foreign key (EntrenadorId)
      references Entrenador (EntrenadorId)
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Usuario') and o.name = 'FK_Usuario_DatosPersona')
alter table Usuario
   drop constraint FK_Usuario_DatosPersona
go
alter table Usuario
   add constraint FK_Usuario_DatosPersona foreign key (DatosPersonaId)
      references DatosPersona (DatosPersonaId)

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DatosPersona') and o.name = 'FK_DatosPersona_Usuario')
alter table DatosPersona
   drop constraint FK_DatosPersona_Usuario
go

alter table DatosPersona
   add constraint FK_DatosPersona_Usuario foreign key (UsuarioId)
      references Usuario (UsuarioId)
go
