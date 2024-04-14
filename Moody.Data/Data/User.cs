using Microsoft.AspNetCore.Identity;
using Moody.Data.Data.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Moody.Data.Data
{
    public class User : IdentityUser
    {
        [Key]
        public string Id { get; set; }
        public string UserName { get; set; }
        public virtual IEnumerable<Daily>? Dailies { get; set; }
    }
}
