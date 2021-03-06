using ath_p4_proj2.Commands;
using ath_p4_proj2.Models;

namespace ath_p4_proj2.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private string _userString;
        private Employee? _user;

        public OpenWindowCommand OpenWindowCommand { get; set; }

        public Employee User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserString = $"Zalogowany użytkownik: {User.FirstName} {User.LastName}";
            }
        }

        public string UserString
        {
            get { return _userString; }
            private set
            {
                _userString = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _userString = $"Zalogowany użytkownik: null";
            OpenWindowCommand = new(this);
        }
    }
}
