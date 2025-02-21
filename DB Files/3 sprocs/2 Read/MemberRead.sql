create or alter proc MemberRead(
    @MemberId int = 0,
    @All bit = 0
)
as 
begin 
    select MemberId, FirstName, LastName, SubTotal, BirthDate, AmountPaidUp, FinalTotal
    from Member
    where MemberId = @MemberId
    or @All = 1
    order by BirthDate
end 
go

GRANT EXECUTE ON MemberRead TO basicuserrole