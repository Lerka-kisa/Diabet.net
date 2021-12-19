use [Diabet.net]

go
Create Procedure CreateRandomWord
@size integer,
	@Name char(50) OUTPUT
AS
Begin
	SET @Name = (
	SELECT
		c1 AS [text()]
	FROM
		(
		SELECT TOP (@size) c1
		FROM
		  (
		VALUES
		  ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H'), ('I'), ('J'),
		  ('K'), ('L'), ('M'), ('N'), ('O'), ('P'), ('Q'), ('R'), ('S'), ('T'),
		  ('U'), ('V'), ('W'), ('X'), ('Y'), ('Z')
		  ) AS T1(c1)
		ORDER BY ABS(CHECKSUM(NEWID()))
		) AS T2
	FOR XML PATH('')
	);
End;
go

Create Procedure InsertAppProd AS
Begin

DECLARE @NUMBER int, @Random_Name nvarchar(20),
		@Random_Cal int, @Random_Protein real,
		@Random_Fat real, @Random_Carb real,
		@set_prod nvarchar(20);

SET @number = 1;

While @number <= 577000
	BEGIN
		exec CreateRandomWord 4, @Random_Name OUTPUT;
		set @Random_Cal = floor(1000*RAND());
		set @Random_Protein =  floor(300.0*RAND());
		set @Random_Fat =  floor(300.0*RAND());
		set @Random_Carb =  floor(300.0*RAND());
		set @set_prod = (select name_product from Products_Awaiting_Approval where name_product = @Random_Name);

		insert into Products_Awaiting_Approval(name_product, calorific_product, protein_product, fat_product, carbs_product) 
		values (@Random_Name, @Random_Cal, @Random_Protein, @Random_Fat, @Random_Carb);
		SET @number = @number + 1;
	END;
End;

exec InsertAppProd;

drop procedure InsertAppProd;

select * from Products_Awaiting_Approval;


go
create procedure AddApprovalMln
as
begin
	set nocount on;
	Declare @i int =0, @p real = 0;
	while @i<=500000
	begin
		insert Products_Awaiting_Approval ( name_product, calorific_product, protein_product, fat_product, carbs_product ) values (@i, 33, @p, @p, @p );
		set @i=@i+1; set @p = @p+0.001;
	end;
	
end

exec AddApprovalMln
--drop procedure AddApprovalMln
select * from Products_Awaiting_Approval;
select * from Products

