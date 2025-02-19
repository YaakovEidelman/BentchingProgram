using BusinessLogicLayer;
using ViewModel;

namespace BentchingProgram2;

public partial class Members : ContentPage
{
    int id = 0;
    ViewModelBinder _viewmodelbinder;
    public Members(ViewModelBinder viewmodelbinder)
    {
        InitializeComponent();
        _viewmodelbinder = viewmodelbinder;
        this.BindingContext = _viewmodelbinder;
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DynamicCol.Width = new GridLength(1, GridUnitType.Star);

        id = ((bizMember)((Grid)sender).BindingContext).MemberId;
        _viewmodelbinder.LoadMember(id);
        await _viewmodelbinder.LoadMemberEarningDisplay(id);
    }

    private void Close_Clicked(object sender, EventArgs e)
    {
        DynamicCol.Width = new GridLength(0);
    }

    private async void AddBtn_Clicked(object sender, EventArgs e)
    {
        bool isvalid = int.TryParse(AmountEntry.Text, out int amt);
        try
        {
            if(!isvalid)
            {
                throw new Exception("Must enter numbers only");
            }
            await _viewmodelbinder.UpdateStats(amt, id);
        }
        catch (Exception ex)
        {
            await DisplayAlert(this.ToString(), ex.Message, "Close");
        }
    }

    private void med_Tapped(object sender, TappedEventArgs e)
    {
        int i = ((bizMemberEarningDisplay)((Grid)sender).BindingContext).MemberEarningId;
        _viewmodelbinder.SelectedMemberEarning(i);
    }
}