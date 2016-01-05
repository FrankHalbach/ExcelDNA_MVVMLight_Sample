using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;

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





        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            // This will rest SimpleIOC and unregister the messenger. 
            // If you don't reset when you close the form you will run into cross thread issues with the OberservableCollection when you re-open the MainWindow a second time since it will open in a new thread.
            // If you like to preserve your viewmodels when the form is closed you will either need to hide the form instead of closing it or implement
            // a thread safe OberservableCollection, eg: https://github.com/burningmime/curves/blob/master/burningmime.curves.sample/src/util/wpf/AsyncObservableCollection.cs
            //

            SimpleIoc.Default.Reset();


            //Unregistering the messenger is required in order to avoid double registration uppon creatation of a new window.
            //Messenger.Reset();

        }
    }
}