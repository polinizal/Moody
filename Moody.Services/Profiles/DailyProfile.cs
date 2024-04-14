﻿using AutoMapper;
using Moody.Data.Data;
using Moody.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Services.Profiles
{
    public class DailyProfile:Profile
    {
        public DailyProfile()
        {
            CreateMap<Daily, DailyDTO>()
                .ReverseMap();
        }
    }
}
