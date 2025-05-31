using System.Windows;
using System.Windows.Controls;

namespace MYDWP.Component
{
    public partial class UserRegister : UserControl
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
