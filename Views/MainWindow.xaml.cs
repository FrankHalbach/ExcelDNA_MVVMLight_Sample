using MvvmLightExcelDnaDemo.ViewModels;
using System.Windows;

namespace MvvmLightExcelDnaDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            Closing += (s, e) => ViewModelLocator.Cleanup();
            
            this.Title = "Main Window - running on Thread:"+System.Threading.Thread.CurrentThread.ManagedThreadId.ToString();
            
        }


    }
}
