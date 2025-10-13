using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTeamWindow.xaml
    /// </summary>
    public partial class CreateTeamWindow : Window
    {
        public CreateTeamWindow()
        {
            InitializeComponent();
        }

        private void createMemberButton_Click(object sender, RoutedEventArgs e)
        {

            if(ValidateForm())
            {
                PersonModel p = new PersonModel(); // Create a new instance of PersonModel

                p.FirstName = firstNameValue.Text; // Assign the first name from the input field
                p.LastName = lastNameValue.Text; // Assign the last name from the input field
                p.EmailAddress = emailValue.Text; // Assign the email address from the input field
                p.CellphoneNumber = cellphoneValue.Text; // Assign the cellphone number from the input field


                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = ""; 
                lastNameValue.Text = ""; 
                emailValue.Text = ""; 
                cellphoneValue.Text = ""; 
            }
            else
            {
                MessageBox.Show("You need to fill in all of the fields.");
            }

        }

        private bool ValidateForm()
        {

            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }


            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellphoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;



        }


    }
}
