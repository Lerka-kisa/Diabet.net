USE master

CREATE LOGIN [User] WITH PASSWORD = 'User', DEFAULT_DATABASE = [Diabet.net];
CREATE LOGIN [Admin] WITH PASSWORD = 'Admin', DEFAULT_DATABASE = [Diabet.net];
CREATE LOGIN [Unauthuser] WITH PASSWORD = 'Unauthuser', DEFAULT_DATABASE = [Diabet.net];

USE [Diabet.net]    
CREATE USER [User] FOR LOGIN [User]   
    WITH DEFAULT_SCHEMA = dbo;  

CREATE USER [Admin] FOR LOGIN [Admin]   
    WITH DEFAULT_SCHEMA = dbo; 

CREATE USER [Unauthuser] FOR LOGIN [Unauthuser]   
    WITH DEFAULT_SCHEMA = dbo;

CREATE ROLE User_role AUTHORIZATION [User];
CREATE ROLE Admin_role AUTHORIZATION [Admin];
CREATE ROLE Unauthuser_role AUTHORIZATION [Unauthuser];

--User
GRANT SELECT ON DATABASE::[Diabet.net] TO  User_role;
GRANT INSERT ON DATABASE::[Diabet.net] TO  User_role;
GRANT UPDATE ON OBJECT::Daily_Cal_Water_Pill TO  User_role;
GRANT UPDATE ON OBJECT::Daily_Food TO  User_role;
GRANT UPDATE ON OBJECT::Daily_Insulin TO  User_role;
GRANT UPDATE ON OBJECT::Users TO  User_role;

GRANT EXECUTE ON OBJECT::[dbo].[AddDailyCal] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddInsulin] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddPill] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddProductInApproval] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddProductInDailyFood] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddRecipeInDailyFood] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddWater] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetCalProductByID] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetCalRecipeByID] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDailyCal] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDailyCalInTableUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDateForDailyCal] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDateForInsulin] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDateForPill] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDateForWater] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetDateFromHistory] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdProductByName] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdRecipeByName] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdUserByLogin] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetInfoFromHistory] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIngtedients] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetInsulin] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIsAdminUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameFoodByIdType] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameProductById] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameRecipeById] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetPill] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetProduct] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetRecipe] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetSearchProduct] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetSearchRecipe] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetSugar] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetTypeOfFoodById] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetUserInfo] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetWater] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[GiveUserByLoginAndPassword] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateAgeUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateDailyCal] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateDailyCalUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateMassUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdatePill] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdatePurposeUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateSugarUser] TO User_role;
GRANT EXECUTE ON OBJECT::[dbo].[UpdateWater] TO User_role;

--Admin
GRANT SELECT ON DATABASE::[Diabet.net] TO  Admin_role;
GRANT INSERT ON DATABASE::[Diabet.net] TO  Admin_role;
GRANT UPDATE ON OBJECT::[dbo].[Prod_Rec] TO Admin_role;
GRANT UPDATE ON OBJECT::[dbo].[Products] TO Admin_role;
GRANT UPDATE ON OBJECT::[dbo].[Recipe] TO Admin_role;
GRANT UPDATE ON OBJECT::[dbo].[Products_Awaiting_Approval] TO Admin_role;

GRANT EXECUTE ON OBJECT::[dbo].[AddIngred] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddProductInProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddRecipe] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[ApprovalProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[DeleteFromApproveProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[DeleteProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[DeleteRecipe] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetAllApproveProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetCalProductByID] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetCalRecipeByID] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdProductByName] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdRecipeByName] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdUserByLogin] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIngtedients] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIsAdminUser] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameFoodByIdType] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameProductById] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetNameRecipeById] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetRecipe] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetSearchProduct] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetSearchRecipe] TO Admin_role;
GRANT EXECUTE ON OBJECT::[dbo].[GiveUserByLoginAndPassword] TO Admin_role;

--Unauthuser
GRANT SELECT ON OBJECT::Users TO  Unauthuser_role;
GRANT INSERT ON OBJECT::Users TO  Unauthuser_role;

GRANT EXECUTE ON OBJECT::[dbo].[GiveUserByLoginAndPassword] TO Unauthuser_role;
GRANT EXECUTE ON OBJECT::[dbo].[AddUser] TO Unauthuser_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIdUserByLogin] TO Unauthuser_role;
GRANT EXECUTE ON OBJECT::[dbo].[GetIsAdminUser] TO Unauthuser_role;




