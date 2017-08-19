use BusDep
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Menu') and o.name = 'FK_Menu_MenuParent')
alter table Menu
   drop constraint FK_Menu_MenuParent
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Menu') and o.name = 'FK_Menu_TipoUsuario')
alter table Menu
   drop constraint FK_Menu_TipoUsuario
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Menu')
            and   type = 'U')
   drop table Menu
go

/*==============================================================*/
/* Table: Menu                                                  */
/*==============================================================*/
create table Menu (
   MenuId               numeric(10)          identity,
   TipoUsuarioId        numeric(10)          null,
   ParentMenuId         numeric(10)          null,
   Descripcion          nvarchar(200)        null,
   Url                  nvarchar(400)        null,
   Icono                nvarchar(200)        null,
   Img                  nvarchar(400)        null,
   Orden                numeric(2)           null,
   Estado               nvarchar(2)          null,
   constraint PK_MENU primary key (MenuId)
)
go

alter table Menu
   add constraint FK_Menu_MenuParent foreign key (ParentMenuId)
      references Menu (MenuId)
go

alter table Menu
   add constraint FK_Menu_TipoUsuario foreign key (TipoUsuarioId)
      references TipoUsuario (TipoUsuarioId)
go



use BusDep
go

DECLARE @TipoUsuario_id numeric(10), @Descripcion varchar(200);

DECLARE _cursor CURSOR FOR
SELECT TipoUsuarioId, Descripcion FROM TipoUsuario;

OPEN _cursor;

delete from Menu

FETCH NEXT FROM _cursor
INTO @TipoUsuario_id, @Descripcion;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN

   -- Concatenate and display the current values in the variables.
   PRINT 'info: ' + convert(varchar(10),@TipoUsuario_id) + ' ' +  @Descripcion

   if @Descripcion = 'Jugador'
   begin
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Mi pefil', '#!Profile/PrivateProfile','icon-home', 1, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Antecedentes', '#!History/SportsHistory/List','fa fa-futbol-o', 2, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'AutoEvaluación', '#!Evaluation/SelfAppraisal','fa fa-star', 3, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Cambio de Password', '#!/Account/PasswordChange','fa fa-lock', 4, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Certificaciones', '','icon-folder-close', 5, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Mis pendientes', '','icon-hourglass', 6, 'A')
		insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		values (@TipoUsuario_id, 'Ofertas', '','icon-hourglass', 7, 'A')
   end
   -- This is executed as long as the previous fetch succeeds.
   FETCH NEXT FROM _cursor
   INTO @TipoUsuario_id, @Descripcion;
END

CLOSE _cursor;
DEALLOCATE _cursor;
GO