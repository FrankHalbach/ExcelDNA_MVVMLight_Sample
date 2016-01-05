using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;
using System.Threading;
using MvvmLightExcelDnaDemo.Views;
using ExcelDna.Logging;

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
        static MainWindow _mainWindow;

        /// <summary>
        /// Opens new MainWindow in seperate Thread or focus open MainWindow
        /// </summary>
        public static void OpenMainForm()
        {            
            if (_threadMainWindow == null || !_threadMainWindow.IsAlive)
            {
                _threadMainWindow = new Thread(
                    () => {
                        _mainWindow = new MainWindow();
                        _mainWindow.ShowDialog();
                        _mainWindow.Closed += (sender1, e1) => _mainWindow.Dispatcher.InvokeShutdown();
                    }
                                               );

                _threadMainWindow.SetApartmentState(ApartmentState.STA);
                _threadMainWindow.Start();

            }
            else
            {
                _mainWindow.Dispatcher.Invoke(new System.Action(() =>
                 {
                     _mainWindow.Activate();
                     _mainWindow.WindowState = System.Windows.WindowState.Normal;
                 }
                  ));

            }
        }
    }
}
