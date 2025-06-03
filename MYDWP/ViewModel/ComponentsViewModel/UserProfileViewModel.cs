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


        private readonly RelayCommand _loseCommand;
        public ICommand CloseCommand => _loseCommand;

        public UserProfileViewModel(MenuViewModel menuViewModel)
        {
            this.menuViewModel = menuViewModel;

            //menuViewModel.ShowProfile = System.Windows.Visibility.Collapsed;
        }




    }
}
