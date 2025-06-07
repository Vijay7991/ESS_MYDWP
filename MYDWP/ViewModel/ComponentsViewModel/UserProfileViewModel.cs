using MYDWP.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MYDWP.ViewModel.ComponentsViewModel
{
    public class UserProfileViewModel : ViewModelBase
    {
        private MenuViewModel menuViewModel;

        private readonly RelayCommand _closeCommand;
        public ICommand CloseCommand => _closeCommand ?? new RelayCommand(Cose);

        public UserProfileViewModel(MenuViewModel menuViewModel)
        {
            this.menuViewModel = menuViewModel;
        }

        private void Cose()
        {
            menuViewModel.ShowProfile = System.Windows.Visibility.Collapsed;
        }

    }
}
