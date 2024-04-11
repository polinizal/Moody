using Moody.Data.Data.Abstractions;
using Moody.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Data.Data
{
    public class Mood: BaseEntity
    {
        public MoodType MoodType { get; set; }
        
    }
}
