USE [BusDep]
GO

INSERT INTO [dbo].[TipoUsuario] ([Descripcion]) VALUES('Administrador')
go

DECLARE @TipoUsuarioid numeric(10)

BEGIN

set @TipoUsuarioid =(select TipoUsuarioid from TipoUsuario where Descripcion='Administrador')
PRINT 'info: ' + convert(varchar(10),@TipoUsuarioid) 

INSERT INTO Usuario(TipoUsuarioId, Mail, [Password], Estado)
values (@TipoUsuarioid, 'admin@allwiners.com', '+gUroPeb7APsevQP2Fq6Ig==', 'A')

INSERT INTO Menu(TipoUsuarioId, Descripcion, Url, Icono, Img, Orden, Estado)
VALUES(@TipoUsuarioid, 'Abm Publicidad','#!/Publicidad/List','fa fa-star',null,1,'A')

END
go

USE [BusDep]
GO

if exists (select 1
            from  sysobjects
           where  id = object_id('Publicidad')
            and   type = 'U')
   drop table Publicidad
go

/*==============================================================*/
/* Table: Publicidad                                            */
/*==============================================================*/
create table Publicidad (
   PublicidadId         numeric(10)          identity,
   ImageUrl             nvarchar(400)        null,
   Link                 nvarchar(400)        null,
   Estado               nvarchar(2)          null default 'A',
   constraint PK_PUBLICIDAD primary key (PublicidadId)
)
go
