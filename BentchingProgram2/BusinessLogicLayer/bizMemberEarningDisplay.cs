namespace BusinessLogicLayer
{
    public class bizMemberEarningDisplay : bizObject<bizMemberEarningDisplay>
    {
        private int _earningyear;
        private int _amount;
        public bizMemberEarningDisplay()
        {

        }

        public int MemberEarningId { get; set; }
        public int MemberId { get; set; }
        public string FirstName { get; set; } = "";
        public int ParshaId { get; set; }
        public string ParshaName { get; set; } = "";
        public string ParshaNameEnglish { get; set; } = "";
        public int EarningYearId { get; set; }
        public int EarningYear
        {
            get => _earningyear;
            set
            {
                _earningyear = value;
                InvokePropertyChanged();
            }
        }
        public int Amount 
        { 
            get => _amount; 
            set
            {
                _amount = value;
                InvokePropertyChanged();
            }
        }
        public DateTime EarnedDate { get; set; }

    }
}
