
namespace MvvmLightExcelDnaDemo.ViewModels 
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewBViewModel : WorkSpaceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the ViewBViewModel class.
        /// </summary>
        public ViewBViewModel(string GUID) 
        {

           MyName = "I'm View B";

           base.DisplayName = "View B";
           base.GUID = GUID;
        }

      public  string MyName { get; set; }

        
    }
}