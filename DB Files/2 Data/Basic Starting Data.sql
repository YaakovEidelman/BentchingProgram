delete MemberEarning
delete EarningYear
delete Parsha
delete Member

insert Member(FirstName, LastName, BirthDate)
      select 'Moshe', 'Eidelman', '2013-02-01'
union select 'Chani', 'Eidelman', '2015-01-01'
union select 'Tziporah', 'Eidelman', '2006-01-01'
union select 'Shana', 'Eidelman', '2008-01-01'
union select 'Chaya', 'Eidelman', '2010-01-01'
union select 'Leah', 'Eidelman', '2018-01-01'

insert Parsha (ParshaName, ParshaNameEnglish) values
(N'בראשית', 'Berashis'),
(N'נח', 'Noach'),
(N'לך לך', 'Lech Lecha'),
(N'וירא', 'Vayeira'),
(N'חיי שרה', 'Chayei Sarah'),
(N'תולדות', 'Toldos'),
(N'ויצא', 'Vayeitzei'),
(N'וישלח', 'Vayishlach'),
(N'וישב', 'Vayeishev'),
(N'מקץ', 'Mikeitz'),
(N'ויגש', 'Vayigash'),
(N'ויחי', 'Vayechi'),
(N'שמות', 'Shmois'),
(N'וארא', 'Va’eira'),
(N'בא', 'Bo'),
(N'בשלח', 'Beshalach'),
(N'יתרו', 'Yisroi'),
(N'משפטים', 'Mishpotim'),
(N'תרומה', 'Terumah'),
(N'תצוה', 'Tetzaveh'),
(N'כי תשא', 'Ki Sisa'),
(N'ויקהל', 'Vayakhel'),
(N'פקודי', 'Pekudei'),
(N'ויקרא', 'Vayikro'),
(N'צו', 'Tzav'),
(N'שמיני', 'Shemini'),
(N'תזריע', 'Tazria'),
(N'מצורע', 'Metzora'),
(N'אחרי מות', 'Acharei Mois'),
(N'קדושים', 'Kedoshim'),
(N'אמר', 'Emor'),
(N'בהר', 'Behar'),
(N'בחקתי', 'Bechukoisai'),
(N'במדבר', 'Bamidbor'),
(N'נשא', 'Noso'),
(N'בהעלותך', 'Beha’aloscha'),
(N'שלח', 'Shlach'),
(N'קרח', 'Korach'),
(N'חקת', 'Chukas'),
(N'בלק', 'Bolok'),
(N'פנחס', 'Pinchos'),
(N'מטות', 'Matos'),
(N'מסעי', 'Masei'),
(N'דברים', 'Devorim'),
(N'ואתחנן', 'Vo’eschanan'),
(N'עקב', 'Eikev'),
(N'ראה', 'Re’eh'),
(N'שופטים', 'Shoiftim'),
(N'כי תצא', 'Ki Seitzei'),
(N'כי תבוא', 'Ki Savo'),
(N'נצבים', 'Nitzovim'),
(N'וילך', 'Vayelech'),
(N'האזינו', 'Ha’azinu'),
(N'וזאת הברכה', 'V’zos Habrocho');

insert EarningYear(EarningYear)
select '2024'
union select '2025'


-- INSERT INTO MemberEarning (MemberId, ParshaId, EarningYearId, Amount)
-- SELECT m.MemberId, p.ParshaId, e.EarningYearId, t.Amount
-- FROM (
--     VALUES 
--         ('Moshe', 'Berashis', 3),
--         ('Chani', 'Berashis', 3),
--         ('Tziporah', 'Berashis', 2),
--         ('Shana', 'Berashis', 2),
--         ('Chaya', 'Berashis', 2),
--         ('Leah', 'Berashis', 1),
--         ('Moshe', 'Noach', 3),
--         ('Chani', 'Noach', 0),
--         ('Tziporah', 'Noach', 3),
--         ('Shana', 'Noach', 2),
--         ('Chaya', 'Noach', 2),
--         ('Leah', 'Noach', 1),
--         ('Moshe', 'Lech Lecha', 3),
--         ('Chani', 'Lech Lecha', 2),
--         ('Tziporah', 'Lech Lecha', 1),
--         ('Shana', 'Lech Lecha', 0),
--         ('Chaya', 'Lech Lecha', 3),
--         ('Leah', 'Lech Lecha', 1),
--         ('Moshe', 'Vayeira', 3),
--         ('Chani', 'Vayeira', 3),
--         ('Tziporah', 'Vayeira', 1),
--         ('Shana', 'Vayeira', 2),
--         ('Chaya', 'Vayeira', 2),
--         ('Leah', 'Vayeira', 1)
-- ) AS t (FirstName, ParshaNameEnglish, Amount)
-- JOIN dbo.Member m ON t.FirstName = m.FirstName
-- JOIN dbo.Parsha p ON t.ParshaNameEnglish = p.ParshaNameEnglish
-- JOIN dbo.EarningYear e ON e.EarningYear = 2025
go
exec  MemberEarningUpsert 0, 6, 2, 2, 3
exec  MemberEarningUpsert 0, 5, 2, 2, 1
exec  MemberEarningUpsert 0, 4, 2, 2, 2
exec  MemberEarningUpsert 0, 3, 2, 2, 3
exec  MemberEarningUpsert 0, 2, 2, 2, 1
exec  MemberEarningUpsert 0, 1, 2, 2, 2
exec  MemberEarningUpsert 0, 6, 3, 2, 3
exec  MemberEarningUpsert 0, 5, 3, 2, 1
exec  MemberEarningUpsert 0, 4, 3, 2, 0
exec  MemberEarningUpsert 0, 3, 3, 2, 2
exec  MemberEarningUpsert 0, 2, 3, 2, 3
exec  MemberEarningUpsert 0, 1, 3, 2, 2
exec  MemberEarningUpsert 0, 6, 4, 2, 2
exec  MemberEarningUpsert 0, 5, 4, 2, 1
exec  MemberEarningUpsert 0, 4, 4, 2, 0
exec  MemberEarningUpsert 0, 3, 4, 2, 3
exec  MemberEarningUpsert 0, 2, 4, 2, 1
exec  MemberEarningUpsert 0, 1, 4, 2, 3
exec  MemberEarningUpsert 0, 1, 5, 2, 3
exec  MemberEarningUpsert 0, 2, 5, 2, 3
exec  MemberEarningUpsert 0, 3, 5, 2, 3
exec  MemberEarningUpsert 0, 4, 5, 2, 3
exec  MemberEarningUpsert 0, 5, 5, 2, 3
exec  MemberEarningUpsert 0, 6, 5, 2, 3
exec  MemberEarningUpsert 0, 1, 6, 2, 3
exec  MemberEarningUpsert 0, 2, 6, 2, 3
exec  MemberEarningUpsert 0, 3, 6, 2, 3
exec  MemberEarningUpsert 0, 4, 6, 2, 3
exec  MemberEarningUpsert 0, 5, 6, 2, 3
exec  MemberEarningUpsert 0, 6, 6, 2, 3
go

-- select * 
-- from Member

-- select m.FirstName, m.LastName, m.SubTotal, m.AmountPaidUp, m.FinalTotal, p.ParshaNameEnglish, ey.EarningYear, me.Amount
-- from MemberEarning me 
-- left join Member m 
-- on m.MemberId = me.MemberId
-- left join Parsha p 
-- on p.ParshaId = me.ParshaId
-- left join EarningYear ey 
-- on ey.EarningYearId = me.EarningYearId