
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.DTOs
{
    public class DailyDTO : BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }
        public int MoodId { get; set; }
        
        public virtual MoodDTO? Mood { get; set; }
        public virtual UserDTO? User { get; set; }
    }

}
