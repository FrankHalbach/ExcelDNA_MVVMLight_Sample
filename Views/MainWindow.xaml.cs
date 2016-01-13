using MvvmLightExcelDnaDemo.ViewModels;
using System.Windows;

namespace MvvmLightExcelDnaDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModelLocator Locator;

        public MainWindow(ViewModelLocator locator)
        {
            InitializeComponent();

            //Locator = new ViewModelLocator();
            this.Locator = locator;

            DataContext = Locator.Main;

            Closing += (s, e) => ViewModelLocator.Cleanup();

            MessageBox.Show("I run on Thread: "+System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }


    }
}
