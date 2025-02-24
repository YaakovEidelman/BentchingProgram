namespace BentchingProgram2
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.LoggedIn = false;
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
