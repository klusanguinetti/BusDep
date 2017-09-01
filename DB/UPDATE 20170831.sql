use BusDep
go

update TemplateEvaluaciondetalle
set Descripcion = 'Control orientación'
where Descripcion = 'Control orientación (recepción y pase)'
go

update TemplateEvaluaciondetalle
set Descripcion = 'Visión de Juego'
where Descripcion = 'Inteligencia de juego (visión)'
go

update TemplateEvaluaciondetalle
set Descripcion = 'Juego ofensivo'
where Descripcion = 'Conducta o juego ofensivo'
go
update TemplateEvaluaciondetalle
set Descripcion = 'Juevo defensivo'
where Descripcion = 'Conducta o juevo defensivo'
go


insert into TemplateEvaluaciondetalle(TemplateEvaluacionId, Descripcion)
values (3, 'Adaptación a Sistemas')
go
insert into TemplateEvaluaciondetalle(TemplateEvaluacionId, Descripcion)
values (3, 'Polifuncionalidad')
go
