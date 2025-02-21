CREATE PROCEDURE ParshaDelete(
    @ParshaId INT = 0
)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY        
        DELETE Parsha WHERE ParshaId = @ParshaId        
        COMMIT TRANSACTION;    
    END TRY    
    BEGIN CATCH        
        ROLLBACK TRANSACTION;        
        THROW;    
    END CATCH
END
GO