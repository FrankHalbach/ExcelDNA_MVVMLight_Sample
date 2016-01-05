namespace MvvmLightExcelDnaDemo.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewAViewModel:WorkSpaceViewModel
    {
        /// <summary>
        /// Initializes a new instance of the ViewAViewModel class.
        /// </summary>
        public ViewAViewModel(string GUID)
        {
            MyName = "I'm ViewA";

            base.DisplayName = "View A";
            base.GUID = GUID;
        }

       public  string MyName { get; set; }
    }
}