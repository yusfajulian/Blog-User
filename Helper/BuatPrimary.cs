﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pertemuan1.Helper
{
    public class BuatPrimary
    {
        public static string buatPrimary()
        {
            Guid buat = Guid.NewGuid();
            return buat.ToString();
        }
    }
}
