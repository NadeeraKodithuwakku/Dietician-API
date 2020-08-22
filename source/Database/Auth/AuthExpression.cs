using Dietician.Domain;
using System;
using System.Linq.Expressions;

namespace Dietician.Database
{
    public static class AuthExpression
    {
        public static Expression<Func<Auth, bool>> Login(string login)
        {
            return auth => auth.Login == login;
        }
    }
}
