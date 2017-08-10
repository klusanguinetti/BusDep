/*Modificaciones*/
use BusDep
go

/*==============================================================*/
/* Table: RecuperoUsuario                                       */
/*==============================================================*/
create table RecuperoUsuario (
   RecuperoUsuarioId    numeric(10)          identity,
   Mail                 nvarchar(200)        null,
   Codigo               numeric(8)           null,
   Fecha                datetime             null,
   constraint PK_RECUPEROUSUARIO primary key (RecuperoUsuarioId)
)
go

