use master; 
create database [Diabet.net];

use [Diabet.net]

--drop table Users
create table Users
(
	id_user int  Identity (1,1) primary key,
	login  nvarchar(20) not null unique,
	password  nvarchar(100) not null,
	is_admin bit not null, --0-user, 1-admin
	First_Name nvarchar(20) not null,
	Last_Name nvarchar(20) not null,
	Height real ,
	Weight real,
	Daily_Calories smallint,
	Age int,
	Gender nvarchar(5), --0-M, 1-Ж,
	Activity float ,
	Purpose_of_Use smallint,
	blood_sugar real null
);
insert into  Users  ( login,   password, is_admin, First_Name, Last_Name )
	values	( 'Kisa', 'ccefd1bf9e84154d3f11b6745eb1cfe3', 1,'Админ', 'Админский' );

--drop table Products
create table Products(
	id_product int identity(1,1) primary key,
	name_product nvarchar(20) unique,
	calorific_product int,
	protein_product real,
	fat_product real, 
	carbs_product real
);

--drop table Recipe
create table Recipe(
	id_recipe int identity(1,1) primary key,
	name_recipe nvarchar(50) not null,
	calorific_recipe int,
	protein_recipe real,
	fat_recipe real, 
	carbs_recipe real,
	description nvarchar(500) null,
	screen_img varbinary(max) null
);

--drop table Prod_Rec
create table Prod_Rec
(
	id_recipe int foreign key (id_recipe) references Recipe(id_recipe),
	id_product int foreign key (id_product) references Products(id_product),
	weight_product smallint
);

--drop table Products_Awaiting_Approval
create table Products_Awaiting_Approval
(
	id_product int identity(1,1) primary key,
	name_product nvarchar(20),
	calorific_product int,
	protein_product real,
	fat_product real, 
	carbs_product real
);

--drop create table Type_of_Food
create table Type_of_Food
(
id_type int identity(1,1) primary key,
type_of_food nvarchar(20)
);
insert into Type_of_Food (type_of_food) values ('Завтрак'),('Обед'),('Ужин'), ('Перекус');

--drop create table Daily_Food
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

--drop table Daily_Cal_Water_Pill
create table Daily_Cal_Water_Pill
(
	id int identity(1,1) primary key,
	id_user int foreign key (id_user) references Users(id_user),
	daily_cal int,
	water real,
	pill real,
	now_date date default CONVERT (date, SYSDATETIME()) not null
)

--drop table Type_of_Insulin
create table Type_of_Insulin
(
id_type int identity(1,1) primary key,
type_of_Insulin nvarchar(40)
);
insert into Type_of_Insulin (type_of_insulin) values ('Дневной (быстрого действия)'),('Ночной (длительного действия)');

--drop create table Daily_Insulin
create table Daily_Insulin
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user), 
id_type_of_insulin int foreign key (id_type_of_insulin) references Type_of_Insulin(id_type),
now_date date default CONVERT (date, SYSDATETIME()) not null,
weight real not null
);

--drop create table History
create table History
(
	Date_of_Change datetime, 
	id_user int,
	Weight real
);

--drop create table History
create table History_Blood_Sugar
(
	Date_of_Change datetime, 
	id_user int,
	blood_shugar real
);
