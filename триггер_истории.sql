--use KP_DataBase

drop trigger Users_History
create trigger Users_History
on Users
after update, insert  
as 
	begin
		DECLARE @oldWeight real
		SELECT @oldWeight  = (SELECT Weight FROM deleted)
		DECLARE @newWeight real
		SELECT @newWeight  = (SELECT Weight FROM inserted)
		DECLARE @id int
		SELECT @id  = (SELECT id_user FROM inserted)
	    IF @oldWeight != @newWeight 
		begin
		 INSERT INTO History(Date_of_Change, id_user, Weight ) VALUES( GETDATE(), @id, @newWeight)
		end
	end


drop trigger Users_History_Blood
go
create trigger Users_History_Blood
on Users
after update, insert  
as 
	begin
		DECLARE @oldBlood real
		SELECT @oldBlood  = (SELECT blood_sugar FROM deleted)
		DECLARE @newBlood real
		SELECT @newBlood  = (SELECT blood_sugar FROM inserted)
		DECLARE @id int
		SELECT @id  = (SELECT id_user FROM inserted)
	    IF @oldBlood != @newBlood 
		begin
		 INSERT INTO History_Blood_Sugar(Date_of_Change, id_user, blood_shugar ) VALUES( GETDATE(), @id, @newBlood)
		end
	end