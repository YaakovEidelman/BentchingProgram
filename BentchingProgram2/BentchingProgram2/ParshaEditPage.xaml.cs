using BusinessLogicLayer;
using ViewModel;

namespace BentchingProgram2;

public partial class ParshaEditPage : ContentPage
{
	ViewModelBinder _viewmodelbinder;
	int _id;
	string _nameenglish;
	string _nameheb;
	public ParshaEditPage(ViewModelBinder viewmodelbinder, int id = 0, string nameenglish = "", string nameheb = "")
	{
		InitializeComponent();
		_viewmodelbinder = viewmodelbinder;
		_id = id;
		_nameenglish = nameenglish;
		_nameheb = nameheb;
		EditParsha();
	}

	private void EditParsha()
	{
		EnterParsha.Text = _nameenglish;
		EnterParshaHeb.Text = _nameheb;
	}

	private void Cancel_Clicked(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}

	private async void Save_Clicked(object sender, EventArgs e)
	{
		try
		{
			await new bizParsha().Update(
				($"@{nameof(bizParsha.ParshaId)}", _id), 
				($"@{nameof(bizParsha.ParshaName)}", EnterParshaHeb.Text), 
				($"@{nameof(bizParsha.ParshaNameEnglish)}", EnterParsha.Text)
			);
			await _viewmodelbinder.LoadParshaList();
			await Navigation.PopModalAsync();
		}
		catch (Exception ex)
		{
			await DisplayAlert(this.ToString(), ex.Message, "Close");
		}
	}
}