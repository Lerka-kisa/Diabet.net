--use KP_DataBase

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
