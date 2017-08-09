/*Modificaciones*/
use BusDep
go

ALTER TABLE TemplateEvaluacion ADD Chart nvarchar(50);
go
update TemplateEvaluacion
set Chart = 'doughnut'
where Descripcion = 'Técnica';
go

update TemplateEvaluacion
set Chart = 'doughnut'
where Descripcion = 'Condición Fisica';
go

update TemplateEvaluacion
set Chart = 'polarArea'
where Descripcion = 'Táctica (cualidades cognoscitivas)';
go

update TemplateEvaluacion
set Chart = 'polarArea'
where Descripcion = 'Cualidades mentales';
go

update TemplateEvaluacion
set Chart = 'pie'
where Descripcion = 'Coordinación';
go

update TemplateEvaluacion
set Chart = 'pie'
where Descripcion = 'Entorno social';
go

update Jugador
set perfil = 'Profesional'
where perfil = 'Profecional'
GO