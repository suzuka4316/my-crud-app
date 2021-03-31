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
using ICTPRG403_ICTPRG404_ICTPRG410.Data;

namespace ICTPRG403_ICTPRG404_ICTPRG410.View
{
    /// <summary>
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class Insert : Page
    {
        private Repository _repo;

        /// <summary>
        /// Constructor for instantiating and assigning a new Person object to the DataContext property of Insert class.
        /// </summary>
        /// <param name="repo">Repository class object</param>
        public Insert(Repository repo)
        {
            _repo = repo;
            InitializeComponent();
            //TODO: (Task 7A) 
            //instantiate a new instance of a Person object and assign it 
            //to the View's DataContext property
            Person p = new Person();
            DataContext = p;

        }

        /// <summary>
        /// Method to add logic to the Button_Click event in Insert class.
        /// If correct data type values are entered, a new record will be added to the database and navigate back to Index page with the new record.
        /// If any exception error is to occur, then exception message will appear on a dialog box and will not go back to Index page.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: (Task 7B) 
            // i. Invoke the repository InsertPerson method passing in the Person object (from DataContext)
            // ii. Instantiate a new Index view object and navigate to it using the NavigationService property
            // iii. Ensure all logic is nested in a try/catch block incase an exception is raised whilst attempting to perform a data driven operation
            // iiii. Add the logic required to display the message of any exception that might be raised using a MessageBox in the catch block
            try
            {
                _repo.InsertPerson((Person)DataContext);
                NavigationService.Navigate(new Index(_repo));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK);
            }
        }
    }
}
