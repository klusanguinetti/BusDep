use busdep
go
DECLARE @TipoUsuarioid numeric(10);

BEGIN
set @TipoUsuarioid =(select TipoUsuarioid from TipoUsuario where Descripcion='Video Analista')
PRINT 'info: ' + convert(varchar(10),@TipoUsuarioid) 

insert into menu(TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
values(@TipoUsuarioid, 'Mis Datos', '#!/Analyst/PrivateProfile', 'fa fa-male', 1, 'A');

insert into menu(TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
values(@TipoUsuarioid, 'AutoEvaluación', '#!/Analyst/SelfAppraisal', 'fa fa-star', 2, 'A');

insert into menu(TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
values(@TipoUsuarioid, 'Cambio de Password', '#!/Account/PasswordChange', 'fa fa-lock', 3, 'A');

end
go
