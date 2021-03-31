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
using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using ICTPRG403_ICTPRG404_ICTPRG410.View;

namespace ICTPRG403_ICTPRG404_ICTPRG410
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Repository _repo;

        /// <summary>
        /// Constructor to navigate to the Index page
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _repo = new Repository(); 
            frame.Navigate(new Index(_repo));
        }

        /// <summary>
        /// Method to add logic to the Button_Click even in MainWindow class.
        /// When Add Person button is clicked, a user will be navigated to Insert page.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Insert(_repo));
        }
    }
}
