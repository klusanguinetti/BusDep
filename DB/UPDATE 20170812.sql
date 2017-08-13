/*Modificaciones*/
use BusDep
go

ALTER TABLE DatosPersona ADD ContactoNombre     nvarchar(200);
go
ALTER TABLE DatosPersona ADD ContactoTelefono	nvarchar(20);
go
ALTER TABLE DatosPersona ADD ContactoMail       nvarchar(200);
go

ALTER TABLE Antecedente ADD Puesto        nvarchar(3);
go
ALTER TABLE Antecedente ADD PuestoAlt     nvarchar(3);
go
ALTER TABLE Antecedente ADD TecnicoNombre nvarchar(200);
go
ALTER TABLE Antecedente ADD TecnicoMail   nvarchar(200);
go
ALTER TABLE Antecedente ADD TextoLibre   nvarchar(2000);
go