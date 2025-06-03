using System;
using System.Windows;
using System.Windows.Input;
using DBEnity.Services;
using DbEntity.Models;
using MYDWP.Command;
using MYDWP.ViewModel;

public class RegistorViewModel : ViewModelBase
{
    public LoginViewModel LoginViewModel;
    private readonly DbUserService _userService;
    public readonly RelayCommand _registerCommand;
    private Visibility _showRegistorPage = Visibility.Collapsed;

    public Visibility ShowRegistorPage
    {
        get { return _showRegistorPage; }
        set
        {
            if (_showRegistorPage != value)
            {
                _showRegistorPage = value;
                OnPropertyChanged(nameof(ShowRegistorPage));
            }
        }
    }
    public ICommand RegisterCommand => _registerCommand;
    public RegistorViewModel(DbUserService userService)
    {
        _userService = userService;
        _registerCommand = new RelayCommand(OnRegister, CanLogin); ;
    }

    private string _userName;
    public string UserName
    {
        get => _userName;
        set { _userName = value; OnPropertyChanged(nameof(UserName)); }
    }

    private string _email;
    public string Email
    {
        get => _email;
        set { _email = value; OnPropertyChanged(nameof(Email)); }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set { _password = value; OnPropertyChanged(nameof(Password)); }
    }

    private string _phoneNumber;
    public string PhoneNumber
    {
        get => _phoneNumber;
        set { _phoneNumber = value; OnPropertyChanged(nameof(PhoneNumber)); }
    }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
    }

    private async void OnRegister()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "Please fill in all required fields.";
            return;
        }

        // TODO: Add password hashing & validation
        var user = new DbUser
        {
            UserName = UserName,
            Email = Email,
            Password = Password,
            PhoneNumber = PhoneNumber,
            IsActive = true
        };

        try
        {
            await _userService.AddAsync(user);
            ErrorMessage = "Registration successful!";
            ClearFields();
            ShowRegistorPage = Visibility.Collapsed;
            LoginViewModel.ShowLoginPage = Visibility.Visible;
}
        catch (Exception ex)
        {
            ErrorMessage = $"Registration failed: {ex.Message}";
        }
    }

    private void ClearFields()
    {
        UserName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        PhoneNumber = string.Empty;
    }

    private bool CanLogin()
    {
        return true;
    }
}
