﻿using BE_2505.DataAccess.Netcore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DALImpl
{
    public class LaoCongDALImpl : Employeer
    {
        public override string working()
        {
            return "clean";
        }

        public string OtherWork()
        {
            return "otherwork";
        }
    }
}
