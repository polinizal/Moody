using Moody.Data.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Data.Data
{
    public class Daily:BaseEntity
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Mood))]
        public int MoodId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Mood Mood { get; set; }
        public string Note { get; set; } // Note for the day
    }
}
