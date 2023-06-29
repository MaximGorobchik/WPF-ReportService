using Page_Navigation_App.ViewModel;
using ReportServiceWPF.Utilities;
using System.Windows.Input;

namespace ReportServiceWPF.ViewModel
{
    public class MainViewModel: BaseViewModel
    {

        private BaseViewModel _SelectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _SelectedViewModel; }
            set
            {
                _SelectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        public ICommand HomeCommand { get; set; }
        public ICommand CategoriesCommand { get; set; }
        public ICommand DepartmentsCommand { get; set; }
        public ICommand EmployeesCommand { get; set; }
        public ICommand ReportsCommand { get; set; }
        public ICommand StatusCommand { get; set; }
        public ICommand UsersCommand { get; set; }

        private void Home(object obj) => SelectedViewModel = new HomeViewModel();
        private void Category(object obj) => SelectedViewModel = new CategoriesViewModel();
        private void Employee(object obj) => SelectedViewModel = new EmployeesViewModel();
        private void Report(object obj) => SelectedViewModel = new ReportsViewModel();
        private void Status(object obj) => SelectedViewModel = new StatusViewModel();
        private void User(object obj) => SelectedViewModel = new UsersViewModel();
        private void Department(object obj) => SelectedViewModel = new DepartmentsViewModel();

        public MainViewModel()
        {
            HomeCommand = new RelayCommand(Home);
            CategoriesCommand = new RelayCommand(Category);
            DepartmentsCommand = new RelayCommand(Department);
            EmployeesCommand = new RelayCommand(Employee);
            ReportsCommand = new RelayCommand(Report);
            StatusCommand = new RelayCommand(Status);
            UsersCommand = new RelayCommand(User);

            SelectedViewModel = new HomeViewModel();
        }

    }
}
