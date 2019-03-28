namespace FriendOrganizer.DataAccess.Migrations
{
    using FriendOrganizer.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAccess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAccess.FriendOrganizerDbContext context)
        {
            context.Friends.AddOrUpdate(
                f => f.FirstName,
                 new Friend { FirstName = "Odete", LastName = "Costa" },
                 new Friend { FirstName = "Paulo", LastName = "Costa" },
                 new Friend { FirstName = "Leonor", LastName = "Costa" },
                 new Friend { FirstName = "Mário", LastName = "Costa" },
                 new Friend { FirstName = "Ricardo", LastName = "Silva" }
                 );
        }
    }
}
