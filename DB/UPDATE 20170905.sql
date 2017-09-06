use BusDep
go

ALTER TABLE Usuario ADD Estado nvarchar(2) null default 'A';

go

update Usuario
set Estado = 'A'
go

