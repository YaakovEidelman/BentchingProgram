using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLogicLayer;

namespace ViewModel
{
    public partial class ViewModelBinder : INotifyPropertyChanged
    {
        public ViewModelBinder()
        {
            _member = new();
            _bmed = new();
            _parsha = new();
            _earningyear = new();
            _bizmemberearning = new();
            _ = LoadMemberList();
            _ = LoadParshaList();
            _ = LoadEarningYearList();
        }

        //Methods go here
        public async Task UpdateStats(int amount, int id)
        {
            await this.LoadMemberEarning();

            await this.MemberEarning.Update(
                ($"@{nameof(bizMemberEarning.MemberEarningId)}", MemberEarning.MemberEarningId),
                ($"@{nameof(bizMemberEarning.MemberId)}", MemberEarning.MemberId),
                ($"@{nameof(bizMemberEarning.ParshaId)}", MemberEarning.ParshaId),
                ($"@{nameof(bizMemberEarning.EarningYearId)}", MemberEarning.EarningYearId),
                ($"@{nameof(bizMemberEarning.Amount)}", amount)
            );
            await this.LoadMemberList();
            this.LoadMember(id);
            await this.LoadMemberEarningDisplay(id);

        }

        //Event Handler stuff go here
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
