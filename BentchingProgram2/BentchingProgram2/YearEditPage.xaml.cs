using BusinessLogicLayer;
using ViewModel;

namespace BentchingProgram2;

public partial class YearEditPage : ContentPage
{
    int _id;
    ViewModelBinder _viewmodelbinder;
    public YearEditPage(ViewModelBinder viewmodelbinder, int id = 0)
    {
        InitializeComponent();
        _viewmodelbinder = viewmodelbinder;
        _id = id;
        EditLabel();
    }

    public void EditLabel()
    {
        int? i = _viewmodelbinder.EarningYearList.FirstOrDefault(l => l.EarningYearId == _id)?.EarningYear ?? 0;
        EnterYear.Text = i.ToString();
    }

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
    private async void Save_Clicked(object sender, EventArgs e)
    {
        try
        {
            await new bizEarningYear().Update(
                ("@EarningYearId", _id),
                ("@EarningYear", EnterYear.Text)
            );
            await _viewmodelbinder.LoadEarningYearList();
            await Navigation.PopModalAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert(this.ToString(), ex.Message, "Close");
        }
    }
}