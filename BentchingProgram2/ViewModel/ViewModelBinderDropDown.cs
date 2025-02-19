using BusinessLogicLayer;

namespace ViewModel
{
    public partial class ViewModelBinder
    {
        private bizParsha _parsha;
        private int _parshaid;
        private bizEarningYear _earningyear;
        private int _earningyearid;

        private List<bizParsha> _parshalist = new();
        private List<bizEarningYear> _earningyearlist = new();


        //Properties go here
        public List<bizParsha> ParshaList
        {
            get
            {
                return _parshalist;
            }
            private set
            {
                _parshalist = value;
                OnPropertyChanged();
            }
        }
        public List<bizEarningYear> EarningYearList
        {
            get => _earningyearlist;
            set
            {
                _earningyearlist = value;
                OnPropertyChanged();
            }
        }
        public bizParsha? Parsha
        {
            get
            {
                return _parshalist?.FirstOrDefault(pl => pl.ParshaId == this.ParshaId);
            }
            set
            {
                this.ParshaId = (value == null) ? 0 : value.ParshaId;
                OnPropertyChanged();
            }
        }
        public string ParshaName
        {
            get
            {
                if(Parsha != null)
                {
                    return Parsha.ParshaName;
                }
                return "";
            }
        }
        public int ParshaId
        {
            get => _parshaid;
            set
            {
                _parshaid = value;
                OnPropertyChanged();
                OnPropertyChanged("Parsha");
            }
        }
        public bizEarningYear? EarningYear
        {
            get => _earningyearlist.FirstOrDefault(ey => ey.EarningYearId == this.EarningYearId);
            set
            {
                EarningYearId = (value == null) ? 0 : value.EarningYearId;
                OnPropertyChanged();
            }
        }
        public int EarningYearId
        {
            get => _earningyearid;
            set
            {
                _earningyearid = value;
                OnPropertyChanged();
                OnPropertyChanged("EarningYear");
            }
        }

        //Methods go here
        public void SelectedMemberEarning(int memberearningid)
        {
            this.Amount = MemberEarningDisplay.FirstOrDefault(m => m.MemberEarningId == memberearningid).Amount;
            this.ParshaId = MemberEarningDisplay.FirstOrDefault(m => m.MemberEarningId == memberearningid).ParshaId;
            this.EarningYearId = MemberEarningDisplay.FirstOrDefault(m => m.MemberEarningId == memberearningid).EarningYearId;
        }
        public async Task LoadParshaList()
        {
            ParshaList = await _parsha.GetList();
        }
        public async Task LoadEarningYearList()
        {
            EarningYearList = await _earningyear.GetList();
        }
    }
}
