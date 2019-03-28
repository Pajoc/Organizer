using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService //A interface é k vai ser usada pelo view model
    {
        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Odete", LastName = "Costa" };
            yield return new Friend { FirstName = "Paulo", LastName = "Costa" };
            yield return new Friend { FirstName = "Leonor", LastName = "Costa" };
            yield return new Friend { FirstName = "Mário", LastName = "Costa" };
            yield return new Friend { FirstName = "Ricardo", LastName = "Silva" };
        }
    }
}
