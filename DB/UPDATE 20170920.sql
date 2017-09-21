use BusDep
go
update Menu
set Descripcion = 'Abm Eventos Publicidad', Url = '#!/EventoPublicidadList'
where Descripcion like 'Abm Publicidad'
go
