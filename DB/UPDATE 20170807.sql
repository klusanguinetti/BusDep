/*Modificaciones*/
use BusDep
go

ALTER TABLE Puesto ADD Codigo nvarchar(3);
go

update Puesto
set Codigo = 'ar'
where PuestoEspecifico = 'Arquero';
go
update Puesto
set Codigo = 'di'
where PuestoEspecifico like 'Defensor Izquierdo';
go
update Puesto
set Codigo = 'dd'
where PuestoEspecifico like 'Defensor Derecho';
go
update Puesto
set Codigo = 'dc'
where PuestoEspecifico = 'Defensor Centro';
go
update Puesto
set Codigo = 'mi'
where PuestoEspecifico = 'Mediocampista Izquierdo';
go
update Puesto
set Codigo = 'md'
where PuestoEspecifico = 'Mediocampista Derecho';
go
update Puesto
set Codigo = 'mc'
where PuestoEspecifico = 'Mediocampista Centro';
go
update Puesto
set Codigo = 'ei'
where PuestoEspecifico = 'Delantero Izquierdo';
go
update Puesto
set Codigo = 'ed'
where PuestoEspecifico = 'Delantero Derecho';
go
update Puesto
set Codigo = 'ec'
where PuestoEspecifico = 'Delantero Centro';
go