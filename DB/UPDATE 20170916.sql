use busdep
go
DECLARE @TipoUsuario_id numeric(10), @Descripcion varchar(200);

DECLARE _cursor CURSOR FOR
SELECT TipoUsuarioId, Descripcion FROM TipoUsuario;

OPEN _cursor;
FETCH NEXT FROM _cursor
INTO @TipoUsuario_id, @Descripcion;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN

   -- Concatenate and display the current values in the variables.
   PRINT 'info: ' + convert(varchar(10),@TipoUsuario_id) + ' ' +  @Descripcion

   
   if @Descripcion = 'Entrenador'
   begin
		--insert into Menu (TipoUsuarioId, Descripcion, Url, Icono, Orden, Estado)
		--values (@TipoUsuario_id, 'Antecedentes', '#!Coach/SportsHistory/List','fa fa-futbol-o', 2, 'A')
		update menu 
		set url = '#!/Coach/SelfAppraisal'
		where url url like'%Evaluation/SelfAppraisal'  and TipoUsuarioId= @TipoUsuario_id
   end
  
   -- This is executed as long as the previous fetch succeeds.
   FETCH NEXT FROM _cursor
   INTO @TipoUsuario_id, @Descripcion;
END

CLOSE _cursor;
DEALLOCATE _cursor;
go
