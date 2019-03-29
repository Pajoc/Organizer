using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService //A interface é k vai ser usada pelo view model
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }


        public IEnumerable<Friend> GetAll()
        {
            //yield return new Friend { FirstName = "Odete", LastName = "Costa" };
            //yield return new Friend { FirstName = "Paulo", LastName = "Costa" };
            //yield return new Friend { FirstName = "Leonor", LastName = "Costa" };
            //yield return new Friend { FirstName = "Mário", LastName = "Costa" };
            //yield return new Friend { FirstName = "Ricardo", LastName = "Silva" };


            //using (var ctx = new FriendOrganizerDbContext())
            //{
            //    return ctx.Friends.AsNoTracking().ToList();
            //}

            using (var ctx = _contextCreator())
            {
                return ctx.Friends.AsNoTracking().ToList();
            }

        }

        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                //Senão o ctx pode ser disposed anetes da função retornar
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
        }
    }
}
