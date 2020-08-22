using DotNetCore.Domain;
using System;

namespace Dietician.Domain
{
    public class Auth : Entity<long>
    {
        public Auth
        (
            string login,
            string password,
            Roles roles
        )
        {
            Login = login;
            Password = password;
            Roles = roles;
            Salt = Guid.NewGuid().ToString();
        }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public string Salt { get; private set; }

        public Roles Roles { get; private set; }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
