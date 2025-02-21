create or alter proc MemberEarningUpsert(
    @MemberEarningId int = 0 output,
    @MemberId int,
    @ParshaId int,
    @EarningYearId int,
    @Amount int = 0
)
as
begin
    declare @SubTotal int

    begin try
    
        if @MemberEarningId = 0
        begin
            begin try
                insert MemberEarning(MemberId, ParshaId, EarningYearId, Amount)
                values(@MemberId, @ParshaId, @EarningYearId, @Amount)

                select @MemberEarningId = scope_identity();
            end try
            begin catch
                throw;
            end catch
        end
        else 
        begin 
            update me 
            set 
                me.MemberId = @MemberId,
                me.ParshaId = @ParshaId,
                me.EarningYearId = @EarningYearId,
                me.Amount = @Amount
            from MemberEarning me
            where me.MemberEarningId = @MemberEarningId

            if @@rowcount = 0
                throw 50000, 'Update Faild: MemberEarningId not found', 1
        end
    
        select @SubTotal = sum(Amount)
        from MemberEarning
        where MemberId = @MemberId
    
        update Member
        set SubTotal = @SubTotal
        where MemberId = @MemberId

    end try
    begin catch
        throw;
    end catch
end
go

GRANT EXECUTE ON MemberEarningUpsert TO basicuserrole