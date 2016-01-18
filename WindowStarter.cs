using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLightExcelDnaDemo.ViewModels;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;


namespace MvvmLightExcelDnaDemo
{
    public class WindowStarter
    {
        protected Thread _threadWindow;
        internal ViewModelLocator _viewModelLocator;
        protected Dispatcher _GUIDispatcher;


        public WindowStarter()
        {

            _threadWindow = new Thread(() =>
            {

                _viewModelLocator = new ViewModelLocator();
                
                _GUIDispatcher = Dispatcher.CurrentDispatcher;

                Dispatcher.Run();

            });

            _threadWindow.SetApartmentState(ApartmentState.STA);

            _threadWindow.Start();

        }

        /// <summary>
        /// Shows new Window W
        /// </summary>
        /// <typeparam name="W">Window</typeparam>
        public void ShowWindow<W>() where W : Window, new()
        {
            this._GUIDispatcher.Invoke(new Action(() =>
            {
                W window = new W();
                window.Show();

            }));

        }


        /// <summary>
        /// Shows a Singelton Window W with ViewModel VM, ViewModel must be registered in ViewModelLocator class
        /// </summary>
        /// <typeparam name="W">Window</typeparam>
        /// <typeparam name="VM">ViewModel</typeparam>
        public void ShowSingeltonWindow<W,VM>() where W : Window, new() where VM:class
        {
            if (!SimpleIoc.Default.IsRegistered<VM>())  //ViewModel needs to be registered in ViewModelLocator class
                 SimpleIoc.Default.Register<VM>();
                //throw new NotImplementedException("ViewModel not registered");

            else

            this._GUIDispatcher.Invoke(new Action(() =>
            {
                W window = GetWindow<W>.Instance;

                if (window.DataContext == null)
                {   
                    window.DataContext = SimpleIoc.Default.GetInstance<VM>(); 
                }

                window.Show();
                window.Activate();
                
                

            }));
        }

        /// <summary>
        /// Creates Singeltong Window W
        /// </summary>
        /// <typeparam name="W">Window</typeparam>
        public abstract class GetWindow<W> where W : Window, new()
        {
            protected GetWindow()
            {
            }

            private static W _instance;

            public static W Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new W();
                        _instance.Closed += delegate { _instance = null; };
                    }
                    return _instance;
                }
            }

        }

    }
}
