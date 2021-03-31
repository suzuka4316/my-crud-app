using ICTPRG403_ICTPRG404_ICTPRG410.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ICTPRG403_ICTPRG404_ICTPRG410.View
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Page
    {
        private Repository _repo;

        /// <summary>
        /// Constructor for assigning Person object parameter passed in as a constructor argument to the DataContext property of Update class.
        /// </summary>
        /// <param name="repo">Repository class object</param>
        /// <param name="p">Person class object</param>
        public Update(Repository repo, Person p)
        {
            _repo = repo;
            InitializeComponent();
            //TODO: (Task 8A) 
            //assign the Person instance passed in as a constructor argument
            //to the View's DataContext property
            DataContext = p;
        }

        /// <summary>
        /// Method to add logic to the Button_Click event in Update class.
        /// When Save button is clicked, the specified record will be updated in the database, then navigated back to the Index page.
        /// If any exception error is to occur, then exception message will appear on a dialog box and will not go back to Index page.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: (Task 8B) 
            // i. Invoke the repository UpdatePerson method passing in the updated Person object (from DataContext)
            // ii. Instantiate a new Index view object and navigate to it using the NavigationService property
            // iii. Ensure all logic is nested in a try/catch block incase an exception is raised whilst attempting to perform a data driven operation
            // iiii. Add the logic required to display the message of any exception that might be raised using a MessageBox in the catch block
            try
            {
                _repo.UpdatePerson((Person)DataContext);
                NavigationService.Navigate(new Index(_repo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK);
            }
        }
    }
}
