/*Modificaciones tabla Entrenador*/
use BusDep
go
update Menu
set Url = '#!/Coach/PrivateProfileEntrenador'
where Url = '#!Profile/PrivateProfileEntrenador'
go
