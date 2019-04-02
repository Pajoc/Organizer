using FriendOrganizer.UI.Data;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;
        private Friend _friend;

        public FriendDetailViewModel(IFriendDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task LoadAsync (int friendID)
        {
            Friend = await _dataService.GetByIdAsync(friendID);
        }

        public Friend Friend {

            get { return _friend; }

            private set {
                _friend = value;
                OnPropertyChanged();
            }
        }
    }
}
