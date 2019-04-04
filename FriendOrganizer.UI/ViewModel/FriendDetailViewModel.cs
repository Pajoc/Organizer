using FriendOrganizer.UI.Data;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using FriendOrganizer.UI.Event;
using System.Windows.Input;
using Prism.Commands;

namespace FriendOrganizer.UI.ViewModel
{
    public class FriendDetailViewModel : ViewModelBase, IFriendDetailViewModel
    {
        private IFriendDataService _dataService;
        private IEventAggregator _eventAggregator;
        private Friend _friend;

        public FriendDetailViewModel(IFriendDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>().Subscribe(OnOpenFriendDetailViewAsync);
            SaveCommand = new DelegateCommand(OnSaveExecuteAsync, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            //Check if valid
            return true;
        }

        private async void OnSaveExecuteAsync()
        {
           await _dataService.SaveAsync(Friend);
            //raise the event
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(
                new AfterFriendSavedEventArgs
                {
                    Id = Friend.Id,
                    DisplayMember = $"{Friend.FirstName} {Friend.LastName}"
                });
        }

        private async void OnOpenFriendDetailViewAsync(int friendId)
        {
            await LoadAsync(friendId);
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

        public ICommand SaveCommand { get; }

    }
}
