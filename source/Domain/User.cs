using DotNetCore.Domain;

namespace Dietician.Domain
{
    public class User : Entity<long>
    {
        public User
        (
            FullName fullName,
            Email email,
            Auth auth
        )
        {
            FullName = fullName;
            Email = email;
            Auth = auth;
            Activate();
        }

        public User(long id) : base(id) { }

        public FullName FullName { get; private set; }

        public Email Email { get; private set; }

        public Status Status { get; private set; }

        public Auth Auth { get; private set; }

        public void Activate()
        {
            Status = Status.Active;
        }

        public void Inactivate()
        {
            Status = Status.Inactive;
        }

        public void ChangeFullName(string name, string surname)
        {
            FullName = new FullName(name, surname);
        }

        public void ChangeEmail(string email)
        {
            Email = new Email(email);
        }
    }
}
