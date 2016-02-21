﻿using StryfeCore.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StryfeRPG.Models.Utils
{
    public class Script
    {
        public int Id { get; set; }
        public List<ScriptPage> Pages { get; set; }
    }
}
