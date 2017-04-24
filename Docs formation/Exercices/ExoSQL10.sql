-- 1. Cr�er une proc�dure usp_UpdateEmployeeTerritory, permettant de modifier l'id du territoire
-- dans la table EmployeeTerritories pour un couple EmployeeId, TerritoryId donn�
drop procedure usp_UpdateEmployeeTerritory
go

create procedure usp_UpdateEmployeeTerritory @EmployeeId int, @TerritoryId nvarchar(20), @NTerritoryId nvarchar(20)
as
begin
	update EmployeeTerritories set TerritoryID = @NTerritoryId
	where EmployeeID = @EmployeeId and TerritoryID = @TerritoryId
end
go

-- 2. Tenter d'affecter le territoire '01730' � la place du '01581' pour l'employ� 2
-- Intercepter sp�cifiquement l'erreur remont�e en affichant un message indiquant
-- clairement la cause de l'erreur

begin tran
begin try
	exec usp_UpdateEmployeeTerritory 2, '01581', '01730'
end try
begin catch
	if ERROR_NUMBER() = 2627
		print 'Erreur sur la proc�dure usp_UpdateEmployeeTerritory : ' + ERROR_MESSAGE()
end catch

rollback


-- 3. Ex�cuter ce nouveau code en tantant d'affecter un territoire inconnu
-- � la place du '01581' pour l'employ� 2
-- V�rifier qu'une erreur diff�rente de la pr�c�dente s'affiche
exec usp_UpdateEmployeeTerritory 2, '01581', '00110'


-- 4. Modifier la proc�dure afin qu'elle g�n�re elle-m�me des erreurs
-- avec des num�ros sp�cifiques et des messages explicites
-- dans les deux cas rencontr�s pr�c�demment

exec sp_addmessage @msgnum = 50010, @severity = 16, @msgtext = 'Le territoire sp�cifi� est d�j� li� � cet employ�',
						@lang = us_english

exec sp_addmessage @msgnum = 50011, @severity = 16, @msgtext = 'Le nouveau territoire n''existe pas',
						@lang = us_english
go

drop procedure usp_UpdateEmployeeTerritory2
go

create procedure usp_UpdateEmployeeTerritory2 @EmployeeId int, @TerritoryId nvarchar(20), @NTerritoryId nvarchar(20)
as
begin
	-- Si le territoire d'ID @NTerritoryId est d�j� li� � @EmployeeId, lever une erreur 50010
	if exists (select * from EmployeeTerritories where EmployeeID = @EmployeeId and TerritoryID = @NTerritoryId)
	begin
		RAISERROR(50010, 16, 1)
		return 
	end
	
	-- Si le territoire d'ID @NTerritoryId n'existe pas (donc n'est pas pr�sent dans Territories, lever une erreur 50011
	if not exists(select * from Territories where TerritoryID = @NTerritoryId)
	begin
		RAISERROR(50011, 16, 1)
		return
	end
	
	update EmployeeTerritories set TerritoryID = @NTerritoryId
	where EmployeeID = @EmployeeId and TerritoryID = @TerritoryId
end
go

-- 5. Tester de nouveau les deux cas pr�c�dents et v�rifier que les erreurs 
-- s'affichent correctement

exec usp_UpdateEmployeeTerritory2 2, '01581', '01730'

exec usp_UpdateEmployeeTerritory2 2, '01581', '00110'