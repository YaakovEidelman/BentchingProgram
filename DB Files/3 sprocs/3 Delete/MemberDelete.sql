CREATE PROCEDURE MemberDelete(
    @MemberId INT = 0
)
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY        
        DELETE Member WHERE MemberId = @MemberId        
        COMMIT TRANSACTION;    
    END TRY    
    BEGIN CATCH        
        ROLLBACK TRANSACTION;        
        THROW;    
    END CATCH
END
GO