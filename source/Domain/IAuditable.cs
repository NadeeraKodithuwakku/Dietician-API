using System;
using System.Collections.Generic;
using System.Text;

namespace Dietician.Domain
{
    public interface IAuditable
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
