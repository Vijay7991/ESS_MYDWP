using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBEnity.Services;
using MYDWP.ViewModel.ComponentsViewModel;

namespace MYDWP.ViewModel
{
    internal class MainViewModel: ViewModelBase
    {
       
        public BodyViewModel BodyViewModel { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public RegistorViewModel RegistorViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }



        public MainViewModel(DbUserService UserService)
        {
            BodyViewModel = new BodyViewModel();
            RegistorViewModel = new RegistorViewModel(UserService);
            LoginViewModel = new LoginViewModel(UserService);
            MenuViewModel = new MenuViewModel();

            RegistorViewModel.LoginViewModel = LoginViewModel;
            LoginViewModel.RegistorViewModel = RegistorViewModel;
        }
    }
}
