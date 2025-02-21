create or alter proc ParshaUpsert(
    @ParshaId int = 0 output,
    @ParshaName nvarchar(50),
    @ParshaNameEnglish nvarchar(50)
)
as
begin
    select @ParshaId = isnull(@ParshaId, 0)

    if @ParshaId = 0
    begin
        begin try
            insert Parsha(ParshaName, ParshaNameEnglish)
            select @ParshaName, @ParshaNameEnglish

            select @ParshaId = scope_identity();
        end try
        begin catch
            throw;
        end catch
    end
    else
    begin
        begin try
            update p 
            set 
                p.ParshaName = @ParshaName,
                p.ParshaNameEnglish = @ParshaNameEnglish 
            from Parsha p 
            where p.ParshaId = @ParshaId

            if @@rowcount = 0
                throw 50000, 'Update Failed: ParshaId not fount', 1;
        end try
        begin catch
            throw;
        end catch
    end
end