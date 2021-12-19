use [Diabet.net]
----DB_AddFood
go
Create or alter procedure dbo.GetTypeOfFoodById
	@id_type int
as 
	Select type_of_food From Type_of_Food Where id_type = @id_type

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetRecipe
as 
	Select id_recipe, name_recipe, calorific_recipe,protein_recipe,
			fat_recipe,carbs_recipe, description, screen_img From Recipe

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetProduct
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddProductInDailyFood
	@id_user int,
	@id_product int,
	@weight int, 
	@id_type_of_food int, 
	@now_date date
as 
	INSERT INTO Daily_Food (id_user, id_product, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_product,@weight, @id_type_of_food, @now_date)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddRecipeInDailyFood
	@id_user int,
	@id_recipe int,
	@weight int, 
	@id_type_of_food int, 
	@now_date date
as 
	INSERT INTO Daily_Food (id_user, id_recipe, weight, id_type_of_food, now_date ) VALUES (@id_user,@id_recipe,@weight, @id_type_of_food, @now_date)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddIngred
	@id_recipe int, 
	@id_product int, 
	@weight_product int
as 
	INSERT INTO Prod_Rec ( id_recipe, id_product, weight_product) VALUES (@id_recipe, @id_product, @weight_product)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddRecipe
	@name_recipe nvarchar(50),
	@calorific_recipe int,
	@protein_recipe real, 
	@fat_recipe real, 
	@carbs_recipe real, 
	@description nvarchar(500), 
	@screen_img varbinary(max)
as 
	INSERT INTO Recipe (name_recipe, calorific_recipe, protein_recipe, fat_recipe, carbs_recipe, description, screen_img ) 
	VALUES (@name_recipe,@calorific_recipe,@protein_recipe, @fat_recipe, @carbs_recipe, @description, @screen_img)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetSearchRecipe
	@search_TextBox nvarchar(50)
as 
	Select id_recipe, name_recipe, calorific_recipe,protein_recipe,fat_recipe,carbs_recipe, description, screen_img From Recipe Where name_recipe Like @search_TextBox

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetSearchProduct
	@search_TextBox nvarchar(50)
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products Where name_product Like @search_TextBox

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetIdRecipeByName
	@name_recipe nvarchar(50)
as 
	Select id_recipe From Recipe Where name_recipe = @name_recipe

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetIdProductByName
	@name_product nvarchar(20)
as 
	Select id_product From Products Where name_product = @name_product

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetCalProductByID
	@id_product int
as 
	Select calorific_product From Products Where id_product = @id_product

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetCalRecipeByID
	@id_recipe int
as 
	Select calorific_recipe From Recipe Where id_recipe = @id_recipe

	Select SCOPE_IDENTITY()
go
---Dropping---
/*
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
*/

use [Diabet.net]
----DB_AddInsulin
go
Create or alter procedure dbo.AddInsulin
	@id_user int,
	@weight int, 
	@id_type_of_insulin int, 
	@now_date date
as 
	INSERT INTO Daily_Insulin (id_user, weight, id_type_of_insulin, now_date ) VALUES (@id_user,@weight, @id_type_of_insulin, @now_date)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetInsulin
	@id_user int,
	@now_date date,
	@id_type_of_insulin int
as 
	Select sum(weight) insulin From Daily_Insulin Where id_user = @id_user and now_date=@now_date and id_type_of_insulin=@id_type_of_insulin

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDateForInsulin
	@now_date date,
	@id_user int
as 
	Select id_user From Daily_Insulin Where now_date = @now_date and id_user = @id_user

	Select SCOPE_IDENTITY()
go
---Dropping---
/*
drop procedure dbo.AddInsulin
drop procedure dbo.GetInsulin
drop procedure dbo.GetDateForInsulin
*/

use [Diabet.net]
---DB_NewFood
go
Create or alter procedure dbo.AddProductInApproval
	@name_product nvarchar(20),
	@calorific_product int,
	@protein_product real, 
	@fat_product real, 
	@carbs_product real
as 
	INSERT INTO Products_Awaiting_Approval (name_product, calorific_product, protein_product, fat_product, carbs_product ) 
	VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetAllApproveProduct
as 
	Select id_product, name_product, calorific_product,protein_product,fat_product,carbs_product From Products_Awaiting_Approval

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.DeleteFromApproveProduct
	@id int
as 
	Delete From Products_Awaiting_Approval Where id_product = @id

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.ApprovalProduct
	@id int
as 
	INSERT INTO Products (name_product, calorific_product, protein_product, fat_product, carbs_product ) 
		SELECT name_product, calorific_product, protein_product, fat_product, carbs_product FROM Products_Awaiting_Approval WHERE id_product = @id
		
	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddProductInProduct
	@name_product nvarchar(20),
	@calorific_product int,
	@protein_product real, 
	@fat_product real, 
	@carbs_product real
as 
	INSERT INTO Products(name_product, calorific_product, protein_product, fat_product, carbs_product ) VALUES (@name_product,@calorific_product,@protein_product, @fat_product, @carbs_product)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.DeleteProduct
	@id int
as 
	Delete From Products Where id_product = @id

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.DeleteRecipe
	@id int
as 
	begin tran;
	begin try
	  Delete From Prod_Rec Where id_recipe = @id
	Delete From Recipe Where id_recipe = @id
	commit;
	end try
	begin catch
	  rollback;
	end catch
	select count(*) [count] from Recipe where id_recipe = @id

	Select SCOPE_IDENTITY()
go
---Dropping---
/*
drop procedure dbo.AddProductInApproval
drop procedure dbo.GetAllApproveProduct
drop procedure dbo.DeleteFromApproveProduct
drop procedure dbo.AddProduct
drop procedure dbo.AddProductInProduct
drop procedure dbo.DeleteProduct
drop procedure dbo.DeleteRecipe
*/

use [Diabet.net]
----DataBaseUser
go
Create or alter procedure dbo.GiveUserByLoginAndPassword
	@login nvarchar(20),
	@password nvarchar(100)
as 
	Select count(*) From Users Where login = @login and password = @password

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetIsAdminUser
	@id_user int
as 
	Select is_admin From Users Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetInfoFromHistory
	@id_user int, 
	@type bit
as 
if (@type = 1)
	begin
		WITH SRC AS (SELECT TOP (10) Date_of_Change, Weight
		FROM History Where id_user = @id_user Order by Date_of_Change desc)
		SELECT Weight FROM SRC ORDER BY Date_of_Change
	end
else
	begin
		WITH SRC AS (SELECT TOP (10) Date_of_Change, blood_shugar
		FROM History_Blood_Sugar Where id_user = @id_user Order by Date_of_Change desc)
		SELECT blood_shugar FROM SRC ORDER BY Date_of_Change
	end

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDateFromHistory
	@id_user int,
	@type bit
as 
	if(@type = 1)
		begin
			WITH SRC AS (SELECT TOP (10) Date_of_Change, Weight
			FROM History Where id_user = @id_user Order by Date_of_Change desc)
			SELECT Date_of_Change FROM SRC ORDER BY Date_of_Change 
		end
	else
		begin
			WITH SRC AS (SELECT TOP (10) Date_of_Change, blood_shugar
			FROM History_Blood_Sugar Where id_user = @id_user Order by Date_of_Change desc)
			SELECT Date_of_Change FROM SRC ORDER BY Date_of_Change
		end

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddUser
	@login nvarchar(20),
	@password nvarchar(100),
	@is_admin bit,
	@First_Name nvarchar(20),
	@Last_Name nvarchar(20),  
	@Height real, 
	@Weight real, 
	@Daily_Calories smallint, 
	@Age int, 
	@Gender nvarchar(5), 
	@Activity float, 
	@Purpose_of_Use smallint, 
	@Sugar real
as 
	INSERT INTO Users (login, password, is_admin, First_Name, Last_Name,  Height, Weight, Daily_Calories,  Age, Gender, Activity, Purpose_of_Use, blood_sugar) 
		VALUES (@login,@password,@is_admin,@First_Name,@Last_Name,  @Height, @Weight, @Daily_Calories, @Age, @Gender, @Activity, @Purpose_of_Use, @Sugar)
	
	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetIdUserByLogin
	@login nvarchar(20)
as 
	Select id_user From Users Where login = @login

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetUserInfo
	@id_user int
as 
	Select  login, First_Name, Last_Name, Height, Weight, Daily_Calories, Age, Gender, Activity, Purpose_of_Use From Users Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetSugar
	@id_user int
as 
	Select blood_sugar From Users Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateAgeUser
	@id_user int,
	@age int
as 
	Update Users Set Age = @age Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateMassUser
	@id_user int,
	@weight real
as 
	Update Users Set Weight = @weight Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdatePurposeUser
	@id_user int,
	@Purpose_of_Use smallint
as 
	Update Users Set Purpose_of_Use = @Purpose_of_Use Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateSugarUser
	@id_user int,
	@blood_sugar real
as 
	Update Users Set blood_sugar = @blood_sugar Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateDailyCalUser
	@id_user int,
	@daily_cal smallint
as 
	Update Users Set Daily_Calories = @daily_cal Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
--Dropping---
/*
drop procedure dbo.GiveUserByLoginAndPassword
drop procedure dbo.GetIsAdminUser
drop procedure dbo.GetInfoFromHistory
drop procedure dbo.GetDateFromHistory
drop procedure dbo.AddUser
drop procedure dbo.GetIdUserByLogin
drop procedure dbo.GetUserInfo
drop procedure dbo.GetSugar
drop procedure dbo.UpdateAgeUser
drop procedure dbo.UpdateMassUser
drop procedure dbo.UpdatePurposeUser
drop procedure dbo.UpdateSugarUser
drop procedure dbo.UpdateDailyCalUser
*/

use [Diabet.net]
--------DB_Main
go
Create or alter procedure dbo.GetDateForWater
	@id_user int,
	@now_date date
as 
	Select water From Daily_Cal_Water_Pill Where now_date = @now_date and id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetWater
	@id_user int,
	@now_date date
as 
	Select water From Daily_Cal_Water_Pill Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateWater
	@id_user int,
	@water real,
	@now_date date
as 
	Update Daily_Cal_Water_Pill Set water = @water Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDateForPill
	@id_user int,
	@now_date date
as 
	Select pill From Daily_Cal_Water_Pill Where now_date = @now_date and id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetPill
	@id_user int,
	@now_date date
as 
	Select pill From Daily_Cal_Water_Pill Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdatePill
	@id_user int,
	@pill real,
	@now_date date
as 
	Update Daily_Cal_Water_Pill Set pill = @pill Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDailyCalInTableUser
	@id_user int
as 
	Select Daily_Calories From Users Where id_user = @id_user

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDateForDailyCal
	@id_user int,
	@now_date date
as 
	Select id_user From Daily_Cal_Water_Pill Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetDailyCal
	@id_user int,
	@now_date date
as 
	Select daily_cal From Daily_Cal_Water_Pill Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.AddDailyCal
	@id_user int,
	@daily_cal int
as 
	INSERT INTO Daily_Cal_Water_Pill (id_user, daily_cal ) VALUES (@id_user, @daily_cal)

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.UpdateDailyCal
	@id_user int,
	@daily_cal int,
	@now_date date
as 
	Update Daily_Cal_Water_Pill Set daily_cal = @daily_cal Where id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetNameFoodByIdType
	@id_user int,
	@id_type_of_food int,
	@now_date date
as 
	Select id_product, id_recipe, weight From Daily_Food Where id_type_of_food = @id_type_of_food and id_user = @id_user and now_date = @now_date

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetNameProductById
	@id_product int
as 
	Select name_product From Products Where id_product = @id_product

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetNameRecipeById
	@id_recipe int
as 
	Select name_recipe From Recipe Where id_recipe = @id_recipe

	Select SCOPE_IDENTITY()
go
Create or alter procedure dbo.GetIngtedients
	@id_recipe int
as 
	Select id_product, weight_product From Prod_Rec Where id_recipe = @id_recipe

	Select SCOPE_IDENTITY()
go
---Dropping---
/*
drop procedure dbo.GetDateForWater
drop procedure dbo.GetWater
drop procedure dbo.UpdateWater
drop procedure dbo.GetDateForPill
drop procedure dbo.GetPill
drop procedure dbo.UpdatePill
drop procedure dbo.GetDailyCalInTableUser
drop procedure dbo.GetDateForDailyCal
drop procedure dbo.GetDailyCal
drop procedure dbo.AddDailyCal
drop procedure dbo.UpdateDailyCal
drop procedure dbo.GetNameFoodByIdType
drop procedure dbo.GetNameProductById
drop procedure dbo.GetNameRecipeById
drop procedure dbo.GetIngtedients
*/
----------

