create or alter proc MemberUpsert(
    @MemberId int = 0 output,
    @FirstName varchar(30),
    @LastName varchar(20),
    @BirthDate date,
    @AmountPaidUp int = 0
)
as
begin
    select @MemberId = isnull(@MemberId, 0), @AmountPaidUp = isnull(@AmountPaidUp, 0)

    if @MemberId = 0
    begin
        begin try 
            insert Member (FirstName, LastName, BirthDate, AmountPaidUp)
        select @FirstName, @LastName, @BirthDate, @AmountPaidUp

            select @MemberId = scope_identity();
        end try
        begin catch
            throw;
        end catch
    end
    else 
    begin
        begin try
            update m
            set 
                m.FirstName = @FirstName,
                m.LastName = @LastName,
                m.BirthDate = @BirthDate,
                m.AmountPaidUp = @AmountPaidUp
            from Member m 
            where m.MemberId = @MemberId

            if @@rowcount = 0
                throw 50000, 'Update Failed: MemberId not found', 1
            end try
        begin catch
            throw;
        end catch
    end
end
go
GRANT EXECUTE ON MemberUpsert TO basicuserrole