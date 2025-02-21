create or alter proc EarningYearRead(
    @All bit = 0
)
as 
begin
    select EarningYearId, EarningYear
    from EarningYear
    where @All = 1
end
go