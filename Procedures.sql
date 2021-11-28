go

----DB_AddFood
Create procedure dbo.GetTypeOfFoodById
	@id_type int
as 
	Select type_of_food From Type_of_Food Where id_type = @id_type

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetRecipe
as 
	Select id_recipe, name_recipe, calorific_recipe,protein_recipe,fat_recipe,carbs_recipe, description, screen_img From Recipe

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetProduct
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products

	Select SCOPE_IDENTITY()
go
Create procedure dbo.AddProductInDailyFood
	@id_user int,
	@id_product int,
	@weight int, 
	@id_type_of_food int, 
	@now_date date
as 
	INSERT INTO Daily_Food (id_user, id_product, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_product,@weight, @id_type_of_food, @now_date)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.AddRecipeInDailyFood
	@id_user int,
	@id_recipe int,
	@weight int, 
	@id_type_of_food int, 
	@now_date date
as 
	INSERT INTO Daily_Food (id_user, id_recipe, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_recipe,@weight, @id_type_of_food, @now_date)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.AddIngred
	@id_recipe int, 
	@id_product int, 
	@weight_product int
as 
	INSERT INTO Prod_Rec ( id_recipe, id_product, weight_product) VALUES (@id_recipe, @id_product, @weight_product)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.AddRecipe
	@name_recipe nvarchar(50),
	@calorific_recipe int,
	@protein_recipe real, 
	@fat_recipe real, 
	@carbs_recipe real, 
	@description nvarchar(500), 
	@screen_img varbinary(max)
as 
	INSERT INTO Recipe (name_recipe, calorific_recipe, protein_recipe, fat_recipe, carbs_recipe, description, screen_img ) VALUES (@name_recipe,@calorific_recipe,@protein_recipe, @fat_recipe, @carbs_recipe, @description, @screen_img)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetSearchRecipe
	@search_TextBox nvarchar(50)
as 
	Select id_recipe, name_recipe, calorific_recipe,protein_recipe,fat_recipe,carbs_recipe, description, screen_img From Recipe Where name_recipe Like @search_TextBox

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetSearchProduct
	@search_TextBox nvarchar(50)
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products Where name_product Like @search_TextBox

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetIdRecipeByName
	@name_recipe nvarchar(50)
as 
	Select id_recipe From Recipe Where name_recipe = @name_recipe

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetIdProductByName
	@name_product nvarchar(20)
as 
	Select id_product From Products Where name_product = @name_product

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetCalProductByID
	@id_product int
as 
	Select calorific_product From Products Where id_product = @id_product

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetCalRecipeByID
	@id_recipe int
as 
	Select calorific_recipe From Recipe Where id_recipe = @id_recipe

	Select SCOPE_IDENTITY()
go

drop procedure dbo.GetTypeOfFoodById
drop procedure dbo.GetRecipe
drop procedure dbo.GetProduct
drop procedure dbo.AddProductInDailyFood
drop procedure dbo.AddRecipeInDailyFood
drop procedure dbo.AddIngred
drop procedure dbo.AddRecipe
drop procedure dbo.GetSearchRecipe
drop procedure dbo.GetSearchProduct
drop procedure dbo.GetIdRecipeByName
drop procedure dbo.GetIdProductByName
drop procedure dbo.GetCalProductByID
drop procedure dbo.GetCalRecipeByID

----DB_AddInsulin
Create procedure dbo.AddInsulin
	@id_user int,
	@weight int, 
	@id_type_of_insulin int, 
	@now_date date
as 
	INSERT INTO Daily_Insulin (id_user, weight, id_type_of_insulin, now_date ) VALUES (@id_user,@weight, @id_type_of_insulin, @now_date)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetInsulin
	@id_user int,
	@now_date date,
	@id_type_of_insulin int
as 
	Select sum(weight) insulin From Daily_Insulin Where id_user = @id_user and now_date=@now_date and id_type_of_insulin=@id_type_of_insulin

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetDateForInsulin
	@now_date date,
	@id_user int
as 
	Select id_user From Daily_Insulin Where now_date = @now_date and id_user = @id_user

	Select SCOPE_IDENTITY()
go

drop procedure dbo.AddInsulin
drop procedure dbo.GetInsulin
drop procedure dbo.GetDateForInsulin

---DB_NewFood
Create procedure dbo.AddProductInApproval
	@name_product nvarchar(20),
	@calorific_product int,
	@protein_product real, 
	@fat_product real, 
	@carbs_product real
as 
	INSERT INTO Products_Awaiting_Approval (name_product, calorific_product, protein_product, fat_product, carbs_product ) VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)

	Select SCOPE_IDENTITY()
go
Create procedure dbo.GetAllApproveProduct
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products_Awaiting_Approval

	Select SCOPE_IDENTITY()
go
Create procedure dbo.DeleteFromApproveProduct
	@name_product nvarchar(20),
	@calorific_product int,
	@protein_product real, 
	@fat_product real, 
	@carbs_product real
as 
	Delete From Products_Awaiting_Approval Where name_product = @name_product and calorific_product = @calorific_product and protein_product = @protein_product and fat_product = @fat_product and carbs_product = @carbs_product

	Select SCOPE_IDENTITY()
go
Create procedure dbo.AddProduct
	@name_product nvarchar(20),
	@calorific_product int,
	@protein_product real, 
	@fat_product real, 
	@carbs_product real
as 
	INSERT INTO Products (name_product, calorific_product, protein_product, fat_product, carbs_product ) VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)

	Select SCOPE_IDENTITY()
go

drop procedure dbo.AddProductInApproval
drop procedure dbo.GetAllApproveProduct
drop procedure dbo.DeleteFromApproveProduct
drop procedure dbo.AddProduct
