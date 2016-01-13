using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;
using System.Threading;
using MvvmLightExcelDnaDemo.Views;
using ExcelDna.Logging;
using MvvmLightExcelDnaDemo.ViewModels;
using System.Windows;
using System.Windows.Threading;

namespace MvvmLightExcelDnaDemo
{
    public class CreateMenu
    {

        [ExcelCommand(MenuName = "MVVMForm", MenuText = "OpenMVVMForm")]
        public static void LoadForm()  
        {
            try
            {
                OpenMainForm();
            }
            catch (Exception e)
            {
                LogDisplay.WriteLine(e.ToString());
            }
           
        }

        


        static Thread _threadMainWindow;        
        static ViewModelLocator _viewModelLocator;
        protected static Dispatcher _dispatcher;

        /// <summary>
        /// Opens new ViewModelLocator in seperate Thread 
        /// </summary>
        static void OpenMainForm()
        {
            
            if (_threadMainWindow == null || !_threadMainWindow.IsAlive)
            {
                _threadMainWindow = new Thread(
                    () => {

                        _viewModelLocator = new ViewModelLocator();                        
                        
                        _viewModelLocator.OpenWindow();

                        _dispatcher = Dispatcher.CurrentDispatcher;

                        Dispatcher.Run();  
                    }
                                               );

                _threadMainWindow.SetApartmentState(ApartmentState.STA);
                
                _threadMainWindow.Start();                

            }
            else
            {                                    
                    _dispatcher.Invoke( new Action(() => {
                    
                        _viewModelLocator.OpenWindow();
                    }
                                                   )
                                    );

            }
        }

    }
}
