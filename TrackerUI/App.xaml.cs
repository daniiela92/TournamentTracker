using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using TrackerLibrary;

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

            // Lê a appsettings.json, para conseguir obter os dados de ligação (connection string) à base de dados

           // var cfg = new ConfigurationBuilder()
           //.SetBasePath(Directory.GetCurrentDirectory())
           //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();


            // Initialize the database connections

            TrackerLibrary.GlobalConfig.InitializeConnections(DataBaseType.TextFile);

            var mainWindow = new CreateTeamWindow();
            // var mainWindow = new TournamentDashboardWindow();
            mainWindow.Show();
        }
    }

}
