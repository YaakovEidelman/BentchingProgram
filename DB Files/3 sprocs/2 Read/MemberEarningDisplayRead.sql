create or alter proc MemberEarningDisplayRead(
    @MemberId int = 0
)
as
begin 
    select me.MemberEarningId, m.MemberId, m.FirstName, p.ParshaId, p.ParshaName, p.ParshaNameEnglish, ey.EarningYearId, ey.EarningYear, me.Amount, me.EarnedDate
    from MemberEarning me 
    join Member m 
    on m.MemberId = me.MemberId
    join Parsha p 
    on p.ParshaId = me.ParshaId
    join EarningYear ey 
    on ey.EarningYearId = me.EarningYearId
    -- select MemberEarningId, MemberId, ParshaId, EarningYearId, Amount, EarnedDate
    -- from MemberEarning
    where me.MemberId = @MemberId
    order by ey.EarningYear desc, p.ParshaId desc
end 
go
--exec MemberEarningRead @MemberId = 1
