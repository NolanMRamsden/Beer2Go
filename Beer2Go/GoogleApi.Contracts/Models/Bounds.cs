﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleApi.Contracts.Models
{
    [Serializable]
    public class Bounds
    {
        public Location northeast { get; set; }
        public Location southwest { get; set; }
    }
}
