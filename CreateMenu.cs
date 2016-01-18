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
using System.Runtime.InteropServices;

namespace MvvmLightExcelDnaDemo
{
    public class CreateMenu : IExcelAddIn
    {

      internal static  WindowStarter _windowStarter = new WindowStarter();

        [ExcelCommand(MenuName = "MVVMForm", MenuText = "OpenMVVMForm")]
        public static void LoadForm()
        {
            try
            {
                _windowStarter.ShowSingeltonWindow<MainWindow,MainWindowViewModel>();
            }
            catch (Exception ex)
            {
                LogDisplay.WriteLine(ex.ToString());
            }

        }


        public void AutoOpen() { }

        public void AutoClose() { }
            
    }
}
