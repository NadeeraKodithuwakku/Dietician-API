using DotNetCore.Domain;
using System.Collections.Generic;

namespace Dietician.Domain
{
    public sealed class Email : ValueObject
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        protected override IEnumerable<object> GetEquals()
        {
            yield return Value;
        }
    }
}
