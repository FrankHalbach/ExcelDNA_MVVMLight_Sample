using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace MvvmLightExcelDnaDemo.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public abstract class WorkSpaceViewModel : ViewModelBase
    {
                /// <summary>
        /// Initializes a new instance of the WorkSpaceViewModel class.
        /// </summary>
        protected WorkSpaceViewModel()
        {
            CloseWorkSpaceItemCommand = new RelayCommand(() => CloseWorkSpaceItemExecute(), () => true);                
        }

        
        /// <summary>
        /// sends close command to Messenger for this workspace. 
        /// </summary>
        private void CloseWorkSpaceItemExecute()
        {
            Messenger.Default.Send(this, "RemoveWorkSpaceItem");                       
        }             


        /// <summary>
        /// Display name of this workspace.
        /// Child classes can set this property to a new value or override it.
        /// </summary>
        public virtual string DisplayName { get; protected set; }

        /// <summary>
        /// GUID of this instances
        /// </summary>
        public virtual string GUID { get; protected set; }

        /// <summary>
        /// Command to remove this workspace from the user interface.
        /// </summary>
        public ICommand CloseWorkSpaceItemCommand { get; private set; }

        
                

    }
}