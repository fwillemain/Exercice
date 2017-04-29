-- 1. Trouver la requ�te permettant de s'assurer qu'une fonction existe avant de la supprimer 
drop procedure usp_TestAndDropRoutine
go

-- Am�liorer pour g�rer Proc et Func
create procedure usp_TestAndDropRoutine @Func varchar(20), @Schema varchar(20) = 'dbo'
as
begin
	declare @TypeRoutine varchar(20)
	if exists(select 1
			from INFORMATION_SCHEMA.ROUTINES
			where Specific_schema = @Schema
				and specific_name = @Func
				--and Routine_Type = 'FUNCTION'
				)
	begin
		select @TypeRoutine = Routine_Type from INFORMATION_SCHEMA.ROUTINES
			where Specific_schema = @Schema
				and specific_name = @Func
		declare @SQL nvarchar(max)
		set @SQL = 'Drop ' + @TypeRoutine + ' ' + @Schema + '.' + @Func
		print @SQL
		exec sp_Executesql @SQL
	end
end					
go

-- 2.Idem pour une vue 
drop procedure usp_TestAndDropView
go

create procedure usp_TestAndDropView @Vue varchar(20)
as
begin
	if exists(select 1
			from INFORMATION_SCHEMA.VIEWS
			where TABLE_NAME = @Vue)
	begin
		declare @SQL nvarchar(max) 
		set @SQL = 'Drop view ' + @Vue
		print @SQL
		exec sp_Executesql @SQL
	end
end	
go
	
-- 3. Idem pour une tables 
drop procedure usp_TestAndDropTable
go

create procedure usp_TestAndDropTable @Table varchar(20)
as
begin
	if exists(select 1
				from INFORMATION_SCHEMA.TABLES
				where TABLE_NAME = @Table)
	begin
		declare @req nvarchar(max)
		set @req = 'Drop table ' + @Table
		
		print @req + ' ' + @Table
		exec sp_Executesql @req
	end
end
go

-- 4. Idem pour une contrainte de cl� �trang�re (foreign key) 
drop procedure usp_TestAndDropFK
go

create procedure usp_TestAndDropFK @FKey varchar(20), @TableFKey varchar(20)
as
begin
	if exists(select 1
			from INFORMATION_SCHEMA.KEY_COLUMN_USAGE
			where CONSTRAINT_NAME = @FKey and TABLE_NAME = @TableFKey)	
	begin
			declare @SQL nvarchar(max) 
			set @SQL = 'Alter table ' + @TableFKey + ' drop constraint ' + @FKey
			print @SQL
			exec sp_Executesql @SQL
	end
end
go			

-- 5. Dans un des scripts sql g�n�r� par Data Modeler (ex : LieuxAnimaux ou autre), 
-- ajouter les requ�tes pr�c�dentes pour la suppression des diff�rents objets de la base
-- Tester le script en l'ex�cutant 2 fois de suite dans SSMS

begin tran
exec usp_TestAndDropRoutine 'ufn_MinDate'

exec sp_Executesql

rollback
go

begin tran
exec usp_TestAndDropTable 'Order_Details'
rollback
go

begin tran
create table toto (
Id int)



-- 6. Faire une proc�dure qui prend en param�tre le nom d'une table et qui supprime les liens
-- vers cette table (c�est-�-dire les contraintes de cl�s �trang�res r�f�ren�ant cette table),
-- puis qui supprime la table elle-m�me. 
-- Faire un test sur l'une des bases vides g�n�r�es � partir d'un script Data Modeler 
drop procedure usp_TestAndDropTableAndFK
go

create procedure usp_TestAndDropTableAndFK @Table nvarchar(20)
as
begin
	-- Si la table existe bien
	if exists(select 1
				from INFORMATION_SCHEMA.TABLES
				where TABLE_NAME = @Table)
	begin
		declare @SQL nvarchar(max) = '' 
		-- Pour chaque FK de ma table, je rajoute le drop de cette derni�re dans la variable @SQL
		select @SQL = @SQL + 'Alter table ' + @Table + ' drop constraint ' + CONSTRAINT_NAME + CHAR(13)
		from INFORMATION_SCHEMA.TABLE_CONSTRAINTS
				where TABLE_NAME = @Table and CONSTRAINT_TYPE = 'FOREIGN KEY'
		
		-- J'affiche la requete puis l'execute
		print @SQL
		exec sp_Executesql @SQL
	
		declare @req nvarchar(max)
		set @req = 'Drop table dbo.' + @Table
		
		-- J'affiche le drop de ma table et l'execute
		print @req
		exec sp_Executesql @req
	end
end

begin tran
exec usp_TestAndDropTableAndFK 'Order_Details'
rollback

select * from Order_Details

-- 7. Dans un script g�n�r� par DataModeler, ajouter cette proc�dure
-- et l'ex�cuter avant la cr�ation des contraintes et tables
-- Tester le script en l'ex�cutant 2 fois de suite dans SSMS
