﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Models.EnumEntity
{
    public enum Gender
    {
        [Description("男")]
        Male,
        [Description("女")]
        Female
    }
}