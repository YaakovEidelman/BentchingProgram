using System.Diagnostics;
using ViewModel;

namespace BentchingProgram2
{
    public partial class App : Application
    {
        public static bool AdminPermmisions = false;
        public static string ConnectionStringSetting = "";
        public App()
        {
            InitializeComponent();
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}