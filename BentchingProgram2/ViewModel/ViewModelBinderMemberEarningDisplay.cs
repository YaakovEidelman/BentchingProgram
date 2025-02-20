using BusinessLogicLayer;

namespace ViewModel
{
    public partial class ViewModelBinder
    {
        private bizMemberEarning _bizmemberearning;
        private bizMemberEarningDisplay _bmed;

        private List<bizMemberEarningDisplay> _memberearningdisplay = new();

        //Properties go here
        public bizMemberEarning MemberEarning
        {
            get => _bizmemberearning;
            set
            {
                _bizmemberearning = value;
                OnPropertyChanged();
            }
        }
        public List<bizMemberEarningDisplay> MemberEarningDisplay
        {
            get
            {
                return _memberearningdisplay;
            }
            set
            {
                _memberearningdisplay = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadMemberEarningDisplay(int id)
        {
            MemberEarningDisplay = await _bmed.Load(id);
        }
        public async Task LoadMemberEarning()
        {
            List<bizMemberEarning> lst;

            lst = await _bizmemberearning.Load(Member.MemberId, ($"@{nameof(bizParsha.ParshaId)}", ParshaId), ($"@{nameof(bizEarningYear.EarningYearId)}", EarningYearId));
            if (lst[0] != null)
            {
                MemberEarning = lst[0];
            }
        }

    }
}
