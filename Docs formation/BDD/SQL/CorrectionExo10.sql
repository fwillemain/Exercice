-- 1. Créer une procédure usp_UpdateEmployeeTerritory, permettant de modifier l'id du territoire
-- dans la table EmployeeTerritories pour un couple EmployeeId, TerritoryId donné
drop procedure usp_UpdateEmployeeTerritory
go
create procedure usp_UpdateEmployeeTerritory 
	@employeeId int, @territoryId nvarchar(20), @newTerritoryId nvarchar(20)
as
begin
	update EmployeeTerritories
	set TerritoryID = @newTerritoryId
	where EmployeeID = @employeeId and TerritoryID = @territoryId
end
go

select * from EmployeeTerritories

-- 2. Tenter d'affecter le territoire '01730' à la place du '01581' pour l'employé 2
-- Intercepter spécifiquement l'erreur remontée en affichant un message indiquant
-- clairement la cause de l'erreur
begin try
exec usp_UpdateEmployeeTerritory 2, '01581', '01730'
end try
begin catch
	if ERROR_NUMBER() = 2627
		print 'Ce territoire est déjà affecté à cette personne !'
	--else
	--THROW
end catch

-- 3. Exécuter ce nouveau code en tantant d'affecter un territoire inconnu
-- à la place du '01581' pour l'employé 2
-- Vérifier qu'une erreur différente de la précédente s'affiche
begin try
exec usp_UpdateEmployeeTerritory 2, '01581', '00'
print 'Après exécution de usp_UpdateEmployeeTerritory' -- Pas exécuté si erreur avant
end try
begin catch
	if ERROR_NUMBER() = 547
		print 'Ce territoire est déjà affecté à cette personne !'
	--else
	--THROW
end catch

-- 4. Modifier la procédure afin qu'elle génère elle-même des erreurs
-- avec des numéros spécifiques et des messages explicites
-- dans les deux cas rencontrés précédemment
exec sp_addmessage @msgnum = 50001, @severity = 12,
	@msgText = 'This territory is already set to this employee',
	@lang='us_english',
	@replace = 'replace'

exec sp_addmessage @msgnum = 50001, @severity = 12,
	@msgText = 'Ce territoire est déjà affecté à ce salarié',
	@lang='French',
	@replace = 'replace'

exec sp_addmessage @msgnum = 50002, @severity = 12,
	@msgText = 'This territory does not exist', @lang='us_english'

exec sp_addmessage @msgnum = 50002, @severity = 12,
	@msgText = 'Ce territoire n''existe pas', @lang='french'

drop procedure usp_UpdateEmployeeTerritory
go
create procedure usp_UpdateEmployeeTerritory 
	@employeeId int, @territoryId nvarchar(20), @newTerritoryId nvarchar(20)
as
begin
	if (select count(*) from EmployeeTerritories
		where EmployeeID = @employeeId and TerritoryID = @newTerritoryId) > 0
	begin
		RAISERROR(50001, 12, 1)
		return
	end

	if not exists(select * from Territories where TerritoryID = @newTerritoryId)
	begin
		RAISERROR(50002, 12, 1)
		return
	end

	update EmployeeTerritories
	set TerritoryID = @newTerritoryId
	where EmployeeID = @employeeId and TerritoryID = @territoryId
end
go

-- 5. Tester de nouveau les deux cas précédents et vérifier que les erreurs 
-- s'affichent correctement
exec usp_UpdateEmployeeTerritory 2, '01581', '01730'
exec usp_UpdateEmployeeTerritory 2, '01581', '00'
