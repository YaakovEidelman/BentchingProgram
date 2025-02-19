namespace BusinessLogicLayer
{
    public class bizMemberEarning : bizObject<bizMemberEarning>
    {
        public bizMemberEarning()
        {

        }

        public int MemberEarningId { get; set; }
        public int MemberId { get; set; }
        public int ParshaId { get; set; }
        public int EarningYearId { get; set; }
        public int Amount { get; set; }
        public DateTime EarnedDate { get; set; }

    }
}