using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DBEnity.Services;
using MYDWP.Command;

namespace MYDWP.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {

        private int _mainWindowBlureEffect = 10;
        public int MainWindowBlureEffect
        {
            get { return _mainWindowBlureEffect; }
            set
            {
                _mainWindowBlureEffect = value;
                OnPropertyChanged(nameof(MainWindowBlureEffect));
            }
        }
        private Visibility _loginVisibility = Visibility.Visible;
        public Visibility IsVisible
        {
            get { return _loginVisibility; }
            set
            {
                _loginVisibility = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private string _userName = "Admin";
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }

        private string _password = "Password";
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private readonly RelayCommand _loginCommand;
        private readonly RelayCommand _registoreUser;
        public ICommand RegisterCommand => _registoreUser;
        public ICommand LoginCommand => _loginCommand;

        private Visibility _showLoginPage  = Visibility.Visible;

        public Visibility ShowLoginPage
        {
            get { return _showLoginPage; }
            set
            {
                if (_showLoginPage != value)
                {
                    _showLoginPage = value;
                    OnPropertyChanged(nameof(ShowLoginPage));
                }
            }
        }


        public RegistorViewModel? RegistorViewModel { get; set; }
        public DbUserService UserService { get; }

        
        public LoginViewModel(DBEnity.Services.DbUserService userService)
        {
            _loginCommand = new RelayCommand(Login, CanLogin);
            _registoreUser = new RelayCommand(OpenRestorePage);
            UserService = userService;
        }

        private void OpenRestorePage()
        {
            ShowLoginPage = Visibility.Collapsed;
            RegistorViewModel.ShowRegistorPage = Visibility.Visible;
        }

        private async void Login()
        {
            bool ValidUSer = await UserService.UserHas(UserName, Password);

            if (ValidUSer)
            {
                MessageBox.Show("Login successful!");

                IsVisible = Visibility.Collapsed;
                MainWindowBlureEffect = 0;
            }
            else
            {
                MessageBox.Show("Invalid credentials.");
            }
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }
        
    }
}
