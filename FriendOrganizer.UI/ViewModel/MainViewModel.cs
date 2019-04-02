using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //private IFriendDataService _friendDataService;
        //private Friend _selectedFriend;

        //public MainViewModel(IFriendDataService friendDataService)
        //{
        //    Friends = new ObservableCollection<Friend>();
        //    _friendDataService = friendDataService;
        //}

        ////O Task faz com que quem chama tenha de esperar
        //public async Task LoadAsync()
        //{
        //    var friends = await _friendDataService.GetAllAsync();
        //    Friends.Clear();
        //    foreach (var friend in friends)
        //    {
        //        Friends.Add(friend);
        //    }
        //}

        ////Collection que permite notificação quando existe alteração da estrutura (importante para o data bindind)
        //public ObservableCollection<Friend> Friends { get; set; }

        //public Friend SelectedFriend
        //{
        //    get { return _selectedFriend; }
        //    set {
        //        _selectedFriend = value;
        //        //OnPropertyChanged("SelectedFriend"); || OnPropertyChanged(nameof(SelectedFriend)); || ...
        //        OnPropertyChanged();//Colocado noutra classe para poder ser reutilizado
        //    }
        //}

        public INavigationViewModel NavigationViewModel { get; }

        public IFriendDetailViewModel FriendDetailViewModel { get; }

        public MainViewModel(INavigationViewModel navigationViewModel, IFriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }
    }
}
