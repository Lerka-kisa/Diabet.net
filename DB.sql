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
Select count(*) From Users Where login = 'Lerka' and password = '5442488l';

drop table Users
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
Daily_Calories smallint,
Age int,
Gender nvarchar(5), --0-male, 1-female,
Activity float ,
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
alter table Users add blood_sugar real null
alter table Users add notifications bit
alter table Products drop column name_product

create table Products(
	id_product int identity(1,1) primary key,
	name_product nvarchar(20) unique,
	calorific_product int,
	protein_product real,
	fat_product real, 
	carbs_product real
);

ALTER TABLE Products
ADD UNIQUE (name_product);
alter table Products 
	alter column name_product nvarchar(20) not null 
select * from Products 

Select name_product, calorific_product,protein_product,fat_product,carbs_product From Products

alter table Recipe add description nvarchar(500) null
alter table Recipe drop column description

select * from Recipe
create table Recipe(
	id_recipe int identity(1,1) primary key,
	name_recipe nvarchar(50),
	calorific_recipe int,
	protein_recipe real,
	fat_recipe real, 
	carbs_recipe real,
	description nvarchar(500) NULL,
	screen_img varbinary(max) NULL
);
drop table Recipe
alter table Recipe 
	add screen_img varbinary(max) NULL

drop table Prod_Rec
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
insert into Type_of_Food (type_of_food) values ('Завтрак'),('Обед'),('Ужин'), ('Перекус');

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

select * from Daily_Food
delete from Daily_Food where id_user = 22

drop table Daily_Cal
drop table Daily_Food
drop table Daily_Water

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

create table Daily_Pill
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user), 
pill real,
now_date date default CONVERT (date, SYSDATETIME()) not null,
)

drop table Type_of_Insulin
create table Type_of_Insulin
(
id_type int identity(1,1) primary key,
type_of_Insulin nvarchar(40)
);
insert into Type_of_Insulin (type_of_insulin) values ('Дневной (быстрого действия)'),('Ночной (длительного действия)');

create table Daily_Insulin
(
id int identity(1,1) primary key,
id_user int foreign key (id_user) references Users(id_user), 
id_type_of_insulin int foreign key (id_type_of_insulin) references Type_of_Insulin(id_type),
now_date date default CONVERT (date, SYSDATETIME()) not null,
weight real not null
);

Select sum (weight) insulin From Daily_Insulin Where id_user = 3 and now_date='12.05.2021' and id_type_of_insulin=1

alter table History_Blood_Sugar drop column Date_of_Change
alter table History_Blood_Sugar add Date_of_Change datetime
drop table History_Blood_Sugar
create table History_Blood_Sugar
(
Date_of_Change datetime, 
id_user int,
blood_shugar real
);



insert into  Users  ( login,   password, is_admin, First_Name, Last_Name )
	values	( 'Lerka', '5442488l', 1,'Админ', 'Админский' );
	
select count(*) count_product from Products_Awaiting_Approval


Select* From History_Blood_Sugar Where id_user = 3 Order by Date_of_Change;
Select* From History Where id_user = 3 Order by Date_of_Change;