use [Diabet.net]

create or alter procedure XmlToProduct
as begin
DECLARE @xml XML;

SELECT @xml = CONVERT(xml, BulkColumn, 2) FROM OPENROWSET(BULK 'C:\test\Export.xml', SINGLE_BLOB) AS x

INSERT INTO  Products(name_product, calorific_product, protein_product, fat_product, carbs_product)
SELECT 
	t.x.query('name_product').value('.', 'nvarchar(20)'),
	t.x.query('calorific_product').value('.', 'INT'),
	t.x.query('protein_product').value('.', 'real') ,
	t.x.query('fat_product').value('.', 'real'),
	t.x.query('carbs_product').value('.', 'real')
FROM @xml.nodes('//products/product') t(x)
end

select * from Products;
exec XmlToProduct;
-----
drop procedure XmlToProduct;



go
create or alter procedure ProductToXml
as
begin
	select name_product, calorific_product, protein_product, fat_product, carbs_product
	from Products
		for xml path('product'), root('products');

	exec master.dbo.sp_configure 'show advanced options', 1
		reconfigure with override
	exec master.dbo.sp_configure 'xp_cmdshell', 1
		reconfigure with override;

	declare @cmd nvarchar(255);
	select @cmd = 'bcp "use [Diabet.net]; select name_product, calorific_product, protein_product, fat_product, carbs_product from Products for xml path(''product''), root(''products'')" ' +
    'queryout "C:\test\Export.xml" -S .\SQLEXPRESS -T -w -r -t';
exec xp_cmdshell @cmd;
end; 

exec ProductToXml;

--drop procedure ProductToXml;

DELETE FROM Products_Awaiting_Approval
WHERE id_product > 1100;
