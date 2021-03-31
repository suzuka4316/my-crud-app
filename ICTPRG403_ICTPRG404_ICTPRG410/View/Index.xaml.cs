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
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        private Repository _repo;

        /// <summary>
        /// Constructor for retrieving the collection of Person objects from the Repository.
        /// These Person objects will be assigned as the data source for the DataGrid named dgPeople in the constructor.
        /// </summary>
        /// <param name="repo">Repository class object</param>
        public Index(Repository repo)
        {
            _repo = repo;
            InitializeComponent();

            //TODO: (Task 6A) 
            //assign the collection of People objects return from the repository
            //as the data source for the DataGrid (dgPeople)
            dgPeople.ItemsSource = repo.GetPeople();
        }

        /// <summary>
        /// Method to add logic to the Button_Click event.
        /// If clicked button is "Edit", then navigate to Update page, otherwise navigate to Delete page.
        /// For each button, specified row's data will be passed as arguments to the navigated page's constructor.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //TODO: (Task 6B) 
            //add the required logic for instantiating and navigating to a new instance of the Edit or Delete view.
            //Be sure to pass in the selected Person object and repository as arguments for the constructor.
            //TIP: the related Person instance can be accessed via the RoutedEventArgs 
            
            //edit or delete
            string action = (sender as Button).Content.ToString();

            if (action == "Edit")
            {
                NavigationService.Navigate(new Update(_repo, (Person)((Button)e.Source).DataContext));
            }
            else
            {
                NavigationService.Navigate(new Delete(_repo, (Person)((Button)e.Source).DataContext));
            }
        }    
    }
}
