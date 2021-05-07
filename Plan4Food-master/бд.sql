use master; 
create database KP_DataBase;

use KP_DataBase

select * from Products_Awaiting_Approval
drop table Products_Awaiting_Approval
create table Products_Awaiting_Approval
(
id_product int identity(1,1) primary key,
name_product nvarchar(70),
calorific_product int,
protein_product real,
fat_product real, 
carbs_product real
);

Delete From Products_Awaiting_Approval Where name_product = @name_product and calorific_product = @calorific_product and protein_product = @protein_product and fat_product = @fat_product and carbs_product = @carbs_product

select id_user, login, First_Name, Last_Name, Height, Weight,Daily_Calories, Age, Gender, Activity,Purpose_of_Use From Users Where id_user=21  ;
alter table Users add Gender nvarchar(5)
alter table Users drop column The_Goals_Weight
select * from Users

delete from Users where  id_user = '20'-- and id_user = '15' and id_user = '16' and id_user = '17' and id_user = '18' and id_user = '19' and id_user = '20'
create table Users
(
id_user int  Identity (1,1) primary key,
login  nvarchar(20) not null unique,
password  nvarchar(100) not null,
is_admin bit not null, --0-user, 1-superuser
First_Name nvarchar(20) not null,
Last_Name nvarchar(20) not null,
Height real ,
Weight real,
The_Goals_Weight real,
Daily_Calories smallint,
Date_of_Birth date,
Gender bit, --0-male, 1-female,
Activity real ,
Purpose_of_Use smallint
);


create table History
(
Date_of_Change date, 
id_user int,
Weight real
);
 
 drop table Recipe

 alter table Products add name_product nvarchar(50)
alter table Products drop column name_product

create table Products
(
id_product int identity(1,1) primary key,
name_product nvarchar(20),
calorific_product int,
protein_product real,
fat_product real, 
carbs_product real
);

select * from Products 

Select name_product, calorific_product,protein_product,fat_product,carbs_product From Products

 alter table Recipe add description TEXT
alter table Recipe drop column name_recipe
select * from Recipe
create table Recipe
(
id_recipe int identity(1,1) primary key,
name_recipe nvarchar(20),
calorific_recipe int,
protein_recipe real,
fat_recipe real, 
carbs_recipe real
);

create table Prod_Rec
(
id_recipe int foreign key (id_recipe) references Recipe(id_recipe),
id_product int foreign key (id_product) references Products(id_product),
weight_product smallint
);

select * from Prod_Rec
select * from Recipe
create table Type_of_Food
(
id_type int identity(1,1) primary key,
type_of_food nvarchar(20)
);

 alter table Products add name_product nvarchar(50)
alter table Daily_Activity drop column now_date_time
select * from Daily_Food where id_user = 21 and id_type_of_food = 1 and now_date = CONVERT (date, SYSDATETIME()) 
select * from Daily_Food
select * from Daily_Cal
delete from Daily_Cal where id_user = 22
create table Daily_Cal
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user),
daily_cal int,
now_date date default CONVERT (date, SYSDATETIME()) not null
)
drop table Daily_Cal
select * from Daily_Food
delete from Daily_Food where id_user = 22
create table Daily_Food
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user), 
id_type_of_food int foreign key (id_type_of_food) references Type_of_Food(id_type),
now_date date default CONVERT (date, SYSDATETIME()) not null,
id_product int foreign key (id_product) references Products(id_product),
id_recipe int foreign key (id_recipe) references Recipe(id_recipe),
weight real not null
);

create table Daily_Water
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user), 
water real,
now_date date default CONVERT (date, SYSDATETIME()) not null,
)



insert into  Users  ( login,   password, is_admin, First_Name, Last_Name )
	values	( 'bigBOOS', 'adminadmin', 1,'Админ', 'Админский' );
	


