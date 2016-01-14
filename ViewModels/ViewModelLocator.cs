using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using MvvmLightExcelDnaDemo.Views;
using System.Windows;
using System.Windows.Forms;

namespace MvvmLightExcelDnaDemo.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);            
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public MainWindowViewModel Main
        {
            get
            {
                if(!SimpleIoc.Default.IsRegistered<MainWindowViewModel>())
                    SimpleIoc.Default.Register<MainWindowViewModel>();
                
                    return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
                
            }
        }

        static MainWindow _window;

        public void OpenWindow()
        {
            if(_window==null ||_window.IsLoaded==false)
            { 
                _window = new MainWindow(this);        
                _window.Show();
            }

            _window.Activate();
          


          
          

        }





        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
           // This will rest SimpleIOC and unregister the messenger.             

           // SimpleIoc.Default.Reset();            

           // Messenger.Reset();

        }
    }
}