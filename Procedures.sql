go
Create procedure dbo.GetTypeOfFoodById
	@id_type int
as 
	Select type_of_food From Type_of_Food Where id_type = @id_type

	Select SCOPE_IDENTITY()
go