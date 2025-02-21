CREATE OR ALTER PROCEDURE EarningYearDelete(
    @EarningYearId INT = 0
)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY        
        DELETE EarningYear WHERE EarningYearId = @EarningYearId        
    COMMIT TRANSACTION;    
    END TRY    
    BEGIN CATCH        
        ROLLBACK TRANSACTION;        
        THROW;    
    END CATCH
END
GO

GRANT EXECUTE ON EarningYearDelete TO basicuserrole