use master
go
/*==============================================================*/
/* Database name:  BusDep                                       */
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     10/07/2017 07:42:38 p.m.                     */
/*==============================================================*/


drop database BusDep
go

/*==============================================================*/
/* Database: BusDep                                             */
/*==============================================================*/
create database BusDep
go

use BusDep
go

/*==============================================================*/
/* Table: Antecedente                                           */
/*==============================================================*/
create table Antecedente (
   AntecedenteId        numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   ClubDescripcion      nvarchar(400)        null,
   ClubLogo             nvarchar(200)        null,
   FechaInicio          datetime             null,
   FechaFin             datetime             null,
   InformacionAdicional nvarchar(2000)       null,
   Video                nvarchar(400)        null,
   Goles                numeric(8)           null,
   Partidos             numeric(8)           null,
   Asistencias          numeric(8)           null,
   constraint PK_ANTECEDENTE primary key (AntecedenteId)
)
go

/*==============================================================*/
/* Table: Certificacion                                         */
/*==============================================================*/
create table Certificacion (
   CertificacionId      numeric(10)          identity,
   Nombre               nvarchar(200)        null,
   Apellido             nvarchar(200)        null,
   constraint PK_CERTIFICACION primary key (CertificacionId)
)
go

/*==============================================================*/
/* Table: Club                                                  */
/*==============================================================*/
create table Club (
   ClubId               numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   constraint PK_CLUB primary key (ClubId)
)
go

/*==============================================================*/
/* Table: DatosPersona                                          */
/*==============================================================*/
create table DatosPersona (
   DatosPersonaId       numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   Mail                 nvarchar(200)        null,
   Nombre               nvarchar(200)        null,
   Apellido             nvarchar(200)        null,
   Telefono             nvarchar(20)         null,
   Pais                 nvarchar(100)        null,
   PaisIso              nvarchar(5)          null,
   Provincia            nvarchar(30)         null,
   Ciudad               nvarchar(100)        null,
   TipoDocumento        nvarchar(100)        null,
   NumeroDocumento      nvarchar(30)         null,
   FechaNacimiento      datetime             null,
   Direccion            nvarchar(400)        null,
   CodigoPostal         nvarchar(10)         null,
   Nacionalidad         nvarchar(100)        null,
   Nacionalidad1        nvarchar(100)        null,
   NacionalidadIso      nvarchar(5)          null,
   NacionalidadIso1     nvarchar(5)          null,
   Informacion          nvarchar(4000)       null,
   constraint PK_DATOSPERSONA primary key (DatosPersonaId)
)
go

/*==============================================================*/
/* Table: Deporte                                               */
/*==============================================================*/
create table Deporte (
   DeporteId            numeric(10)          identity,
   Descripcion          nvarchar(100)        null,
   Tipo                 nvarchar(100)        null,
   constraint PK_DEPORTE primary key (DeporteId)
)
go

/*==============================================================*/
/* Table: Entrenador                                            */
/*==============================================================*/
create table Entrenador (
   EntrenadorId         numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   constraint PK_ENTRENADOR primary key (EntrenadorId)
)
go

/*==============================================================*/
/* Table: Envio                                                 */
/*==============================================================*/
create table Envio (
   EnvioId              numeric(10)          identity,
   EventoId             numeric(10)          null,
   UsuarioId            numeric(10)          null,
   Fecha                datetime             null,
   constraint PK_ENVIO primary key (EnvioId)
)
go

/*==============================================================*/
/* Table: Evaluacion                                            */
/*==============================================================*/
create table Evaluacion (
   EvaluacionId         numeric(10)          identity,
   JugadorId            numeric(10)          null,
   TipoEvaluacionId     numeric(10)          null,
   FechaAlta            datetime             null default getdate(),
   constraint PK_EVALUACION primary key (EvaluacionId)
)
go

/*==============================================================*/
/* Table: EvaluacionCabecera                                    */
/*==============================================================*/
create table EvaluacionCabecera (
   EvaluacionCabeceraId numeric(10)          identity,
   EvaluacionId         numeric(10)          null,
   TemplateEvaluacionId numeric(10)          null,
   constraint PK_EVALUACIONCABECERA primary key (EvaluacionCabeceraId)
)
go

/*==============================================================*/
/* Table: EvaluacionDetalle                                     */
/*==============================================================*/
create table EvaluacionDetalle (
   EvaluacionDetalleId  numeric(10)          identity,
   EvaluacionCabeceraId numeric(10)          null,
   TemplateEvaluacionDetalleId numeric(10)          null,
   Puntuacion           numeric(2)           null,
   constraint PK_EVALUACIONDETALLE primary key (EvaluacionDetalleId)
)
go

/*==============================================================*/
/* Table: Evento                                                */
/*==============================================================*/
create table Evento (
   EventoId             numeric(10)          identity,
   TipoEventoId         numeric(10)          null,
   Titulo               nvarchar(200)        null,
   Descripcion          nvarchar(2000)       null,
   Logo                 nvarchar(200)        null,
   FechaInicio          datetime             null,
   FechaFin             datetime             null,
   Pais                 nvarchar(200)        null,
   Provincia            nvarchar(200)        null,
   Ciudad               nvarchar(200)        null,
   Calle                nvarchar(400)        null,
   PaginaWeb            nvarchar(400)        null,
   constraint PK_EVENTO primary key (EventoId)
)
go

/*==============================================================*/
/* Table: InscripcionEvento                                     */
/*==============================================================*/
create table InscripcionEvento (
   InscripcionEventoId  numeric(10)          identity,
   EventoId             numeric(10)          null,
   UsuarioId            numeric(10)          null,
   Fecha                datetime             null,
   constraint PK_INSCRIPCIONEVENTO primary key (InscripcionEventoId)
)
go

/*==============================================================*/
/* Table: Intermediario                                         */
/*==============================================================*/
create table Intermediario (
   IntermediarioId      numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   constraint PK_INTERMEDIARIO primary key (IntermediarioId)
)
go

/*==============================================================*/
/* Table: Jugador                                               */
/*==============================================================*/
create table Jugador (
   JugadorId            numeric(10)          identity,
   PuestoId             numeric(10)          null,
   UsuarioId            numeric(10)          null,
   Altura               numeric(3,2)         null,
   Peso                 numeric(5,2)         null,
   FotoCuertoEntero     nvarchar(200)        null,
   FotoRostro           nvarchar(200)        null,
   Perfil               nvarchar(20)         null,
   Fichaje              nvarchar(50)         null,
   Pie                  nvarchar(20)         null,
   ClubDescripcion      nvarchar(400)        null,
   ClubLogo             nvarchar(200)        null,
   constraint PK_JUGADOR primary key (JugadorId)
)
go

/*==============================================================*/
/* Table: Participacion                                         */
/*==============================================================*/
create table Participacion (
   ParticipacionId      numeric(10)          identity,
   EventoId             numeric(10)          null,
   Categoria            numeric(4)           null,
   constraint PK_PARTICIPACION primary key (ParticipacionId)
)
go

/*==============================================================*/
/* Table: Puesto                                                */
/*==============================================================*/
create table Puesto (
   PuestoId             numeric(10)          identity,
   DeporteId            numeric(10)          null,
   Descripcion          nvarchar(200)        null,
   PuestoEspecifico     nvarchar(200)        null,
   constraint PK_PUESTO primary key (PuestoId)
)
go

/*==============================================================*/
/* Table: TemplateEvaluacion                                    */
/*==============================================================*/
create table TemplateEvaluacion (
   TemplateEvaluacionId numeric(10)          identity,
   TipoEvaluacionId     numeric(10)          null,
   Descripcion          nvarchar(100)        null,
   constraint PK_TEMPLATEEVALUACION primary key (TemplateEvaluacionId)
)
go

/*==============================================================*/
/* Table: TemplateEvaluacionDetalle                             */
/*==============================================================*/
create table TemplateEvaluacionDetalle (
   TemplateEvaluacionDetalleId numeric(10)          identity,
   TemplateEvaluacionId numeric(10)          null,
   Descripcion          nvarchar(100)        null,
   constraint PK_TEMPLATEEVALUACIONDETALLE primary key (TemplateEvaluacionDetalleId)
)
go

/*==============================================================*/
/* Table: TipoEvaluacion                                        */
/*==============================================================*/
create table TipoEvaluacion (
   TipoEvaluacionId     numeric(10)          identity,
   DeporteId            numeric(10)          null,
   TipoUsuarioId        numeric(10)          null,
   Descripcion          nvarchar(400)        null,
   EsDefault            nvarchar(1)          null default 'N',
   constraint PK_TIPOEVALUACION primary key (TipoEvaluacionId)
)
go

/*==============================================================*/
/* Table: TipoEvento                                            */
/*==============================================================*/
create table TipoEvento (
   TipoEventoId         numeric(10)          identity,
   Descripcion          nvarchar(200)        null,
   constraint PK_TIPOEVENTO primary key (TipoEventoId)
)
go

/*==============================================================*/
/* Table: TipoUsuario                                           */
/*==============================================================*/
create table TipoUsuario (
   TipoUsuarioId        numeric(10)          identity,
   Descripcion          nvarchar(200)        null,
   constraint PK_TIPOUSUARIO primary key (TipoUsuarioId)
)
go

/*==============================================================*/
/* Table: TipoVideo                                             */
/*==============================================================*/
create table TipoVideo (
   TipoVideoId          numeric(10)          identity,
   Descripcion          nvarchar(100)        null,
   constraint PK_TIPOVIDEO primary key (TipoVideoId)
)
go

/*==============================================================*/
/* Table: Usuario                                               */
/*==============================================================*/
create table Usuario (
   UsuarioId            numeric(10)          identity,
   TipoUsuarioId        numeric(10)          null,
   DeporteId            numeric(10)          null,
   Mail                 nvarchar(200)        null,
   Password             nvarchar(100)        null,
   constraint PK_USUARIO primary key (UsuarioId)
)
go

/*==============================================================*/
/* Table: UsuarioAplicativo                                     */
/*==============================================================*/
create table UsuarioAplicativo (
   UsuarioAplicativoId  numeric(10)          identity,
   UsuarioId            numeric(10)          null,
   Aplicativo           nvarchar(30)         null,
   Token                nvarchar(200)        null,
   constraint PK_USUARIOAPLICATIVO primary key (UsuarioAplicativoId)
)
go

/*==============================================================*/
/* Table: Video                                                 */
/*==============================================================*/
create table Video (
   VideoId              numeric(10)          identity,
   TipoVideoId          numeric(10)          null,
   UsuarioId            numeric(10)          null,
   Descripcion          nvarchar(2000)       null,
   constraint PK_VIDEO primary key (VideoId)
)
go

alter table Antecedente
   add constraint FK_Antecedente_Usuario foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Club
   add constraint FK_CLUB_REFERENCE_USUARIO foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table DatosPersona
   add constraint FK_DATOSPER_REFERENCE_USUARIO foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Entrenador
   add constraint FK_ENTRENAD_REFERENCE_USUARIO foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Envio
   add constraint FK_Envio_Usuario foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Envio
   add constraint FK_Evento_Envio foreign key (EventoId)
      references Evento (EventoId)
go

alter table Evaluacion
   add constraint FK_Evaluacion_TipoEvaluacion foreign key (TipoEvaluacionId)
      references TipoEvaluacion (TipoEvaluacionId)
go

alter table Evaluacion
   add constraint FK_Jugador_Evaluacion foreign key (JugadorId)
      references Jugador (JugadorId)
go

alter table EvaluacionCabecera
   add constraint FK_EvaluacionCabecera_Template foreign key (TemplateEvaluacionId)
      references TemplateEvaluacion (TemplateEvaluacionId)
go

alter table EvaluacionCabecera
   add constraint FK_Evaluacion_Cabecera foreign key (EvaluacionId)
      references Evaluacion (EvaluacionId)
go

alter table EvaluacionDetalle
   add constraint FK_EvaluacionCabecera_Detalle foreign key (EvaluacionCabeceraId)
      references EvaluacionCabecera (EvaluacionCabeceraId)
go

alter table EvaluacionDetalle
   add constraint FK_EvaluacionDetalle_Template foreign key (TemplateEvaluacionDetalleId)
      references TemplateEvaluacionDetalle (TemplateEvaluacionDetalleId)
go

alter table Evento
   add constraint FK_TipoEvento_Evento foreign key (TipoEventoId)
      references TipoEvento (TipoEventoId)
go

alter table InscripcionEvento
   add constraint FK_Usuario_Inscripcion foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table InscripcionEvento
   add constraint PK_Evento_Inscripcion foreign key (EventoId)
      references Evento (EventoId)
go

alter table Intermediario
   add constraint FK_INTERMED_REFERENCE_USUARIO foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Jugador
   add constraint FK_Puesto_Jugador foreign key (PuestoId)
      references Puesto (PuestoId)
go

alter table Jugador
   add constraint FK_JUGADOR_REFERENCE_USUARIO foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Participacion
   add constraint FK_Evento_Participacion foreign key (EventoId)
      references Evento (EventoId)
go

alter table Puesto
   add constraint FK_Deporte_Puesto foreign key (DeporteId)
      references Deporte (DeporteId)
go

alter table TemplateEvaluacion
   add constraint FK_TipoEvaluacion_TemplateEvaluacion foreign key (TipoEvaluacionId)
      references TipoEvaluacion (TipoEvaluacionId)
go

alter table TemplateEvaluacionDetalle
   add constraint FK_TemplateEvaluacion_Detalle foreign key (TemplateEvaluacionId)
      references TemplateEvaluacion (TemplateEvaluacionId)
go

alter table TipoEvaluacion
   add constraint FK_TipoEvaluacion_Deporte foreign key (DeporteId)
      references Deporte (DeporteId)
go

alter table TipoEvaluacion
   add constraint FK_TipoEvaluacion_TipoUsuario foreign key (TipoUsuarioId)
      references TipoUsuario (TipoUsuarioId)
go

alter table Usuario
   add constraint FK_TipoUsuario_Usuario foreign key (TipoUsuarioId)
      references TipoUsuario (TipoUsuarioId)
go

alter table Usuario
   add constraint FK_Usuario_Deporte foreign key (DeporteId)
      references Deporte (DeporteId)
go

alter table UsuarioAplicativo
   add constraint FK_Aplicativo_Usuario foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

alter table Video
   add constraint FK_TipoVideo_Video foreign key (TipoVideoId)
      references TipoVideo (TipoVideoId)
go

alter table Video
   add constraint FK_Video_Usuario foreign key (UsuarioId)
      references Usuario (UsuarioId)
go

