/*Modificaciones tabla Entrenador*/
use BusDep
go

ALTER TABLE Entrenador ADD FotoRostro nvarchar(400);
ALTER TABLE Entrenador ADD Perfil nvarchar(200);
ALTER TABLE JUGADOR ALTER COLUMN FotoRostro varchar(400);
ALTER TABLE JUGADOR ALTER COLUMN FotoCuertoEntero varchar(400);
ALTER TABLE JUGADOR ALTER COLUMN VideoUrl varchar(400);
go
