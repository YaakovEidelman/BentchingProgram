namespace BentchingProgram2;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        this.Loaded += LoginPage_Loaded;
    }

    private async void LoginPage_Loaded(object? sender, EventArgs e)
    {
        if (await GetPass() is not null && await GetUser() is not null)
        {
            SetForm(true);
            return;
        }
        SetForm(false);
    }

    private async static Task<string> GetPass()
    {
        return await SecureStorage.GetAsync("Password");
    }
    private async Task<string> GetUser()
    {
        return await SecureStorage.GetAsync("Username");
    }
    private void SetForm(bool userexist)
    {
        UserExist.IsVisible = userexist;
        UserNotExist.IsVisible = !userexist;
    }


    private async void Login_Clicked(object sender, EventArgs e)
    {
        try
        {
            string? pass = await GetPass();
            string? user = await GetUser();
            if (pass is not null && user is not null)
            {
                if (EnterPassword.Text == pass && EnterUsername.Text == user)
                {
                    App.LoggedIn = true;
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert(this.ToString(), "Wrong Username or Password, Try Again", "Close");
                }
            }
            else
            {
                if (EnterCreatePass.Text == EnterVerify.Text)
                {

                    await SecureStorage.SetAsync("Username", EnterCreateUsername.Text);
                    await SecureStorage.SetAsync("Password", EnterCreatePass.Text);
                    SetForm(true);
                }
                else
                {
                    await DisplayAlert(this.ToString(), "Please Verify Password", "Close");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert(this.ToString(), ex.Message, "Close");
        }
    }
    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Application.Current?.Quit();
    }

}