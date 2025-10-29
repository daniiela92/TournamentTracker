using System.Windows;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTeamWindow.xaml
    /// </summary>
    public partial class CreateTeamWindow : Window
    {

        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();

        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamWindow()
        {
            InitializeComponent();

          //  CreateSampleData();

            WireUpLists();
        }

      

        private void CreateSampleData() // method to create sample data for testing (funciona como o Seed)
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Tim", LastName = "Corey" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Sue", LastName = "Storm" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Jane", LastName = "Smith" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Bill", LastName = "Jones" });
        }

        private void WireUpLists() // method to wire up the lists (comboBox and listbox)
        {
            selectTeamMemberDropDown.ItemsSource = null;

            selectTeamMemberDropDown.ItemsSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMemberPath = "FullName";

            teamMembersListBox.ItemsSource = null;

            teamMembersListBox.ItemsSource = selectedTeamMembers;
            teamMembersListBox.DisplayMemberPath = "FullName";

        }

        private void createMemberButton_Click(object sender, RoutedEventArgs e)
        {

            if (ValidateForm())
            {
                PersonModel p = new PersonModel(); // Create a new instance of PersonModel

                p.FirstName = firstNameValue.Text; // Assign the first name from the input field
                p.LastName = lastNameValue.Text; // Assign the last name from the input field
                p.EmailAddress = emailValue.Text; // Assign the email address from the input field
                p.CellphoneNumber = cellphoneValue.Text; // Assign the cellphone number from the input field


                p = GlobalConfig.Connection.CreatePerson(p);

                selectedTeamMembers.Add(p);

                WireUpLists();

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

        private void addMemberButton_Click(object sender, RoutedEventArgs e)
        {
           PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;

           if (p != null)
            {

                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);

                WireUpLists();

            }
        }

        private void removeSelectedMemberButton_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;

            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);

                WireUpLists();
            }
        }
    }
}
