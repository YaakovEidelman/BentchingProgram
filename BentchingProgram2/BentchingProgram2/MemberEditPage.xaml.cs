using BusinessLogicLayer;
using ViewModel;

namespace BentchingProgram2;

public partial class MemberEditPage : ContentPage
{
	ViewModelBinder _viewmodelbinder;
	int _id;
	string _firstname;
	string _lastname;
	DateTime _dob;
	int _amountpaidup;

	DateTime d = DateTime.Now.Date;
	public MemberEditPage(ViewModelBinder viewmodelbinder, int id = 0, string firstname = "", string lastname = "", DateTime? dob = null, int amountpaidup = 0)
	{
		InitializeComponent();
		_viewmodelbinder = viewmodelbinder;
		_id = id;
		_firstname = firstname;
		_lastname = lastname;
		_dob = (dob == null) ? DateTime.Now.Date : (DateTime)dob;
		_amountpaidup = amountpaidup;
		EditFields();
	}
	private void EditFields()
	{
		EnterFirstName.Text = _firstname;
		EnterLastName.Text = _lastname;
		EnterBirthdate.Date = _dob;
		EnterAmountPaidUp.Text = _amountpaidup.ToString();
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
		Navigation.PopModalAsync();
    }
	private async void Save_Clicked(object sender, EventArgs e)
	{
		try
		{
			await new bizMember().Update(
				("@MemberId", _id),
				("@FirstName", EnterFirstName.Text),
				("@LastName", EnterLastName.Text),
				("@BirthDate", EnterBirthdate.Date),
				("@AmountPaidUp", EnterAmountPaidUp.Text)
			);
			await _viewmodelbinder.LoadMemberList();
			await Navigation.PopModalAsync();
		}
		catch (Exception ex)
		{
			await DisplayAlert(this.ToString(), ex.Message, "Close");
		}
	}

}