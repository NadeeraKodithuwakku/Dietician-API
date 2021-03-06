using Dietician.Domain;
using Dietician.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dietician.Database
{
    public static class UserExpression
    {
        public static Expression<Func<User, long>> AuthId => user => user.Auth.Id;

        public static Expression<Func<User, UserModel>> Model => user => new UserModel
        {
            Id = user.Id,
            Name = user.FullName.Name,
            Surname = user.FullName.Surname,
            Email = user.Email.Value
        };

        public static Expression<Func<User, bool>> Id(long id)
        {
            return user => user.Id == id;
        }

        internal static Expression<Func<User, bool>> Email(string email)
        {
            return user => user.Email.Value == email;
        }
    }
}
