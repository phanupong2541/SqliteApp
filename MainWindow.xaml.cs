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

namespace SqlliteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
            //DataAccess.AddData("phanupong", "0951752263");
            DataAccess.GetData();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddData(txtName.Text,txtTell.Text);
            Output.ItemsSource = DataAccess.GetData();
        }
    }
}
