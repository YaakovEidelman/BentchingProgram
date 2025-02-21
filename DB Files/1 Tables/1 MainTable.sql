--use BentchingProgram
go
drop table if exists MemberEarning
drop table if exists EarningYear
drop table if exists Parsha
drop table if exists Member
go
create table dbo.Member
(
  MemberId int not null identity primary key,
  FirstName varchar(30) not null
    constraint ck_firstname_cannot_be_blank check(FirstName <> ''),
  LastName varchar(20) not null
    constraint ck_lastname_cannot_be_blank check(LastName <> ''),
  SubTotal int not null
    constraint d_subtotal_defaults_to_0 default 0,
  BirthDate date
    constraint ck_cannot_be_born_before_1996 check(BirthDate > '1996-01-01'),
  AmountPaidUp int not null
    constraint d_amountpaidup_defaults_to_0 default 0,
  FinalTotal as SubTotal - AmountPaidUp,
  constraint firstname_and_last_name_must_be_unique unique(FirstName, LastName)
)
go

create table dbo.Parsha
(
  ParshaId int not null identity primary key,
  ParshaName nvarchar(50) not null
    constraint c_parshaname_must_not_be_blank check(ParshaName <> '')
    constraint u_parshaname_must_be_unique unique,
  ParshaNameEnglish nvarchar(50) not null
    constraint c_parshanameenglish_must_not_be_blank check(ParshaNameEnglish <> '')
    constraint u_parshanameenglish_must_be_unique unique
)

create table dbo.EarningYear
(
  EarningYearId int identity primary key,
  EarningYear int not null 
    constraint c_earningyear_must_be_greater_than_2020 check(EarningYear > 2020)
    constraint u_earningyear_must_be_unique unique
    constraint d_earningyear_defaults_to_current_year default year(getdate())
)

create table dbo.MemberEarning
(
  MemberEarningId int not null identity primary key,
  MemberId int not null foreign key references Member(MemberId), --on delete cascade,
  ParshaId int not null foreign key references Parsha(ParshaId),
  EarningYearId int not null foreign key references EarningYear(EarningYearId),
  Amount int not null 
    constraint d_amount_defaults_to_0 default 0, -- check (Amount between 0 and 3),
  EarnedDate date not null default getdate(),
    constraint u_member_parsha_year unique (MemberId, ParshaId, EarningYearId)
);
go