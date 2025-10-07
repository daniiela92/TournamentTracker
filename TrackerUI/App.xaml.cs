using System.Configuration;
using System.Data;
using System.Windows;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialize the database connections

             TrackerLibrary.GlobalConfig.InitializeConnections(true, true);

            var mainWindow = new CreatePrizeWindow();
            // var mainWindow = new TournamentDashboardWindow();
            mainWindow.Show();
        }
    }

}
