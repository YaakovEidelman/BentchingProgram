using System.ComponentModel;
using System.Runtime.CompilerServices;

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
                ("@MemberEarningId", MemberEarning.MemberEarningId),
                ("@MemberId", MemberEarning.MemberId),
                ("@ParshaId", MemberEarning.ParshaId),
                ("@EarningYearId", MemberEarning.EarningYearId),
                ("@Amount", amount)
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
