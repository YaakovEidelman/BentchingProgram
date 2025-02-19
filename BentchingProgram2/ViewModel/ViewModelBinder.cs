using BusinessLogicLayer;


namespace ViewModel
{
    public partial class ViewModelBinder
    {
        private bizMember _member;
        private int _amount;

        private List<bizMember> _memberlist = new();

        // Properties go here
        public bizMember Member
        {
            get
            {
                return _member;
            }
            private set
            {
                _member = value;
                OnPropertyChanged();
            }
        }
        public List<bizMember> MemberList
        {
            get
            {
                return _memberlist;
            }
            private set
            {
                _memberlist = value;
                OnPropertyChanged();
            }
        }
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        //Methods go here
        public void LoadMember(int id)
        {
            bizMember? mem = _memberlist.FirstOrDefault(m => m.MemberId == id);
            if (mem != null)
            {
                Member = mem;
            }
            //await LoadMemberList();
        }

        public async Task LoadMemberList()
        {
            MemberList = await _member.GetList();
        }

    }
}