use BusDep
go
truncate table [dbo].[Antecedente]
truncate table [dbo].[EvaluacionDetalle]
truncate table [dbo].[LogActividad]
truncate table [dbo].[LogError]
truncate table [dbo].[RecuperoUsuario]
truncate table [dbo].[UsuarioAplicativo]
go
update Usuario
set JugadorId=null, IntermediarioId=null, EntrenadorId=null,ClubId=null,DatosPersonaId=null
go
delete from [dbo].[DatosPersona]
go
delete from [dbo].[EvaluacionCabecera]
delete from [dbo].[Evaluacion]
delete from  [dbo].[Entrenador]
delete from  [dbo].[Intermediario]
delete from  [dbo].[Jugador]
delete from  [dbo].[Club]
delete from  [dbo].[Usuario]
go

