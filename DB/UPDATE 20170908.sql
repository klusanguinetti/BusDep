use BusDep
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Recomendacion') and o.name = 'FK_Recomedacion_Emisor')
alter table Recomendacion
   drop constraint FK_Recomedacion_Emisor
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Recomendacion') and o.name = 'FK_Recomedacion_Receptor')
alter table Recomendacion
   drop constraint FK_Recomedacion_Receptor
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Recomendacion')
            and   type = 'U')
   drop table Recomendacion
go

/*==============================================================*/
/* Table: Recomendacion                                         */
/*==============================================================*/
create table Recomendacion (
   RecomendacionId      numeric(10)          identity,
   EmisorId             numeric(10)          null,
   ReceptorId           numeric(10)          null,
   Texto                nvarchar(4000)       not null,
   Estado               nvarchar(2)          not null,
   Fecha                datetime             null default getdate(),
   constraint PK_RECOMENDACION primary key (RecomendacionId)
)
go

alter table Recomendacion
   add constraint FK_Recomedacion_Emisor foreign key (EmisorId)
      references Usuario (UsuarioId)
go

alter table Recomendacion
   add constraint FK_Recomedacion_Receptor foreign key (ReceptorId)
      references Usuario (UsuarioId)
go
