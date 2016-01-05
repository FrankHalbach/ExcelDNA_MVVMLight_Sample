using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MvvmLightExcelDnaDemo.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainWindowViewModel class.
        /// </summary>
        public MainWindowViewModel()
        {
            WorkSpace = new ObservableCollection<WorkSpaceViewModel>();


            AddViewACommand = new RelayCommand(() =>
                {
                    var guid= System.Guid.NewGuid().ToString();
                    SimpleIoc.Default.Register<ViewAViewModel>(() => new ViewAViewModel(guid), guid, true);
                    WorkSpaceViewModel w = SimpleIoc.Default.GetInstance<ViewAViewModel>(guid);                    
                    AddWorkSpaceItem(w);
                }
                );

            AddViewBCommand = new RelayCommand(() =>
            {
                var guid = System.Guid.NewGuid().ToString();
                SimpleIoc.Default.Register<ViewBViewModel>(() => new ViewBViewModel(guid), guid, true);
                WorkSpaceViewModel w = SimpleIoc.Default.GetInstance<ViewBViewModel>(guid);
                AddWorkSpaceItem(w);
            }
                );

            // If don't need to register the viewmodel.
            //AddViewBCommand = new RelayCommand(() => AddWorkSpaceItem(new ViewBViewModel()));

            //Listen for RemoveWorkSpaceItem
            Messenger.Default.Register<WorkSpaceViewModel>(this, "RemoveWorkSpaceItem", item => RemoveWorkSpaceItem(item));            

        }


        public ObservableCollection<WorkSpaceViewModel> WorkSpace { get; private set; }


        public ICommand AddViewACommand { get; private set; }
        public ICommand AddViewBCommand { get; private set; }

        

        void AddWorkSpaceItem(WorkSpaceViewModel w)
        {
            WorkSpace.Add(w);
        }

        void RemoveWorkSpaceItem(WorkSpaceViewModel w)
        {
            WorkSpace.Remove(w);

        }
    }
}
