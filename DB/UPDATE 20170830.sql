USE [BusDep]
GO

DECLARE @TipoUsuarioid numeric(10), @DeporteId numeric(10),  @TipoEvaluacionid numeric(10), @TemplateEvaluacionId numeric(10); 

BEGIN

set @TipoUsuarioid =(select TipoUsuarioid from TipoUsuario where Descripcion='Entrenador')
PRINT 'info: ' + convert(varchar(10),@TipoUsuarioid) 
set @DeporteId =(select DeporteId from Deporte where Descripcion='Futbol')
PRINT 'info: ' + convert(varchar(10),@DeporteId) 

insert into TipoEvaluacion( DeporteId, TipoUsuarioId, Descripcion, EsDefault, FechaAlta, Estado)
values (@DeporteId, @TipoUsuarioid, 'Evaluación Entrenador Default', 'S', GETDATE(),'A')
set @TipoEvaluacionid = SCOPE_IDENTITY()

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Habilidad', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()

		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Armado del Equipo de alto rendimiento')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Administración del Grupo')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Conocimientos tácticos y como enseñarlos/implementarlos')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Conocimientos Físico y cómo enseñarlos/implementarlos')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Detallista')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Creatividad')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Uso de Herramientas tecnológicas')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Detección de Jugadores')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Gestión y desarrollo del Talento')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Estrategia Operativa (preparación de partidos)')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Sistema de Juego Ideal', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-4-4-2')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-4-3-1-2')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-4-3-3')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-3-5-2')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-5-4-1')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, '1-3-4-3')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Idea de Juego Ofensivo', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Estilo Combinativo')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Directo')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Contra golpe')
	
	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Idea de Juego Defensivo', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Contención')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Presión')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Mixto')


	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Planteamiento Ideal', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Ofensivo')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Defensivo')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Maniobra')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Zonas de ataque', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Centralizados')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Por las bandas')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Estilo y Adaptabilidad al rival', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Jugar igual independientemente del Rival')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Jugar adaptándonos al rival')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Posiciones', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Amplia libertad para los jugadores')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Liberta posicional limitada')

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Marca en Pelota parada', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Marca Hombre a Hombre')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Marca en Zona')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Marca Mixta')
END