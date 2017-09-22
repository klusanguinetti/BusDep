use BusDep
go

ALTER TABLE EventoPublicidad ADD Lugar nvarchar(400) null;
ALTER TABLE EventoPublicidad ADD Categorias nvarchar(200) null;
ALTER TABLE EventoPublicidad ADD ClubDescripcion nvarchar(200) null;
ALTER TABLE EventoPublicidad ADD ClubLogo nvarchar(4) null;
go
