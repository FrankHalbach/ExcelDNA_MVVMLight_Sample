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
        
            //register ViewModels here
            SimpleIoc.Default.Register<MainWindowViewModel>();
            

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