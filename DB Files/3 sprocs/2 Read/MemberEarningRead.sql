create or alter proc MemberEarningRead(
    @MemberId int = 0,
    @ParshaId int,
    @EarningYearId int
)
as
begin
    if @MemberId = 0 or @ParshaId = 0 or @EarningYearId = 0
    begin 
        return
    end
    declare @t table (MemberEarningId int, MemberId int, ParshaId int, EarningYearId int, Amount int, EarnedDate datetime)
    
    insert into @t
    select MemberEarningId, MemberId, ParshaId, EarningYearId, Amount, EarnedDate
    from MemberEarning 
    where MemberId = @MemberId
    and ParshaId = @ParshaId
    and EarningYearId = @EarningYearId
    
    if not exists (select 1 from @t) 
    begin 
        insert MemberEarning (MemberId, ParshaId, EarningYearId)
        select @MemberId, @ParshaId, @EarningYearId

        declare @id int = scope_identity()

        insert @t
        select MemberEarningId, MemberId, ParshaId, EarningYearId, Amount, EarnedDate
        from MemberEarning 
        where MemberId = @MemberId
        and ParshaId = @ParshaId
        and EarningYearId = @EarningYearId
    end

    select MemberEarningId, MemberId, ParshaId, EarningYearId, Amount, EarnedDate
    from @t
end 
go