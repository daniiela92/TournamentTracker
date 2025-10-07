using System.Windows;
using TrackerLibrary;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for CreatePrizeWindow.xaml
    /// </summary>
    public partial class CreatePrizeWindow : Window
    {
        public CreatePrizeWindow()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    prizeAmountValue.Text,
                    prizePercentageValue.Text);

                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }

                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                prizeAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information. Please check it and try again.");
            }


        }

        private bool ValidateForm() // Validações da informação que o utilizador coloca no formulário   
        {

            bool output = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (placeNumberValidNumber == false)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount); // changed from bool to int for prizePercentageValid
            bool prizePercentageValid = double.TryParse(prizePercentageValue.Text, out prizePercentage); // changed from bool to int for prizePercentageValid

            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;

            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }


            return output;

        }
    }
}
