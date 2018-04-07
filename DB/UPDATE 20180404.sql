use BusDep
go

/*==============================================================*/
/* Table: VideoAnalista                                         */
/*==============================================================*/
create table VideoAnalista (
   VideoAnalistaId      numeric(10)          identity,
   constraint PK_VIDEOANALISTA primary key (VideoAnalistaId)
)
go

ALTER TABLE Usuario ADD VideoAnalistaId numeric(10) null;
go

alter table Usuario
   add constraint FK_VideoAnalista_Usuario foreign key (VideoAnalistaId)
      references VideoAnalista (VideoAnalistaId)
go


INSERT INTO TipoUsuario(Descripcion)
VALUES ('Video Analista')
GO