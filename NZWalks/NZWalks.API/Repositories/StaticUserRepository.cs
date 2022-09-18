using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            //new User()
            //{
            //    FirstName = "Read Only", LastName = "User" , EmailAddress = "readonly@user.com",
            //    Id = Guid.NewGuid(), Username = "readonly@user.com", Password = "Readonly@user",
            //    Roles = new List<string>{ "reader" }
            //},

            //new User()
            //{
            //    FirstName = "Write Only", LastName = "User" , EmailAddress = "writeonly@user.com",
            //    Id = Guid.NewGuid(), Username = "writeonly@user.com", Password = "Writeonly@user",
            //    Roles = new List<string>{ "reader","writer" }
            //}

        };
        public async Task<User> UserAuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
                                       x.Password.Equals(password));

            return user;
        }
    }
}
