use BusDep
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EventoPublicidad')
            and   type = 'U')
   drop table EventoPublicidad
go

/*==============================================================*/
/* Table: EventoPublicidad                                      */
/*==============================================================*/
create table EventoPublicidad (
   EventoPublicidadId   numeric(10)          identity,
   Titulo               nvarchar(200)        null,
   Informacion          nvarchar(2000)       null,
   ImageUrl             nvarchar(400)        null,
   Link                 nvarchar(400)        null,
   FechaHasta           datetime             null,
   Estado               nvarchar(2)          null,
   constraint PK_EVENTOPUBLICIDAD primary key (EventoPublicidadId)
)
go
