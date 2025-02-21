create or alter proc EarningYearUpsert(
    @EarningYearId int = 0 output,
    @EarningYear int 
)
as
begin
    select @EarningYearId = isnull(@EarningYearId, 0)

    if @EarningYearId = 0
    begin
        begin try
            insert EarningYear(EarningYear)
            select @EarningYear

            select @EarningYearId = scope_identity();
        end try
        begin catch
            throw;
        end catch
    end
    else
    begin
        begin try
            update ey
            set 
                ey.EarningYear = @EarningYear
            from EarningYear ey
            where ey.EarningYearId = @EarningYearId

            if @@rowcount = 0
                throw 50000, 'Update Failed: EarningYearId not fount', 1;
        end try
        begin catch
            throw;
        end catch
    end
end