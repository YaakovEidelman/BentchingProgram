create or alter proc ParshaRead(
    @All int = 0
)
as 
begin 
    select ParshaId, ParshaName, ParshaNameEnglish
    from Parsha
end 
go