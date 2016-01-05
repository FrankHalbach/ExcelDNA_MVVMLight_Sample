using MvvmLightExcelDnaDemo.ViewModels;
using System.Windows;

namespace MvvmLightExcelDnaDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelLocator Locator;// = new ViewModelLocator();

        public MainWindow()
        {
            InitializeComponent();

            Locator = new ViewModelLocator();

            DataContext = Locator.Main;

            Closing += (s, e) => ViewModelLocator.Cleanup();          
        }


    }
}
