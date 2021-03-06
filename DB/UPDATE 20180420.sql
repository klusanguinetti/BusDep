USE [BusDep]
GO

DECLARE @TipoUsuarioid numeric(10), @DeporteId numeric(10),  @TipoEvaluacionid numeric(10), @TemplateEvaluacionId numeric(10); 

BEGIN

set @TipoUsuarioid =(select TipoUsuarioid from TipoUsuario where Descripcion='Video Analista')
PRINT 'info: ' + convert(varchar(10),@TipoUsuarioid) 
set @DeporteId =(select DeporteId from Deporte where Descripcion='Futbol')
PRINT 'info: ' + convert(varchar(10),@DeporteId) 

insert into TipoEvaluacion( DeporteId, TipoUsuarioId, Descripcion, EsDefault, FechaAlta, Estado)
values (@DeporteId, @TipoUsuarioid, 'Evaluación Video Analista Default', 'S', GETDATE(),'A')
set @TipoEvaluacionid = SCOPE_IDENTITY()

	insert into TemplateEvaluacion (TipoEvaluacionId, Descripcion, Chart)
	values (@TipoEvaluacionid, 'Especialidad', 'bar')
	set @TemplateEvaluacionId = SCOPE_IDENTITY()

		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Análisis Individual')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Análisis Equipo Propio')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Análisis Equipo Rival')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Conocimientos de Herramientas de Video Análisis')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Análisis On line')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Conocimientos de Táctica, Evaluación/Interpretación')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Uso de Herramientas tecnológicas')
		insert into TemplateEvaluacionDetalle (TemplateEvaluacionId, Descripcion)
		values (@TemplateEvaluacionId, 'Conocimiento de Técnica, Evaluación/Interpretación')
END