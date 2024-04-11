using Moody.Data.Data.Abstractions;

namespace Moody.Data.Data
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public virtual IEnumerable<Daily>? Dailies { get; set; }
    }
}
